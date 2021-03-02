using RobinHoodDownload.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodDownload.Business
{
    public sealed class ApplicationSettings
    {
        private static ApplicationSettings m_instance = null;
        private ApplicationSettings()
        {
            Initialize();
        }
        public string RobinKey { get; set; } = string.Empty;
        public bool IsLogOnFileSystem { get; internal set; } = true;
        public string LoggingFolder { get; internal set; } = @"C:\LogFiles";
        public static ApplicationSettings Default
        {
            get
            {
                if (m_instance == null)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ApplicationSettings();
                    }
                }
                return m_instance;
            }
        }

        private void Initialize()
        {
            this.LoggingFolder = Settings.Default.LoggingFolder;
            this.IsLogOnFileSystem = Settings.Default.IsLogOnFileSystem;
        }
    }
}
