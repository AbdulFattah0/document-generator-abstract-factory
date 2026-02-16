/**
 * Class Name:        Program
 * Purpose:           Entry point for the document generator. Reads and processes commands from
 *                    CreateDocumentScript.txt to dynamically build and generate HTML or Markdown documents.
 * Coder:             Abdul Marouf, Youssef Rajeh
 * Date:              June 09, 2025
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFactory;

namespace Director
{
    class Program
    {
        /*Method Name:      Main
         *Purpose:          Reads structured script commands from a text file, uses a factory to create
         *                  documents and elements, and generates formatted output files.
         *Accepts:          string[] args – command-line arguments (not used here).
         *Returns:          void
         */
        static void Main(string[] args)
        {
            // Read and split commands using '#' as the delimiter
            string[] commands;
            var list = File.ReadAllText("CreateDocumentScript.txt");
            commands = list.Split('#');

            IDocumentFactory factory = null;
            IDocument doc = null;

            foreach (var command in commands)
            {
                var strippedCommand = Regex.Replace(command, @"\t|\n|\r", "").Trim();
                if (string.IsNullOrWhiteSpace(strippedCommand))
                    continue;

                var commandList = strippedCommand.Split(':');

                switch (commandList[0])
                {
                    case "Document":
                        // Extract document type and filename
                        var docParts = commandList[1].Split(';');
                        var docType = docParts[0].Trim().ToLower();
                        var fileName = docParts[1].Trim();

                        // Choose the appropriate factory
                        if (docType == "html")
                            factory = HtmlFactory.Instance;
                        else if (docType == "markdown")
                            factory = MarkdownFactory.Instance;
                        else
                            throw new Exception("Unsupported document type");

                        doc = factory.CreateDocument(fileName);
                        break;

                    case "Element":
                        if (factory == null || doc == null)
                            throw new Exception("Factory or Document is not initialized");

                        // Extract element type and its associated data
                        var elementType = commandList[1].Trim();
                        var elementData = commandList.Length > 2 ? commandList[2].Trim() : "";

                        var element = factory.CreateElement(elementType, elementData);
                        doc.AddElement(element);
                        break;

                    case "Run":
                        if (doc != null)
                        {
                            doc.RunDocument();    // Write to file and confirm
                            doc = null;
                            factory = null;
                        }
                        break;

                    default:
                        Console.WriteLine($"Unknown command: {commandList[0]}");
                        break;
                }
            }

            Console.WriteLine("Finished processing script.");
        }
    }
}
