<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="RecipeDetailsPage.aspx.cs" Inherits="RecipeDetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Recipe Details Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="forContent" Runat="Server">
  <div class="details-div text-center">
   <div class="content" >  
    <div class="inside-content-text">
    <div class="image-div"> 
    <asp:Image runat="server" ID="imagePct" CssClass="detailsImg"/>
    <asp:Label runat="server" CssClass="label-image" ID="labelImage">Type a new image path:</asp:Label>
    <asp:TextBox runat="server" ID="boxImage" CssClass="image-box"/>
    </div>
    <div class="inside-text">
    <p style="border-bottom: 1px black solid">
    <span class="span-text">Name: </span><asp:Label runat="server" class="text-details-label" ID="lblName" /> 
        <asp:TextBox runat="server" ID="boxName" CssClass="textBoxPage" /><br />
    </p>
    <p>
    <span class="span-text">Cooking Time: </span><asp:Label runat="server" class="text-details-label" ID="lblTime" />
        <asp:TextBox runat="server" ID="boxTime" CssClass="textBoxPage" /><br />
    </p>
    <p>
    <span class="span-text"">Category: </span><asp:Label runat="server" class="text-details-label" ID="lblCategory" />
        <asp:TextBox runat="server" ID="boxCategory" CssClass="textBoxPage" /><br />
    </p>
    <p>
    <span class="span-text">Portion(s): </span><asp:Label runat="server" class="text-details-label" ID="lblPortion" /> 
        <asp:TextBox runat="server" ID="boxPortion" CssClass="textBoxPage" /><br />
    </p>
    <p>
    <span class="span-text">Cuisine: </span><asp:Label runat="server" class="text-details-label"  ID="lblCuisine" /> 
        <asp:TextBox runat="server" ID="boxCuisine" CssClass="textBoxPage" /><br />
    </p>
    <p>
    <span class="span-text">Is it Private?: </span><asp:Label runat="server" class="text-details-label" ID="lblPrivate" /> 
        <asp:RadioButton runat="server" ID="yes" GroupName="private" Text="Yes"/><asp:RadioButton runat="server" ID="no" Text="No" Value="No" GroupName="private" /><br />
    </p>
    <asp:Button runat="server" ID="deleteBtn" Text="Delete Recipe" CssClass="bg-primary" OnClick="deleteBtn_Click"/>
    <asp:Button runat="server" ID="editBtn" Text="Edit Recipe" CssClass="bg-primary" OnClick="editBtn_Click" />
    <asp:Button runat="server" ID="cancelBtn" Text="Cancel" CssClass="bg-success" OnClick="cancelBtn_Click" />
    <asp:Button runat="server" ID="updateBtn" Text="Update" CssClass="bg-success" OnClick="updateBtn_Click"/>
        </div>
    </div>
    <br /> 
    <div class="description-block">
        <span class="span-text">Description of the Recipe </span><br /><asp:Label runat="server" class="text-details-label" ID="lblDesc" /> 
        <asp:TextBox TextMode="MultiLine" runat="server" ID="boxDesc" Rows="5" Columns="78"/>
    </div>
    <div class="gridViewClass">
     <h2>Ingredients in this recipe</h2>
    <asp:GridView runat="server" ID="ingridients" AutoGenerateColumns="False" OnRowEditing="ingridients_RowEditing" OnRowCancelingEdit="ingridients_RowCancelingEdit1" OnRowUpdating="ingridients_RowUpdating">
        <Columns>
            <asp:TemplateField HeaderText="Ingredient Number" ItemStyle-Width="0">
                <ItemTemplate>
                    <asp:Label ID="labelID" runat="server" Text='<%# Bind("INGREDIENT_ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ingredient Name">
                <EditItemTemplate>
                    <asp:TextBox ID="editName" runat="server" Text='<%# Bind("INGREDIENTNAME") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="labelName" runat="server" Text='<%# Bind("INGREDIENTNAME") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Qunatity">
                <EditItemTemplate>
                    <asp:TextBox ID="editQnt" runat="server" Text='<%# Bind("INGREDIENTQNT") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="labelQnt" runat="server" Text='<%# Bind("INGREDIENTQNT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Measure">
                <EditItemTemplate>
                    <asp:TextBox ID="editMeasure" runat="server" Text='<%# Bind("INGREDIENTCMNT") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="labelMeasure" runat="server" Text='<%# Bind("INGREDIENTCMNT") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="true" HeaderText="Edit/Delete" />
        </Columns>
    </asp:GridView>
    </div>
   </div>
  </div>       
</asp:Content>