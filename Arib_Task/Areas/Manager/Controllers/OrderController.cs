//using AutoMapper;
//using Arib_Task.Areas.Admin.Enums;
//using Arib_Task.Areas.Admin.Helpers;
//using Arib_Task.Areas.Admin.ViewModels.OrderViewModels;
//using Arib_Task.Models;
//using Arib_Task.Services.InvoicePdfServices;
//using Arib_Task.Services.OrderServices;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace Arib_Task.Areas.Admin.Controllers
//{
//    [Area("Admin")]
//    public class OrderController : Controller
//    {
//        private readonly IOrderService _orderService;
//        private readonly IInvoicePdfService _invoicePdfService;
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly IMapper _mapper;

//        public OrderController(IOrderService orderService,IInvoicePdfService invoicePdfService,UserManager<ApplicationUser> userManager,IMapper mapper)
//        {
//            _orderService = orderService;
//            _invoicePdfService = invoicePdfService;
//            _userManager = userManager;
//            _mapper = mapper;
//        }

//        public IActionResult OrderConfirmation()
//        {
//            return View();
//        }
//        // أكشن لعرض جميع الطلبات
//        public async Task<IActionResult> AllOrders()
//        {
//            var orders = await _orderService.GetAllOrders();
//            return View(orders);  // عرض الطلبات في الـ View
//        }

//        //public async Task<IActionResult> OrderDetails()
//        //{
//        //    var 
//        //}

//        [HttpPost]

//        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus newStatus)
//        {
//            var order = await _orderService.GetOrderById(orderId);

//            if (order == null)
//            {
//                return NotFound();
//            }
//            if (order.OrderStatus != newStatus)

//            {
//                await _orderService.UpdateOrderStatus(order.Id, newStatus);

//            }

//            return RedirectToAction(nameof(AllOrders));
//        }

//        public async Task<IActionResult> OrderDetails(int id)
//        {
//            var order = await _orderService.GetOrderDetails(id);
//            if (order == null)
//                return NotFound();
//            return View(order);
//        }

//        public async Task<IActionResult> Invoice(int id)
//        {
//            var order = await _orderService.GetOrderById(id);
//            if(order == null)
//            {
//                return NotFound();
//            }
//            var viewModel = _mapper.Map<OrderDetailsViewModel>(order);

//            return View(viewModel);
//        }
//        //DinkToPdf
//        public async Task<IActionResult> DownloadInvoice(int id)
//        {
//            var orderViewModel = await _orderService.GetOrderDetails(id);
//            if (orderViewModel == null) return NotFound();

//            // إنشاء الـ HTML من الفاتورة

//            string html = await this.RenderViewAsync(nameof(Invoice), orderViewModel, true);

//            var pdfBytes = _invoicePdfService.GeneratePdfFromHtml(html);

//            return File(pdfBytes, "application/pdf", $"فاتورة_طلب_{id}.pdf");

//        }

//        //HtmlRenderer.PdfSharp

//        //public async Task<IActionResult> DownloadInvoice(int id)
//        //{
//        //    var orderViewModel = await _orderService.GetOrderDetails(id);
//        //    if (orderViewModel == null)
//        //        return NotFound();

//        //    // ✅ عرض View كامل (لأنه يحتوي على HTML كامل)
//        //    string fullHtml = await this.RenderViewAsync(nameof(Invoice), orderViewModel, isPartial: false);

//        //    // ✅ توليد PDF
//        //    var pdfBytes = _invoicePdfService.GeneratePdfFromHtml(fullHtml);

//        //    // ✅ تجهيز اسم الملف
//        //    var fileName = $"فاتورة_طلب_{id}.pdf";
//        //    fileName = Uri.EscapeDataString(fileName);

//        //    return File(pdfBytes, "application/pdf", fileName);
//        //}

//        public async Task<IActionResult> MyOrders()
//        {
//            var userId = _userManager.GetUserId(User);

//            var orders = await _orderService.GetOrdersByUserId(userId);
//            return View(orders);
//        }
//    }
//}
