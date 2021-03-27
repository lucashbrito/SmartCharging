namespace SmartCharging.Setup.Infrastructure
{
    public interface IGroupStationDatabaseSettings
    {
        string OrderCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
