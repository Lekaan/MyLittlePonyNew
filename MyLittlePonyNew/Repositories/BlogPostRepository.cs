using MyLittlePonyNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittlePonyNew.Repositories
{
    public class BlogPostRepository
    {
        public static List<BlogPost> blogList = new List<BlogPost>();
        private static int _idCounter = 0;
        private static BlogPostRepository instance;

        private BlogPostRepository() { }
        
        public static BlogPostRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BlogPostRepository();
                    instance.LoadBlogPosts();
                }
                return instance;
            }
        }

        private void LoadBlogPosts()
        {
            blogList.Add(new BlogPost(++_idCounter, "Blog post 1", "Content of blog post 1 goes here", DateTime.Now, "Jan"));
            blogList.Add(new BlogPost(++_idCounter, "Blog post 2", "Content of blog post 2 goes here", DateTime.Now, "Jonas"));
            blogList.Add(new BlogPost(++_idCounter, "Blog post 3", "Content of blog post 3 goes here", DateTime.Now, "Jan"));
            blogList.Add(new BlogPost(++_idCounter, "Blog post 4", "Content of blog post 4 goes here", DateTime.Now, "Simon"));
            blogList.Add(new BlogPost(++_idCounter, "Blog post 5", "Content of blog post 5 goes here", DateTime.Now, "Bjørk"));
        }

        public List<BlogPost> ReturnPostByAuthor(string author)
        {
            return blogList.Where(b => b.Author == author).ToList();
        }
        public List<BlogPost> GetAllPosts()
        {
            return blogList;
        }

        public void CreatePost(string title, string content, string author)
        {
            blogList.Add(new BlogPost(++_idCounter, title, content, DateTime.Now, author));
        }
        public void CreatePost(BlogPost post)
        {
            blogList.Add(post);
        }
    }
}
