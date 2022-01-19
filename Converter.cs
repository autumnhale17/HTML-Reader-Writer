
using System;
using System.IO;

namespace HTMLWriter
{
    class Converter
    {
        private string readingFile;
        private string writingFile;

        public Converter(string readingPath, string writingPath)
        {
            readingFile = readingPath;
            writingFile = writingPath;
        }

        public void convert()
        {
            try
            {
                using StreamReader reader = new StreamReader(readingFile);
                using StreamWriter writer = new StreamWriter(writingFile);

                HTMLDocument doc = new HTMLDocument();

                HeadElement head = new HeadElement();
                doc.Head = head;
                doc.Body = new BodyElement();
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("TITLE:"))
                    {
                        head.Title = new TitleElement(line.Remove(0, 6));
                    }

                    else if (line.Contains("HEADING:"))
                    {
                        doc.Body.Add(new HeadingElement(line.Remove(0, 8)));
                    }

                    else if (line.Contains("PARAGRAPH:"))
                    {
                        doc.Body.Add(new ParagraphElement(line.Remove(0, 10)));
                    }
                }
                writer.WriteLine(doc.Render());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Problem with file.");
                Console.WriteLine(e);
            }
        }
    }
}
