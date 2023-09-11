using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace Final
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptResourceDefinition ResDef = new ScriptResourceDefinition();
            ResDef.Path = "https://unpkg.com/jquery";
            ResDef.DebugPath = "https://unpkg.com/jquery";
            ResDef.CdnPath = "https://unpkg.com/jquery";
            ResDef.CdnDebugPath = "https://unpkg.com/jquery";

            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, ResDef);
        }
    }
}