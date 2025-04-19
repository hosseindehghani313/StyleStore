public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}