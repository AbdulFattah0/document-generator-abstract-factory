/**
   * Class Name:        HtmlDocument
   * Purpose:           Represents an HTML document that can store and render HTML elements.
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
 
    public class HtmlDocument : IDocument
    {
        private readonly List<IElement> elements = new List<IElement>();  // Holds document elements
        private readonly string filename;  // Output filename

        public HtmlDocument(string filename)
        {
            this.filename = filename;
        }

      
        public void AddElement(IElement element)
        {
            elements.Add(element);
        }

        /*Method Name:      RunDocument
         *Purpose:          Generates an HTML file using the added elements and writes it to disk.
         *Accepts:          None
         *Returns:          void
         */
        public void RunDocument()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), filename);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("<!DOCTYPE html>");
                writer.WriteLine("<html><body>");

                // Render each element using its ToString method
                foreach (var element in elements)
                {
                    writer.WriteLine(element.ToString());
                }

                writer.WriteLine("</body></html>");
            }

            // Launching the file in a browser was removed as per project requirements
            Console.WriteLine("HTML file generated at: " + path);
        }
    }
}
