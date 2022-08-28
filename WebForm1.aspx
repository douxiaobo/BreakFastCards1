<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BreakfastCards1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Breakfast Cards Manage System</h1>
        </div>
        <div>
            <h2>早餐卡管理系统</h2>
        </div>
        <hr />
        <div>
            Add:增加：<br />
            Year:<asp:DropDownList ID="DropDownList_Add_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Add_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Add_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            Quantity:<asp:TextBox ID="TextBox_Add_Quantity" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Add_Comfirm" runat="server" Text="Add" OnClick="Button_Add_Comfirm_Click"  />
        </div>
        <div>
            Delete:删除：<br />
            Year:<asp:DropDownList ID="DropDownList_Delete_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Delete_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Delete_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            <asp:Button ID="Button_Delete" runat="server" Text="Delete" OnClick="Button_Delete_Click"  />
        </div>
        <div>
            Revise:修改：<br />
            Year:<asp:DropDownList ID="DropDownList_Revise_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Revise_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Revise_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            Quantity:<asp:TextBox ID="TextBox_Revise_Quantity" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Revise" runat="server" Text="Revise" OnClick="Button_Revise_Click" />
        </div>
        <div>
            Inquiry:查询<br />
            Year:<asp:DropDownList ID="DropDownList_Inquiry_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Inquiry_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Inquiry_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            <asp:Button ID="Button_Inquiry" runat="server" Text="Inquiry" />
        </div>
        <hr />
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="GroupName" HeaderText="GroupName" SortExpression="GroupName" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Manager" HeaderText="Manager" SortExpression="Manager"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BreakfastCards;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Table_FourName]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
