<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ToDoApplication.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="To-Do Application" Font-Bold="True"></asp:Label>
        </div>
        <br />
        <br />
        <br />
        To-Do List:<br />
        <asp:Label ID="Label2" runat="server" Text="Add New To-Do List Item : "></asp:Label>
        <asp:TextBox ID="txt_newtodolistitem" runat="server" Width="187px"></asp:TextBox>&nbsp;
        <asp:Button ID="btn_addnewtodolist" runat="server" Text="ADD" Width="100px" OnClick="btn_addnewtodolist_Click" />
        <asp:CheckBoxList ID="chkToDoList" runat="server" DataSourceID="SqlDataSource1" DataTextField="ToDoListItem" DataValueField="Id" OnSelectedIndexChanged="chkToDoList_SelectedIndexChanged" AutoPostBack="true">
        </asp:CheckBoxList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ToDoListConnectionString %>" SelectCommand="SELECT * FROM [tblToDoListItem]"></asp:SqlDataSource>
        <br />
        <br />
        Completed List:<br />
        <asp:CheckBoxList ID="chkCompletedList" runat="server" DataSourceID="SqlDataSource2" DataTextField="CompletedListItem" DataValueField="Id" OnSelectedIndexChanged="chkCompletedList_SelectedIndexChanged" AutoPostBack="true">
        </asp:CheckBoxList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ToDoListConnectionString %>" SelectCommand="SELECT * FROM [CompletedListItem]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Delete Item : "></asp:Label>
        <asp:TextBox ID="txt_deleteitem" runat="server" Width="187px"></asp:TextBox> &nbsp;
        <asp:Button ID="btn_delete" runat="server" OnClick="btn_delete_Click" Text="DELETE" Width="148px" />
        <br />
    </form>
</body>
</html>
