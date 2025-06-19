using Arib_Task.Areas.Manager.ViewModels.DepartmentViewModels;
using Arib_Task.Areas.Manager.ViewModels.EmployeeViewModel;
using Arib_Task.Models;
using AutoMapper;

namespace Arib_Task.Mapping_Proile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Department
            CreateMap<Department,AddDepartmentViewModel>().ReverseMap();

            CreateMap<Employee, AddEmployeeViewModel>().ReverseMap();

            //CreateMap<Product, CreateProductViewModel>().ReverseMap();
            //CreateMap<CreateProductDTO, CreateProductViewModel>().ReverseMap();

            //CreateMap<EditProductViewModel, Product>().ReverseMap();


            //        CreateMap<Product, ProductDetailsViewModel>()
            //.ForMember(dest => dest.VideoEmbedUrl, opt => opt.MapFrom(src => "https://www.youtube.com/embed/vgFVhIwmmU4"));


            //        CreateMap<Product, ProductDetailsViewModel>()
            //.ForMember(dest => dest.VideoEmbedUrl, opt => opt.MapFrom(src => src.VideoUrl != null ? YouTubeHelper.ConvertYouTubeUrlToEmbed(src.VideoUrl) : null))
            //.ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageUrl).ToList()));

            //        CreateMap<Product, ProductDetailsViewModel>()
            //.ForMember(dest => dest.VideoEmbedUrl,
            //    opt => opt.MapFrom(src =>
            //        string.IsNullOrWhiteSpace(src.VideoUrl)
            //        ? null
            //        : YouTubeHelper.ConvertYouTubeUrlToEmbed(src.VideoUrl)))
            //.ForMember(dest => dest.ImageUrls,
            //    opt => opt.MapFrom(src =>
            //        src.Images != null
            //        ? src.Images.Select(i => i.ImageUrl).ToList()
            //        : new List<string>()));




            //        //        CreateMap<Product, ProductListItemViewModel>()
            //        //.ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageUrl)));

            //        // Category

            //        CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            //        CreateMap<CreateCategoryDTO, CreateCategoryViewModel>().ReverseMap();
            //        CreateMap<CreateCategoryViewModel, Category>().ReverseMap();
            //        CreateMap<EditCategoryViewModel, Category>().ReverseMap();


            //        CreateMap<CartItem, CartItemDTO>()
            //            .ForMember(dest => dest.ProductName,
            //            opt => opt.MapFrom(src => src.Product.Name))
            //             .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price));

            //        CreateMap<CartItem, CartItemViewModel>()
            //            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            //            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Product.Price))
            //            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Product.Images != null && src.Product.Images.Any() ? src.Product.Images.First().ImageUrl : null));



            //        CreateMap<Cart, CartDTO>()
            //   .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));

            //        CreateMap<Cart, CartViewModel>()
            //            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.CartItems));

            //        CreateMap<Order, OrderDetailsViewModel>()
            //            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.OrderItems))
            //            .ForMember(dest => dest.OrderStatusArabic, opt => opt.MapFrom(src => src.OrderStatus.ToString()));

            //        CreateMap<OrderItem, OrderItemViewModel>()
            //.ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.Id))
            //.ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
            //.ForMember(dest => dest.ImageUrl,
            //           opt => opt.MapFrom(src =>
            //               src.Product.Images != null && src.Product.Images.Any()
            //                   ? src.Product.Images.First().ImageUrl
            //                   : null))
            //.ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
            //.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            //.ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Quantity * src.Price));


            //        CreateMap<Product, ProductListItemViewModel>()
            //            .ForMember(dest => dest.ImageUrls, opt => opt.MapFrom(src => src.Images.Select(i => i.ImageUrl).ToList()))
            //            .ForMember(dest => dest.DisplayPrice, opt => opt.MapFrom(src => src.Price));
        }
    }
}
