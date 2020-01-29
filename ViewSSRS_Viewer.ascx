<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewSSRS_Viewer.ascx.cs" Inherits="GIBS.Modules.SSRS_Viewer.ViewSSRS_Viewer" %>



<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<div style="text-align:right"><asp:linkbutton cssclass="dnnSecondaryAction" id="cmdReturn" resourcekey="cmdReturn" runat="server" OnClick="cmdReturn_Click" Visible="false" /></div>


<rsweb:ReportViewer ID="ReportViewer1" OnPreRender="ReportViewer1_PreRender" AsyncRendering="False" Width="100%" Height="1392px" ShowToolBar="true" ShowExportControls="true" ShowFindControls="false" ShowPrintButton="true" ShowParameterPrompts="true" runat="server">
</rsweb:ReportViewer>