using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ.Exercises
{
    /// <summary>
    /// These tests require the combination of various linq methods to arrive at a solution.
    /// </summary>

    [TestClass]
    public class CombinedOperations
    {
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names

        // Hint: try to use set operations.
        // There are many ways to solve this.
        [TestMethod]
        public void GetCharactersCommonToEveryonesFirstNamesUsingSetElements_ReturnCharEnumerable()
        {
          //  List<char> commonCharacters = new List<char>(); // please edit/complete so that the test passes

            var  commonCharacters = new List<char>();

            commonCharacters = TestData.People.Select(p => p.FirstName).Aggregate(commonCharacters, (charTillnow, newFirstName) =>
            charTillnow.Intersect(newFirstName).ToList()
            );

            Assert.IsTrue(commonCharacters.OrderBy(x => x).SequenceEqual(new char[] { 'J' }.OrderBy(x => x)));
        }

        // Bonus Question
        // we have a list of people
        // we have their first names
        // i need you to find out which letters are common
        // to all the first names names
        // But you are not allowed to use set operations.
        [TestMethod]
        public void GetCharactersCommonToEveryonesFirstNamesNotUsingSetOperations_ReturnCharEnumerable()
        {
            IEnumerable<char> result = new List<char>();

            Assert.IsTrue(result.OrderBy(x => x).SequenceEqual(new char[] { 'J' }.OrderBy(x => x)));
        }

        // we have a list of employees (TestData.Employees)
        // we have a list of departments (TestData.Departments)
        // i need you to return a list of departments with the average of employees salaries
        [TestMethod]
        public void GetSalaryAveragePerDepartment()
        {
            // var result = new [] {new {DepartmentName = "", AverageSalary = 0m}}; // please edit/complete so that the test passes

            var result = TestData.Departments.GroupJoin(TestData.Employees,
                t => t.DepartmentId,
                e => e.DepartmentId,
                (Depart, Employee) => new
                {
                    DepartmentName = Depart.Name,
                    AverageSalary = Employee.Average(e => e.Salary)
                }
                ) ;

            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep1").AverageSalary == 1900m);
            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep2").AverageSalary == 700m);
            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep3").AverageSalary == 400m);
        }

        // Bonus Question
        // we have a list of employees
        // we have a list of departments
        // i need you to return a list of departments with the average of employees salaries
        // you are required to use group join
        [TestMethod]
        public void GetSalaryAveragePerDepartmentUsingGropJoin()
        {
         //   var result = new[] { new { DepartmentName = "", AverageSalary = 0m } }; // please edit/complete so that the test passes

            var result = TestData.Departments.GroupJoin(TestData.Employees,
                t => t.DepartmentId,
                e => e.DepartmentId,
                (Depart, Employee) => new
                {
                    DepartmentName = Depart.Name,
                    AverageSalary = Employee.Average(e => e.Salary)
                }
                ) ;

            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep1").AverageSalary == 1900m);
            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep2").AverageSalary == 700m);
            Assert.IsTrue(result.Single(d => d.DepartmentName == "Dep3").AverageSalary == 400m);
        }
    }
}
