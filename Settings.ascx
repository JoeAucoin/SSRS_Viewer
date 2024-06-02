<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="GIBS.Modules.SSRS_Viewer.Settings" %>

<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="SectionHead" Src="~/controls/SectionHeadControl.ascx" %>

<div class="dnnForm" id="form-settings">

    <fieldset>
      
        
<dnn:sectionhead id="Sectionhead1" cssclass="Head" runat="server" text="Report Server Settings" section="ReportServerSection"
	includerule="True" isexpanded="True"></dnn:sectionhead>

<div id="ReportServerSection" runat="server">   

     <div class="dnnFormItem">					
    <dnn:label id="lblurlReportServer" runat="server" suffix=":" controlname="txturlReportServer" ResourceKey="lblurlReportServer" />
         <asp:TextBox ID="txturlReportServer" runat="server" />		
    </div>
 
      <div class="dnnFormItem">					
    <dnn:label id="lblReportPath" runat="server" suffix=":" controlname="txtReportPath" ResourceKey="lblReportPath" />
         <asp:TextBox ID="txtReportPath" runat="server" />		
    </div>
 
      <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsUserName" runat="server" suffix=":" controlname="txtRSCredentialsUserName" ResourceKey="lblRSCredentialsUserName" />
         <asp:TextBox ID="txtRSCredentialsUserName" runat="server" />		
    </div>



     <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsPassword" runat="server" suffix=":" controlname="txtRSCredentialsPassword" ResourceKey="lblRSCredentialsPassword" />
         <asp:TextBox ID="txtRSCredentialsPassword" runat="server" />		
    </div>



     <div class="dnnFormItem">					
    <dnn:label id="lblRSCredentialsDomain" runat="server" suffix=":" controlname="txtRSCredentialsDomain" ResourceKey="lblRSCredentialsDomain" />
         <asp:TextBox ID="txtRSCredentialsDomain" runat="server" />		
    </div>

</div>        			


    </fieldset>

</div>