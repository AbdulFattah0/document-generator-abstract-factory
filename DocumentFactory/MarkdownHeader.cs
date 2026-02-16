/**
 * Class Name:        MarkdownHeader
 * Purpose:           Represents a Markdown header element (e.g., # Title, ## Subtitle).
 *                    Parses header level and text from a string and formats it according to Markdown syntax.
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
    public class MarkdownHeader : IElement
    {
        private readonly int level;     
        private readonly string text;   

        /*Constructor:      MarkdownHeader
         *Purpose:          Parses the input data to extract header level and text.
         *Accepts:          string data – formatted as "level;text"
         */
        public MarkdownHeader(string data)
        {
            var parts = data.Split(';');
            // Extract level 
            level = int.Parse(parts[0].Trim());
            // Extract header content
            text = parts[1].Trim();            
        }

        /*Method Name:      ToString
         *Purpose:          Converts the header into a valid Markdown header string (e.g., ## Heading).
         *Accepts:          None
         *Returns:          string – Markdown header format
         */
        public override string ToString()
        {
            return $"{new string('#', level)} {text}\n";
        }
    }
}
