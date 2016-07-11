namespace MusicDatabase.ViewModel
{
    public enum EventType
    {
        Concert,
        Festival,
        MultiDayFestival
    }

    public enum PerformanceType
    {
        Performance,
        Support,
        Headliner
    }

    public enum FilterLocationBy
    {
        City,
        State,
        Country
    }

    public enum AcquisitionType
    {
        StorePurchase,
        OnlinePurchase,
        EventPurchase,
        Gift,
        CompetitionPrize
    }
}
