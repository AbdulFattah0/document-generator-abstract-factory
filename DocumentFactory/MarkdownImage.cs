/**
 * Class Name:        MarkdownImage
 * Purpose:           Represents a Markdown image element. Stores image source, alt text, and title, 
 *                    and formats them into a proper Markdown image string.
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
    public class MarkdownImage : IElement
    {
        private readonly string src, alt, title;  

        /*Constructor:      MarkdownImage
         *Purpose:          Parses image properties (source, alt, title) from the input string.
         *Accepts:          string data – formatted as "src;alt;text"
         */
        public MarkdownImage(string data)
        {
            var parts = data.Split(';');
            src = parts[0];    
            alt = parts[1];     
            title = parts[2];   
        }

        /*Method Name:      ToString
         *Purpose:          Returns the Markdown representation of the image.
         *Accepts:          None
         *Returns:          string – Markdown image string format
         */
        public override string ToString()
        {
            return $"![{alt}]({src} \"{title}\")";
        }
    }
}
