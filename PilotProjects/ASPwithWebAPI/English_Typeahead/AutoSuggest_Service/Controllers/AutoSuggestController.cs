using AutoSuggest_Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutoSuggest_Service.Controllers
{
    public class AutoSuggestController : ApiController
    {
        public IHttpActionResult GetAutoSuggestItem(string input)
        {
            return FindMatchingData(input);
        }

        char[] chrList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        [HttpPost]
        [ActionName("GetAutoSuggestionItems")]
        public IHttpActionResult GetAutoSuggestItemsP(string str)
        {
            return FindMatchingData(str);
        }

        private IHttpActionResult FindMatchingData(string str)
        { 
            string rootPath = @"C:\testData\";
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
                    filename = rootPath + @"parts\" + filename + ".txt";

                    IEnumerable<String> lines = File.ReadLines(filename);

                    suggestItems = lines.Where(t => t.StartsWith(str)).Take(10).ToArray();
                }
            }
            catch (Exception ex)
            {
                suggestItems = null;
            }
               
            if (suggestItems == null)
            {
                return NotFound();
            }
            return Ok(suggestItems);
        }
    }
}
