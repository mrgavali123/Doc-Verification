using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerateCertificate
{
    class GlobalConfig
    {
       private static GlobalConfig globalConfig;
        private String user = "";
        private GlobalConfig()
        {

        }

        public string User { get => user; set => user = value; }

        public static GlobalConfig getInstance()
        {
            if(globalConfig==null)
            {
                globalConfig= new GlobalConfig();
                return globalConfig;
            }
            else
            {
                return globalConfig;
            }
        }
    }
}
