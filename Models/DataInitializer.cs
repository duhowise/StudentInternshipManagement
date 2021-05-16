using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Models
{
    public class DataInitializer: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(Models.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Teacher"));
            roleManager.Create(new IdentityRole("Student"));

            var user = new ApplicationUser
            {
                UserName = "ADS19A00153Y",
                Email = "duhowise@gmail.com"
            };
            userManager.Create(user, "qwerty123");

            userManager.AddToRole(user.Id, "Student");

            var user2 = new ApplicationUser
            {
                UserName = "ADS19A00152Y",
                Email = "duhowise+second@gmail.com"
            };
            userManager.Create(user2, "qwerty123");

            userManager.AddToRole(user2.Id, "Student");

            userManager.AddToRole(user2.Id, "Student");

            var user3 = new ApplicationUser
            {
                UserName = "20134713",
                Email = "20134713@yopmail.com"
            };
            userManager.Create(user3, "qwerty123");

            userManager.AddToRole(user3.Id, "Student");

            var user4 = new ApplicationUser
            {
                UserName = "20133847",
                Email = "20133847@yopmail.com"
            };
            userManager.Create(user4, "qwerty123");

            userManager.AddToRole(user4.Id, "Student");

            var user5 = new ApplicationUser
            {
                UserName = "20132820",
                Email = "20132820@yopmail.com"
            };
            userManager.Create(user5, "qwerty123");

            userManager.AddToRole(user5.Id, "Student");

            var user6 = new ApplicationUser
            {
                UserName = "20132231",
                Email = "20132231@yopmail.com"
            };
            userManager.Create(user6, "qwerty123");

            userManager.AddToRole(user6.Id, "Student");

            var user7 = new ApplicationUser
            {
                UserName = "20130707",
                Email = "20130707@yopmail.com"
            };
            userManager.Create(user7, "qwerty123");

            userManager.AddToRole(user7.Id, "Student");

            var user8 = new ApplicationUser
            {
                UserName = "20132558",
                Email = "20132558@yopmail.com"
            };
            userManager.Create(user8, "qwerty123");

            userManager.AddToRole(user8.Id, "Student");

            var user9 = new ApplicationUser
            {
                UserName = "20134579",
                Email = "20134579@yopmail.com"
            };
            userManager.Create(user9, "qwerty123");

            userManager.AddToRole(user9.Id, "Student");

            var user10 = new ApplicationUser
            {
                UserName = "TrungLD",
                Email = "TrungLD@yopmail.com"
            };

            userManager.Create(user10, "qwerty123");

            userManager.AddToRole(user10.Id, "Teacher");

            var user12 = new ApplicationUser
            {
                UserName = "Admin",
                Email = "Admin@yopmail.com"
            };

            userManager.Create(user12, "qwerty123");
            userManager.AddToRole(user12.Id, "Admin");

            var semesters = new List<Semester>
            {
                new Semester()
                {
                    SemesterId = 20182,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            };

            foreach (var item in semesters)
            {
                context.Semesters.Add(item);
            }

            var departments = new List<Department>
            {
                new Department()
                {
                    DepartmentName = "ASDASS"
                }
            };

            foreach (var item in departments)
            {
                context.Departments.Add(item);
            }

            var studenClasses = new List<StudentClass>
            {
                new StudentClass()
                {
                    ClassName = "Networking101",
                    Department = departments[0]
                },
                new StudentClass()
                {
                    ClassName = "DATABASE102",
                    Department = departments[0]
                },
                new StudentClass()
                {
                    ClassName = "Electronics103",
                    Department = departments[0]
                }
            };

            foreach (var item in studenClasses)
            {
                context.StudentClasses.Add(item);
            }

            var students = new List<Student>
            {
                new Student()
                {
                    StudentId = "20131070",
                    StudentName = "Duhp Dance",
                    Avatar = "20131070.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0123456789",
                    Cpa = 3.0f,
                    Program = "Computer Science",
                    Class = studenClasses[0]
                },
                new Student()
                {
                    StudentId = "20130325",
                    StudentName = "Student Again",
                    Avatar = "20131070.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0123456789",
                    Cpa = 3.0f,
                    Program = "Computer Science",
                    Class = studenClasses[0]
                },
                new Student()
                {
                    StudentId = "20131071",
                    StudentName = "Third Dance",
                    Avatar = "20131070.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0123456789",
                    Cpa = 3.0f,
                    Program = "Computer Science",
                    Class = studenClasses[0]
                },
                new Student()
                {
                    StudentId = "20130324",
                    StudentName = "Student Fourth",
                    Avatar = "20131070.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0123456789",
                    Cpa = 3.0f,
                    Program = "Computer Science",
                    Class = studenClasses[0]
                }
            };

            foreach (var item in students)
            {
                context.Students.Add(item);
            }

            var admins = new List<Admin>
            {
                new Admin()
                {
                    AdminId = "Admin",
                    AdminName = "Admin 1",
                    Avatar = "avatar.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0241566985",
                    Department = departments[0]
                }
            };

            foreach (var item in admins)
            {
                context.Admins.Add(item);
            }

            var teachers = new List<Teacher>
            {
                new Teacher()
                {
                    TeacherId = "1230456",
                    TeacherName = "SUper Od",
                    Avatar = "avatar.png",
                    Address = "MK",
                    BirthDate = new DateTime(1995, 5, 14),
                    Phone = "0123456789",
                    Department = departments[0]
                }
            };

            foreach (var item in teachers)
            {
                context.Teachers.Add(item);
            }

            var subjects = new List<Subject>
            {
                new Subject()
                {
                    SubjectId = "IT101",
                    SubjectName = "INFORMATION TECHNOLOGY",
                    Department = departments[0]
                },
                new Subject()
                {
                    SubjectId = "IT102",
                    SubjectName = "INFORMATION TECHNOLOGY II",
                    Department = departments[0]
                }
            };

            foreach (var item in subjects)
            {
                context.Subjects.Add(item);
            }

            var learningClasses = new List<LearningClass>
            {
                new LearningClass()
                {
                    ClassName = "IT101 - 1",
                    Subject = subjects[0],
                    Semester = semesters[0]
                },
                new LearningClass()
                {
                    ClassName = "IT102 - 1",
                    Subject = subjects[0],
                    Semester = semesters[0]
                }
            };

            foreach (var item in learningClasses)
            {
                context.LearningClasses.Add(item);
            }

            var learningClassStudents = new List<LearningClassStudent>
            {
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                },
                new LearningClassStudent
                {
                    Class = learningClasses[0],
                    Student = students[0]
                }
            };

            foreach (var item in learningClassStudents)
            {
                context.LearningClassStudents.Add(item);
            }

            var majors = new List<TrainingMajor>
            {
                new TrainingMajor()
                {
                    TrainingMajorName = "C",
                    Subject = subjects[0]
                },
                new TrainingMajor()
                {
                    TrainingMajorName = "Java",
                    Subject = subjects[0]
                },
                new TrainingMajor()
                {
                    TrainingMajorName = "Dev",
                    Subject = subjects[0]
                },
                new TrainingMajor()
                {
                    TrainingMajorName = "Tester",
                    Subject = subjects[0]
                }
            };

            foreach (var item in majors)
            {
                context.TrainingMajors.Add(item);
            }

            var companies = new List<Company>
            {
                new Company()
                {
                    CompanyName = "Amazon",
                    CompanyDescription = "FPT",
                    Address = "17 Duy tan",
                    Email = "Amazon@Amazonmail.com",
                    Phone = "0123456789"
                },
                new Company()
                {
                    CompanyName = "Microsoft",
                    CompanyDescription = "MISA",
                    Address = "Microsoft address",
                    Email = "Microsoft@Microsoftmail.com",
                    Phone = "0123456789"
                },
                new Company()
                {
                    CompanyName = "NETFLIX",
                    CompanyDescription = "BKAV",
                    Address = "NETFLIX road",
                    Email = "NETFLIX@NETFLIXmail.com",
                    Phone = "0123456789"
                }
            };

            foreach (var item in companies)
            {
                context.Companies.Add(item);
            }

            var companyMajors = new List<CompanyTrainingMajor>
            {
                new CompanyTrainingMajor()
                {
                    Company = companies[0],
                    TrainingMajor = majors[0],
                    AvailableTraineeCount = 10,
                    TotalTraineeCount = 10
                },
                new CompanyTrainingMajor()
                {
                    Company = companies[0],
                    TrainingMajor = majors[0],
                    AvailableTraineeCount = 10,
                    TotalTraineeCount = 10
                },
                new CompanyTrainingMajor()
                {
                    Company = companies[0],
                    TrainingMajor = majors[0],
                    AvailableTraineeCount = 5,
                    TotalTraineeCount = 5
                },
                new CompanyTrainingMajor()
                {
                    Company = companies[0],
                    TrainingMajor = majors[0],
                    AvailableTraineeCount = 5,
                    TotalTraineeCount = 5
                },
                new CompanyTrainingMajor()
                {
                    Company = companies[0],
                    TrainingMajor = majors[0],
                    AvailableTraineeCount = 5,
                    TotalTraineeCount = 5
                }
            };

            foreach (var item in companyMajors)
            {
                context.CompanyTrainingMajors.Add(item);
            }

            var internships = new List<Internship>
            {
                new Internship()
                {
                    RegistrationDate = DateTime.Now,
                    Status = InternshipStatus.Registered,
                    Student = students[0],
                    Class = learningClasses[0],
                    Major = companyMajors[0]
                },
                new Internship()
                {
                    RegistrationDate = DateTime.Now,
                    Status = InternshipStatus.Registered,
                    Student = students[0],
                    Class = learningClasses[0],
                    Major = companyMajors[0]
                },
                new Internship()
                {
                    RegistrationDate = DateTime.Now,
                    Status = InternshipStatus.Registered,
                    Student = students[0],
                    Class = learningClasses[0],
                    Major = companyMajors[0]
                },
                new Internship()
                {
                    RegistrationDate = DateTime.Now,
                    Status = InternshipStatus.Registered,
                    Student = students[0],
                    Class = learningClasses[0],
                    Major = companyMajors[0]
                }
            };

            foreach (var item in internships)
            {
                context.Internships.Add(item);
            }


            var news = new List<News>
            {
                new News()
                {
                    Title = "Initial News ",
                    Content = "We are settings up",
                    Time = DateTime.Now
                }
            };

            foreach (var item in news)
            {
                context.Newses.Add(item);
            }

            base.Seed(context);
        }

    }
}
