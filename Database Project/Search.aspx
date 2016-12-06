<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Search
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="forContent" Runat="Server">
   <div class="datalist-page text-center">

       <asp:DropDownList ID="categoryTxt" runat="server" >
           
       </asp:DropDownList>
       <asp:DropDownList ID="ingridientTxt" runat="server" >
           
       </asp:DropDownList>
       <asp:Button ID="search" Text="Search" runat="server" OnClick="searchFunction"/>
       <br /><br />
     <asp:Repeater ID="resultView" runat="server" >
         <HeaderTemplate>
             <table>
                 <tr>
                     <th>Name</th>
                     <th>Time</th>
                 </tr>
         </HeaderTemplate>
         <ItemTemplate>
             <tr>
                 <td><%#Eval("RECIPE_NAME") %></td>
                 <td><%#Eval("IS_PRIVATE") %></td>
             </tr>
         </ItemTemplate>
         <FooterTemplate>
             </table>
         </FooterTemplate>
     </asp:Repeater>
    </div>
</asp:Content>

