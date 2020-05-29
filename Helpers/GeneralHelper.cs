using System.Net;
using System.Threading.Tasks;

namespace KafuuSwitcher
{
    static class GeneralHelper
    {
        public async static Task<string> GetKafuuAddressAsync()
        {
            using (var webClient = new WebClient())
            {
                string result = string.Empty;
                try
                {
                    var line = await webClient.DownloadStringTaskAsync(Constants.KafuuIpApiAddress);
                    result = line;
                }
                catch { }
                return result.Trim();
            }
        }
    }
}