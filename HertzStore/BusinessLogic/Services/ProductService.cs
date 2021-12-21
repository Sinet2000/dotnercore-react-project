using BusinessLogic.DAL;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(IDataContext dataContext) : base(dataContext)
        {
        }
    }

    public interface IProductService : IBaseService<Product>
    {

    }
}
