using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Pdf;
using Aspose.Pdf.Text;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReplaceContentInPdf
{
    public class ReplaceTextInPdfHeaderOrFooter
    {
        public static void Run()
        {
            while (true)
            {
                //Console.WriteLine("Input the input pdf path please.");
                //var path = Console.ReadLine();

                //if (!File.Exists(path) || !path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                //{
                //    continue;
                //}

                var textStamp = new TextStamp("Header Text");
                textStamp.TopMargin = 10;
                textStamp.HorizontalAlignment = HorizontalAlignment.Center;
                textStamp.VerticalAlignment = VerticalAlignment.Top;

                //var pdfDocument = new Document(path);
                var pdfDocument = new Document("C:\\Users\\Administrator\\Desktop\\D807060.PDF");

                pdfDocument.Pages[1].Resources.Images.Delete(1);
                pdfDocument.Pages[1].Resources.Images.Delete(1);

                //Console.WriteLine("Input the output pdf path please.");
                //var outputPath = Console.ReadLine();

                //pdfDocument.Save(outputPath);
                pdfDocument.Save("D:\\output"+ DateTime.Now.Ticks +".pdf");

                break;
            }


            Console.WriteLine("Input any key to exit.");
            Console.ReadKey();
        }
    }
}
