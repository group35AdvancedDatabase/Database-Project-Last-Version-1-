<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="Recipes.aspx.cs" Inherits="Recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Recipes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="forContent" Runat="Server">
    <div class="datalist-page text-center">
     
        <h1>The list of recipes</h1>
        <h2>Look at the list of recipes which we have</h2>
        <asp:GridView runat="server" ID="grid" AutoGenerateColumns="false" OnRowCommand="grid_RowCommand">
            <Columns>
             <asp:TemplateField HeaderText="Recipe Name">
                <ItemTemplate>
                    <asp:LinkButton ID="recipeNameLB" runat="server" 
                        Text='<%# Eval("RECIPE_NAME") %>'
                        CommandName="takeAllDetails" 
                        CommandArgument='<%#Bind("RECIPE_ID") %>'
                        >
                     </asp:LinkButton>
                 </ItemTemplate>
              </asp:TemplateField>
                <asp:BoundField DataField="CUISINE_NAME" HeaderText="Cuisine" />
                <asp:BoundField DataField="CATEGORY_NAME" HeaderText="Category" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

