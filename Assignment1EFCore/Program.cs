using Core;

namespace Assignment1EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DataContext())
            {

                var users = new[]
                {
                    new User { Name = "Malik Prince", EmailAddress = "malik@example.com", PhoneNumber = "123-456-7890" },
                    new User { Name = "Jane Boston", EmailAddress = "jane@example.com", PhoneNumber = "987-654-3210" },
                    new User { Name = "Bob Jonah", EmailAddress = "bob@example.com", PhoneNumber = "555-555-5555" }
                };
                context.Users.AddRange(users);
                context.SaveChanges();



                var blogTypes = new[]
                {
                new BlogType { Status = "Active", Name = "Tech", Description = "Technology Blogs" },
                new BlogType { Status = "Active", Name = "Lifestyle", Description = "Lifestyle Blogs" }
                };
                context.BlogTypes.AddRange(blogTypes);
                context.SaveChanges();

                
                var postTypes = new[]
                {
                new PostType { Status = "Published", Name = "Article", Description = "Article Post" },
                new PostType { Status = "Draft", Name = "Tutorial", Description = "Tutorial Post" }
                };
                context.PostTypes.AddRange(postTypes);
                context.SaveChanges();


                //create a new blog
                var blog = new Blog { Url = "http://example.com", IsPublic = true, BlogTypeId = 1 };
                context.Blogs.Add(blog);
                context.SaveChanges();

                // Add a post tied to one of the users
                var post = new Post
                {
                    Title = "First Post",
                    Content = "This is the content of the first post.",
                    BlogId = blog.Id,
                    PostTypeId = postTypes.First().Id,
                    UserId = users.First().Id
                };

                //Add the post to the Post table
                context.Posts.Add(post);
                context.SaveChanges();
            }
            
        }
    }
}
