<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataListDemo1.aspx.cs" Inherits="DataListDemo1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server">
            <ItemTemplate>
                <strong>Person ID:</strong><asp:Label ID="Label1" runat="server" Text='<%#Eval("PersonID") %>'></asp:Label>
                <br />
                <strong>Person Name:</strong><asp:Label ID="Label2" runat="server" Text='<%#Eval("PersonName") %>'></asp:Label>
                <br />
                <strong>Person Age:</strong><asp:Label ID="Label3" runat="server" Text='<%#Eval("PersonAge") %>'></asp:Label>
                <hr />
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
