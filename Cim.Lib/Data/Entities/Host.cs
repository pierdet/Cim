namespace Cim.Lib.Data.Entities
{
    public class Host
    {
        public int HostId { get; set; }
        public string HostName { get; set; }
        
        // foreign Key
        public int InventoryId { get; set; }
        
        // Navigation Property
        public Inventory Inventory { get; set; }
    }
}
