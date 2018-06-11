namespace NetCoreServiceTemplate.HeatlhCheck
{
    public class HealthCheckStatus
    {
        public int Threads { get; set; }
        public double UptimeInMinutes { get; set; }
        public int RamInMBytes { get; set; }
        public string Version { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public decimal FreeDiskSpaceGb { get; set; }
    }
}