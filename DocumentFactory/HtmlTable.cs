/**
 * Class Name:        HtmlTable
 * Purpose:           Represents an HTML table element. Parses input data to build table rows
 *                    and cells dynamically using <table>, <tr>, <th>, and <td> tags.
 * Coder:             Abdul Marouf, Youssef Rajeh
 * Date:              June 09, 2025
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentFactory
{
    public class HtmlTable : IElement
    {
        private readonly string[] lines;  

        /*Constructor:      HtmlTable
         *Purpose:          Splits incoming table data into multiple row definitions.
         *Accepts:          string data – each row is separated by ';', and columns by '$'
         */
        public HtmlTable(string data)
        {
            lines = data.Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /*Method Name:      ToString
         *Purpose:          Converts the parsed table data into a properly formatted HTML table string.
         *Accepts:          None
         *Returns:          string – HTML table markup
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border='1'>");

            foreach (var line in lines)
            {
                var parts = line.Split('$');                 
                var rowType = parts[0].ToLower();            

                sb.AppendLine("  <tr>");
                for (int i = 1; i < parts.Length; i++)
                {
                    var tag = rowType == "head" ? "th" : "td";  
                    sb.AppendLine($"    <{tag}>{parts[i]}</{tag}>");
                }
                sb.AppendLine("  </tr>");
            }

            sb.AppendLine("</table><br />");
            return sb.ToString();
        }
    }
}
