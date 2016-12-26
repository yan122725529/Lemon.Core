using System;
using System.Management;
using Microsoft.Win32;

namespace ZilLion.Core.Infrastructure.Unities
{
    public static class SysHelper
    {
        static SysHelper()
        {
            OSProductName = GetOSName();
            ComputerMacAddress = GetMacAddress();
            ComputerName = Environment.MachineName != null ? Environment.MachineName.ToLower() : null;
            HasFramework40 = CheckFramework();
        }

        //public static string VersionName { get; private set; }

        public static string ComputerName { get; private set; }


        public static string OSProductName { get; private set; }
        public static string ComputerMacAddress { get; private set; }


        public static bool HasFramework40 { get; private set; }

        private static string GetOSName()
        {
            try
            {
                var rk = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
                var OSname = rk.GetValue("ProductName").ToString();
                rk.Close();
                return OSname;
            }
            catch (Exception)
            {
                return @"Can't find LocalMachine\Software\Microsoft\Windows NT\CurrentVersion\ProductName";
            }
        }

        private static bool CheckFramework()
        {
            return CheckInstallFramework(@"Software\Microsoft\NET Framework Setup\NDP\v4\Client") ||
                   CheckInstallFramework(@"Software\Microsoft\NET Framework Setup\NDP\v4\Full");
        }

        private static string GetMacAddress()
        {
            try
            {
                //获取网卡硬件地址
                var mac = "";
                var mc = new
                    ManagementClass("Win32_NetworkAdapterConfiguration");
                var moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    if ((bool) mo["IPEnabled"])
                    {
                        mac = mo["MacAddress"].ToString();
                        break;
                    }
                }
                moc = null;
                mc = null;
                return mac;
            }
            catch
            {
                return null;
            }
            finally
            {
            }
        }

        private static bool CheckInstallFramework(string registryPath)
        {
            var framework = Registry.LocalMachine.OpenSubKey(registryPath);
            return framework != null && CheckInstallValue(framework);
        }

        private static bool CheckInstallValue(RegistryKey framework)
        {
            var fullValue = framework.GetValue("Install");
            return fullValue != null && fullValue.ToString() == "1";
        }

        #region Registry AbizClient

        public static string GetRegistryCurrentUserOfAbizClientValue(string key)
        {
            return GetRegistryCurrentUserOfValue("SOFTWARE\\AbizClient", key);
        }

        public static void SetRegistryCurrentUserOfAbizClientValue(string key, string value)
        {
            SetRegistryCurrentUserOfValue("SOFTWARE\\AbizClient", key, value);
        }

        public static void DeleteRegistryCurrentUserOfAbizClientValue(string key)
        {
            DeleteRegistryCurrentUserOfValue("SOFTWARE\\AbizClient", key);
        }

        #endregion

        #region Registry Custom SubKey

        /// <summary>
        ///     找不到注册表记录，直接忽略
        /// </summary>
        /// <param name="subKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRegistryCurrentUserOfValueIgnoerEx(string subKey, string key)
        {
            var versionKey = Registry.CurrentUser.OpenSubKey(subKey, true);
            if (versionKey == null)
                return string.Empty;
            var versionValue = versionKey.GetValue(key);
            if (versionValue == null || string.IsNullOrEmpty(versionValue.ToString().Trim()))
                return string.Empty;
            return versionValue.ToString();
        }

        /// <summary>
        ///     找不到注册表记录，报错
        /// </summary>
        /// <param name="subKey"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetRegistryCurrentUserOfValue(string subKey, string key)
        {
            var versionKey = Registry.CurrentUser.OpenSubKey(subKey, true);

            if (versionKey == null)
                throw new NullReferenceException(string.Format("Can't find Registry.CurrentUser.OpenSubKey of {0}",
                    subKey));

            var versionValue = versionKey.GetValue(key);
            return versionValue == null ? string.Empty : versionValue.ToString();
        }

        public static void SetRegistryCurrentUserOfValue(string subKey, string key, string value)
        {
            var subValue = Registry.CurrentUser.CreateSubKey(subKey);
            subValue.SetValue(key, value);
        }

        public static void DeleteRegistryCurrentUserOfValue(string subKey, string key)
        {
            var subValue = Registry.CurrentUser.CreateSubKey(subKey);
            subValue.DeleteValue(key, false);
        }

        #endregion
    }
}