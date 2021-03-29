<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonComments.aspx.cs" Inherits="PersonComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" 
            OnItemDataBound="DataList1_ItemDataBound">
            <ItemTemplate>
                Person Name:<strong>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("PersonName") %>'></asp:Label>
                <br />
                </strong>Person Age: <strong>
                <asp:Label ID="Label2" runat="server" Text='<%# Eval("PersonAge") %>'></asp:Label>
                </strong>
                <asp:HiddenField ID="hdfPersonID" runat="server" Value='<%# Eval("PersonID") %>' />
                <br />
                <asp:LinkButton ID="lnkComment" runat="server" CommandName="Comment">Comment(0)</asp:LinkButton>
                <br />
                <asp:Panel ID="Panel1" runat="server" Visible="False">
                    Enter Comment:
                    <asp:TextBox ID="txtComment" runat="server" MaxLength="100" ValidationGroup="Post"></asp:TextBox>
                    <asp:Button ID="btnPost" runat="server" CommandName="CPost" Text="Post" ValidationGroup="Post" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="CCancel" Text="Cancel" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtComment" Display="Dynamic" ErrorMessage="Required" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Post"></asp:RequiredFieldValidator>
                </asp:Panel>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Comment" HeaderText="Comment" />
                        <asp:BoundField DataField="Dated" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Dated" />
                        <asp:BoundField DataField="Timed" DataFormatString="{0:hh:mm:ss tt}" HeaderText="Timed" />
                    </Columns>
                </asp:GridView>
                <hr />
            </ItemTemplate>
        </asp:DataList>
    
    </div>
    </form>
</body>
</html>
