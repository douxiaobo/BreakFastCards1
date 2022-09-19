using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Globalization;
using Newtonsoft.Json.Converters;
using LitJson;
using System.Collections;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("选日期，按下A，还是月份，按下B：");
            String Choose=Console.ReadLine();
            if (Choose == "A" || Choose == "a")
            {
                Console.Write("年份：");
                String year = Console.ReadLine();
                Console.Write("月份：");
                String month = Console.ReadLine();
                Console.Write("日期：");
                String day = Console.ReadLine();
                string url = @"http://timor.tech/api/holiday/info/";
                url += year.ToString() + "-" + month.ToString().PadLeft(2, '0') + "-" + day.ToString().PadLeft(2, '0');
                Console.WriteLine(url);
                try
                {
                    WebClient wc = new WebClient();
                    wc.Credentials = CredentialCache.DefaultCredentials;
                    wc.Encoding = Encoding.UTF8;
                    string returnText = wc.DownloadString(url);
                    Console.WriteLine(returnText);
                    var jsonDes = JsonConvert.DeserializeObject<Workdays>(returnText);
                    Console.WriteLine(jsonDes.Type.Type);

                    /*
                    WebRequest request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    Stream webstream = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(webstream);
                    string json = streamReader.ReadToEnd();
                    Console.WriteLine(json);
                    var jsonDes = JsonConvert.DeserializeObject<Workdays>(json);
                    Console.WriteLine(jsonDes.Type.Type);
                    */
                }
                catch
                {
                    Uri uri = new Uri(url);
                    HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(uri);
                    HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
                    Stream respStream = httpResp.GetResponseStream();
                    StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
                    string strBuff = respStreamReader.ReadToEnd();
                    Console.WriteLine(strBuff);
                    var jsonDes = JsonConvert.DeserializeObject<Workdays>(strBuff);
                    Console.WriteLine(jsonDes.Type.Type);
                }
                Console.ReadKey();
            }
            else if (Choose == "B" || Choose == "b")
            {
                Console.Write("年份：");
                String year = Console.ReadLine();
                Console.Write("月份：");
                String month = Console.ReadLine();
                DateTime dt = Convert.ToDateTime(year + "-" + month + "-" + 01.ToString());
                int days = DateTime.DaysInMonth(Convert.ToInt16(year), Convert.ToInt16(month));
                

                string url = @"http://timor.tech/api/holiday/year/";
                url += year.ToString() + "-" + month.ToString().PadLeft(2, '0');
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();//System.Net.WebException:“未能解析此远程名称: 'timor.tch'”
                Stream webstream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(webstream);
                string json = streamReader.ReadToEnd();
                Console.WriteLine("json=");
                Console.WriteLine(json);
                List<string> holidaylist_for = new List<string>();
                var holidaylist_foreach=new List<string>();
                var root = JsonConvert.DeserializeObject<Holiday>(json);
                var keys = root.HolidayHoliday1.Keys;
                foreach(var key in keys)
                {
                    Console.WriteLine(key);
                    holidaylist_for.Add(key);
                    holidaylist_foreach.Add(key);
                }
                Console.WriteLine("holidaylist_For=");
                for(int i=0;i<holidaylist_for.Count;i++)
                {
                    Console.WriteLine(holidaylist_for[i]);
                }
                Console.WriteLine("holidaylist_foreach=");
                foreach(string date in holidaylist_foreach)
                {
                    Console.WriteLine(date);
                }





                /*
                代码正确的
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                wc.Encoding = Encoding.UTF8;
                string returnText = wc.DownloadString(url);//System.Net.WebException:“未能解析此远程名称: 'timor.tch'”
                Console.WriteLine("returnText=");
                Console.WriteLine(returnText);
                */

                int workdays = 0;
                var workdaylist = new List<string>();
                bool workdaybool;
                for (int i = 1;i<=days;i++)
                {
                    string date_check = month.ToString().PadLeft(2,'0') + "-" + i.ToString().PadLeft(2, '0');
                    if(dt.DayOfWeek!=DayOfWeek.Saturday&&dt.DayOfWeek != DayOfWeek.Sunday) 
                    {
                        workdaybool = true;
                        foreach(string date in holidaylist_foreach)
                        {
                            if (date_check == date)
                                workdaybool = false;
                        }
                        if (workdaybool == true)
                        {
                            workdays++;
                            workdaylist.Add(date_check);
                        }
                    }
                    dt = dt.AddDays(1);
                }
                Console.WriteLine(workdays);
                foreach(string data in workdaylist)
                {
                    Console.WriteLine(data+"\t");
                }
                Console.ReadKey();
            }   
        }
    }
}
