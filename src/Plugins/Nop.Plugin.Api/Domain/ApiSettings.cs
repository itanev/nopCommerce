﻿using Nop.Core.Configuration;

namespace Nop.Plugin.Api.Domain
{
    public class ApiSettings : ISettings
    {
        public bool EnableApi { get; set; }
    }
}