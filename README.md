# Document Generator – Abstract Factory Implementation

A flexible document generation system built in C# using core object-oriented design patterns.

This project generates HTML5 and GitHub-style Markdown documents dynamically from a script file. It demonstrates practical implementation of Abstract Factory, Singleton, and Factory Method patterns in a real-world scenario.

---

## Features

- Generates HTML and Markdown documents
- Script-driven document creation
- Supports multiple element types:
  - Headers (H1–H3)
  - Images (with alt & title text)
  - Ordered and unordered lists
  - Tables (with headers and rows)
- Saves generated documents to disk
- Automatically opens output in browser
- Fully modular and extensible architecture

---

## Design Patterns Used

### Abstract Factory
Creates families of related document objects (HTML or Markdown) without specifying their concrete classes.

### Singleton
Ensures only one instance of each factory exists.

### Factory Method
Handles dynamic creation of document elements (header, image, list, table).

---

## Architecture

- **Director** → Reads and processes the script file
- **DocumentFactory** → Implements factories and element creation
- **Elements** → Each element formats itself properly based on document type

---

## How It Works

1. The Director reads `CreateDocumentScript.txt`
2. It determines the document type (HTML or Markdown)
3. The appropriate factory is selected
4. Elements are created dynamically using Factory Method
5. The final document is generated and opened in a browser

---

## Technologies

- C#
- .NET
- Object-Oriented Programming
- Design Patterns

---

## Purpose

This project demonstrates how design patterns improve modularity, scalability, and maintainability. The architecture makes it easy to add new document formats or element types with minimal changes.
