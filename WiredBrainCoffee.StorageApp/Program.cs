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

            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmpployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);


            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

           

            Console.ReadLine();

        }


        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Garfield" });
            managerRepository.Add(new Manager { FirstName = "Winne" });
            managerRepository.Save();

        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmpployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                 new Employee { FirstName = "John"},
                 new Employee { FirstName = "Gandalf"},
                 new Employee { FirstName = "Joey"},
            };

            employeeRepository.AddBatch(employees);

        }   

    private static void AddOrganizations(IRepository<Organization> organizationRepository)
    {
        var organizations = new[]
        {
                new Organization { Name = "Pluralsight"},
                new Organization { Name = "SomeCoffeeBeanPlace" },
                new Organization { Name = "The Business" }
            };
        organizationRepository.AddBatch(organizations);

    }
}
   
}

