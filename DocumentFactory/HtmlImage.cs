/**
 * Class Name:        HtmlImage
 * Purpose:           Represents an HTML image element, storing its source path, 
 *                    alternative text, and title, and rendering them into a valid <img> tag.
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
    public class HtmlImage : IElement
    {
        private readonly string src, alt, title;  

        /*Constructor:      HtmlImage
         *Purpose:          Parses and assigns image source, alt text, and title from the input string.
         *Accepts:          string data – formatted as "src;alt;title"
         */
        public HtmlImage(string data)
        {
            var parts = data.Split(';');
            src = parts[0];      
            alt = parts[1];     
            title = parts[2];    
        }

        /*Method Name:      ToString
         *Purpose:          Converts the image data into a valid HTML <img> element string.
         *Accepts:          None
         *Returns:          string – formatted HTML image tag
         */
        public override string ToString()
        {
            return $"<img alt='{alt}' title='{title}' src='{src}' /><br />";
        }
    }
}
