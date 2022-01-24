namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string? Name { get; set; } // string? = property can be Null**

        public override string ToString() => $"Id: {Id}, FirstName: {Name}";
    }
}
