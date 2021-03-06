using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.Unity;
using MusicDatabase.Model;
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

                // People
                cfg.CreateMap<Person, PersonBasic>();
                cfg.CreateMap<Person, PersonListing>()
                    .ForMember(dest => dest.EventsAttended, opts => opts.MapFrom(
                        src => src.EventsAttended.Count(e => e is SingleDayEvent) + src.EventsAttended.OfType<MultiDayFestival>().Select(e => e.FestivalGroup).Distinct().Count()))
                    .ForMember(dest => dest.GiftsGiven, opts => opts.MapFrom(src => src.GiftsGiven.Count));
                cfg.CreateMap<Person, PersonDetails>()
                    .ForMember(dest => dest.EventsAttended, opts => opts.MapFrom(src => src.EventsAttended.Where(e => e.EventDate < DateTime.Now)))
                    .ForMember(dest => dest.UpcomingEvents, opts => opts.MapFrom(src => src.EventsAttended.Where(e => e.EventDate >= DateTime.Now)));

                // Locations
                cfg.CreateMap<Location, LocationListing>()
                    .ForMember(dest => dest.MusicalEvents, opts => opts.Ignore())
                    .ForMember(dest => dest.Purchases, opts => opts.Ignore());
                cfg.CreateMap<Location, LocationDetails>()
                    .ForMember(dest => dest.OtherNames, opts => opts.Ignore())
                    .ForMember(dest => dest.MusicalEvents, opts => opts.MapFrom(src => src.MusicalEvents.Where(e => e.EventDate < DateTime.Now)))
                    .ForMember(dest => dest.UpcomingMusicalEvents, opts => opts.MapFrom(src => src.MusicalEvents.Where(e => e.EventDate >= DateTime.Now)))
                    .AfterMap((src, dest) =>
                    {
                        foreach (var name in src.OtherNames)
                            dest.OtherNames.Add(name.Position, name.Name);
                    });

                // Location Groups
                cfg.CreateMap<LocationGroup, LocationGroupDetails>();

                // Websites

                // Musical Entities
                cfg.CreateMap<MusicalEntity, MusicalEntityListing>()
                    .ForMember(dest => dest.Performances, opts => opts.MapFrom(src => src.Performances.Count))
                    .ForMember(dest => dest.Releases, opts => opts.MapFrom(src => src.Discography.Count));

                cfg.CreateMap<MusicalEntity, MusicalEntityDetails>()
                    .ForMember(dest => dest.UpcomingPerformances, opts => opts.MapFrom(src => src.Performances.Where(e => e.Event.EventDate >= DateTime.Now)))
                    .ForMember(dest => dest.Performances, opts => opts.MapFrom(src => src.Performances.Where(e => e.Event.EventDate < DateTime.Now)));

                // Releases
                cfg.CreateMap<DiscographyEntry, KeyValuePair<int, ReleaseListing>>()
                    .ConstructUsing((src, ctx) => new KeyValuePair<int, ReleaseListing>(src.Position, ctx.Mapper.Map<ReleaseListing>(src.Release)));

                cfg.CreateMap<Release, ReleaseListing>();

                cfg.CreateMap<Copy, CopyBase>()
                    .Include<Copy, CopyListing>()
                    .Include<Copy, CopyDetails>()
                    .ForMember(dest => dest.DateAdded, opts => opts.MapFrom(src => src.AcquisitionDetails.DateAdded))
                    .ForMember(dest => dest.AcquisitionNotes, opts => opts.MapFrom(src => src.AcquisitionDetails.Notes))
                    .ForMember(dest => dest.CopyNotes, opts => opts.MapFrom(src => src.Notes));

                cfg.CreateMap<Copy, CopyListing>();
                cfg.CreateMap<Copy, CopyDetails>();

                cfg.CreateMap<Element, ElementDetails>();

                // Musical Events
                cfg.CreateMap<MusicalEvent, MusicalEventBase>()
                    .Include<MusicalEvent, MusicalEventListing>()
                    .Include<MusicalEvent, MusicalEventDetails>()
                    .Include<MusicalEvent, MusicalEventByLocation>()
                    .Include<MusicalEvent, MusicalEventByMusicalEntity>()
                    .ForMember(dest => dest.IsSecret, opts => opts.ResolveUsing(src => 
                        {
                            var isSecret = false;

                            if (src is Concert)
                            {
                                var concert = src as Concert;
                                isSecret = concert.IsSecret;
                            }

                            return isSecret;
                        }))
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
                                : src.Venue.FullName
                        ));

                cfg.CreateMap<MusicalEvent, MusicalEventListing>()
                    .ForMember(dest => dest.Headliners, opts => opts.MapFrom(src => src.Lineup.OfType<Headliner>()));
                cfg.CreateMap<MusicalEvent, MusicalEventDetails>();
                cfg.CreateMap<MusicalEvent, MusicalEventByLocation>()
                    .ForMember(dest => dest.Headliners, opts => opts.MapFrom(src => src.Lineup.OfType<Headliner>()));

                cfg.CreateMap<MusicalEvent, MusicalEventByMusicalEntity>();
                cfg.CreateMap<Performance, MusicalEventByMusicalEntity>()
                    .ConvertUsing((src, ctx) => ctx.Mapper.Map<MusicalEventByMusicalEntity>(src.Event));

                // Musical Events - Event Groups
                cfg.CreateMap<EventGroup, EventGroupDetails>();

                // Musical Events - EventAttendees, Performances and Performers
                cfg.CreateMap<EventAttendee, KeyValuePair<int, PersonBasic>>()
                    .ConstructUsing((src, ctx) => new KeyValuePair<int, PersonBasic>(src.Position, ctx.Mapper.Map<PersonBasic>(src.Person)));

                cfg.CreateMap<Performance, PerformanceDetails>()
                    .ForMember(dest => dest.PerformanceType, opts => opts.ResolveUsing(src =>
                        {
                            var performanceType = PerformanceType.Performance;

                            if (src is Headliner)
                                performanceType = PerformanceType.Headliner;
                            else if (src is Support)
                                performanceType = PerformanceType.Support;

                            return performanceType;
                        }));

                cfg.CreateMap<Performer, PerformerDetails>();

            });

            // Add in Automapper
            container.RegisterInstance(config);
            container.RegisterInstance(container.Resolve<MapperConfiguration>().CreateMapper());

        }
    }
}
