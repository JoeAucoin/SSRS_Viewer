using System;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

using GIBS.SSRS_Viewer.Components;

namespace GIBS.Modules.SSRS_Viewer
{
    public partial class Settings : ModuleSettingsBase
    {

        /// <summary>
        /// handles the loading of the module setting for this
        /// control
        /// </summary>
        public override void LoadSettings()
        {
            try
            {
                if (!IsPostBack)
                {
                    SSRS_ViewerSettings settingsData = new SSRS_ViewerSettings(this.TabModuleId);

                    if (settingsData.ReportServerURL != null)
                    {
                        txturlReportServer.Text = settingsData.ReportServerURL.ToString();
                    }

                    if (settingsData.ReportPath != null)
                    {
                        txtReportPath.Text = settingsData.ReportPath.ToString();
                    }

                    if (settingsData.ReportCredentialsUserName != null)
                    {
                        txtRSCredentialsUserName.Text = settingsData.ReportCredentialsUserName.ToString();
                    }

                    if (settingsData.ReportCredentialsPassword != null)
                    {

                        txtRSCredentialsPassword.Text = settingsData.ReportCredentialsPassword.ToString();
                    }
                    if (settingsData.ReportCredentialsDomain != null)
                    {
                        txtRSCredentialsDomain.Text = settingsData.ReportCredentialsDomain.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }

        /// <summary>
        /// handles updating the module settings for this control
        /// </summary>
        public override void UpdateSettings()
        {
            try
            {
                SSRS_ViewerSettings settingsData = new SSRS_ViewerSettings(this.TabModuleId);

                settingsData.ReportCredentialsDomain = txtRSCredentialsDomain.Text.ToString();
                settingsData.ReportCredentialsPassword = txtRSCredentialsPassword.Text.ToString();
                settingsData.ReportCredentialsUserName = txtRSCredentialsUserName.Text.ToString();
                settingsData.ReportPath = txtReportPath.Text.ToString();
                settingsData.ReportServerURL = txturlReportServer.Text.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}