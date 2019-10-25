using System;
using System.Collections.Generic;

namespace LINQ.Exercises
{
    /// <summary>
    /// Data used for tests.
    /// Don't change it in any way, order and content of each test data set is important.
    /// </summary>
    internal static class TestData
    {
        internal static IEnumerable<int> Numbers
        {
            get
            {
                return new[] { 1, -3, 1, -1, 2, -4, 3, -1, 5, -5 };
            }
        }

        internal static ICollection<string> Animals
        {
            get
            {
                return new[] { "tiger", "lion", "swordfish", "penguin", "elephant", "shark" };
            }
        }

        internal static IList<Person> People
        {
            get
            {
                return new[]
                {
                    new Person("Jack", "Tuck", new DateTime(1990, 3, 12)),
                    new Person("Jean", "Gean", new DateTime(1950, 12, 1)),
                    new Person("Jill", "Lill", new DateTime(2001, 5, 21)),
                    new Person("Jimmy", "Jilly", new DateTime(1974, 9, 16)),
                };
            }
        }

        internal class Person
        {
            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public DateTime Born { get; private set; }

            public Person(string firstname, string lastname, DateTime born)
            {
                this.FirstName = firstname ?? string.Empty;
                this.LastName = lastname ?? string.Empty;
                this.Born = born;
            }

            public override string ToString()
            {
                return string.Format("{{ {0} {1}; {2:yyyy-MM-dd} }}", FirstName, LastName, Born);
            }

            public override int GetHashCode()
            {
                // overflow is fine
                unchecked
                {
                    int hash = 17;
                    // test data should never be null
                    hash = hash * 23 + FirstName.GetHashCode();
                    hash = hash * 23 + LastName.GetHashCode();
                    hash = hash * 23 + Born.GetHashCode();
                    return hash;
                }
            }

            public override bool Equals(Object obj)
            {
                Person person = obj as Person;
                if (person == null)
                {
                    return false;
                }

                return FirstName.Equals(person.FirstName) && LastName.Equals(person.LastName) && Born.Equals(person.Born);
            }
        }

        /// <summary>
        /// The following Data was using for the partioning Tests
        /// </summary>
        ///
        internal static IEnumerable<int> PartitionNumbers
        {
            get
            {
                return new int[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            }
        }

        /// <summary>
        /// The following Data was using for the Orderby Tests
        /// </summary>
        ///

        internal static IEnumerable<string> OrderByWords
        {
            get { return new string[] { "cherry", "apple", "blueberry" }; }
        }

        internal static IEnumerable<string> OrderByWordsExtended
        {
            get { return new string[] { "cherry", "apple", "blueberry", "tamarind", "zuchini" }; }
        }

        /// <summary>
        /// Additional employee exercises
        /// </summary>
        ///

        internal static IEnumerable<Employee> Employees
        {
            get
            {
                return new List<Employee>
                {
                    new Employee {EmployeeId = 1, DepartmentId = 1, FirstName = "Andy", LastName = "Doyle",
                        Country = "USA", EmploymentDate = new DateTime(2018, 1, 1),
                        Salary = 1800},
                    new Employee {EmployeeId = 2, DepartmentId = 1, FirstName = "David", LastName = "Brown",
                        Country = "USA", EmploymentDate = new DateTime(2018, 2, 1),
                        Salary = 2000},
                    new Employee {EmployeeId = 3, DepartmentId = 2, FirstName = "Mihai", LastName = "Popescu",
                        Country = "Romania", EmploymentDate = new DateTime(2017, 5, 1),
                        Salary = 700},
                    new Employee {EmployeeId = 4, DepartmentId = 3, FirstName = "Andrei", LastName = "Moraru",
                        Country = "Moldova", EmploymentDate = new DateTime(2018, 6, 10),
                        Salary = 450},
                    new Employee {EmployeeId = 5, DepartmentId = 3, FirstName = "Valeriu", LastName = "Busuioc",
                        Country = "Moldova", EmploymentDate = new DateTime(2018, 6, 10),
                        Salary = 350}
                };
            }
        }

        internal static IEnumerable<Department> Departments
        {
            get
            {
                return new List<Department>
                {
                    new Department {DepartmentId = 1, Name = "Dep1"},
                    new Department {DepartmentId = 2, Name = "Dep2"},
                    new Department {DepartmentId = 3, Name = "Dep3"}
                };
            }
        }

        public class Employee
        {
            public int EmployeeId { get; set; }
            public int DepartmentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime EmploymentDate { get; set; }
            public decimal Salary { get; set; }
        }

        public class Department
        {
            public int DepartmentId { get; set; }
            public string Name { get; set; }
        }
    }
}