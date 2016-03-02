using System.Web.Http.ModelBinding;
using Nop.Plugin.Api.ModelBinders;

namespace Nop.Plugin.Api.Models.CustomersParameters
{
    [ModelBinder(typeof(ParametersModelBinder<CustomerParametersModel>))]
    public class CustomerParametersModel : BaseParametersModel
    {
         public int Id { get; set; }
    }
}