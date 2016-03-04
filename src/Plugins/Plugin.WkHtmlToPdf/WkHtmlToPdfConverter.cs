using Sediment.HtmlToPdf;
using System;
using System.Diagnostics;
using System.IO;

namespace Plugin.WkHtmlToPdf
{
    public class WkHtmlToPdfConverter : IHtmlToPdfConverter
    {
        public byte[] Convert(string url)
        {
            byte[] content = null;

            using (var process = new Process())
            {
                process.StartInfo.FileName = "wkhtmltopdf.exe";
                process.StartInfo.Arguments = string.Format("\"{0}\" \"{1}\"", url, "html.pdf");
                process.StartInfo.UseShellExecute = false;

                try
                {
                    process.Start();
                    process.WaitForExit();

                    content = File.ReadAllBytes("html.pdf");
                }
                catch (Exception ecp)
                {
                    throw ecp;
                }
            }

            return content;
        }
    }
}
