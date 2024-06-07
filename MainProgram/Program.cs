using Assignment1EFCore;
using Core;

namespace MainProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {

                // create 3 users
                var firstUser = new User { Name = "Malik Prince", EmailAddress = "malik@example.com", PhoneNumber = "123-456-7890" };
                var secondUser = new User { Name = "Jane Boston", EmailAddress = "jane@example.com", PhoneNumber = "987-654-3210" };
                var thirdUser = new User { Name = "Bob Jonah", EmailAddress = "bob@example.com", PhoneNumber = "555-555-5555" };

                //add users to the User table
                context.Users.Add(firstUser);
                context.Users.Add(secondUser);
                context.Users.Add(thirdUser);

                //create 2 blog types and add to BlogType table
                var firstBlogType = new BlogType { Status = "Active", Name = "Tech", Description = "Technology Blogs" };
                var secondBlogType = new BlogType { Status = "Active", Name = "Lifestyle", Description = "Lifestyle Blogs" };

                context.BlogTypes.Add(firstBlogType);
                context.BlogTypes.Add(secondBlogType);

                //create 2 post types and add to PostType table
                var firstPostType = new PostType { Status = "Published", Name = "Article", Description = "Article Post" };
                var secondPostType = new PostType { Status = "Draft", Name = "Tutorial", Description = "Tutorial Post" };

                context.PostTypes.Add(firstPostType);
                context.PostTypes.Add(secondPostType);

                //create a new blog
                var blog = new Blog { Url = "http://example.com", IsPublic = true, BlogTypeId = 1 };
                context.Blogs.Add(blog);

                // Add a post tied to one of the users
                var post = new Post
                {
                    Title = "First Post",
                    Content = "This is the content of the first post.",
                    BlogId = blog.Id,
                    PostTypeId = firstPostType.Id,
                    UserId = firstUser.Id,
                };

                //Add the post to the Post table
                context.Posts.Add(post);

                //Save all changes
                context.SaveChanges();
            }
    }
}
