<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonMaster.aspx.cs" Inherits="PersonMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Enter Person Name:<asp:TextBox ID="txtPersonName" runat="server"></asp:TextBox>
&nbsp;Enter Age:<asp:TextBox ID="txtPersonAge" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
        <asp:HiddenField ID="hdfID" runat="server" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="Record Not Found !!!" OnRowCommand="GridView1_RowCommand">
            <Columns>
                <asp:BoundField DataField="PersonID" HeaderText="ID" />
                <asp:BoundField DataField="PersonName" HeaderText="Full Name" />
                <asp:BoundField DataField="PersonAge" HeaderText="Age" />
                <asp:ButtonField CommandName="Ed" Text="Edit" />
                <asp:ButtonField CommandName="Del" Text="Delete" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
