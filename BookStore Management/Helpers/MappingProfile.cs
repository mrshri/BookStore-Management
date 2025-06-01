using AutoMapper;
using BookStore_Management.ModelDtos;
using BookStore_Management.ModelDtos.BookDtos;
using BookStore_Management.ModelDtos.CartDto;
using BookStore_Management.ModelDtos.CategoryDtos;
using BookStore_Management.ModelDtos.OrderDto;
using BookStore_Management.Models;

namespace BookStore_Management.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            

            // Book
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateBookDto, Book>();
            CreateMap<UpdateBookDto, Book>();

            // Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            // Cart
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Book.Price));

            // Order
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<CreateOrderDto, Order>();
            CreateMap<CreateOrderItemDto, OrderItem>();



        }

    }
}
