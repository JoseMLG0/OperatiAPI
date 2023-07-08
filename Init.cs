using OperatiAPI.Context;
using OperatiAPI.Models;

namespace OperatiAPI
{
    public static class Init
    {
        public static void Seed(this OperatiContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User
                {
                    FullName = "Jose Manuel Landero Gonzalez",
                    Email = "j-m-l-g@hotmail.com",
                    Pass = "Pass1"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
