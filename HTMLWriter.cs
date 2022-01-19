
using System;
using System.Collections.Generic;

namespace HTMLWriter
{

    public abstract class HTMLElement
    {
        public abstract string Render();
    }

    public class HTMLDocument : HTMLElement
    {
        public HeadElement Head { get; set; }
        public BodyElement Body { get; set; }

        public override string Render()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("HTMLDocument missing required Head");
            }

            if (Body == null)
            {
                throw new InvalidOperationException("HTMLDocument missing required Body");
            }

            else
            {
                return $"<html>\n{Head.Render()}{Body.Render()}\n</html>\n";
            }
        }
    }

    public class HeadElement : HTMLElement
    {
        public TitleElement Title { get; set; }

        public override string Render()
        {
            if (Title == null)
            {
                throw new InvalidOperationException("HeadElement missing required Title");
            }

            return $"<head>\n{Title.Render()}\n</head>\n";
        }
    }

    public class TitleElement : HTMLElement
    {
        public string Text { get; set; }

        public TitleElement(string text)
        {
            Text = text;
        }

        public override string Render()
        {
            if (Text == null || Text.Trim() == "")
            {
                throw new InvalidOperationException("TitleElement required to have text");
            }
            return $"<title> {Text} </title>";
        }
    }

    public class BodyElement : HTMLElement
    {
        private List<TextElement> _elements;

        public BodyElement()
        {
            _elements = new List<TextElement>();
        }

        public void Add(TextElement element)
        {
            _elements.Add(element);
        }

        public override string Render()
        {
            string s = "<body>\n";

            // Entire list is empty
            if (_elements.Count == 0)
            {
                return $"<body>\n</body>";
            }

            // Loop through _elements and make a long string of broken up TextElement items
            foreach (TextElement t in _elements)
            {
                // Skip if an item in the list is null
                if (t != null)
                {
                    s += t.Render() + "\n";
                }
            }
            return $"{s}</body>";
        }
    }

    public abstract class TextElement : HTMLElement
    {
        public string Text { get; set; }

        public TextElement(string text)
        {
            Text = text;
        }
    }

    public class HeadingElement : TextElement
    {
        public HeadingElement(string text) : base(text) { }

        public override string Render()
        {
            if (Text == null)
            {
                return "<h1></h1>";
            }
            else
            {
                return $"<h1>{Text}</h1>";
            }
        }
    }

    public class ParagraphElement : TextElement
    {
        public ParagraphElement(string text) : base(text) { }

        public override string Render()
        {
            if (Text == null)
            {
                return "<p></p>";
            }
            else
            {
                return $"<p>{Text}</p>";
            }
        }
    }
}

