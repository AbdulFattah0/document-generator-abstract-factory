/**
 * Class Name:        HtmlFactory
 * Purpose:           Responsible for creating HTML documents and their elements. 
 *                    Uses Singleton pattern to ensure a single instance and Factory Method 
 *                    to create various HTML elements like headers, images, lists, and tables.
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
    public class HtmlFactory : IDocumentFactory
    {
        private static HtmlFactory _instance;

        // Private constructor to enforce Singleton pattern
        private HtmlFactory() { }

        /*Method Name:      Instance
         *Purpose:          Provides access to the single instance of HtmlFactory.
         *Accepts:          None
         *Returns:          HtmlFactory – the single shared instance.
         */
        public static HtmlFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HtmlFactory();
                return _instance;
            }
        }

        /*Method Name:      CreateDocument
         *Purpose:          Instantiates a new HtmlDocument with the provided filename.
         *Accepts:          string filename – name of the output file.
         *Returns:          IDocument – a new HtmlDocument instance.
         */
        public IDocument CreateDocument(string filename)
        {
            return new HtmlDocument(filename);
        }

        /*Method Name:      CreateElement
         *Purpose:          Uses Factory Method to create specific HTML elements based on the type.
         *Accepts:          string elementType – the type of element (header, image, list, table);
         *                  string data – data specific to that element.
         *Returns:          IElement – an instance of the corresponding HTML element class.
         */
        public IElement CreateElement(string elementType, string data)
        {
            switch (elementType.ToLower())
            {
                case "header":
                    return new HtmlHeader(data);
                case "image":
                    return new HtmlImage(data);
                case "list":
                    return new HtmlList(data);
                case "table":
                    return new HtmlTable(data);
                default:
                    throw new ArgumentException($"Unknown HTML element type: {elementType}");
            }
        }
    }
}
