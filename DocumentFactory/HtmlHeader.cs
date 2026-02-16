/**
 * Class Name:        HtmlHeader
 * Purpose:           Represents an HTML header element (h1, h2, h3) with a text value. 
 *                    Parses data from a string input to determine the level and content.
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
    public class HtmlHeader : IElement
    {
        private readonly int level;    
        private readonly string text;  

        /*Constructor:      HtmlHeader
         *Purpose:          Parses header level and text from input data.
         *Accepts:          string data – formatted as "level;text"
         *Note:             Constructor comments are optional per your instructions, so this is for clarity.
         */
        public HtmlHeader(string data)
        {
            var parts = data.Split(';');             
            level = int.Parse(parts[0].Trim());      
            text = parts[1].Trim();                  
        }

        /*Method Name:      ToString
         *Purpose:          Converts the header data to a properly formatted HTML string.
         *Accepts:          None
         *Returns:          string – HTML header line (e.g., <h1>Title</h1><br />)
         */
        public override string ToString()
        {
            return $"<h{level}>{text}</h{level}><br />";
        }
    }
}
