<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="SetupPage.aspx.cs" Inherits="SetupPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Setup page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="forContent" Runat="Server">
   <div class="setup-page-container">
     <div class="dd-list text-center">
         <h1>Select the Theme for the web site</h1>
    <asp:DropDownList runat="server" ID="Theme" CssClass="dropdown-list-theme">
        <asp:ListItem Value="Default" Name="Default" ID="Default" runat="server" />
        <asp:ListItem Value="Light" Name="Light" ID="Light" runat="server" />
        <asp:ListItem Value="Dark" Name="Dark" ID="Dark" runat="server" />
    </asp:DropDownList>
        <p>
            <asp:Label runat="server" ID="chosenTheme"  CssClass="choice-label"/>
         </p>
     </div>
     <div class="choose-button text-center">
         <p>        
           <asp:Button runat="server" CssClass="buttonChoose btn btn-info" ID="submitButton" Text="Setup page" OnClick="Choose_Theme" />
         </p>
     </div>
   </div>
</asp:Content>

