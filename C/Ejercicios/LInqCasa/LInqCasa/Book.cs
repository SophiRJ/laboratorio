using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoLinqLibrary
{
    public class Book
    {
        public Subject Subject { get; set; }
        public string Title { get; set; }
        public Publisher Publisher { get; set; }
        public Author[] Authors { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public string isbn { get; set; }
    }
}
