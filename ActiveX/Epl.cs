using System;
using System.Text;
using System.Globalization;

namespace MyActiveX
{
    public class Label
    {

        private string raw;
        private string filePath;
        private string printName;

        public Label(string printName, string raw = null, string filePath = null)
        {
            if(printName == null)
            {
                throw new ArgumentNullException("printName");
            }
            else
            {
                this.printName = printName;
            }
            this.raw = raw;

            this.filePath = filePath;

        }

        /*打印EPL*/
        public void PrintEpl(string Epl = null)
        {
            StringBuilder sb;

            sb = new StringBuilder(this.raw);

            string cmd;

            if(Epl != null)
            {
                cmd = Epl; 
            }
            else
            {
                cmd = sb.ToString();
            }
            RawPrinterHelper.SendStringToPrinter(this.printName, cmd);
        }

        /*打印文件*/
        public void PrintFile(string filePath)
        {
            string path;
            if(filePath != null)
            {
                path = filePath;
            }
            else
            {
                path = this.filePath;
            }

            RawPrinterHelper.SendFileToPrinter(this.printName, path);
        }
    }

   
}