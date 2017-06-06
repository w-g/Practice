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
    public class ReplaceTextInPdfContent
    {
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Input the input pdf path please.");
                var path = Console.ReadLine();

                if (!File.Exists(path) || !path.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                Console.WriteLine("Input the phrase which to be replaced please.");
                var phrase = Console.ReadLine();

                var pdfDocument = new Document(path);
                var textFragmentAbsorber = new TextFragmentAbsorber(phrase);

                pdfDocument.Pages.Accept(textFragmentAbsorber);
                var textFragmentCollection = textFragmentAbsorber.TextFragments;

                foreach (TextFragment textFragment in textFragmentCollection)
                {
                    textFragment.Text = "*REPLACED*";
                    textFragment.TextState.Font = FontRepository.FindFont("Verdana");
                    textFragment.TextState.FontSize = 22;
                }

                Console.WriteLine("Input the output pdf path please.");
                var outputPath = Console.ReadLine();

                pdfDocument.Save(outputPath);

                break;
            }


            Console.WriteLine("Input any key to exit.");
            Console.ReadKey();
        }
    }
}
