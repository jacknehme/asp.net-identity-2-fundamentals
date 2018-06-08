using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity2Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = "jack@jack.com";
            var password = "Password123!";

            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            var creationResult = userManager.Create(new IdentityUser("jack@jack.com"), "Password123!");
            Console.WriteLine("Created: {0}", creationResult.Succeeded);
            Console.Read();

            var user = userManager.FindByName(username);
            var claimResult = userManager.AddClaim(user.Id, new Claim("given_name", "Jack"));
            Console.WriteLine("Claim: {0}", claimResult.Succeeded);
            Console.Read();

            var isMatch = userManager.CheckPassword(user, password);
            Console.WriteLine("Password Match: {0}", isMatch);

        }
    }
}
