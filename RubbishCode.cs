using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BreakfastCards1
{
    public class RubbishCode
    {
        /*
                    string json = urltojson(url);
                    var jsonDes = JsonConvert.DeserializeObject<WorkDay>(json);
                    if (Convert.ToInt16(jsonDes.Type.Type) == 0)
                        workdays++;
                    */
        /*                    
        WebClient client = new WebClient();
        client.Encoding = Encoding.UTF8;
        var jsondata=client.DownloadString(url);
        var model = JsonConvert.DeserializeObject<Types>(jsondata);//Newtonsoft.Json.JsonReaderException:“Unexpected character encountered while parsing value: {. Path 'type', line 1, position 18.”
        if (model.type == "0")
            workdays++;
        */
        /*
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream webstream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(webstream);
        string json = streamReader.ReadToEnd();
        JObject jobj = JObject.Parse(json);
        JArray types = JArray.Parse(jobj["type"].ToString());
        if (types["type"].ToString() == "1")
            workdays++;
        */

        /*
        string url = "https://www.mxnzp.com/api/holiday/single/";
        url += year.ToString() + "-" + month.ToString() + "-" + i.ToString().PadLeft(2,'0');
        url += "ignoreHoliday=false&app_id=igsgjipmqtktwrmp&app_secret=a2plWmRqNSs2MUNseVlSYnJtTEdzZz09";
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream webstream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(webstream);
        string json = streamReader.ReadToEnd();
        Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        string typeDsc = jobject["date"]["typeDes"].ToString();     //System.NullReferenceException:“未将对象引用设置到对象的实例。”
        if (typeDsc == "工作日")
            workdays++;
        */
        /*
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream webstream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(webstream);
        string json = streamReader.ReadToEnd();
        Newtonsoft.Json.Linq.JObject jobject = (Newtonsoft.Json.Linq.JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        */
        /*
        string holiday = jobject["holiday"].ToString();
        if(holiday==null
        /*
            workdays++;
        */
        /*
        decimal type_type = Convert.ToDecimal(jobject["type"]["type"]);
        if (type_type == 0)
            workdays++;
        */
        /*
        string type_type = jobject["type"]["type"].ToString();
        if (type_type == "0")
            workdays++;
        */

        /*
        JavaScriptSerializer workdays_json = new JavaScriptSerializer();
        JsonContent content = workdays_json.Deserialize<JsonContent>(url);
        if (content.holiday.holiday != true)
            workdays++;
        */

        /*
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();       //System.Net.WebException:“无法连接到远程服务器”
        Stream webstream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(webstream);
        string json = streamReader.ReadToEnd();
        JavaScriptSerializer workdays_Json = new JavaScriptSerializer();
        JsonContent Workdays_Content = workdays_Json.Deserialize<JsonContent>(json);
        */

        /*
        System.NullReferenceException:“未将对象引用设置到对象的实例。”

        BreakfastCards1.WebForm1.JsonContent.holiday.get 返回 null。
        */

        //if (Convert.ToInt16(Workdays_Content.type.type) == 0)
        //    workdays++;

        //if (Workdays_Content.type.type=='0')
        //    workdays++;


        /*
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream webstream = response.GetResponseStream();
        StreamReader streamReader = new StreamReader(webstream);
        string json = streamReader.ReadToEnd();
        JavaScriptSerializer json1 = new JavaScriptSerializer();
        Dictionary<string, object> DicText = (Dictionary<string, object>)json1.DeserializeObject(json);

        if (DicText["type"] == 'Y')        //这个代码有问题，大括号/花括号的事，不知道怎么实现holiday!=true。
            workdays++;
        */




        //Types type = json1.Deserialize<Types>(json1);
        //if (type["type"] == 1)
        //    workdays++;
        //Dictionary<string, odbject> DicText = (Dictionary<string, object>)json1.DeserializeObject(json);
        //if (DicText["holiday"] == null )        //这个代码有问题，大括号/花括号的事，不知道怎么实现holiday!=true。
        //    workdays++;


        /*
        {
        try
            {
                WebRequest request = WebRequest.Create(url); // 这里重复多次去请求页面，导致了429的问题，我们要避免这样的情况发生，不能短时间内触发多个request去页面
                WebResponse response = request.GetResponse();   //System.Net.WebException:“请求被中止: 操作超时。”//System.Net.WebException:“远程服务器返回错误: (429) Too Many Requests。”
                Stream webstream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(webstream);
                string json = streamReader.ReadToEnd();
                return json;
            }
            catch(System.Net.WebException)
            {
                WebClient wc = new WebClient();
                wc.Credentials=CredentialCache.DefaultCredentials;
                wc.Encoding=Encoding.UTF8;
                string returnText=wc.DownloadString(url);   //System.Net.WebException:“远程服务器返回错误: (429) Too Many Requests。”
                return returnText;

                
                Uri uri = new Uri(url);
                HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();//System.Net.WebException:“远程服务器返回错误: (429) Too Many Requests。”
                Stream respStream = httpResp.GetResponseStream();
                StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                string strBuff = respStreamReader.ReadToEnd();
                return strBuff;
                
}
          */


        /*
for (int i = 1; i <= days; i++) // 问题出在这里，这里重复了多次去触发下文的request
{
    //我遇到一个棘手的问题，在CheckBoxList控件里，遇到周五之后，都要换行，不知道怎么解决。间隔距离，不知道怎么解决。
    if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday) 
    {

        if ((i == 1 && dt.DayOfWeek == DayOfWeek.Friday) || (i == 4 && dt.DayOfWeek == DayOfWeek.Monday))
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 1;
        else if ((i == 1 && dt.DayOfWeek == DayOfWeek.Thursday) || (i == 2 && dt.DayOfWeek == DayOfWeek.Friday) || (i == 5 && dt.DayOfWeek == DayOfWeek.Monday))
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 2;
        else if (i == 1 && dt.DayOfWeek == DayOfWeek.Wednesday)
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 3;
        else if (i == 1 && dt.DayOfWeek == DayOfWeek.Tuesday)
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 4;
        else if ((i == 1 && dt.DayOfWeek == DayOfWeek.Monday) || (i == 4 && dt.DayOfWeek == DayOfWeek.Thursday))
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 5;
        else if(i>4)
            CheckBoxList_ActualBreakfast_Add.RepeatColumns = 5;

    }
    dt = dt.AddDays(1);
}*/
        /*
        protected void FullAttendanceAndLostCard_BreakfastBoolean()                 //增加不了数据库，怎么办？
        {
            
            
            foreach (ListItem item in CheckBoxList_ActualBreakfast_Add.Items)
            {
                Label_Json.Text += item.Text.Substring(3) + "<br/>";
            }
            
            int workday = workdays(DropDownList_ActualBreakfast_AddYear.SelectedValue, DropDownList_ActualBreakfast_AddMonth.SelectedValue);
            foreach (ListItem item in CheckBoxList_ActualBreakfast_Add.Items)       //代码有问题。
            {
                BreakfastCardsEntities db = new BreakfastCardsEntities();
                String year = DropDownList_ActualBreakfast_AddYear.SelectedValue;
                String month = Month_EngToDigit(DropDownList_ActualBreakfast_AddMonth.SelectedValue);
                String groupname = GroupName_Num(DropDownList_ActualBreakfast_AddGroupName.SelectedValue);
                String cards = EngOrderToDigit(DropDownList_ActualBreakfast_AddCards.SelectedValue);

                Table_BreakfastBoolean b = new Table_BreakfastBoolean();

                //在Table_BreakfastBoolean里，ID的规则，顺序分别：4位是年份，2位是月份，2位是团队代号，2位是卡号顺序，2位是日期

                b.Year = year;
                b.Month = DropDownList_ActualBreakfast_AddMonth.SelectedValue;
                b.GroupName = DropDownList_ActualBreakfast_AddGroupName.SelectedValue;
                b.Cards = DropDownList_ActualBreakfast_AddCards.SelectedValue;
                b.Data = item.Text.Substring(3);
                if (LostCard_bool == true)
                {
                    b.Breakfast_Boolean = "Null";
                    b.ID = year + month + groupname + cards + item.Text.Substring(3) + "Y";
                }
                else
                {
                    b.Breakfast_Boolean = "True";
                    b.ID = year + month + groupname + cards + item.Text.Substring(3) + "N";
                }
                db.Table_BreakfastBoolean.Add(b);
                int t = db.SaveChanges();
                //System.Data.Entity.Infrastructure.DbUpdateException:“An error occurred while updating the entries. See the inner exception for details.”
                //UpdateException: An error occurred while updating the entries. See the inner exception for details.
                //SqlException: Violation of PRIMARY KEY constraint 'PK_Table_Breakfast'. Cannot insert duplicate key in object 'dbo.Table_BreakfastBoolean'. The duplicate key value is (202208030101). The statement has been terminated.
            }

            Response.Redirect(Request.Url.ToString());// 这个要在外面，否则执行了第一个之后就中断了

        }
        */

    }
}