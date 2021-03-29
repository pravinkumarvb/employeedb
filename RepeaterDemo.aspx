<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepeaterDemo.aspx.cs" Inherits="RepeaterDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="1">
        <tr>
            <th>Roll No.</th>
            <th>Student Name</th>
            <th>Sub 1</th>
            <th>Sub 2</th>
            <th>Sub 3</th>
            <th>Total</th>
            <th>Avg.</th>
        </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("RollNo") %></td>
                    <td><%#Eval("SName") %></td>
                    <td><%#Eval("S1") %></td>
                    <td><%#Eval("S2") %></td>
                    <td><%#Eval("S3") %></td>
                    <td><%#Eval("TotalMarks") %></td>
                    <td><%#Eval("Average") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
        
    
    </div>
    </form>
</body>
</html>
