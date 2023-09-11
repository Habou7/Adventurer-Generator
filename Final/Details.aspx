<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Final.Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Adventurer's Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div class="row">
        <div class="col col-lg-8 offset-lg-2 d-grid justify-content-center">
            <div class="p-5 mt-5 border border-1">
                <h1 class="display-4 pt-5 text-center" id="txtName" runat="server">Adventurer's Name</h1>
                <h4 class="text-center" id="txtType" runat="server">Adventurer's Type</h4>

                <h2 class="text-center fst-italic py-5" id="txtPhrase" runat="server">Adventurer's Greeting</h2>


                <h3 class="text-center mb-3">Stats</h3>
                <asp:Panel ID="pnlStats" runat="server" CssClass="stats">
                    <div class="stats-item">
                        Strength: <asp:Label ID="lblStrength" runat="server" Text=""/>
                    </div>
                    <div class="stats-item">
                        Dexterity: <asp:Label ID="lblDexterity" runat="server" Text=""/>
                    </div>
                    <div class="stats-item">
                        Vitality: <asp:Label ID="lblVitality" runat="server" Text=""/>
                    </div>
                    <div class="stats-item">
                        Mana: <asp:Label ID="lblMana" runat="server" Text=""/>
                    </div>
                </asp:Panel>

                <h3 class="text-center mb-3">Items</h3>
                <asp:Label ID="lblErrorMessages" runat="server" CssClass="d-block alert alert-danger" Visible="false"></asp:Label>
                
                <asp:CheckBoxList ID="cblItems" runat="server" RepeatLayout="Flow" CssClass="checkbox-list"></asp:CheckBoxList>

                <asp:Button ID="btnEquipItems" runat="server" Text="Equip Items" CssClass="btn btn-primary" OnClick="btnEquipItems_Click" />
            </div>

            <asp:HyperLink ID="hlReturn" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-primary m-5">Back</asp:HyperLink>
        </div>
    </div>
</asp:Content>
