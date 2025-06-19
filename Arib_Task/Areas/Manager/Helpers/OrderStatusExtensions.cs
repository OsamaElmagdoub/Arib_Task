using Arib_Task.Areas.Admin.Enums;

namespace Arib_Task.Areas.Admin.Helpers
{
    public static class OrderStatusExtensions
    {
        private static readonly Dictionary<OrderStatus, string> _arabicLabels = new()
        {
            { OrderStatus.Pending, "قيد الانتظار" },
            { OrderStatus.Contacted, "تم التواصل" },
            { OrderStatus.Preparing, "جاري التجهيز" },
            { OrderStatus.Shipped, "تم الشحن" },
            { OrderStatus.Delivered, "تم التوصيل" },
            { OrderStatus.Cancelled, "تم الإلغاء" }
        };

        public static string ToArabic(this OrderStatus status)
        {
            return _arabicLabels.TryGetValue(status,out var label )  ? label : status.ToString();
        }

    }
}
