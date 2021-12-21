using Website.ViewModels.ProductVM;

namespace Website.ModelFactories
{
    public class ProductFormViewModelFactory : IProductFormViewModelFactory
    {
        // DI can be used there
        public ProductFormViewModelFactory()
        {
        }

        //public ProductFormViewModel InitProductFormViewModel()
        //{
        //    // there can be retrieved suppliers
        //    // var suppliers = ...
        //    return new ProductFormViewModel(suppliers)
        //}
    }

    public interface IProductFormViewModelFactory
    {
        // ProductFormViewModel InitProductFormViewModel();
    }
}
