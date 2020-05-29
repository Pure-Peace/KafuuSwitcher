using System.Linq;
using KafuuSwitcher.Extensions;
using KafuuSwitcher.Helpers;
using System.Threading.Tasks;

namespace KafuuSwitcher
{
    class ServerSwitcher
    {
        private readonly string serverAddress;

        public ServerSwitcher(string KafuuIpAddress)
        {
            this.serverAddress = KafuuIpAddress;
        }

        public void SwitchToKafuu()
        {
            var lines = HostsFile.ReadAllLines();
            var result = lines.Where(x => !x.Contains("ppy.sh")).ToList();
            result.AddRange
            (
                serverAddress + " osu.ppy.sh",
                serverAddress + " c.ppy.sh",
                serverAddress + " c1.ppy.sh",
                serverAddress + " c2.ppy.sh",
                serverAddress + " c3.ppy.sh",
                serverAddress + " c4.ppy.sh",
                serverAddress + " c5.ppy.sh",
				serverAddress + " c6.ppy.sh",
                serverAddress + " ce.ppy.sh",
                serverAddress + " a.ppy.sh",
                serverAddress + " i.ppy.sh"
            );
            HostsFile.WriteAllLines(result);
        }

        public void SwitchToOfficial()
        {
            HostsFile.WriteAllLines(HostsFile.ReadAllLines().Where(x => !x.Contains("ppy.sh")));
        }

        public Task<Server> GetCurrentServerAsync()
        {
            return Task.Run<Server>(() => GetCurrentServer());
        }

        public Server GetCurrentServer()
        {
            bool isKafuu = HostsFile.ReadAllLines().Any(x => x.Contains("osu.ppy.sh") && !x.Contains("#"));
            return isKafuu ? Server.Kafuu : Server.Official;
        }
    }

    public enum Server
    {
        Official,
        Kafuu
    }
}
