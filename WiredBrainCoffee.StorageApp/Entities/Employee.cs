namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; } // string? = property can be Null**

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
