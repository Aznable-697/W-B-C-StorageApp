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

            IReadRepository<object> repo = new ListRepository<Organization>();
      
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
            employeeRepository.Add(new Employee { FirstName = "John" });
            employeeRepository.Add(new Employee { FirstName = "Gandalf" });
            employeeRepository.Add(new Employee { FirstName = "Joey" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization {Name = "Pliralsight"},
                new Organization { Name = "SomeCoffeeBeanPlace" },
                new Organization { Name = "The Business" }
            };
            AddBatch(organizationRepository, organizations);
            
        }

        private static void AddBatch(IRepository<Organization> organizationRepository, Organization[] organizations)
        {
            foreach (var item in organizations)
            {
                organizationRepository.Add(item);
            }
            organizationRepository.Save();
        }
    }
}
