using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;
using System;
using System.Web.UI.WebControls;

using GIBS.SSRS_Viewer.Components;

namespace GIBS.Modules.SSRS_Viewer
{
    public partial class Settings : SSRS_ViewerSettings
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

                    if (ReportServerURL != null)
                    {
                        txturlReportServer.Text = ReportServerURL;
                    }


                    if (ReportPath != null)
                    {
                        txtReportPath.Text = ReportPath;
                    }


                    if (ReportCredentialsUserName != null)
                    {
                        txtRSCredentialsUserName.Text = ReportCredentialsUserName;
                    }

                    if (ReportCredentialsPassword != null)
                    {

                        txtRSCredentialsPassword.Text = ReportCredentialsPassword;
                    }
                    if (ReportCredentialsDomain != null)
                    {
                        txtRSCredentialsDomain.Text = ReportCredentialsDomain;
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
               
                ReportCredentialsDomain = txtRSCredentialsDomain.Text.ToString();
                ReportCredentialsPassword = txtRSCredentialsPassword.Text.ToString();
                ReportCredentialsUserName = txtRSCredentialsUserName.Text.ToString();
                ReportPath = txtReportPath.Text.ToString();
                ReportServerURL = txturlReportServer.Text.ToString();

            }
            catch (Exception ex)
            {
                Exceptions.ProcessModuleLoadException(this, ex);
            }
        }
    }
}