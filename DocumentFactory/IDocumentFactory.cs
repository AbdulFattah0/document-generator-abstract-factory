/**
 * Class Name:        IDocumentFactory
 * Purpose:           Defines the contract for document factories (HTML and Markdown). 
 *                    Each factory should be able to create documents and elements dynamically.
 * Coder:             Abdul Marouf, Youssef Rajeh
 * Date:              June 09, 2025
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentFactory
{
    public interface IDocumentFactory
    {
        // Creates a new document (e.g., HtmlDocument or MarkdownDocument)
        IDocument CreateDocument(string filename);

        // Creates a document element (e.g., header, image, list, table)
        IElement CreateElement(string elementType, string data);
    }
}
