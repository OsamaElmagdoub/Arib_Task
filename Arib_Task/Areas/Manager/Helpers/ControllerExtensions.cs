using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Arib_Task.Areas.Admin.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<string> RenderViewAsync<TModel>(
            this Controller controller,
            string viewName,
            TModel model,
            bool isPartial = false
            )
        {
            // جهز الموديل
             controller.ViewData.Model = model;

            using var writer = new StringWriter();
            // جبنا الـ View Engine
            var viewEngine = controller.HttpContext.RequestServices
                .GetRequiredService<ICompositeViewEngine>();
            // جبنا الـ View
            var viewResult = viewEngine.FindView(controller.ControllerContext, viewName, !isPartial);

            if(!viewResult.Success)
                throw new Exception($"View '{viewName}' not found.");

            // جهز السياق
            var viewContext = new ViewContext(
            controller.ControllerContext,
            viewResult.View,
            controller.ViewData,
            controller.TempData,
            writer,
            new HtmlHelperOptions()
        );
            // اعرض الـ View كـ HTML
            await viewResult.View.RenderAsync(viewContext);
            return writer.ToString();

        }
    }
}
