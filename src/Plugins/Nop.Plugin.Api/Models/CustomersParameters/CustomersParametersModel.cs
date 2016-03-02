using System.Web.Http.ModelBinding;
using Nop.Plugin.Api.ModelBinders;

namespace Nop.Plugin.Api.Models.CustomersParameters
{
    [ModelBinder(typeof(ParametersModelBinder<CustomersParametersModel>))]
    public class CustomersParametersModel : BaseParametersModelWithPaging
    {
        public CustomersParametersModel()
        {
            SinceId = 0;
            CreatedAtMin = string.Empty;
            CreatedAtMax = string.Empty;
        }
        
        public int SinceId { get; set; }
        public string CreatedAtMin { get; set; }
        public string CreatedAtMax { get; set; }
    }
}