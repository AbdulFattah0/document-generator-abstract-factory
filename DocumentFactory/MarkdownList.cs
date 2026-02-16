/**
 * Class Name:        MarkdownList
 * Purpose:           Represents a Markdown list element, supporting both ordered and unordered formats.
 *                    Parses list type and list items from input data and renders the appropriate Markdown syntax.
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
    public class MarkdownList : IElement
    {
        private readonly string type;         
        private readonly string[] items;      

        /*Constructor:      MarkdownList
         *Purpose:          Parses the list type and items from the provided data string.
         *Accepts:          string data – formatted as "type;item1;item2;..."
         */
        public MarkdownList(string data)
        {
            var parts = data.Split(';');

            // First entry is the list type
            type = parts[0].ToLower();         
            items = parts.Skip(1).ToArray();  
        }

        /*Method Name:      ToString
         *Purpose:          Converts the list into Markdown-formatted syntax.
         *Accepts:          None
         *Returns:          string – Markdown list representation
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Length; i++)
            {
                if (type == "ordered")
                    sb.AppendLine($"{i + 1}. {items[i]}");   
                else
                    sb.AppendLine($"- {items[i]}");          
            }

            sb.AppendLine(); 
            return sb.ToString();
        }
    }
}
