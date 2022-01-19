
using System;

namespace HTMLWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Testing
            HTMLDocument doc = new HTMLDocument();

            HeadElement head = new HeadElement();
            head.Title = new TitleElement("This is a title");
            doc.Head = head;

            doc.Body = new BodyElement();

            doc.Body.Add(new HeadingElement("This is a heading"));
            doc.Body.Add(new ParagraphElement("This is a paragraph"));
            doc.Body.Add(new ParagraphElement(null));
            doc.Body.Add(new ParagraphElement("This is a paragraph too"));
            Console.WriteLine(doc.Render());
            */

            Converter c = new Converter(@"C:\data\poem.txt", @"C:\data\poem.html");
            c.convert();
            c = new Converter(@"C:\data\quotes.txt", @"C:\data\quotes.html");
            c.convert();
        }
    }
}

