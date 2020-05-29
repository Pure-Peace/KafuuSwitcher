using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KafuuSwitcher
{
    class CertificateManager
    {
        public Task<bool> GetStatusAsync()
        {
            return Task.Run<bool>(() => GetStatus());
        }

        public void Install()
        {
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            var certificate = new X509Certificate2(KafuuSwitcher.Properties.Resources.cert);
            store.Add(certificate);

            store.Close();
        }

        public void Uninstall()
        {
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadWrite);

            var certificates = store.Certificates.Find(X509FindType.FindBySubjectName, "*.ppy.sh", true);

            foreach (var cert in certificates)
            {
                try
                {
                    store.Remove(cert);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            if (store != null)
            {
                store.Close();
            }
        }

        public bool GetStatus()
        {
            var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            var c = store.Certificates.Find(X509FindType.FindBySubjectName, "*.ppy.sh", true);
            bool result = c.Count >= 1;

            store.Close();

            return result;
        }
    }
}
