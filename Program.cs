using System;
using System.Collections.Generic;

namespace demoConsoleApp
{

    class Program
    {

        static void Main(string[] args)
        {
            Member mem1 = new Member();
            mem1.FirstName = "Dat";
            mem1.LastName = "Le";
            mem1.Gender = "male";
            mem1.Dob = new DateTime(2001, 01, 01);
            mem1.Phone = 098;
            mem1.BirthPlace = "Ha Noi";
            mem1.IsGraduated = false;
            mem1.StartDate = new DateTime(2015, 01, 01);
            mem1.EndDate = new DateTime(2021, 02, 11);

            Member mem2 = new Member();
            mem2.FirstName = "Huan";
            mem2.LastName = "Bui";
            mem2.Gender = "male";
            mem2.Dob = new DateTime(1998, 01, 01);
            mem2.Phone = 098;
            mem2.BirthPlace = "Lao Cai";
            mem2.IsGraduated = false;
            mem2.StartDate = new DateTime(2015, 01, 01);
            mem2.EndDate = new DateTime(2021, 02, 11);


            Member mem3 = new Member();
            mem3.FirstName = "Trang";
            mem3.LastName = "Bui";
            mem3.Gender = "male";
            mem3.Dob = new DateTime(2000, 09, 12);
            mem3.Phone = 0981345641;
            mem3.BirthPlace = "Duong Noi";
            mem3.IsGraduated = false;
            mem3.StartDate = new DateTime(2015, 01, 01);
            mem3.EndDate = new DateTime(2021, 02, 11);

            Member mem4 = new Member();
            mem4.FirstName = "Viet";
            mem4.LastName = "Vu";
            mem4.Gender = "female";
            mem4.Dob = new DateTime(1999, 01, 01);
            mem4.Phone = 098234941;
            mem4.BirthPlace = "Ha Noi";
            mem4.IsGraduated = false;
            mem4.StartDate = new DateTime(2015, 01, 01);
            mem4.EndDate = new DateTime(2021, 02, 11);

            Member mem5 = new Member();
            mem5.FirstName = "Thu";
            mem5.LastName = "Nguyen";
            mem5.Gender = "female";
            mem5.Dob = new DateTime(1989, 11, 23);
            mem5.Phone = 0981234941;
            mem5.BirthPlace = "Ha Nam";
            mem5.IsGraduated = false;
            mem5.StartDate = new DateTime(2015, 01, 01);
            mem5.EndDate = new DateTime(2021, 02, 11);

            List<Member> members = new List<Member>(){
                mem1,mem2,mem3,mem4,mem5
            };



            System.Console.WriteLine("Please chose the function:");
            System.Console.WriteLine("1: Return the list of members who is male.");
            System.Console.WriteLine("2: Return the oldest member base on 'Age'.");
            System.Console.WriteLine("3: Return a new list that contains Full Name only.");
            System.Console.WriteLine("4: More function.");
            System.Console.WriteLine("5: Return the first people who was born in 'Ha Noi'.");

            string selection = Console.ReadLine();

            switch (int.Parse(selection))
            {
                case 1:
                    SortGender(members);
                    break;
                case 2:
                    FilterOldest(members);
                    break;

                case 3:
                    FullNameList(members);
                    break;

                case 4:
                    SubMenu(members);

                    break;
                case 5:
                    FilterHaNoian(members);

                    break;
                default:
                    break;
            }
        }

        public static void SubMenu(List<Member> members)
        {
            System.Console.WriteLine("Please chose the function:");
            System.Console.WriteLine("1: Return the list of members who has birth year is 2000.");
            System.Console.WriteLine("2: Return the list of members who has birth year > 2000.");
            System.Console.WriteLine("3: Return the list of members who has birth year < 2000.");
            System.Console.WriteLine("4: Back.");
            string selection = Console.ReadLine();
            switch (int.Parse(selection))
            {
                case 1:
                    FilterYearOfBirth(members, "equal");
                    break;
                case 2:
                    FilterYearOfBirth(members, "greater");
                    break;
                case 3:
                    FilterYearOfBirth(members, "less");
                    break;
                default:
                    break;
            }
        }

        static void SortGender(List<Member> list)
        {
            List<int> agesArray = new List<int>();
            //Member who is male
            foreach (var member in list)
            {
                if (member.Gender == "male")
                {
                    Console.WriteLine(member.FirstName);
                }
            }
        }

        static void FilterOldest(List<Member> list)
        {
            List<int> agesArray = new List<int>();

            foreach (var member in list)
            {
                var age = CalculateAge(member.Dob);
                agesArray.Add(age);
                // Console.WriteLine(age);
            }
            int oldest = FindMaxAge(agesArray);
            Console.WriteLine($"The oldest Age is : {oldest} year old");
        }

        static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                age = age - 1;

            return age;
        }
        static int FindMaxAge(List<int> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int maxAge = int.MinValue;
            foreach (int type in list)
            {
                if (type > maxAge)
                {
                    maxAge = type;
                }
            }
            return maxAge;
        }

        static void FullNameList(List<Member> list)
        {
            foreach (var member in list)
            {
                System.Console.WriteLine($"{member.FirstName} {member.LastName}");
            }
        }
        static void FilterHaNoian(List<Member> list)
        {
            foreach (var member in list)
            {
                if (member.BirthPlace == "Ha Noi")
                {
                    System.Console.WriteLine(member.FirstName);
                }
            }
        }
        static void FilterYearOfBirth(List<Member> list, string condition)
        {
            switch (condition)
            {
                case "equal":
                foreach (var item in list)
                {
                    if (item.Dob.Year == 2000)
                    {
                        System.Console.WriteLine(item.FirstName);
                    }
                    
                }
                    break;
                case "greater":
                foreach (var item in list)
                {
                    if (item.Dob.Year < 2000)
                    {
                        System.Console.WriteLine(item.FirstName);
                    }
                }
                    break;
                case "less":
                foreach (var item in list)
                {
                    if (item.Dob.Year > 2000)
                    {
                        System.Console.WriteLine(item.FirstName);
                    }
                }
                    break;
                default:
                    break;
            }
        }
    }
}
