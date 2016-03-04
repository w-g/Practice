
namespace Sediment.HtmlToPdf
{
    public interface IHtmlToPdfConverter
    {
        byte[] Convert(string url);
    }
}
