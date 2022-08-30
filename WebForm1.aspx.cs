﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreakfastCards1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string ThisYear = DateTime.Now.ToString("yyyy");
        string ThisMonth = DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataBind();
            }

            DropDownList_Inquiry_Year.Items.Add("Never Choose");
            DropDownList_Inquiry_Month.Items.Add("Never Choose");
            DropDownList_Inquiry_GroupName.Items.Add("Never Choose");

            //年份Year
            int ThisYearInt = Convert.ToInt16(ThisYear);
            if (ThisMonth == "December")
                ThisYearInt++;
            for (int i = ThisYearInt; i >= 1997; i--)
            {
                DropDownList_Add_Year.Items.Add(i.ToString());
                DropDownList_Delete_Year.Items.Add(i.ToString());
                DropDownList_Revise_Year.Items.Add(i.ToString());
                DropDownList_Inquiry_Year.Items.Add(i.ToString());
                DropDownList_Json_Year.Items.Add(i.ToString());
            }
            
            //Month月份
            Dictionary<int, string> Month_DigitToEng = new Dictionary<int, string>();
            Month_DigitToEng.Add(1, "January");
            Month_DigitToEng.Add(2, "February");
            Month_DigitToEng.Add(3, "March");
            Month_DigitToEng.Add(4, "April");
            Month_DigitToEng.Add(5, "May");
            Month_DigitToEng.Add(6, "June");
            Month_DigitToEng.Add(7, "July");
            Month_DigitToEng.Add(8, "August");
            Month_DigitToEng.Add(9, "September");
            Month_DigitToEng.Add(10, "October");
            Month_DigitToEng.Add(11, "November");
            Month_DigitToEng.Add(12, "December");
            Dictionary<int, string>.ValueCollection MonthCol = Month_DigitToEng.Values;
            foreach (string value in MonthCol)
            {
                DropDownList_Add_Month.Items.Add(value.ToString());
                DropDownList_Delete_Month.Items.Add(value.ToString());
                DropDownList_Revise_Month.Items.Add(value.ToString());
                DropDownList_Inquiry_Month.Items.Add(value.ToString());
                DropDownList_Json_Month.Items.Add(value.ToString());
            }

            //GroupName
            Dictionary<int, string> GroupName_Dic = new Dictionary<int, string>();
            GroupName_Dic.Add(1, "Intune");
            GroupName_Dic.Add(2, "Office");
            GroupName_Dic.Add(3, "SCCM");
            GroupName_Dic.Add(4, "Teams");
            GroupName_Dic.Add(5, "POD1");
            GroupName_Dic.Add(6, "POD2");
            GroupName_Dic.Add(7, "S500_1");
            GroupName_Dic.Add(8, "S500_2");
            GroupName_Dic.Add(9, "SharePoint");
            Dictionary<int, string>.ValueCollection GroupNameCol = GroupName_Dic.Values;
            foreach (string value in GroupNameCol)
            {
                DropDownList_Add_GroupName.Items.Add(value.ToString());
                DropDownList_Delete_GroupName.Items.Add(value.ToString());
                DropDownList_Revise_GroupName.Items.Add(value.ToString());
                DropDownList_Inquiry_GroupName.Items.Add(value.ToString());
            }
            //string url = @"http://timor.tech/api/holiday/info/2022-09-01";
            //WebRequest request = WebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            //Stream webstream = response.GetResponseStream();
            //StreamReader streamReader = new StreamReader(webstream);
            //string json = streamReader.ReadToEnd();
            //Label_Json.Text = json;

        }
        protected void Button_Add_Comfirm_Click(object sender, EventArgs e)
        {
            Table_FourName a = new Table_FourName();            
            a.Date= DropDownList_Add_Year.Text +"-" +DropDownList_Add_Month.Text;
            a.GroupName = DropDownList_Add_GroupName.Text;
            a.Quantity = Convert.ToInt16(TextBox_Add_Quantity.Text);

            Dictionary<string, string> Month_DigitToEng = new Dictionary<string, string>();
            Month_DigitToEng.Add("January", "01");
            Month_DigitToEng.Add("February", "02");
            Month_DigitToEng.Add( "March", "03");
            Month_DigitToEng.Add( "April", "04");
            Month_DigitToEng.Add( "May", "05");
            Month_DigitToEng.Add( "June", "06");
            Month_DigitToEng.Add( "July", "07");
            Month_DigitToEng.Add( "August", "08");
            Month_DigitToEng.Add( "September", "09");
            Month_DigitToEng.Add( "October", "10");
            Month_DigitToEng.Add( "November", "11");
            Month_DigitToEng.Add("December", "12");

            Dictionary<string, string> GroupName_Num = new Dictionary<string, string>();
            GroupName_Num.Add("Intune", "01");
            GroupName_Num.Add("Office", "02");
            GroupName_Num.Add("SCCM", "03");
            GroupName_Num.Add("Teams", "04");
            GroupName_Num.Add("POD1","05");
            GroupName_Num.Add("POD2", "06");
            GroupName_Num.Add("S500_1", "07");
            GroupName_Num.Add("S500_2", "08");
            GroupName_Num.Add("SharePoint", "09");
            a.ID = DropDownList_Add_Year.Text + Month_DigitToEng[DropDownList_Add_Month.Text] + GroupName_Num[DropDownList_Add_GroupName.Text];

            Dictionary<string,string> GroupName_Manager = new Dictionary<string,string>();
            GroupName_Manager.Add("Intune", "John Huang");
            GroupName_Manager.Add("Office", "Amanda Luo");
            GroupName_Manager.Add("SCCM", "Eric Zhang");
            GroupName_Manager.Add("Teams", "Peter Gao");
            GroupName_Manager.Add("POD1", "Haiwei Xu");
            GroupName_Manager.Add("POD2", "Liu Bai");
            GroupName_Manager.Add("S500_1", "Dongli Li");
            GroupName_Manager.Add("S500_2", "Dorothy Deng");
            GroupName_Manager.Add("SharePoint", "Cindy Ge");
            a.Manager = GroupName_Manager[DropDownList_Add_GroupName.Text];

            BreakfastCardsEntities db = new BreakfastCardsEntities();
            db.Table_FourName.Add(a);
            db.SaveChanges();
            Response.Redirect(Request.Url.ToString());
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            Table_FourName a = new Table_FourName();
            Dictionary<string, string> Month_DigitToEng = new Dictionary<string, string>();
            Month_DigitToEng.Add("January", "01");
            Month_DigitToEng.Add("February", "02");
            Month_DigitToEng.Add("March", "03");
            Month_DigitToEng.Add("April", "04");
            Month_DigitToEng.Add("May", "05");
            Month_DigitToEng.Add("June", "06");
            Month_DigitToEng.Add("July", "07");
            Month_DigitToEng.Add("August", "08");
            Month_DigitToEng.Add("September", "09");
            Month_DigitToEng.Add("October", "10");
            Month_DigitToEng.Add("November", "11");
            Month_DigitToEng.Add("December", "12");

            Dictionary<string, string> GroupName_Num = new Dictionary<string, string>();
            GroupName_Num.Add("Intune", "01");
            GroupName_Num.Add("Office", "02");
            GroupName_Num.Add("SCCM", "03");
            GroupName_Num.Add("Teams", "04");
            GroupName_Num.Add("POD1", "05");
            GroupName_Num.Add("POD2", "06");
            GroupName_Num.Add("S500_1", "07");
            GroupName_Num.Add("S500_2", "08");
            GroupName_Num.Add("SharePoint", "09");
            a.ID= DropDownList_Delete_Year.Text + Month_DigitToEng[DropDownList_Delete_Month.Text] + GroupName_Num[DropDownList_Delete_GroupName.Text];
            
            if (a != null)
            {
                db.Table_FourName.Attach(a);
                db.Table_FourName.Remove(a);
                db.SaveChanges();
                Response.Redirect(Request.Url.ToString());
            }
            else
                Response.Write("Sorry！");//不行
            
            
            
            
        }

        protected void Button_Revise_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db=new BreakfastCardsEntities();

            Dictionary<string, string> Month_EngToDigit = new Dictionary<string, string>();
            Month_EngToDigit.Add("January", "01");
            Month_EngToDigit.Add("February", "02");
            Month_EngToDigit.Add("March", "03");
            Month_EngToDigit.Add("April", "04");
            Month_EngToDigit.Add("May", "05");
            Month_EngToDigit.Add("June", "06");
            Month_EngToDigit.Add("July", "07");
            Month_EngToDigit.Add("August", "08");
            Month_EngToDigit.Add("September", "09");
            Month_EngToDigit.Add("October", "10");
            Month_EngToDigit.Add("November", "11");
            Month_EngToDigit.Add("December", "12");

            Dictionary<string, string> GroupName_Num = new Dictionary<string, string>();
            GroupName_Num.Add("Intune", "01");
            GroupName_Num.Add("Office", "02");
            GroupName_Num.Add("SCCM", "03");
            GroupName_Num.Add("Teams", "04");
            GroupName_Num.Add("POD1", "05");
            GroupName_Num.Add("POD2", "06");
            GroupName_Num.Add("S500_1", "07");
            GroupName_Num.Add("S500_2", "08");
            GroupName_Num.Add("SharePoint", "09");

            Table_FourName a = new Table_FourName() { ID = DropDownList_Revise_Year.Text + Month_EngToDigit[DropDownList_Revise_Month.Text] + GroupName_Num[DropDownList_Revise_GroupName.Text] };
            
            if(a!=null)
            {
                db.Table_FourName.Attach(a);
                a.Quantity = Convert.ToInt16(TextBox_Revise_Quantity.Text);
                db.SaveChanges();
                Response.Redirect(Request.Url.ToString());
            }
            else
                this.Response.Write("Sorry！");//不行
        }

        protected void Button_Inquiry_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            if(DropDownList_Revise_Year.Text != "Never Choose"&& DropDownList_Revise_Month.Text != "Never Choose"&& DropDownList_Inquiry_GroupName.Text != "Never Choose")
            {
                string Date = DropDownList_Inquiry_Year.Text +"-"+ DropDownList_Inquiry_Month.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date == Date && c.GroupName == GroupName
                              select c;
                foreach(var client in clients)
                {
                    Label_Inquiry.Text= "Data:" + client.Date + "<&#9;>" + "GroupName:" + client.GroupName + "<&#9;>" + "Manager:" + client.Manager + "<br/>";
                }
            }
            else if(DropDownList_Revise_Year.Text != "Never Choose" && DropDownList_Revise_Month.Text != "Never Choose")
            {
                string Date = DropDownList_Inquiry_Year.Text + "-" + DropDownList_Inquiry_Month.Text;
                var clients = from c in db.Table_FourName
                              where c.Date == Date
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text = "Data:" + client.Date + "<&#9;>" + "GroupName:" + client.GroupName + "<&#9;>" + "Manager:" + client.Manager + "<br/>";
                }
            }
            else if(DropDownList_Revise_Year.Text != "Never Choose" && DropDownList_Inquiry_GroupName.Text != "Never Choose")
            {
                string Data = DropDownList_Inquiry_Year.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date.StartsWith(Data) && c.GroupName == GroupName
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text = "Data:" + client.Date + "<&#9;>" + "GroupName:" + client.GroupName + "<&#9;>" + "Manager:" + client.Manager + "<br/>";
                }
            }
            else if(DropDownList_Revise_Month.Text != "Never Choose" && DropDownList_Inquiry_GroupName.Text != "Never Choose")
            {
                string Data = DropDownList_Inquiry_Month.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date.StartsWith(Data) && c.GroupName == GroupName
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text = "Data:" + client.Date + "<&#9;>" + "GroupName:" + client.GroupName + "<&#9;>" + "Manager:" + client.Manager + "<br/>";
                }
            }
            else if (DropDownList_Revise_Year.Text == "Never Choose" && DropDownList_Revise_Month.Text == "Never Choose" && DropDownList_Inquiry_GroupName.Text == "Never Choose")
            {
                Label_Inquiry.Text = "Sorry!";//不行
            }
        }

        protected void Button_Json_Click(object sender, EventArgs e)
        {
            

            int year=Convert.ToInt16(DropDownList_Json_Year.Text);

            Dictionary<string, string> Month_EngToDigit = new Dictionary<string, string>();
            Month_EngToDigit.Add("January", "01");
            Month_EngToDigit.Add("February", "02");
            Month_EngToDigit.Add("March", "03");
            Month_EngToDigit.Add("April", "04");
            Month_EngToDigit.Add("May", "05");
            Month_EngToDigit.Add("June", "06");
            Month_EngToDigit.Add("July", "07");
            Month_EngToDigit.Add("August", "08");
            Month_EngToDigit.Add("September", "09");
            Month_EngToDigit.Add("October", "10");
            Month_EngToDigit.Add("November", "11");
            Month_EngToDigit.Add("December", "12");

            int month = Convert.ToInt16(Month_EngToDigit[DropDownList_Json_Month.Text]);

            int days = DateTime.DaysInMonth(year, month);
            Label_Json.Text="The Days of Month:" +days + "<br/>";
            DateTime dt = Convert.ToDateTime(DropDownList_Json_Year.Text + "-" + DropDownList_Json_Month.Text+"-"+01.ToString());
            int workDays = 0;
            for(int i=1;i<=days;i++)
            {
                if(dt.DayOfWeek!=DayOfWeek.Saturday&&dt.DayOfWeek!=DayOfWeek.Sunday)
                {
                    string url = @"http://timor.tech/api/holiday/info/";
                    url += year.ToString() + "-" + month.ToString() + "-"+i.ToString();
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    Stream webstream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(webstream);
                    string json = streamReader.ReadToEnd();
                    JavaScriptSerializer json1=new JavaScriptSerializer();
                    Dictionary<string, object> DicText = (Dictionary<string, object>)json1.DeserializeObject(json);
                    if (DicText["holiday"]==null)
                        workDays++;
                }
                dt = dt.AddDays(1);
            }
            Label_Json.Text += "The WorkDays of Month:" + workDays + "<br/>";

            //json格式例子：
            //{"code":0,
            //"type":{"type":0,"name":"周四","week":4},
            //"holiday":null}
        }
    }
}