using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BreakfastCards1
{
    public partial class WebForm__AARegistration : System.Web.UI.Page
    {
        string ThisYear = DateTime.Now.ToString("yyyy");
        string ThisMonth = DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
        string LastMonth = DateTime.Now.AddMonths(-1).ToString("MMMM", CultureInfo.GetCultureInfo("en-US"));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindYear();
                BindMonth();
                BindGroupName();
                BindGridView();
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
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            db.Table_FourName.Add(a);
            db.SaveChanges();
            Response.Redirect(Request.Url.ToString());

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
        protected void BindYear()
        {
            DropDownList_Add_Year.Items.Clear();

            //年份Year
            int ThisYearInt = Convert.ToInt16(ThisYear);
            
            for (int i = ThisYearInt; i >= 1997; i--)
            {
                DropDownList_Add_Year.Items.Add(i.ToString());
                if (i == ThisYearInt && ThisMonth == "December")
                    DropDownList_Add_Year.Items.Add((i + 1).ToString());
            }
        }
        protected void BindMonth()
        {
            DropDownList_Add_Month.Items.Clear();

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

            string ThisMonth = DateTime.Now.ToString("MM");
            for (int i = Convert.ToInt16(ThisMonth) - 1; i <= 12; i++)
            {
                DropDownList_Add_Month.Items.Add(Month_DigitToEng[i]);
            }
            for (int i = 1; i < Convert.ToInt16(ThisMonth) - 1; i++)
            {
                DropDownList_Add_Month.Items.Add(Month_DigitToEng[i]);
            }
        }
        protected void BindGroupName()
        {
            DropDownList_Add_GroupName.Items.Clear();

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
            }
        }
        protected void BindGridView()
        {
            BreakfastCardsEntities db = new BreakfastCardsEntities();
            string date = ThisYear + "-" + ThisMonth;
            string datelastmonth = ThisYear + "-" + LastMonth;
            string datenextmonth;
            if(ThisMonth=="December")
            {
                datenextmonth = DateTime.Now.AddYears(+1).ToString("yyyy") +"-"+ "January";
            }
            else
            {
                datenextmonth = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.AddMonths(+1).ToString();
            }
            var clients = from c in db.Table_FourName
                          where c.Date == date || c.Date == datelastmonth || c.Date==datenextmonth
                          select c;
            GridView1.DataSource = clients.ToList();
            GridView1.DataBind();
        }
    }
}