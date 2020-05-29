
namespace KafuuSwitcher
{
    public class Constants
    {
        // Use this address if we cannot grab from ips.txt
        public const string KafuuHardcodedIp = "149.129.115.46";

        // Grab address from here when possible
        public const string KafuuIpApiAddress = "http://server.kafuu.pro";

        public const string UiInstallCertificate = "Install Certificate";

        public const string UiUninstallCertificate = "Delete Certificate";

        public const string UiYouArePlayingOnKafuu = "You're connected to osu!Kafuu";

        public const string UiYouArePlayingOnOfficial = "You're playing on Bancho!";

        public const string UiSwitchToKafuu = "Connect to Kafuu!";

        public const string UiSwitchToOfficial = "Disconnect from Kafuu!";

        public const string UiUpdatingStatus = "Retrieving addresses..";
    }
}
