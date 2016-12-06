<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="AddRecipe.aspx.cs" Inherits="AddRecipe" %>
<%@ Register src="~/ListOfIngredients.ascx" TagPrefix="LOI" TagName="Ingridient"%>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
    Add Recipe
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="forContent" Runat="Server">

    <div class="inside-container ">
        <div class="container--header text-center">
            <div class="container--header__topLine">
                <h1>Add recipe to the recipe list</h1>
                <h2>You can share a dished which you are proud of.</h2>
            </div>
        </div>
        <asp:Label runat="server" ID="checkValidPage" CssClass="mainError"/>
        <%-- Add recipe block --%>
        <div class="container--addRecipe">
            <%-- Inside the add recipe block --%>
            <div class="container--addRecipe__insideBlock">
                <%-- addForm recipe --%>
                <div class="container--addRecipe__insideBlock__addForm">

                <%-- Name of recipe input --%>
                <div class="input-group text-center">
                    <label class="first-five-labels">Name of recipe <span style="color: red">*</span></label><br />
                    <asp:TextBox runat="server" ID="nnameOfRecipe" CssClass="nameOfRecipe first-five-inputs"/>
                    <asp:RequiredFieldValidator ID="nameOfRecipeReq" runat="server"
                        ControlToValidate="nnameOfRecipe"
                        ErrorMessage = "Required" 
                        SetFocunOnError = "True" Display="Dynamic" CssClass="error-required" ValidationGroup="submit"/>
                </div>
                <%-- End of name of recipe input --%>

                <%-- Cuisine input --%>
                <div class="input-group">
                    <label class="first-five-labels">Cuisine</label>
                    <asp:DropDownList runat="server" ID="cuisineList" data-check="fix"/>
                    <asp:LinkButton ID="addCuisine" Text=" Add your own Cuisine" runat="server" OnClick="addNewCuisine"/>
                    <asp:LinkButton ID="removeCuisine" Text=" Remove your own Cuisine" runat="server" OnClick="removeNewCuisine" />
                    <asp:TextBox runat="server" id="ccuisine" class="category" CssClass="first-five-inputs"/>
                </div>
                    
                <%-- End of Cuisine input --%>

                 <%-- Category input --%>
                    <div class="input-group">
                    <label class="first-five-labels">Category</label>
                    <asp:DropDownList runat="server" ID="categoryList" data-check="fix"/>
                    <asp:LinkButton ID="addCategory" Text=" Add your own category" runat="server" OnClick="addNewCategory"/>
                    <asp:LinkButton ID="removeCategory" Text=" Remove your own category" runat="server" OnClick="removeNewCategory" />
                    <asp:TextBox runat="server" id="ccategory" class="category" CssClass="first-five-inputs"/>
                    </div>
                <%-- End of categoy input --%>

                <%-- Cooking time input --%>
                <div class="input-group">
                    <label class="first-five-labels">Cooking Time<span style="color: red"> *</span></label>
                    <asp:TextBox runat="server" id="ccookingTime" class="cookingTime" CssClass="first-five-inputs"/>
                    <asp:RequiredFieldValidator ID="checkTheCookingTime" runat="server"
                        ControlToValidate="ccookingTime"
                        ErrorMessage = "Required" 
                        SetFocunOnError = "True" Display="Dynamic" CssClass="error-required" ValidationGroup="submit"/>
                </div>
                <%-- End of cooking time input --%>

                <%-- Portion input --%>
                <div class="input-group">
                    <label class="first-five-labels">Number of Servings <span style="color: red">*</span></label>
                    <asp:TextBox runat="server" id="nnumberOfServings" class="numberOfServings" CausesValidation="true" CssClass="first-five-inputs"/>
                    <asp:CustomValidator ID="checkTheTypeOfInput" runat="server"
                        ControlToValidate="nnumberOfServings"
                        ErrorMessage = "Type only number"
                        OnServerValidate="checkTypeOfInput"
                        Display="Dynamic" CssClass="error-required" ValidationGroup="submit" SetFocusOnError="True"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="nnumberOfServings"
                        ErrorMessage = "Required" 
                        SetFocunOnError = "True" Display="Dynamic" CssClass="error-required" ValidationGroup="submit"/>
                </div>
                    
                <%-- End of Portion input --%>

                <%-- Recipe Description input --%>
                <div class="input-group">
                    <label>Recipe Description <span style="color: red">*</span></label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="description"
                        ErrorMessage = "Required" 
                        SetFocunOnError = "True" Display="Static" CssClass="error-required-desc" ValidationGroup="submit"/>
                    <asp:TextBox  TextMode="MultiLine" Columns="71" Rows="5" runat="server" ID="description" class="description" />
                </div>
                    
                <%-- End of recipe description input --%>

                <%-- Is_Private input --%>
                <div class="input-group">
                    <label>Is you recipe private?</label>
                    <asp:CheckBox runat="server" ID="isPrivate" />
                </div>
                <%-- End of Is_Private input --%>

                <%-- Image Path input --%>
                <div class="input-group text-center">
                    <label class="first-five-labels">Image Path</label><br />
                    <asp:TextBox runat="server" ID="imagePath" CssClass="imagePath first-five-inputs"/>
                </div>

                <%-- End of Image Path input --%>

                <%-- List of ingredients --%>
                <div class="input-group ingr-group">
                    <div class="label-here ">
                    <label>List of Ingridients</label>
                    </div>
                <div class="inputs">
                    <ul>
                    <li class="type-here">
                        <span class="title title-one">Ingridient</span><span class="title title-two">Quantity</span><span class="title title-three">Unit</span>
                    </li>
                    <LOI:Ingridient runat="server" ID="ingr_1" />                     
                    <LOI:Ingridient runat="server" ID="ingr_2" />
                    <LOI:Ingridient runat="server" ID="ingr_3" />
                    <LOI:Ingridient runat="server" ID="ingr_4" />
                    <LOI:Ingridient runat="server" ID="ingr_5" />
                    <LOI:Ingridient runat="server" ID="ingr_6" />
                    <LOI:Ingridient runat="server" ID="ingr_7" />
                    <LOI:Ingridient runat="server" ID="ingr_8" />
                    <LOI:Ingridient runat="server" ID="ingr_9" />
                    <LOI:Ingridient runat="server" ID="ingr_10" />
                    <LOI:Ingridient runat="server" ID="ingr_11" />
                    <LOI:Ingridient runat="server" ID="ingr_12" />
                    <LOI:Ingridient runat="server" ID="ingr_13" />
                    <LOI:Ingridient runat="server" ID="ingr_14" />
                    <LOI:Ingridient runat="server" ID="ingr_15" />
                    </ul>
            </div>
          </div>
                    <%-- Submit button --%>
                <div class="input-group">
                    <asp:Button runat="server" ID="submitButton" Text="Save Recipe" OnClick="Save_Recipe" CausesValidation="true" ValidationGroup="submit" CssClass="btn btn-info submitButton" />
                    <asp:Button runat="server" ID="cancelButton" Text="Clear Recipe" OnClick="Reset_Form" CssClass="btn btn-danger cancelButton"/>
                </div>
                <%-- End of submit button --%>
        </div>
       </div>
        </div>
    </div>
</asp:Content>

