/**
 * Class Name:        HtmlList
 * Purpose:           Represents an HTML list element, supporting both ordered (<ol>) and unordered (<ul>) lists.
 *                    Parses input data to extract list type and list items, and generates proper HTML output.
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
    public class HtmlList : IElement
    {
        private readonly string type;         
        private readonly string[] items;      

        /*Constructor:      HtmlList
         *Purpose:          Parses list type and list items from the input string.
         *Accepts:          string data – formatted as "ordered;Item1;Item2;Item3"
         */
        public HtmlList(string data)
        {
            var parts = data.Split(';');
            type = parts[0].ToLower();             
            items = parts.Skip(1).ToArray();       
        }

        /*Method Name:      ToString
         *Purpose:          Converts the list data into a formatted HTML <ul> or <ol> structure.
         *Accepts:          None
         *Returns:          string – HTML list element as a string
         */
        public override string ToString()
        {
            var tag = type == "ordered" ? "ol" : "ul";  // Determine tag based on type
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<{tag}>");

            foreach (var item in items)
            {
                sb.AppendLine($"  <li>{item}</li>");
            }

            sb.AppendLine($"</{tag}><br />");
            return sb.ToString();
        }
    }
}
