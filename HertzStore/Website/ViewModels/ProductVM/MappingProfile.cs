using BusinessLogic.Models;
using System;
using Website.ViewModels.Mapping;

namespace Website.ViewModels.ProductVM
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.CreateDate, o => o.ResolveUsing<DateToFormattedStringResolver, DateTime?>(s => s.CreateDate));

            CreateMap<ProductDTO, Product>();

            CreateMap<ProductFormViewModel, Product>();
        }
    }
}
