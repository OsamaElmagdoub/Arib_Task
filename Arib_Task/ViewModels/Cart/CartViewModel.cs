namespace Arib_Task.ViewModels.Cart
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; }
        public decimal TotalPrice => Items?.Sum(item => item.Price * item.Quantity) ?? 0;
    }
}
