using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace MyActiveX
{

    [Guid("D5CDCDF1-5699-42E6-B81D-8FBB95092B99")]
    public class MyActiveX : ActiveXControl, Param
    {
        private string EPL;
        private string printName;
        private string name = @"\\10.172.0.237\Zebra-FDX ZM400 200 dpi (EPL)";

        public MyActiveX()
        {
           // this.printName = "Zebra  LP2844";
        }

        //文件路径
        public string Param
        {
            get { return this.EPL; }
            set { this.EPL = value; }
        }

        //打印机名
        public string Zmber
        {
            get { return this.printName; }
            set { this.printName = value; }
        }

      

       /*EPL打印*/
        public string Epl()
        {
            string cmd;
            cmd = this.Get();

            return cmd;
        }

      

        public string test()
        {
            return "test";
        }

        //打印机名字
        public string ZmberName()
        {
            string zmber = this.Zmber;
            return zmber;
        }

        //文件路径
        public string Path()
        {
            string path = this.Param;
            return path;
        }

        /*直接打印 EPL*/
        public void PrintEpl()
        {
            string cmd;
            cmd = this.Get();

            Label label = new Label(this.Zmber);

            label.PrintEpl(cmd);
        }

        //打印txt文件
        public void PrintFile()
        {
            string file;
            file = this.WriteStream();

            Label label = new Label(this.Zmber);

            label.PrintEpl(file);
        }

       

        /*获取远程服务器上txt文件的内容*/
        public string Get()
        {
            //http://cn.fs.com:8006/YX_sJsBEkT12004/includes/modules/page/fedex_pdf/ShipLabe_788389599753_0.txt
            HttpWebRequest request;
            // 创建一个HTTP请求
            request = (HttpWebRequest)WebRequest.Create(this.Param);
            HttpWebResponse response;
            response = (HttpWebResponse)request.GetResponse();
            StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = myreader.ReadToEnd();
            myreader.Close();
            return responseText;
        }


        /*获取服务器上的txt文件 并下载*/
        public string WriteStream()
        {
            try
            {
                string ImagesPath = @"E:\epl.txt";
                HttpWebRequest oHttp_Web_Req = (HttpWebRequest)WebRequest.Create(this.Param);
                Stream oStream = oHttp_Web_Req.GetResponse().GetResponseStream();
                using (StreamReader respStreamReader = new StreamReader(oStream, Encoding.UTF8))
                {
                    string line = string.Empty;
                    while ((line = respStreamReader.ReadLine()) != null)
                    {

                        UTF8Encoding utf8 = new UTF8Encoding(false);
                        //写txt文件
                        using (StreamWriter sw = new StreamWriter(ImagesPath, true, utf8))
                        {

                            sw.WriteLine(line);
                        }

                    }
                }
                return ImagesPath;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
