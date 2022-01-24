namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; } // string? = property can be Null**

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}";
    }
}
