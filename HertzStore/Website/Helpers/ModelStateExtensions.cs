using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Linq;

namespace Website.Helpers
{
    public static class ModelStateExtensions
    {
        public static IEnumerable ExtreactModelErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList();
        }
    }
}
