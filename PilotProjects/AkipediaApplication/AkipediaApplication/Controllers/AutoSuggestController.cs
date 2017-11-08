using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
//using System.Web.Mvc;

namespace AkipediaApplication.Controllers
{

    public class AutoSuggestController : ApiController
    {
        public AutoSuggestController()
        {
            OnetimeSetup();
        }

        [HttpGet]
        public IHttpActionResult ReBuildDict()
        {
            OnetimeSetup();
            //FindMatchingData("a");
            return Ok("finish");
        }

        public IHttpActionResult GetAutoSuggestItem(string input)
        {
            return FindMatchingData(input);
        }

        char[] chrList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        [HttpPost]
        [ActionName("GetAutoSuggestionItems")]
        public IHttpActionResult GetAutoSuggestItemsP([FromBody] string str)
        {
            return FindMatchingData(str);
        }

        private void OnetimeSetup()
        {
            int fCount = 0;
            string rootPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/dictionary/");
            if (Directory.Exists(rootPath + @"partsAll"))
            {
                fCount = Directory.GetFiles(rootPath + @"partsAll", "*", SearchOption.TopDirectoryOnly).Length;
            }
            if (fCount > 5)
                return;
            char[] chrList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] escapeList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k' };
            
            using (StreamReader sr = File.OpenText(rootPath + @"words.txt"))
            {
                string str = String.Empty;
                while ((str = sr.ReadLine()) != null)
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(str))
                            continue;
                        char first = str[0];
                        if (escapeList.Contains(first))
                            continue;
                        string filename = first.ToString();
                        if (!chrList.Contains(first))
                            filename = "general";
                        filename = rootPath + @"partsAll\" + filename + ".txt";
                        TextWriter tw = new StreamWriter(filename, true);
                        tw.WriteLine(str);
                        tw.Close();
                    }
                    catch (Exception ex)
                    {
                        var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                        responseMessage.Content = new StringContent(ex.Message);
                        throw new HttpResponseException(responseMessage);
                    }
                }
            }

        }

        private IHttpActionResult FindMatchingData(string str)
        {
            string rootPath = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/dictionary/");

            string[] suggestItems = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(str))
                {
                    //str = str.Trim(new char[]{ ' ', '\'', '\"'});
                    char first = str[0];
                    //if (first == ' ' || first == '\'' || first == '\"')
                    //{
                    //    char last = str[str.Length - 1];
                    //    if (first == last)
                    //    {
                    //        str = str.Trim(new char[] { first });
                    //        first = str[0];
                    //    }
                    //    else
                    //    first = str[1];
                    //}
                    string filename = first.ToString();
                    if (!chrList.Contains(first))
                        filename = "general";
                    filename = rootPath + @"partsAll\" + filename + ".txt";

                    IEnumerable<String> lines = File.ReadLines(filename);

                    suggestItems = lines.Where(t => t.StartsWith(str)).Take(10).ToArray();
                }
            }
            catch (Exception ex)
            {
                suggestItems = null;
                var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.Content = new StringContent(ex.Message);
                throw new HttpResponseException(responseMessage);
            }

            if (suggestItems == null)
            {
                return NotFound();
            }
            return Ok(suggestItems);
        }
    }
}