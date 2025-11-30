using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Localization;
using DotNetNuke.Common;

namespace GIBS.SSRS_Viewer.Components
{
    /// <summary>
    /// Provides strong typed access to settings used by module
    /// </summary>
    public class SSRS_ViewerSettings : ModuleSettingsBase
    {
        //ModuleController controller;
        //int tabModuleId;

       


       

        #region public properties

        /// <summary>
        /// get/set template used to render the module content
        /// to the user
        /// </summary>
       
        public string ReportServerURL
        {
            get
            {
                if (Settings.Contains("reportServerURL"))
                    return Settings["reportServerURL"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(TabModuleId, "reportServerURL", value.ToString());
            }

        }

        public string ReportPath
        {
            get
            {
                if (Settings.Contains("reportPath"))
                    return Settings["reportPath"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(TabModuleId, "reportPath", value.ToString());
            }

        }

        public string ReportCredentialsUserName
        {
            get
            {
                if (Settings.Contains("reportCredentialsUserName"))
                    return Settings["reportCredentialsUserName"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(TabModuleId, "reportCredentialsUserName", value.ToString());
            }

        }

        public string ReportCredentialsPassword
        {
            get
            {
                if (Settings.Contains("reportCredentialsPassword"))
                    return Settings["reportCredentialsPassword"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(TabModuleId, "reportCredentialsPassword", value.ToString());
            }

        }

        public string ReportCredentialsDomain
        {
            get
            {
                if (Settings.Contains("reportCredentialsDomain"))
                    return Settings["reportCredentialsDomain"].ToString();
                return "";
            }
            set
            {
                var mc = new ModuleController();
                mc.UpdateTabModuleSetting(TabModuleId, "reportCredentialsDomain", value.ToString());
            }

        }




        #endregion
    }
}
