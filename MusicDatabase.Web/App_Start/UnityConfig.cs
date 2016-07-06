using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MusicDatabase.Model;
using MusicDatabase.Services.Interfaces;
using MusicDatabase.Services.Repositories;
using MusicDatabase.ViewModel;

namespace MusicDatabase.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // AutoMapper Setup
            var config = new MapperConfiguration(cfg =>
            {
                // Generic Mapping, so empty Guids can be replaced with Nulls
                cfg.CreateMap<Guid, Guid?>().ConvertUsing(src => 
                {
                    if (src == Guid.Empty)
                        return null;
                    else
                        return src;
                });

                // Musical Entities
                cfg.CreateMap<MusicalEntity, MusicalEntityListing>()
                    .ForMember(dest => dest.Performances, opts => opts.MapFrom(src => src.Performances.Count))
                    .ForMember(dest => dest.Releases, opts => opts.MapFrom(src => src.Discography.Count));

                cfg.CreateMap<MusicalEntity, MusicalEntityDetails>()
                    .ForMember(dest => dest.Performances, opts => opts.Ignore());

                // People
                cfg.CreateMap<Person, PersonBasic>();
                cfg.CreateMap<Person, PersonListing>()
                    .ForMember(dest => dest.EventsAttended, opts => opts.MapFrom(src => src.EventsAttended.Count))
                    .ForMember(dest => dest.GiftsGiven, opts => opts.MapFrom(src => src.GiftsGiven.Count));
                cfg.CreateMap<Person, PersonDetails>();

                // Locations
                cfg.CreateMap<Location, LocationListing>()
                    .ForMember(dest => dest.MusicalEvents, opts => opts.MapFrom(src => src.MusicalEvents.Count))
                    .ForMember(dest => dest.Purchases, opts => opts.MapFrom(src => src.Purchases.Count));
                cfg.CreateMap<Location, LocationDetails>()
                    .ForMember(dest => dest.OtherNames, opts => opts.Ignore())
                    .AfterMap((src, dest) => 
                    { 
                        foreach (var name in src.OtherNames)
                            dest.OtherNames.Add(name.Position, name.Name);
                    });

                // Musical Events
                cfg.CreateMap<MusicalEvent, MusicalEventBase>()
                    .Include<MusicalEvent, MusicalEventListing>()
                    .Include<MusicalEvent, MusicalEventDetails>()
                    .Include<MusicalEvent, MusicalEventByLocation>()
                    .Include<MusicalEvent, MusicalEventByMusicalEntity>()
                    .ForMember(dest => dest.EventType, opts => opts.ResolveUsing(src =>
                        {
                            var eventType = EventType.Concert;

                            if (src is Festival)
                                eventType = EventType.Festival;
                            else if (src is MultiDayFestival)
                                eventType = EventType.MultiDayFestival;

                            return eventType;
                        }));

                cfg.CreateMap<MusicalEvent, MusicalEventSimple>()
                    .Include<MusicalEvent, MusicalEventListing>()
                    .Include<MusicalEvent, MusicalEventDetails>()
                    .Include<MusicalEvent, MusicalEventByMusicalEntity>()
                    .ForMember(dest => dest.VenueName, opts => opts.MapFrom(src =>
                            !string.IsNullOrWhiteSpace(src.AlternateVenueName)
                                ? src.AlternateVenueName
                                : src.Venue.SortName
                        ));

                cfg.CreateMap<MusicalEvent, MusicalEventListing>()
                    .ForMember(dest => dest.Headliners, opts => opts.MapFrom(src => src.Lineup.OfType<Headliner>()));
                cfg.CreateMap<MusicalEvent, MusicalEventDetails>();
                cfg.CreateMap<MusicalEvent, MusicalEventByLocation>()
                    .ForMember(dest => dest.Headliners, opts => opts.MapFrom(src => src.Lineup.OfType<Headliner>()));
                cfg.CreateMap<MusicalEvent, MusicalEventByMusicalEntity>();

                // Musical Events - EventAttendees, Performances and Performers
                cfg.CreateMap<EventAttendee, KeyValuePair<int, PersonBasic>>()
                    .ConstructUsing((src, ctx) => new KeyValuePair<int, PersonBasic>(src.Position, ctx.Mapper.Map<PersonBasic>(src.Person)));

                cfg.CreateMap<Performance, PerformanceDetails>();
                cfg.CreateMap<Performer, PerformerDetails>();

            });

            // TODO: Register your types here
            container.RegisterInstance(config);
            container.RegisterInstance(container.Resolve<MapperConfiguration>().CreateMapper());

            container.RegisterType<IRepository, EntityRepository>();
        }
    }
}
