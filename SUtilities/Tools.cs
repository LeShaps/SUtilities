using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Linq;

[assembly:CLSCompliant(true)]

namespace STools
{
    public static class Tools
    {
        public static void CheckDir(string Path)
        {

            if (string.IsNullOrEmpty(Path)) {
                throw new ArgumentNullException(nameof(Path), "Path cannot be null or emtpy");
            }

            string[] List = Path.Split('/');
            for (int i = 0; i <= List.Length; i++)
            {
                if (!Directory.Exists(List[i])) {
                    Directory.CreateDirectory(List[i]);
                }

                if (i + 1 < List.Length) {
                    List[i + 1] = List[i] + "/" + List[i + 1];
                }
            }
        }

        public static void DeleteDirectoryContent(string Path)
        {
            foreach (string f in Directory.GetFiles(Path)) {
                File.Delete(f);
            }

            foreach (string d in Directory.GetDirectories(Path)) {
                DeleteDirectoryContent(d);
                Directory.Delete(d);
            }
        }

        public static string Clarify(string WebString)
        {
            if (string.IsNullOrEmpty(WebString)) {
                throw new ArgumentNullException(nameof(WebString), "String cannot be null or empty");
            }

            return GetPlainTextFromHtml(WebUtility.HtmlDecode(WebString));
        }

        /// <summary>
        /// Get plain text from HTML's one using Regex
        /// </summary>
        /// <param name="htmlString">An HTML string</param>
        /// <returns>The plain text of the HTML string</returns>
        public static string GetPlainTextFromHtml(string htmlString)
        {
            if (string.IsNullOrEmpty(htmlString)) {
                throw new ArgumentNullException(nameof(htmlString), "String cannot be null or empty");
            }

            const string htmlTagPattern = "<.*?>";
            var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);

            htmlString = regexCss.Replace(htmlString, string.Empty);
            htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
            htmlString = Regex.Replace(htmlString, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);

            return htmlString;
        }

        public static Stream GetStreamFromUrl(Uri Url)
        {
            if (Url is null) {
                throw new ArgumentNullException(nameof(Url));
            }

            byte[] Data = null;

            using (var wc = new WebClient()) {
                Data = wc.DownloadData(Url);
            }

            return new MemoryStream(Data);
        }

        public static async Task<Stream> GetStreamFromUrlAsync(Uri Url)
        {
            if (Url is null) {
                throw new ArgumentNullException(nameof(Url));
            }

            byte[] Data = null;

            using (var wc = new WebClient()) {
                Data = await wc.DownloadDataTaskAsync(Url).ConfigureAwait(false);
            }

            return new MemoryStream(Data);
        }

        public static bool HasNullOrEmpty(params string[] Args)
        {
            foreach (string s in Args)
            {
                if (string.IsNullOrEmpty(s)) {
                    return true;
                }
            }

            return false;
        }

        public static T JsonWalker<T>(JObject OriginalJson, string Path)
        {
            if (Path is null) {
                throw new ArgumentNullException(nameof(Path));
            }
            else if (OriginalJson is null) {
                throw new ArgumentNullException(nameof(OriginalJson));
            }

            string[] SplitedPath = Path.Split('/');
            string ValueName = SplitedPath.Last();
            JObject FinalJson = OriginalJson;

            foreach (string Part in SplitedPath.SkipLast(1))
            {
                if (FinalJson[Part].Type == JTokenType.Array) {
                    FinalJson = FinalJson.Value<JArray>(Part)[0].ToObject<JObject>();
                } else {
                    FinalJson = FinalJson[Part].ToObject<JObject>();
                }
            }

            return FinalJson.Value<T>(ValueName);
        }
    }
}