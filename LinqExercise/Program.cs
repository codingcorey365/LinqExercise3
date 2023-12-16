using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Question #1.
            //Done:
            //1. Print the Sum of numbers

            //Method Syntax
            var sum = numbers.Sum();

            //Query syntax
            var sumQuery = (from n in numbers
                            select n).Sum();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 1.\n");

            Console.WriteLine($"The sum of the Method Syntax is {sum}");
            Console.WriteLine($"The sum of the Query Syntax is {sumQuery}");

            //Question #2.
            //Done:
            //2. Print the Average of numbers

            //Method Syntax
            var average = numbers.Average();
            //Query syntax
            var averageQuery = (from n in numbers
                                select n).Average();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 2.\n");
            Console.WriteLine($"The average of the Method Syntax is {average}");            
            Console.WriteLine($"The Query Syntax is {averageQuery}");

            //Question #3.
            //Done:
            //3. Order numbers in ascending order and print to the console

            //Method Syntax
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 3.\n");
            Console.Write("The numbers in ascending order with the Method Syntax are ...");
            var sorted = numbers.OrderBy(n => n);
            foreach (var number in sorted)
            {
                Console.Write($" {number}, ");
            }
            

            //Query syntax
            Console.Write("\nThe numbers in ascending order with the Query Syntax are ...");
            var sortedQuery = (from n in numbers
                               where n >= 0
                               orderby n
                               select n);
            foreach (var number in sortedQuery)
            {
                Console.Write($" {number}, ");
            }


            //Question #4.
            //Done:
            //Order numbers in descending order and print to the console

            //Method Syntax
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("\nQuestion 4.\n");
            Console.Write("The numbers in descending order with the Method Syntax are ...");
            var sortedDescending = numbers.OrderByDescending(n => n);
            foreach (var number in sortedDescending)
            {
                Console.Write($" {number}, ");
            }
            
            //Query syntax            
            Console.Write("\nThe numbers in descending order with the Query Syntax are ...");
            var sortedDescendingQuery = (from n in numbers
                                         where n >= 0
                                         orderby n descending
                                         select n);
            foreach (var number in sortedDescendingQuery)
            {
                Console.Write($" {number}, ");
            }

            //Question #5.
            //Done:
            //5. Print to the console only the numbers greater than 6

            //Method Syntax
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("\nQuestion 5.\n");
            Console.WriteLine("This is numbers greater than six with Method Syntax");
            var greaterThanSix = numbers.Where(n => n > 6);
            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }            

            //Query syntax            
            Console.WriteLine("This is numbers greater than six with Query Syntax");
            var greaterThanSixQuery = (from n in numbers
                                       where n > 6
                                       select n);
            foreach (var number in greaterThanSixQuery)
            {
                Console.WriteLine(number);
            }

            //Question #6.
            //Done:
            //6. Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            //Method Syntax
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 6.\n");
            Console.WriteLine("This is numbers greater than two with Method Syntax, ascending by 4 integers");
            var greaterThanTwoAscending = numbers.Where(n => n > 2 && n < 7);
            foreach (var number in greaterThanTwoAscending)
            {
                Console.WriteLine(number);
            }

            //Query syntax            
            Console.WriteLine("This is numbers less than nine with Query Syntax, descending by 4 integers");
            var lessThanNineQueryDescending = (from n in numbers
                                               where n < 9 && n > 4
                                               orderby n descending
                                               select n);
            foreach (var number in lessThanNineQueryDescending)
            {
                Console.WriteLine(number);
            }

            //Question #7.
            //Done:
            //7. Change the value at index 4 to your age, then print the numbers in descending order
            //Add a new value to int array and index 4, can ask a user for this info.

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 7.\n");
            Console.WriteLine("Enter in your age in numeric format. Example \"35\"\n");
            int result;
            var userAge = int.TryParse(Console.ReadLine(), out result);
            numbers[4] = result;
            Console.WriteLine($"You entered in your age as the value of {result}.\n");
            

            //Method Syntax            
            Console.Write("The numbers in descending order with the Method Syntax are ... ");
            var sortedDescendingIndex4 = numbers.OrderByDescending(n => n);
            foreach (var number in sortedDescendingIndex4)
            {
                Console.Write($" {number}, ");
            }
            

            //Query syntax            
            Console.Write("\nThe numbers in descending order with the Query Syntax are ... ");
            var sortedDescendingIndex4Query = (from n in numbers
                                               where n >= 0
                                               orderby n descending
                                               select n);
            foreach (var number in sortedDescendingIndex4Query)
            {
                Console.Write($" {number}, ");
            }

            /* ---------------------------------- List of employees -------- Do not remove this -------------------------- */
            /* ----------------------------------------------------------------------------------------------------------- */
            /* ----------------------------------------------------------------------------------------------------------- */
            var employees = CreateEmployees();
            /* ----------------------------------------------------------------------------------------------------------- */
            /* ----------------------------------------------------------------------------------------------------------- */


            //Question #8.
            //Done:
            //8. Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            //Method Syntax
            Console.WriteLine("\n---------------------------------------");
            Console.WriteLine("\nQuestion 8.\n");
            bool StartsWithCorS(char c)
            {
                return c is 'c' or 's';
            }

            var list = employees.Where(employee => StartsWithCorS(employee.FirstName.ToLower()[0]))
               .OrderBy(employee => employee.FirstName)
               .Select(employee => employee.FullName);

            Console.WriteLine("This is a list in ascending order using Method Syntax for full names where the first name starts with c or s.\n");
            
            foreach (var name in list)
            {
                Console.WriteLine(name);
            }

            //Query syntax            
            var employeeByFirstName = (from employee in employees
                                       where StartsWithCorS(employee.FirstName.ToLower()[0])
                                       orderby employee.FirstName
                                       select employee.FullName);

            Console.WriteLine("\nThis is a list in ascending order using Query Syntax for full names where the first name starts with c or s.\n");
            
            foreach (var name in employeeByFirstName)
            {
                Console.WriteLine(name);
            }
            
            //Question #9.
            //Done:
            //9. Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            //Method Syntax 1
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 9.\n");
            Console.WriteLine("This is a list in ascending order using Method Syntax for full names where the employee is older than 26 ordered by age of employee then by first name.\n");
            var listByAgeOver26ByAge = employees.Where( employee => employee.Age > 26)
               .OrderBy(employee => employee.Age)
               .ThenBy(employee => employee.FirstName)
               .Select(employee => new { employee.FullName, employee.Age });// ask how this works and why you need the new keyword            
            
            foreach (var employee in listByAgeOver26ByAge)
            {
                Console.WriteLine($"My name is {employee.FullName} and I am {employee.Age} years old.");
            }

            //Query syntax            
            Console.WriteLine("\nThis is a list in ascending order using Query Syntax for full names where the employee is older than 26 ordered by age of employee then by first name.\n");
            var listByAgeOver26ByAgeQuery =  from employee in employees
                                             where employee.Age > 26
                                             orderby employee.Age , employee.FirstName        
                                             select new { employee.FullName, employee.Age };//ask why you need the new keyword

            foreach (var employee in listByAgeOver26ByAgeQuery)
            {
                Console.WriteLine($"My name is {employee.FullName} and I am {employee.Age} years old.");
            }
            
            //Question #10.
            //Done:
            //10. Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //Method Syntax

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 10.\n");
            Console.WriteLine("This is the sum of the years of experience for workers older than 35 and whom are new to the industry with less that 10 years of experience with Method Syntax.");
            var sumYearsOfExperience = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            int sumYOE = 0;
            foreach(var employee in sumYearsOfExperience)
            {
                sumYOE += employee.YearsOfExperience;
            }            
            Console.WriteLine($"\t - The total sum of years of experience for newer employees whom are older than 35 is  {sumYOE} years of experience with Method Syntax.\n");

            //Query syntax
            Console.WriteLine("This is the sum of the years of experience for workers older than 35 and whom are new to the industry with less that 10 years of experience with Query Syntax.");
            var sumYearsOfExperienceQuery = from employee in employees
                                            where employee.YearsOfExperience <= 10 && employee.Age > 35
                                            select employee;
            int sumYOEQuery = 0;
            foreach (var employee in sumYearsOfExperienceQuery)
            {
                sumYOEQuery += employee.YearsOfExperience;
            }
            Console.WriteLine($"\t - The total sum of years of experience for newer employees whom are older than 35 is  {sumYOEQuery} years of experience with Query Syntax.");

            //Question #11.
            //Done:
            //11. Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            //Method Syntax

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 11.\n");
            Console.WriteLine("The average years of experience for workers older than 35 " +
                              "and whom are new to the industry with less that 10 years of experience " +
                              "with Method Syntax.");
            var averageYearsOfExperience = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            var listOfGroupOlderThan35AndLessThan10YOE = new List<int>();
            foreach (var employee in averageYearsOfExperience)
            {
                listOfGroupOlderThan35AndLessThan10YOE.Add(employee.YearsOfExperience);
            }            
            Console.WriteLine($"\t - The average years of experience for newer employees whom are older than 35" +
                $" is {String.Format("{0:0.00}", listOfGroupOlderThan35AndLessThan10YOE.Average())} years of experience with Method Syntax.\n");
            //Query syntax
            Console.WriteLine("The average years of experience for workers older than 35 " +
                              "and whom are new to the industry with less that 10 years of experience " +
                              "with Method Syntax.");
            var averageYearsOfExperienceQuery = from employee in employees
                                                where employee.YearsOfExperience <= 10 && employee.Age > 35
                                                select employee;

            var listOfGroupOlderThan35AndLessThan10YOEQuery = new List<int>();
            foreach (var employee in averageYearsOfExperienceQuery)
            {
                listOfGroupOlderThan35AndLessThan10YOEQuery.Add(employee.YearsOfExperience);
            }
            Console.WriteLine($"\t - The average years of experience for newer employees whom are older than 35" +
                $" is {String.Format("{0:0.00}", listOfGroupOlderThan35AndLessThan10YOEQuery.Average())} years of experience with Method Syntax.\n");
            //Question #12.
            //Done:
            // 12. Add an employee to the end of the list without using employees.Add()

            //Method Syntax
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("\nQuestion 12.\n");
            var corey = new Employee("Corey", "Schroeder", 33, 0);
            Console.WriteLine("This is a list with a new employee appended to the end of the list with Method Syntax.\n");
            var appendedList =employees.Append(corey).ToList();
            foreach (var employee in appendedList)
            {
                Console.WriteLine($"First name {employee.FirstName} Last Name: {employee.LastName} Age {employee.Age} Years of service {employee.YearsOfExperience} ");
            }
            //Query syntax
            Console.WriteLine("\nThis is a list with a new employee appended to the end of the list with Method Syntax.\n");
            var appendedListQuery = employees.Append(corey).ToList();
            foreach (var employee in appendedListQuery)
            {
                Console.WriteLine($"First name {employee.FirstName} Last Name: {employee.LastName} Age {employee.Age} Years of service {employee.YearsOfExperience} ");
            }
            Console.WriteLine("---------------------------------------");
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
