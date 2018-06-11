namespace NetCoreServiceTemplate.HeatlhCheck
{
    public interface IHealthManager
    {
        HealthCheckStatus PerformHealthCheck(HealthCheckTypes type);
    }
}