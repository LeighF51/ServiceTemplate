using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;

namespace NetCoreServiceTemplate.HeatlhCheck
{
    public class SystemHealthManager : IHealthManager
    {
        public HealthCheckStatus PerformHealthCheck(HealthCheckTypes checkType)
        {
            //switch type
            var status = new HealthCheckStatus();
            var p = Process.GetCurrentProcess();
            status = new HealthCheckStatus
            {
                Threads = p.Threads.Count,
                UptimeInMinutes = (DateTime.Now - p.StartTime).TotalMinutes,
                RamInMBytes = (int) p.PeakWorkingSet64 / 1024 / 1024,
                Version = Assembly.GetExecutingAssembly().GetName().Version.ToString(),
                Name = "Email service on " + Environment.MachineName,
                IPAddress = GetLocalIPAddress(),
                FreeDiskSpaceGb = FreeDiskSpaceGb(Path.GetPathRoot(Assembly.GetEntryAssembly().Location))
            };

            return status;
        }

        private decimal FreeDiskSpaceGb(string driveName)
        {
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.IsReady && drive.Name == driveName)
                {
                    var space = drive.AvailableFreeSpace / 1024m / 1024m / 1024m;

                    return decimal.Round(space, 2, MidpointRounding.AwayFromZero);
                }

            return -1;
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();

            return "127.0.0.1";
        }

    }
}