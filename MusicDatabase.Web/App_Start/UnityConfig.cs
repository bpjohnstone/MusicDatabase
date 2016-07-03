using System;
using System.Linq;
using AutoMapper;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
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
                cfg.CreateMap<Person, PersonListing>()
                    .ForMember(dest => dest.GiftsGiven,
                            opts => opts.MapFrom(
                                src => src.GiftsGiven.Count))
                    .ForMember(dest => dest.EventsAttended,
                            opts => opts.MapFrom(
                                src => src.TotalEvents));

                cfg.CreateMap<Person, PersonDetails>();                

                cfg.CreateMap<Location, LocationListing>()
                    .ForMember(dest => dest.MusicalEvents,
                            opts => opts.MapFrom(
                                src => src.TotalEvents))
                    .ForMember(dest => dest.Purchases,
                            opts => opts.MapFrom(
                                src => src.Purchases.Count));

                cfg.CreateMap<Location, LocationDetails>()
                    .ForMember(dest => dest.OtherNames,
                            opts => opts.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        foreach(var name in src.OtherNames)
                            dest.OtherNames.Add(name.Position, name.Name);
                    });

                cfg.CreateMap<MusicalEvent, MusicalEventListing>()
                    .Include<SingleDayEvent, SingleDayEventListing>()
                    .Include<Concert, ConcertListing>()
                    .Include<Festival, FestivalListing>()
                    .Include<MultiDayFestival, MultiDayFestivalListing>()
                    .ForMember(dest => dest.Headliners,
                            opts => opts.MapFrom(
                                src => src.Lineup.OfType<Headliner>()));

                cfg.CreateMap<SingleDayEvent, SingleDayEventListing>();
                cfg.CreateMap<Concert, ConcertListing>();
                cfg.CreateMap<Festival, FestivalListing>();
                cfg.CreateMap<MultiDayFestival, MultiDayFestivalListing>();
                
                cfg.CreateMap<Headliner, HeadlinerDetails>();
                cfg.CreateMap<Support, SupportDetails>();
                cfg.CreateMap<Performance, PerformanceDetails>();
                cfg.CreateMap<Performer, PerformerDetails>();
            });

            // TODO: Register your types here
            container.RegisterInstance(config);
            container.RegisterInstance(container.Resolve<MapperConfiguration>().CreateMapper());
        }
    }
}
