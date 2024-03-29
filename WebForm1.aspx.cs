﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

using LitJson;
using Newtonsoft.Json.Linq;
using System.Resources;
using Newtonsoft.Json;
using BreakfastCards1.Core;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Cryptography;
using System.Data;

namespace BreakfastCards1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string ThisYear = DateTime.Now.ToString("yyyy");
        string ThisMonth = DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
        List<string> HolidaysList=new List<string>();
        List<string> WorkdaysList = new List<string>();

        bool LostCard_bool;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();                                             //年份
                BindMonth();                                           //月份
                BindGroupName();                                        //
                BindActualBreakfast_AddCards();                         //
                BindActualBreakfast_Add_CheckboxList();                 //
                GridView_FourName.DataBind();
            }
            
        }

        protected void BindYear()
        {
            DropDownList_ActualBreakfast_AddYear.Items.Clear();
            DropDownList_ActualBreakfast_InquiryYear.Items.Clear();
            DropDownList_Add_Year.Items.Clear();                        //Add增加的年份Clear
            DropDownList_Delete_Year.Items.Clear();
            DropDownList_Inquiry_Year.Items.Clear();
            DropDownList_Json_Year.Items.Clear();
            DropDownList_Revise_Year.Items.Clear();

            DropDownList_Inquiry_Year.Items.Add("Never Choose");

            //年份Year
            int ThisYearInt = Convert.ToInt16(ThisYear);

            for (int i = ThisYearInt; i >= 1997; i--)
            {
                DropDownList_Add_Year.Items.Add(i.ToString());
                DropDownList_Delete_Year.Items.Add(i.ToString());
                DropDownList_Revise_Year.Items.Add(i.ToString());
                DropDownList_Inquiry_Year.Items.Add(i.ToString());
                DropDownList_Json_Year.Items.Add(i.ToString());
                DropDownList_ActualBreakfast_AddYear.Items.Add(i.ToString());
                DropDownList_ActualBreakfast_InquiryYear.Items.Add(i.ToString());
                if (i == ThisYearInt&& ThisMonth == "December")
                {
                    DropDownList_Add_Year.Items.Add((i+1).ToString());
                    DropDownList_Delete_Year.Items.Add((i + 1).ToString());
                    DropDownList_Revise_Year.Items.Add((i + 1).ToString());
                    DropDownList_Inquiry_Year.Items.Add((i + 1).ToString());
                    DropDownList_Json_Year.Items.Add((i + 1).ToString());
                    DropDownList_ActualBreakfast_AddYear.Items.Add((i + 1).ToString());
                    DropDownList_ActualBreakfast_InquiryYear.Items.Add((i + 1).ToString());
                }
            }
            
        }

        protected void BindMonth()
        {
            
            DropDownList_ActualBreakfast_AddMonth.Items.Clear();
            DropDownList_ActualBreakfast_InquiryMonth.Items.Clear();
            DropDownList_Add_Month.Items.Clear();
            DropDownList_Delete_Month.Items.Clear();
            DropDownList_Inquiry_Month.Items.Clear();
            DropDownList_Json_Month.Items.Clear();
            DropDownList_Revise_Month.Items.Clear();

            DropDownList_Inquiry_Month.Items.Add("NeverChoose");

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

            
            //String ThisMonth1 = DateTime.Now.ToString("MMMM");
            if(ThisMonth=="January"|| ThisMonth == "February")
            {
                for (int i = 1; i <= 12; i++)
                {
                    DropDownList_ActualBreakfast_AddMonth.Items.Add(Month_DigitToEng[i]);
                    DropDownList_ActualBreakfast_InquiryMonth.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Add_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Delete_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Inquiry_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Json_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Revise_Month.Items.Add(Month_DigitToEng[i]);
                }
            }
            else
            {
                string ThisMonth = DateTime.Now.ToString("MM");
                for (int i = Convert.ToInt16(ThisMonth) - 1; i <= 12; i++)
                {
                    DropDownList_ActualBreakfast_AddMonth.Items.Add(Month_DigitToEng[i]);       //System.Collections.Generic.KeyNotFoundException:“The given key was not present in the dictionary.”
                    DropDownList_ActualBreakfast_InquiryMonth.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Add_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Delete_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Inquiry_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Json_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Revise_Month.Items.Add(Month_DigitToEng[i]);
                }
                for (int i = 1; i < Convert.ToInt16(ThisMonth) - 1; i++)
                {
                    DropDownList_ActualBreakfast_AddMonth.Items.Add(Month_DigitToEng[i]);
                    DropDownList_ActualBreakfast_InquiryMonth.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Add_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Delete_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Inquiry_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Json_Month.Items.Add(Month_DigitToEng[i]);
                    DropDownList_Revise_Month.Items.Add(Month_DigitToEng[i]);
                }
            }
            
            
            /*
            Dictionary<int, string>.ValueCollection MonthCol = Month_DigitToEng.Values;
            foreach (string value in MonthCol)
            {
                DropDownList_Add_Month.Items.Add(value.ToString());
                DropDownList_Delete_Month.Items.Add(value.ToString());
                DropDownList_Revise_Month.Items.Add(value.ToString());
                DropDownList_Inquiry_Month.Items.Add(value.ToString());
                DropDownList_Json_Month.Items.Add(value.ToString());
                DropDownList_ActualBreakfast_AddMonth.Items.Add(value.ToString());
                DropDownList_ActualBreakfast_InquiryMonth.Items.Add(value.ToString());
            }
            */
        }

        protected void BindGroupName()
        {
            DropDownList_ActualBreakfast_AddGroupName.Items.Clear();
            DropDownList_ActualBreakfast_InquiryGroupName.Items.Clear();
            DropDownList_Add_GroupName.Items.Clear();
            DropDownList_Delete_GroupName.Items.Clear();
            DropDownList_Inquiry_GroupName.Items.Clear();
            DropDownList_Revise_GroupName.Items.Clear();

            DropDownList_Inquiry_GroupName.Items.Add("Never Choose");

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
                DropDownList_ActualBreakfast_AddGroupName.Items.Add(value.ToString());
                DropDownList_ActualBreakfast_InquiryGroupName.Items.Add(value.ToString());
            }
        }
        
        protected void BindActualBreakfast_AddCards()
        {
            DropDownList_ActualBreakfast_AddCards.Items.Clear();

            string ID = DropDownList_ActualBreakfast_AddYear.SelectedValue + Month_EngToDigit(DropDownList_ActualBreakfast_AddMonth.SelectedValue) + GroupName_Num(DropDownList_ActualBreakfast_AddGroupName.SelectedValue);

            // HardCode for testing... 
            //ID = "20220801";

            BreakfastCardsEntities db = new BreakfastCardsEntities();
            var client = db.Table_FourName.FirstOrDefault(c => c.ID == ID); //System.Data.Entity.Core.EntityException:“The underlying provider failed on Open.”

            Dictionary<int, string> ActualBreakfast_Add_DigitToEng = new Dictionary<int, string>();
            ActualBreakfast_Add_DigitToEng.Add(1, "First");
            ActualBreakfast_Add_DigitToEng.Add(2, "Second");
            ActualBreakfast_Add_DigitToEng.Add(3, "Third");
            ActualBreakfast_Add_DigitToEng.Add(4, "Fourth");
            ActualBreakfast_Add_DigitToEng.Add(5, "Fifth");
            ActualBreakfast_Add_DigitToEng.Add(6, "Sixth");
            ActualBreakfast_Add_DigitToEng.Add(7, "Seventh");
            ActualBreakfast_Add_DigitToEng.Add(8, "Eighth");
            ActualBreakfast_Add_DigitToEng.Add(9, "Ninth");
            ActualBreakfast_Add_DigitToEng.Add(10, "Tenth");
            ActualBreakfast_Add_DigitToEng.Add(11, "Eleventh");
            ActualBreakfast_Add_DigitToEng.Add(12, "Twelfth");
            ActualBreakfast_Add_DigitToEng.Add(13, "Thirteenth");
            ActualBreakfast_Add_DigitToEng.Add(14, "Fourteenth");
            ActualBreakfast_Add_DigitToEng.Add(15, "Fifteenth");

            try
            {
                int a = Convert.ToInt16(client.Quantity.Value);     //System.NullReferenceException:“Object reference not set to an instance of an object.”client 是 null。
                for (int i = 1; i <= a; i++)
                {
                    DropDownList_ActualBreakfast_AddCards.Items.Add(ActualBreakfast_Add_DigitToEng[i]);
                }
            }
            catch (System.NullReferenceException)
            {
                Label_Inquiry.Text = "Sorry_ActualBreakfast_AddCards!";
            }

        }

        protected void BindActualBreakfast_Add_CheckboxList()
        {            
            CheckBoxList_ActualBreakfast_Add.Items.Clear();            

            int workdays_Breakfast_Add = workdays(DropDownList_ActualBreakfast_AddYear.Text.ToString(), DropDownList_ActualBreakfast_AddMonth.Text.ToString());

            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 5;

            foreach(string workday in WorkdaysList)
            {
                CheckBoxList_ActualBreakfast_Add.Items.Add(workday);
            }            
        }

        protected void Button_Add_Comfirm_Click(object sender, EventArgs e)
        {
            Table_FourName a = new Table_FourName();
            a.Date = DropDownList_Add_Year.Text + "-" + DropDownList_Add_Month.Text;
            a.GroupName = DropDownList_Add_GroupName.Text;
            a.Quantity = Convert.ToInt16(TextBox_Add_Quantity.Text);

            //在Table_FourName里，ID的规则，顺序分别：4位是年份，2位是月份，2位是团队代号。
            a.ID = DropDownList_Add_Year.Text + Month_EngToDigit(DropDownList_Add_Month.Text) + GroupName_Num(DropDownList_Add_GroupName.Text);

            Dictionary<string, string> GroupName_Manager = new Dictionary<string, string>();
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

            try
            {
                BreakfastCardsEntities db = new BreakfastCardsEntities();
                db.Table_FourName.Add(a);
                db.SaveChanges();
                Response.Redirect(Request.Url.ToString());
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                Label_Json.Text = "Sorry";
            }
        }

        protected void Button_Delete_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            Table_FourName a = new Table_FourName();

            a.ID = DropDownList_Delete_Year.Text + Month_EngToDigit(DropDownList_Delete_Month.Text) + GroupName_Num(DropDownList_Delete_GroupName.Text);

            try
            {
                db.Table_FourName.Attach(a);
                db.Table_FourName.Remove(a);
                db.SaveChanges();
                Response.Redirect(Request.Url.ToString());

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                Label_Json.Text = "Sorry_catch";
            }
        }

        protected string GroupName_Num(string groupname)
        {
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
            return GroupName_Num[groupname];
        }

        protected string Month_EngToDigit(string month)
        {
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
            return Month_EngToDigit[month];         //System.Collections.Generic.KeyNotFoundException:“给定关键字不在字典中。”
        }

        protected string EngOrderToDigit(string a)
        {
            Dictionary<string, string> EngOrderToDigit = new Dictionary<string, string>();
            EngOrderToDigit.Add("First", "01");
            EngOrderToDigit.Add("Second", "02");
            EngOrderToDigit.Add("Third", "03");
            EngOrderToDigit.Add("Fourth", "04");
            EngOrderToDigit.Add("Fifth", "05");
            EngOrderToDigit.Add("Sixth", "06");
            EngOrderToDigit.Add("Seventh", "07");
            EngOrderToDigit.Add("Eighth", "08");
            EngOrderToDigit.Add("Ninth", "09");
            EngOrderToDigit.Add("Tenth", "10");
            EngOrderToDigit.Add("Eleventh", "11");
            EngOrderToDigit.Add("Twelfth", "12");
            EngOrderToDigit.Add("Thirteenth", "13");
            EngOrderToDigit.Add("Fourteenth", "14");
            EngOrderToDigit.Add("Fifteenth", "15");

            return EngOrderToDigit[a];
        }

        protected void Button_Revise_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();

            Table_FourName a = new Table_FourName() { ID = DropDownList_Revise_Year.Text + Month_EngToDigit(DropDownList_Revise_Month.Text) + GroupName_Num(DropDownList_Revise_GroupName.Text) };

            try
            {
                db.Table_FourName.Attach(a);
                a.Quantity = Convert.ToInt16(TextBox_Revise_Quantity.Text);
                db.SaveChanges();
                Response.Redirect(Request.Url.ToString());
            }
            catch
            {
                Label_Inquiry.Text = "Sorry_Revise!";
            }
        }

        protected void Button_Inquiry_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            Label_Inquiry.Text = "";
            if (DropDownList_Inquiry_Year.Text != "Never Choose" && DropDownList_Inquiry_Month.Text != "Never Choose" && DropDownList_Inquiry_GroupName.Text != "Never Choose")//OK
            {
                string Date = DropDownList_Inquiry_Year.Text + "-" + DropDownList_Inquiry_Month.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date == Date && c.GroupName == GroupName
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text += "Data:" + client.Date + "----" + "GroupName:" + client.GroupName + "----" + "Manager:" + client.Manager + "<br/>";
                }
                GridView_Inquiry.DataSource = clients.ToList();
                GridView_Inquiry.DataBind();
            }
            else if (DropDownList_Inquiry_Year.Text != "Never Choose" && DropDownList_Inquiry_Month.Text != "Never Choose")//OK
            {
                string Date = DropDownList_Inquiry_Year.Text + "-" + DropDownList_Inquiry_Month.Text;
                var clients = from c in db.Table_FourName
                              where c.Date == Date
                              select c; 
                foreach (var client in clients)
                {
                    Label_Inquiry.Text += "Data:" + client.Date + "----" + "GroupName:" + client.GroupName + "----" + "Manager:" + client.Manager + "<br/>";
                }
                GridView_Inquiry.DataSource = clients.ToList();
                GridView_Inquiry.DataBind();
            }
            else if (DropDownList_Inquiry_Year.Text != "Never Choose" && DropDownList_Inquiry_GroupName.Text != "Never Choose")  //OK
            {
                string Year = DropDownList_Inquiry_Year.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date.StartsWith(Year) && c.GroupName == GroupName
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text += "Data:" + client.Date + "----" + "GroupName:" + client.GroupName + "----" + "Manager:" + client.Manager + "<br/>";
                }
                GridView_Inquiry.DataSource = clients.ToList();
                GridView_Inquiry.DataBind();
            }
            else if (DropDownList_Inquiry_Month.Text != "Never Choose" && DropDownList_Inquiry_GroupName.Text != "Never Choose")
            {
                string Month = DropDownList_Inquiry_Month.Text;
                string GroupName = DropDownList_Inquiry_GroupName.Text;
                var clients = from c in db.Table_FourName
                              where c.Date.EndsWith(Month) && c.GroupName == GroupName
                              select c;
                foreach (var client in clients)
                {
                    Label_Inquiry.Text += "Data:" + client.Date + "----" + "GroupName:" + client.GroupName + "----" + "Manager:" + client.Manager + "<br/>";
                }
                GridView_Inquiry.DataSource = clients.ToList();
                GridView_Inquiry.DataBind();
            }
            else
            {
                Label_Inquiry.Text = "Sorry!";//不行
            }
        }

        protected int workdays(string year, string month)
        {
            int workdays = 0;
            int days=DateTime.DaysInMonth(Convert.ToInt16(year), Convert.ToInt16(Month_EngToDigit(month)));
            DateTime dt = Convert.ToDateTime(year + "-" + month + "-" + 01.ToString());
            string jsonPath = @"C:\Users\a-xiaobodou\OneDrive - Microsoft\Projects\ASP.NET\BreakfastCards1\" + year + ".json";
            HolidaysList.Clear();
            WorkdaysList.Clear();
            try
            {
                System.IO.StreamReader sr = File.OpenText(jsonPath);    //System.IO.FileNotFoundException:“未能找到文件“C:\Program Files\IIS Express\2022json”。”
                string json = sr.ReadToEnd();
                var root = JsonConvert.DeserializeObject<Holidays>(json);
                var keys = root.Holiday.Keys;
                String Month_Digit = Month_EngToDigit(month).ToString().PadLeft(2, '0');
                foreach (var key in keys)
                {
                    if(key.StartsWith(Month_Digit))
                        HolidaysList.Add(key);
                }                
                bool workdaybool;
                for (int i = 1; i <= days; i++)
                {
                    string date_check =Month_Digit + "-" + i.ToString().PadLeft(2, '0');
                    if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                    {
                        workdaybool = true;
                        foreach (string date in HolidaysList)
                        {
                            if (date_check == date)
                            {
                                workdaybool = false;
                                break;
                            }                                
                        }
                    }
                    else
                    {
                        workdaybool=false;;
                        foreach(string date in HolidaysList)
                        {
                            if(date_check==date)
                            {
                                workdaybool = true;
                                break;
                            }
                        }
                    }
                    if(workdaybool==true)
                    {
                        workdays++;
                        WorkdaysList.Add(date_check);
                    }
                    dt = dt.AddDays(1);
                }
                return workdays;
            }
            catch(System.IO.FileNotFoundException)
            {
                Label_Json.Text += "System.IO.FileNotFoundException!"+"<br/>";
                return 0;
            }
        }

        protected void Button_Json_Click(object sender, EventArgs e)
        {
            Label_Json.Text = "";
            int days = DateTime.DaysInMonth(Convert.ToInt16(DropDownList_Json_Year.Text), Convert.ToInt16(Month_EngToDigit(DropDownList_Json_Month.Text)));
            int Workdays = workdays(DropDownList_Json_Year.Text, DropDownList_Json_Month.Text);
            Label_Json.Text += "The Days of Month:" + days + "<br/>";
            Label_Json.Text += "The WorkDays of Month:" + Workdays.ToString() + "<br/>";
            Response.Write("Okay!Response.");        //顶部可看到的
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", "alert('Okay!ScriptManager.')", true);
            Button_Json.Visible = false;
        }

        protected void DropDownList_ActualBreakfast_AddYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindYear();
            BindMonth();
            BindActualBreakfast_AddCards();
            BindActualBreakfast_Add_CheckboxList();
        }

        protected void DropDownList_ActualBreakfast_AddMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindMonth();
            BindActualBreakfast_AddCards();
            BindActualBreakfast_Add_CheckboxList();
        }

        protected void DropDownList_ActualBreakfast_AddGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindActualBreakfast_AddCards();
            BindActualBreakfast_Add_CheckboxList();
        }


        protected void Button_Actual_Breakfast_CheckBoxList_Add(object sender, EventArgs e) 
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();

            String year = DropDownList_ActualBreakfast_AddYear.SelectedValue;
            String month = Month_EngToDigit(DropDownList_ActualBreakfast_AddMonth.SelectedValue);
            String groupname=GroupName_Num(DropDownList_ActualBreakfast_AddGroupName.SelectedValue);
            String cards = EngOrderToDigit(DropDownList_ActualBreakfast_AddCards.SelectedItem.Value.ToString());            //这个问题

            int actualquantity = 0;

            Table_ActualQuantity a = new Table_ActualQuantity();

            //在Table_ActualQuantity里，ID的规则，顺序分别：4位年份，2位月份，2位团队代码，2位卡号顺序，1位是否丢失卡的符号。
            a.ID = year + month + groupname + cards + "F";
            a.Year = year;
            a.Month = DropDownList_ActualBreakfast_AddMonth.SelectedValue;
            a.GroupName = DropDownList_ActualBreakfast_AddGroupName.SelectedValue;
            a.Cards = DropDownList_ActualBreakfast_AddCards.SelectedValue;
            a.Workdays = workdays(DropDownList_ActualBreakfast_AddYear.SelectedValue, DropDownList_ActualBreakfast_AddMonth.SelectedValue);
            a.LostCard_Boolean = "False";

            foreach (ListItem item in CheckBoxList_ActualBreakfast_Add.Items)       //代码有问题。
            {
                Table_BreakfastBoolean b = new Table_BreakfastBoolean();
                
                b.Year = year;
                b.Month = DropDownList_ActualBreakfast_AddMonth.SelectedValue;
                b.GroupName=DropDownList_ActualBreakfast_AddGroupName.SelectedValue;
                b.Cards = DropDownList_ActualBreakfast_AddCards.SelectedValue;
                b.Data = item.Text;
                if(item.Selected)
                {
                    actualquantity++;
                    b.Breakfast_Boolean = "True";
                    //在Table_BreakfastBoolean里，ID的规则，顺序分别：4位是年份，2位是月份，2位是团队代号，2位是卡号顺序，2位是日期
                    b.ID = year + month + groupname + cards + item.Text.Substring(3)+"T";
                }
                else
                {
                    b.Breakfast_Boolean = "False";
                    b.ID = year + month + groupname + cards + item.Text.Substring(3) + "F";
                }
                db.Table_BreakfastBoolean.Add(b);
                db.SaveChanges();                
            }
            a.ActualQuantity = actualquantity;
            db.Table_ActualQuantity.Add(a);
            db.SaveChanges();
            Response.Redirect(Request.Url.ToString());
        }

        protected void FullAttendanceAndLostCard()       
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();

            String year = DropDownList_ActualBreakfast_AddYear.SelectedValue;
            String month = Month_EngToDigit(DropDownList_ActualBreakfast_AddMonth.SelectedValue); 
            String groupname = GroupName_Num(DropDownList_ActualBreakfast_AddGroupName.SelectedValue);
            String cards = EngOrderToDigit(DropDownList_ActualBreakfast_AddCards.SelectedValue);           

            Table_ActualQuantity a = new Table_ActualQuantity();

            //在Table_ActualQuantity里，ID的规则，顺序分别：4位年份，2位月份，2位团队代码，2位卡号顺序,1位是否丢失卡的符号。
            
            a.Year = year;
            a.Month = DropDownList_ActualBreakfast_AddMonth.SelectedValue;
            a.GroupName = DropDownList_ActualBreakfast_AddGroupName.SelectedValue;
            a.Cards = DropDownList_ActualBreakfast_AddCards.SelectedValue;

            if (LostCard_bool == true)
            {
                a.LostCard_Boolean = "True";
                a.ID = year + month + groupname + cards + "T";
            }
            else
            {
                a.LostCard_Boolean = "False";
                a.ID = year + month + groupname + cards+"F";
            }
            int workday = workdays(DropDownList_ActualBreakfast_AddYear.SelectedValue, DropDownList_ActualBreakfast_AddMonth.SelectedValue);
            a.ActualQuantity = workday;
            a.Workdays = workday;

            foreach (ListItem item in CheckBoxList_ActualBreakfast_Add.Items)       //代码有问题。
            {
                Table_BreakfastBoolean b = new Table_BreakfastBoolean();                

                b.Year = year;
                b.Month = DropDownList_ActualBreakfast_AddMonth.SelectedValue;
                b.GroupName = DropDownList_ActualBreakfast_AddGroupName.SelectedValue;
                b.Cards = DropDownList_ActualBreakfast_AddCards.SelectedValue;
                b.Data = item.Text;
                if (LostCard_bool == true)
                {
                    b.Breakfast_Boolean = "Lost";
                    //在Table_BreakfastBoolean里，ID的规则，顺序分别：4位是年份，2位是月份，2位是团队代号，2位是卡号顺序，2位是日期
                    b.ID = year + month + groupname + cards + item.Text.Substring(3) + "L";
                }
                else
                {
                    b.Breakfast_Boolean = "True";
                    b.ID = year + month + groupname + cards + item.Text.Substring(3) + "T";
                }
                db.Table_BreakfastBoolean.Add(b);
                int t = db.SaveChanges();
                //System.Data.Entity.Infrastructure.DbUpdateException:“An error occurred while updating the entries. See the inner exception for details.”
                //UpdateException: An error occurred while updating the entries. See the inner exception for details.
                //SqlException: Violation of PRIMARY KEY constraint 'PK_Table_Breakfast'. Cannot insert duplicate key in object 'dbo.Table_BreakfastBoolean'. The duplicate key value is (202208030101). The statement has been terminated.
            }
            db.Table_ActualQuantity.Add(a);
            db.SaveChanges();
            Response.Redirect(Request.Url.ToString());
        }        

        protected void Button_FullAttendance_Click(object sender, EventArgs e)
        {
            LostCard_bool = false;
            FullAttendanceAndLostCard() ;
        }

        protected void Button_LostCard_Click(object sender, EventArgs e)
        {
            LostCard_bool = true;
            FullAttendanceAndLostCard();
        }

        protected void Button_Actual_Breakfast_Inquiry_Click(object sender, EventArgs e)
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            string year =DropDownList_ActualBreakfast_InquiryYear.SelectedItem.Value.ToString();
            string month = DropDownList_ActualBreakfast_InquiryMonth.SelectedItem.Value.ToString();
            string groupname = DropDownList_ActualBreakfast_InquiryGroupName.SelectedItem.Value.ToString();
            var clients_ActualQuantity = from c in db.Table_ActualQuantity
                                         where c.Year == year && c.Month == month && c.GroupName == groupname
                                         select c;
            GridView_Inquiry_ActualQuantity.DataSource = clients_ActualQuantity.ToList();
            GridView_Inquiry_ActualQuantity.DataBind();
            var clients_BreakfastBoolean = from c in db.Table_BreakfastBoolean
                                           where c.Year == year && c.Month == month && c.GroupName == groupname
                                           select c;
            GridView_Inquiry_BreakfastBoolean.DataSource = clients_BreakfastBoolean.ToList();
            GridView_Inquiry_BreakfastBoolean.DataBind();
        }


    }
}