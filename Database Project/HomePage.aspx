<%@ Page Title="" Language="C#" MasterPageFile="~/FooterAndHeader.master" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<asp:Content ID="titleOfPage" ContentPlaceHolderID="title" runat="Server">
    Home Page
</asp:Content>
<asp:Content ID="contentOfPage" ContentPlaceHolderID="forContent" runat="server">
    <div class="container-fluid intro">
            <div class="bgc-img">
                <div class="page-description  text-center">
                    <h1>Manage your favourite recipes online</h1>
                    <p>Create your personal cookbook with "Time Food" to collect recipes from the Internet and add your own ones</p>
                    <button type="button" class="btn btn-info try-button" disabled="disabled">Try it today!</button>
                    <p class="follow">Also follows us in social media!</p>
                    <ul class="follow-media">
                        <li class="facebook"><a href="https://www.facebook.com/"><img src="img/facebook-icon.png" class="nav-img"/></a></li>
                        <li class="youtube"><a href="https://www.youtube.com/"><img src="img/youtube-icon.png" class="nav-img"/></a></li>
                        <li class="instagram"><a href="https://www.instagram.com/"><img src="img/instagram-icon.png" class="nav-img"/></a></li>
                        <li class="twitter"><a href="https://twitter.com/"><img src="img/twitter-icon.png" class="nav-img"/></a></li>
                    </ul>
                </div>
            </div>
    </div>
    <div class="row six-blocks">
        <h1 class="text-center opport">We provide you by next opportunities</h1>
        <div class="inside-blocks text-center">
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc first-block">
                     <a href="Search.aspx">Search new outstanding recipes</a>
                 </div>
            </div>
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc second-block">
                     <a href="AddRecipe.aspx">Add new favourite recipes</a>
                 </div>
            </div>
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc third-block">
                     <a href="Recipes.aspx">Infinite number of recipes</a>
                 </div>
            </div>
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc fourth-block">
                     <a href="AddRecipe.aspx">Plan your every meal daily</a>
                 </div>
            </div>
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc fifth-block">
                     <a href="AddRecipe.aspx">Create lists of purchases</a>
                 </div>
            </div>
            <div class="col-lg-2 block">
                 <div class="inside-block block-desc sixth-block">
                     <a href="AddRecipe.aspx">Write notitifications in the lists</a>
                 </div>
            </div>
        </div>
    </div>
    <div class="container-fluid photos-block">
        <div class=""
    </div>
</asp:Content>

