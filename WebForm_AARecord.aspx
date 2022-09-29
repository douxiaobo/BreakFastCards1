<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm_AARecord.aspx.cs" Inherits="BreakfastCards1.WebForm_AARecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>AA Record Breakfast Cards</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            AA Record Breakfast Cards in Last Month
        </div>
        <br />
        <div>
            Year:<asp:DropDownList ID="DropDownList_AddYear" runat="server"></asp:DropDownList>
            Month:<asp:DropDownList ID="DropDownList_AddMonth" runat="server"></asp:DropDownList>
            Group Name:<asp:DropDownList ID="DropDownList_AddGroupName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_AddGroupName_SelectedIndexChanged" ></asp:DropDownList>
            The <asp:DropDownList ID="DropDownList_AddCards" runat="server"></asp:DropDownList> card 
            <asp:Button ID="Button_FullAttendance" runat="server"  Text="Full Attendance" OnClick="Button_FullAttendance_Click" />
            <asp:Button ID="Button_LostCard" runat="server"  Text="Lost Card" OnClick="Button_LostCard_Click" />
            <br />
            <asp:CheckBoxList ID="CheckBoxList_Add" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            </asp:CheckBoxList>
            <asp:Button ID="Button_Add" runat="server" Text="Add" OnClick="Button_Add_Click" ></asp:Button>
        </div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>       
    </form>
</body>
</html>
