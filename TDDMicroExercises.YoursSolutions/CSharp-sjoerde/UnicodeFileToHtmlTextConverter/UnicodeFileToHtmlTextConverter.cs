using System.IO;
using System.Web;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter
{
    public class UnicodeFileToHtmlTextConverter
    {
        public string ConvertToHtml(string fullFilenameWithPath)
        {
            using (TextReader unicodeFileStream = OpenFile(fullFilenameWithPath))
            {
                return ConvertToHtml(unicodeFileStream);
            }
        }

        public virtual TextReader OpenFile(string fullFilenameWithPath)
        {
            return File.OpenText(fullFilenameWithPath);
        }

        public string ConvertToHtml(TextReader textReader)
        {
            string html = string.Empty;
            string line = textReader.ReadLine();
            while (line != null)
            {
                html += EncodeLine(line);
                line = textReader.ReadLine();
            }
            return html;
        }

        public string EncodeLine(string line)
        {
            return string.Format("{0}<br />", HttpUtility.HtmlEncode(line));
        }
    }
}
