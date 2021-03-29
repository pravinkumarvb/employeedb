<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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

        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center><h2>Employee Master</h2></center>
            <table class="auto-style1">
                <tr>
                    <td>
                        <table class="auto-style1">
                            <tr>
                                <td class="auto-style2">Enter Employee Name</td>
                                <td>
                                    <asp:TextBox ID="txtEmpName" runat="server" MaxLength="100" Width="346px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpName" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Select Designation</td>
                                <td>
                                    <asp:DropDownList ID="ddlDes" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDes" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style2">Enter Salary</td>
                                <td>
                                    <asp:TextBox ID="txtSalary" runat="server" MaxLength="7"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtSalary" Display="Dynamic" ErrorMessage="Invalid Amount" ForeColor="Red" Operator="DataTypeCheck" SetFocusOnError="True" Type="Double"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hdfEmpID" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                    <asp:Button ID="btnClears" runat="server" Text="Clears" CausesValidation="False" OnClick="btnClears_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <center>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"   >
                        <Columns>
                            <asp:BoundField DataField="EmpID" HeaderText="Employee ID" />
                            <asp:BoundField DataField="EmpName" HeaderText="Employee Name" />
                            <asp:BoundField DataField="DesName" HeaderText="Designation" />
                            <asp:BoundField DataField="Salary" HeaderText="Salary" />
                            <asp:ButtonField CommandName="Ed" Text="Edit" />
                            <asp:ButtonField CommandName="Del" Text="Delete" />
                        </Columns>
                    </asp:GridView>
                    </center>
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
