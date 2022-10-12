<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm__AARegistration.aspx.cs" Inherits="BreakfastCards1.WebForm__AARegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>The Registration of The Breakfast Cards Manage System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Year:<asp:DropDownList ID="DropDownList_Add_Year" runat="server" AutoPostBack="false"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_Add_Month" runat="server" AutoPostBack="false"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_Add_GroupName" runat="server" AutoPostBack="false"></asp:DropDownList>
            Quantity:<asp:TextBox ID="TextBox_Add_Quantity" runat="server"></asp:TextBox>
            <asp:Button ID="Button_Add_Comfirm" runat="server" Text="Add" OnClick="Button_Add_Comfirm_Click"  />
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
