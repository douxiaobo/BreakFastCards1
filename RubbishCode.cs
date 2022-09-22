using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    }
}