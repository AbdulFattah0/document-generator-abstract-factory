/**
 * Class Name:        MarkdownFactory
 * Purpose:           Singleton factory that creates Markdown documents and their elements.
 *                    Implements Abstract Factory and Factory Method design patterns to build
 *                    Markdown-compatible document components like headers, images, lists, and tables.
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
    public class MarkdownFactory : IDocumentFactory
    {
        private static MarkdownFactory _instance;

        // Private constructor to prevent external instantiation
        private MarkdownFactory() { }

        /*Method Name:      Instance
         *Purpose:          Provides access to the single instance of MarkdownFactory.
         *Accepts:          None
         *Returns:          MarkdownFactory – the singleton instance.
         */
        public static MarkdownFactory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MarkdownFactory();
                return _instance;
            }
        }

        /*Method Name:      CreateDocument
         *Purpose:          Creates a new MarkdownDocument using the specified filename.
         *Accepts:          string filename – name of the output file.
         *Returns:          IDocument – a new MarkdownDocument instance.
         */
        public IDocument CreateDocument(string filename)
        {
            return new MarkdownDocument(filename);
        }

        /*Method Name:      CreateElement
         *Purpose:          Uses Factory Method to create specific Markdown elements based on type.
         *Accepts:          string elementType – the type of element (header, image, list, table);
         *                  string data – the data string used to create the element.
         *Returns:          IElement – the appropriate Markdown element instance.
         */
        public IElement CreateElement(string elementType, string data)
        {
            switch (elementType.ToLower())
            {
                case "header":
                    return new MarkdownHeader(data);
                case "image":
                    return new MarkdownImage(data);
                case "list":
                    return new MarkdownList(data);
                case "table":
                    return new MarkdownTable(data);
                default:
                    throw new ArgumentException($"Unknown Markdown element type: {elementType}");
            }
        }
    }
}
