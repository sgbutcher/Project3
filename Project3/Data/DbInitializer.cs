using Project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            var locations = new Location[]
            {
            new Location{Name="Drawer One Cabnet One"}
            };
            foreach (Location s in locations)
            {
                context.Location.Add(s);
            }
            context.SaveChanges();

            var goal = new Goal[]
            {
            new Goal{Name="My Goal"}
            };
            foreach (Goal s in goal)
            {
                context.Goal.Add(s);
            }
            context.SaveChanges();

            var beda = new Bedaprogram[]
            {
            new Bedaprogram{Name="Example Program"}
            };
            foreach (Bedaprogram s in beda)
            {
                context.Bedaprogram.Add(s);
            }
            context.SaveChanges();

            var advisors = new Advisor[]
            {
            new Advisor{FirstName="Sample", LastName="Advisor"}
            };
            foreach (Advisor s in advisors)
            {
                context.Advisor.Add(s);
            }
            context.SaveChanges();

            var students = new Student[]
            {
            new Student{FirstName="Example",LastName="Student",PhoneNumber="555-555-5555", Email="winter@blazer.net", Intake=DateTime.Parse("6/27/2017"), Registration=DateTime.Parse("9/1/2017"), SID="000-00-0000" }
            };
            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();

        }
    }
}
