using System;
using System.Collections.Generic;
using _08_Inheritence_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_Inheritence_Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void SetName_ShouldSetName()
        {
            Person person = new Person();
            person.SetFirstName("gary");
            person.PhoneNumber = "8675309";

            Customer customer = new Customer();
            customer.IsPremium = true;
            customer.SetFirstName("wallid");

            SalaryEmployee salaryEmployee = new SalaryEmployee()
            {
                Salary = 80000,
                HireDate = new DateTime(1979, 3, 30)
            };
            Console.WriteLine(salaryEmployee.YearsWithCompany);


        }

        [TestMethod]
        public void CustomerIsPremium_ShouldBePremium()
        {
            Customer customer = new Customer();
            customer.IsPremium = true;

            Assert.IsTrue(customer.IsPremium);
        }

        [TestMethod]
        public void EmployeeTests()
        {
            Employee emp = new Employee();
            HourlyEmployee he = new HourlyEmployee();
            SalaryEmployee se = new SalaryEmployee();
            emp.SetFirstName("george");
            he.HoursPerWeek = 54;
            se.Salary = 40;
            List<Employee> allEmps = new List<Employee>();
            allEmps.Add(emp);
            allEmps.Add(he);
            allEmps.Add(se);
            foreach (Employee worker in allEmps)
            {
                if (worker.GetType() == typeof(SalaryEmployee))
                {
                    //worker is of type employee as of looping through the list, so to get the salary, it must be typecast into a new variable.
                    SalaryEmployee sEmployee = (SalaryEmployee)worker;
                    Console.WriteLine(sEmployee.Salary);
                }
            }
        }
    }
}
