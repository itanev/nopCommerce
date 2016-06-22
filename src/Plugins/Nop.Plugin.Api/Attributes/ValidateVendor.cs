﻿using System.Collections.Generic;
using Nop.Core.Domain.Vendors;
using Nop.Core.Infrastructure;
using Nop.Services.Vendors;

namespace Nop.Plugin.Api.Attributes
{
    public class ValidateVendor : BaseAttributeInvoker
    {
        private Dictionary<string, string> _errors;

        private IVendorService _vendorService;

        private IVendorService VendorService
        {
            get
            {
                if (_vendorService == null)
                {
                    _vendorService = EngineContext.Current.Resolve<IVendorService>();
                }

                return _vendorService;
            }
        }

        public ValidateVendor()
        {
            _errors = new Dictionary<string, string>();
        }

        public override void Invoke(object instance)
        {
            int vendorId = 0;

            if (int.TryParse(instance.ToString(), out vendorId))
            {
                Vendor vendor = VendorService.GetVendorById(vendorId);

                if (vendor == null)
                {
                    _errors.Add("Invalid vendor id", "Non existing vendor");
                }
                // TODO: validate that the vendorId is an existing vendor.
            }
            // The type validation happens in the model binder automatically so we don't need to set an error here.
        }

        public override Dictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}