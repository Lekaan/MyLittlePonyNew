using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittlePonyNew.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string Author { get; set; }

        public BlogPost(int ID, string Title, string Content, DateTime CreateDate, string Author)
        {
            this.ID = ID;
            this.Title = Title;
            this.Content = Content;
            this.CreateDate = CreateDate;
            this.Author = Author;
        }
    }
}
