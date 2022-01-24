using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository); //error ListRepository not SqlRepository
            GetEmpployeeById(employeeRepository); //error ListRepository not SqlRepository
           

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();

        }

        private static void GetEmpployeeById(ListRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(ListRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Gandalf" });
            employeeRepository.Add(new Employee { FirstName = "Joey" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(ListRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "SomeCoffeeBeanPlace" });
            organizationRepository.Add(new Organization { Name = "The Business" });
            organizationRepository.Save();
        }
    }
}
