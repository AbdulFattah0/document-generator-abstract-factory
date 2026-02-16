/**
 * Class Name:        IDocument
 * Purpose:           Defines the structure for any type of document (e.g., HTML or Markdown).
 *                    Provides methods to add elements and generate the final output.
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
    public interface IDocument
    {
        // Adds an element to the document
        void AddElement(IElement element);

        // Generates the document and writes it to a file
        void RunDocument();
    }
}
