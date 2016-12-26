using System;

namespace ZilLion.Core.Infrastructure.Unities
{
    public static class UrlHelper
    {
        static UrlHelper()
        {
             var appname = System.IO.Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().GetName().Name);
            AppDataLocalPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                               string.Format(@"\{0}\", appname);
        }
        public static string AppDataLocalPath { get; set; }

    }
}