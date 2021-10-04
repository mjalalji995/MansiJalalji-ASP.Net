<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web.aspx.cs" Inherits="web" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        ID:<asp:DropDownList ID="ddlID" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlID_SelectedIndexChanged"></asp:DropDownList><br />
        Name:<asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
        Age:<asp:TextBox ID="txtAge" runat="server"></asp:TextBox><br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>&nbsp;
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
    </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
