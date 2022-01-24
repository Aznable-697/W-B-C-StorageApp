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
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Gandalf" });
            employeeRepository.Add(new Employee { FirstName = "Joey" });
            employeeRepository.Save();

            Console.WriteLine($"-------------------------------------");

            var organizationRepository = new GenericRepository<Organization>();
            organizationRepository.Add(new Organization { Name = "Pluralsight" });
            organizationRepository.Add(new Organization { Name = "SomeCoffeeBeanPlace" });
            organizationRepository.Add(new Organization { Name = "The Business" });
            organizationRepository.Save();


            Console.ReadLine();

        }
    }
}
