/**
 * Class Name:        MarkdownDocument
 * Purpose:           Represents a Markdown document that stores and renders Markdown elements.
 *                    Generates a file by combining all added elements into a proper Markdown file.
 * Coder:             Abdul Marouf, Youssef Rajeh
 * Date:              June 09, 2025
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace DocumentFactory
{
    public class MarkdownDocument : IDocument
    {
        private readonly List<IElement> elements = new List<IElement>();  
        private readonly string filename;                                 

        public MarkdownDocument(string filename)
        {
            this.filename = filename;
        }

        /*Method Name:      AddElement
         *Purpose:          Adds an IElement to the Markdown document’s element list.
         *Accepts:          IElement element – the document element to be added.
         *Returns:          void
         */
        public void AddElement(IElement element)
        {
            elements.Add(element);
        }

        /*Method Name:      RunDocument
         *Purpose:          Writes all added Markdown elements to a file, one per line.
         *Accepts:          None
         *Returns:          void
         */
        public void RunDocument()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), filename);

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var element in elements)
                {
                    writer.WriteLine(element.ToString());  
                }
            }

            Console.WriteLine("Markdown file generated at: " + path);
        }
    }
}
