using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            AddEmployees(employeeRepository);
            GetEmpployeeById(employeeRepository);
           

            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();

        }

        private static void GetEmpployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Gandalf" });
            employeeRepository.Add(new Employee { FirstName = "Joey" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "SomeCoffeeBeanPlace" });
            organizationRepository.Add(new Organization { Name = "The Business" });
            organizationRepository.Save();
        }
    }
}
