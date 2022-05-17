namespace ShopASP.Models.ModelForPartialView
{
    public class Customer_with_orders
    {
        public int orderId { get; set; }
        public string customerSurname{ get; set; }
        public string customerId { get; set; }
        public string productName { get; set; }
        public decimal productCost { get; set; }
        public int productQuantity { get; set; }
    }
}