using System.Web.Http.ModelBinding;
using Nop.Plugin.Api.ModelBinders;

namespace Nop.Plugin.Api.Models.CustomersParameters
{
    [ModelBinder(typeof(ParametersModelBinder<CustomersSearchParametersModel>))]
    public class CustomersSearchParametersModel : BaseParametersModelWithPaging
    {
        public CustomersSearchParametersModel()
        {
            Order = "Id";
            Query = "";
        }

        public string Order { get; set; }
        public string Query { get; set; }
    }
}