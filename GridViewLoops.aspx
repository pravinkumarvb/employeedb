<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewLoops.aspx.cs" Inherits="GridViewLoops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="RollNo" HeaderText="Roll No." />
                <asp:BoundField DataField="SName" HeaderText="Student Name" />
                <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks" />
                <asp:BoundField DataField="Average" HeaderText="Average Marks" />
            </Columns>
        </asp:GridView>
        <br />
        No. of Students:
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        , Toal Avg:
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        Enter Average To Find:<asp:TextBox ID="txtAvg" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" OnClick="btnFind_Click" Text="Find" />
    
    </div>
    </form>
</body>
</html>
