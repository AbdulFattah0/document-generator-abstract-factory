/**
 * Class Name:        MarkdownTable
 * Purpose:           Represents a Markdown table element. Parses structured input to generate
 *                    proper Markdown table rows and headers using pipe and dash formatting.
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
    public class MarkdownTable : IElement
    {
        // Array of raw table row strings (head/row)
        private readonly string[] lines;  

        /*Constructor:      MarkdownTable
         *Purpose:          Parses the input data into individual table rows.
         *Accepts:          string data – table rows delimited by ';', columns delimited by '$'
         */
        public MarkdownTable(string data)
        {
            lines = data.Trim().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        /*Method Name:      ToString
         *Purpose:          Converts the parsed table data into valid Markdown table format.
         *Accepts:          None
         *Returns:          string – Markdown-formatted table
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            bool headerDone = false;

            foreach (var line in lines)
            {
                var partsArray = line.Split('$');
                var parts = partsArray.Skip(1).ToArray();  // Skip "head"/"row" label

                // Render table row
                sb.Append("| ");
                sb.Append(string.Join(" | ", parts));
                sb.AppendLine(" |");

                // Render the separator after the header row only once
                if (!headerDone && line.ToLower().StartsWith("head"))
                {
                    sb.Append("| ");
                    sb.Append(string.Join(" | ", parts.Select(p => "---")));
                    sb.AppendLine(" |");
                    headerDone = true;
                }
            }

            sb.AppendLine();  
            return sb.ToString();
        }
    }
}
