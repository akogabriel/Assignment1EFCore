using Core.DataAccess;
using Core.Entities;

namespace Assignment1EFCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userRepo = new Repo<User>();   //Initialize the repository for User

            using (var context = new DataContext())
            {
                context.Database.EnsureCreated();   //Ensure the database is created and apply migrations
            }

            TestDatabase(userRepo);  //Test database CRUD operations

        }

        // Method to list all users
        public static void ListAllUsers(Repo<User> userRepo)
        {
            var users = userRepo.GetAll();
            Console.WriteLine("List of Users:");
            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.EmailAddress}, Phone: {user.PhoneNumber}");
            }
            Console.WriteLine();
        }

        // Method to add a new user
        public static void AddUser(Repo<User> userRepo, string name, string email, string phone)
        {
            var newUser = new User { Name = name, EmailAddress = email, PhoneNumber = phone };
            userRepo.Create(newUser);
            Console.WriteLine($"Added new user: {name}");
        }

        // Method to update an existing user
        public static void UpdateUser(Repo<User> userRepo, int userId, string newName, string newEmail, string newPhone)
        {
            var user = userRepo.Read(userId);
            if (user != null)
            {
                user.Name = newName;
                user.EmailAddress = newEmail;
                user.PhoneNumber = newPhone;
                userRepo.Update(user);
                Console.WriteLine($"Updated user ID {userId}");
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found.");
            }
        }

        // Method to delete a user
        public static void DeleteUser(Repo<User> userRepo, int userId)
        {
            var user = userRepo.Read(userId);
            if (user != null)
            {
                userRepo.Delete(userId);
                Console.WriteLine($"Deleted user ID {userId}");
            }
            else
            {
                Console.WriteLine($"User ID {userId} not found.");
            }
        }

        public static void TestDatabase(Repo<User> userRepo)
        {
            // Initial list of users
            ListAllUsers(userRepo);

            // Add a new user
            AddUser(userRepo, "Alice Johnson", "alice@example.com", "111-222-3333");
            ListAllUsers(userRepo);

            // Update an existing user
            var user = userRepo.GetAll().FirstOrDefault(u => u.Name == "Alice Johnson");
            if (user != null)
            {
                UpdateUser(userRepo, user.Id, "Alice Brown", "alice.brown@example.com", "222-333-4444");
                ListAllUsers(userRepo);
            }

            // Delete the user
            if (user != null)
            {
                DeleteUser(userRepo, user.Id);
                ListAllUsers(userRepo);
            }
        }
    }
}
