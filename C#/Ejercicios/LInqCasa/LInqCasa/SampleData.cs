using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoLinqLibrary
{
    static public class SampleData
    {
        static public Publisher[] Publishers =
        {
            new Publisher{Name ="FunBooks"},
            new Publisher{Name ="Joe Publishing"},
            new Publisher{Name ="I Publisher"}
        };

        static public Author[] Authors =
        {
            new Author{FirstName ="Johnny",LastName ="Good"},
            new Author{FirstName ="Graciella",LastName ="Simplegame"},
            new Author{FirstName ="Octavio",LastName ="Prince"},
            new Author{FirstName ="Jeremy",LastName ="Legrand"}
        };
        static public Subject[] Subjects =
        {
            new Subject{Name="Love", Description="Is a Loves'Storie"},
            new Subject{Name="Terror", Description="Is a Horror'Storie"},
            new Subject{Name="War", Description="Is a Belic's Stories"}
        };
        static public Book[] Books =
        {
            new Book 
            {
                Title = "Funny Stories",
                Publisher= Publishers[0],
                Authors=new[]{Authors[0],Authors[1]},
                PageCount=101,
                Price = 25.55,
                PublicationDate=new DateTime(2004,11,10),
                isbn="0-111-7777-2",
                Subject= Subjects[0]
            },
            new Book 
            {
                Title = "LINQ Rules",
                Publisher=Publishers[1],
                Authors=new[]{Authors[2]},
                PageCount=300,
                Price = 12,
                PublicationDate=new DateTime(2007,9,2),
                isbn="0-111-7777-2",
                Subject= Subjects[1]
            },
            new Book 
            {
                Title = "C# on Rails",
                Publisher= Publishers[1],
                Authors=new[]{Authors[2]},
                PageCount=256,
                Price = 35.5,
                PublicationDate=new DateTime(2007,4,1),
                isbn="0-222-7777-2",
                Subject=Subjects[2]
            },
            new Book 
            {
                Title = "All your base are belong to us",
                Publisher= Publishers[1],
                Authors=new[]{Authors[3]},
                PageCount=1205,
                Price = 35.5,
                PublicationDate=new DateTime(2005,5,5),
                isbn="0-333-7777-2",
                Subject=Subjects[1]
            },
                new Book 
            {
                Title = "Bonjour mon Amour",
                Publisher=Publishers[0],
                Authors=new[]{Authors[1],Authors[2]},
                PageCount=50,
                Price = 29,
                PublicationDate=new DateTime(1973,2,18),
                isbn="2-444-7777-2",
                Subject=Subjects[0]
            },
        };
    }
}
