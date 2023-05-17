using Microsoft.EntityFrameworkCore;
using SchoolMVC.Models;

namespace SchoolMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<CourseList> CourseLists { get; set; }
        public DbSet<ClassList> ClassLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // ONLY ACTIVATE IN DEVELOPMENT
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Enable sensitive data logging
        //    optionsBuilder.EnableSensitiveDataLogging();
        //}

        protected internal void Seed()
        {
            // If there's no Teachers in the db then these will be added
            if (!Teachers.Any())
            {
                var teachList = new List<Teacher>
                {
                    new Teacher
                    {
                        FirstName = "Tobias",
                        LastName = "Landén",
                        Email = "Tobias.L@email.com"
                    },
                    new Teacher
                    {
                        FirstName = "Reidar",
                        LastName = "Nilsen",
                        Email = "Reidar.N@email.com"
                    },
                    new Teacher
                    {
                        FirstName = "Anna",
                        LastName = "Lunder",
                        Email = "Anna.L@email.com"
                    },
                    new Teacher
                    {
                        FirstName = "Kristian",
                        LastName = "Gustavsson",
                        Email = "Kristian.G@email.com"
                    }
                };

                Teachers.AddRange(teachList);
                SaveChanges();
            }

            // If there's no Students in the db then these will be added
            if (!Students.Any())
            {
                var studList = new List<Student>
                {
                    new Student
                    {
                        FirstName = "Emily",
                        LastName = "Garcia",
                        Email = "emily.garcia@email.com"
                    },
                    new Student
                    {
                        FirstName = "Jacob",
                        LastName = "Lee",
                        Email = "jacob.lee@email.com"
                    },
                    new Student
                    {
                        FirstName = "Sophia",
                        LastName = "Nguyen",
                        Email = "sophia.nguyen@email.com"
                    },
                    new Student
                    {
                        FirstName = "Max",
                        LastName = "Kumar",
                        Email = "max.kumar@email.com"
                    },
                    new Student
                    {
                        FirstName = "Ava",
                        LastName = "Wong",
                        Email = "ava.wong@email.com"
                    },
                    new Student
                    {
                        FirstName = "Ethan",
                        LastName = "Zhang",
                        Email = "ethan.zhang@email.com"
                    },
                    new Student
                    {
                        FirstName = "Mia",
                        LastName = "Kim",
                        Email = "mia.kim@email.com"
                    },
                    new Student
                    {
                        FirstName = "William",
                        LastName = "Singh",
                        Email = "william.singh@email.com"
                    },
                    new Student
                    {
                        FirstName = "Isabella",
                        LastName = "Patel",
                        Email = "isabella.patel@email.com"
                    },
                    new Student
                    {
                        FirstName = "James",
                        LastName = "Huang",
                        Email = "james.huang@email.com"
                    },
                    new Student
                    {
                        FirstName = "Olivia",
                        LastName = "Sharma",
                        Email = "olivia.sharma@email.com"
                    },
                    new Student
                    {
                        FirstName = "Benjamin",
                        LastName = "Gupta",
                        Email = "benjamin.gupta@email.com"
                    },
                    new Student
                    {
                        FirstName = "Emma",
                        LastName = "Singhania",
                        Email = "emma.singhania@email.com"
                    },
                    new Student
                    {
                        FirstName = "Lucas",
                        LastName = "Rao",
                        Email = "lucas.rao@email.com"
                    },
                    new Student
                    {
                        FirstName = "Avery",
                        LastName = "Tran",
                        Email = "avery.tran@email.com"
                    },
                    new Student
                    {
                        FirstName = "Jackson",
                        LastName = "Das",
                        Email = "jackson.das@email.com"
                    },
                    new Student
                    {
                        FirstName = "Charlotte",
                        LastName = "Chen",
                        Email = "charlotte.chen@email.com"
                    },
                    new Student
                    {
                        FirstName = "Alexander",
                        LastName = "Desai",
                        Email = "alexander.desai@email.com"
                    },
                    new Student
                    {
                        FirstName = "Sofia",
                        LastName = "Parekh",
                        Email = "sofia.parekh@email.com"
                    },
                    new Student
                    {
                        FirstName = "Logan",
                        LastName = "Mehta",
                        Email = "logan.mehta@email.com"
                    }
                };

                Students.AddRange(studList);
                SaveChanges();
            }

            // If there's no SchoolClasses in the db then these will be added
            if (!SchoolClasses.Any())
            {
                var schList = new List<SchoolClass>
                {
                    new SchoolClass 
                    {
                        ClassName = "NET22",
                        Description = "Systemutvecklare .NET - 2022"
                    },
                    new SchoolClass 
                    {
                        ClassName = "ITSEC22",
                        Description = "IT-säkerhet - 2022"
                    },
                    new SchoolClass 
                    {
                        ClassName = "ASP23",
                        Description = "Systemutvecklare .ASP - 2023"
                    }
                };

                SchoolClasses.AddRange(schList);
                SaveChanges();
            }

            // If there's no Courses in the db then these will be added
            if (!Courses.Any())
            {
                var courList = new List<Course>
                {
                    new Course 
                    {
                        CourseName = "Programmering 1",
                        Description = "Grunderna i programmering" 
                    },
                    new Course
                    {
                        CourseName = "Programmering 2",
                        Description = "Fortsättningskurs"
                    },
                    new Course
                    {
                        CourseName = "OOP",
                        Description = "Objektorienterad programmering"
                    },
                    new Course
                    {
                        CourseName = "AI",
                        Description = "Grunderna i AI"
                    },
                    new Course
                    {
                        CourseName = "Databaser",
                        Description = "SQL och NoSQL databaser"
                    },
                };

                Courses.AddRange(courList);
                SaveChanges();
            }
            // Otherwise nothing will be added and nothing will be returned
            else
            {
                return;
            }
        }
    }
}
