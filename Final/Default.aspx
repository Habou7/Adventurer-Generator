<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Final.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Adventurers
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <h1 class="display-4 p-4 text-center">Adventurer Generator</h1>
    <div class="p-5 bg-light border border-1 mb-5">
        <div class="form-group mb-3">
            <label class="form-label" for="txtName">Adventurer Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control mb-2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" InitialValue="" ErrorMessage="Adventurer's Name is required." Text="Name is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        
        <div class="form-group mb-3">
            <label class="form-label" for="ddlClass">Adventurer Type</label>
            <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select mb-2">
                <asp:ListItem Value="">Select a type...</asp:ListItem>
                
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType" InitialValue="" ErrorMessage="Adventurer's Type is required." Text="Type is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="btnCreateAdventurer" runat="server" Text="Create Adventurer" CssClass="btn btn-primary" OnClick="btnCreateAdventurer_Click" />
    </div>

    <h2 class="text-center mb-3">Adventurers</h2>
    <asp:Table ID="tblAdventurers" runat="server" CssClass="table table-hover border border-1">
        <asp:TableRow>
            <asp:TableCell>
                <asp:HyperLink NavigateUrl="Details.aspx?id=-1" runat="server">Adventurer's Name (Adventurer's Type)</asp:HyperLink>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
