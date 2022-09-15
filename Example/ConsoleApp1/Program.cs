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

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("选日期，按下A，还是月份，按下B：");
            String Choose=Console.ReadLine();
            if (Choose == "A")
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
                    var jsonDes= JsonConvert.DeserializeObject<Workdays>(returnText);
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
            else
            {
                Console.Write("年份：");
                String year = Console.ReadLine();
                Console.Write("月份：");
                String month = Console.ReadLine();
                int days = DateTime.DaysInMonth(Convert.ToInt16(year), Convert.ToInt16(month));
                DateTime dt = Convert.ToDateTime(year + "-" + month + "-" + 01.ToString());
                int workdays = 0;
                for(int i=1;i<=days;i++)
                {
                    if(dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday)
                    {
                        string url = @"http://timor.tech/api/holiday/info/";
                        url += year+ "-" + month + "-" + i.ToString().PadLeft(2, '0');
                        WebRequest request = WebRequest.Create(url);
                        WebResponse response = request.GetResponse();
                        Stream webstream = response.GetResponseStream();
                        StreamReader streamReader = new StreamReader(webstream);
                        string json = streamReader.ReadToEnd();
                        var jsonDes = JsonConvert.DeserializeObject<Workdays>(json);
                        if (Convert.ToInt16(jsonDes.Type.Type) == 0)
                            workdays++;
                    }
                    dt = dt.AddDays(1);
                }
                Console.WriteLine("Days in a month:", days);
                Console.WriteLine("Workdays:",workdays);
                Console.ReadKey();
            }                
        }
    }
}
