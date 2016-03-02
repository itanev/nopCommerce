namespace Nop.Plugin.Api.Models.CustomersParameters
{
    public class CustomerParametersModel
    {
        public CustomerParametersModel()
        {
            Fields = string.Empty;
        }

        public int Id { get; set; }
        public string Fields { get; set; }
    }
}