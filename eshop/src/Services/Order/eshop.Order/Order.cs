namespace eshop.Order
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsApproved { get; set; } = true;
        public string Description { get; set; }

    }
}
