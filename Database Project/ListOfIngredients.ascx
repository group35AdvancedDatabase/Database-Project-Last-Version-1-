<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListOfIngredients.ascx.cs" Inherits="ListOfIngredients" %>

<li class="type-here">
    <asp:TextBox runat="server" id="unit" CssClass="ingridients" />
    <asp:TextBox runat="server" type="number" id="quantity" CssClass="ingridients" />
    <asp:TextBox runat="server" id="ingridient" CssClass="ingridients ingridient-class" CausesValidation="true"/><br />
    <asp:CustomValidator runat="server" 
        SetOnFocusError="True" 
        Display="Dynamic"
        CssClass="error-required ingr-err"
        ID="nameValidation"
        OnServerValidate="nameValidate" 
        ErrorMessage ="Name is required"
        ValidationGroup="submit"/>
</li>