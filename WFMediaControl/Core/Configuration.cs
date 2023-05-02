using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFMediaControl.Core
{
    public class ConfigApp 
    {
        public string UrlWebSocket { get; set; }
    }
    public class AppConfiguration
    {
        private string _pathConfig = "Data/ConfigApp.Json";

        public AppConfiguration()
        {
            string configApp = File.ReadAllText(_pathConfig);

            ConfigApp ConfigApp = JsonConvert.DeserializeObject<ConfigApp>(configApp);
            Configuration = ConfigApp;
        }
        public AppConfiguration(ConfigApp configApp) 
        { 
            string jsonConfig = JsonConvert.SerializeObject(configApp);
            File.WriteAllText(_pathConfig, jsonConfig);
        }

        public ConfigApp Configuration 
        {
            get; private set;

        }
    }
}
