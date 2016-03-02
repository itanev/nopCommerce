using Nop.Plugin.Api.MVC;

namespace Nop.Plugin.Api.Models.CustomersParameters
{
    public class BaseParametersModelWithPaging : BaseParametersModel
    {
        public BaseParametersModelWithPaging()
        {
            Limit = Configurations.DefaultLimit;
            Page = Configurations.DefaultPageValue;
        }

        public byte Limit { get; set; }
        public int Page { get; set; }
    }
}