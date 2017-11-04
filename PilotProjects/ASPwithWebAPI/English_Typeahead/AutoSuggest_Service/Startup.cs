using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.IO;

[assembly: OwinStartup(typeof(AutoSuggest_Service.Startup))]

namespace AutoSuggest_Service
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            try
            {
               // PerformDictRead();  Need to call only once
            }
            catch(Exception ex)
            {

            }
        }

        public void PerformDictRead()
        {
            char[] chrList = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] escapeList = { 'a','b','c','d','e','f','g'};
            string rootPath = @"C:\Users\arvin_000\Downloads\";
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
                        filename = rootPath + @"parts\" + filename + ".txt";
                        TextWriter tw = new StreamWriter(filename, true);
                        tw.WriteLine(str);
                        tw.Close();
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }

        }
    }
}
