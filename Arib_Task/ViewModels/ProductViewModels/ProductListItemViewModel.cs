namespace Arib_Task.ViewModels.ProductViewModels
{
    public class ProductListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Description { get; set; }

        //public string ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();

        // وإذا حابب تعرض أول صورة فقط
        //public string FirstImageUrl => ImageUrls.FirstOrDefault();
        public decimal? DisplayPrice { get; set; } // إما السعر العادي أو أقل سعر من المقاسات
        public string CategoryName { get; set; }
        public bool HasSizes { get; set; }
    }
}
