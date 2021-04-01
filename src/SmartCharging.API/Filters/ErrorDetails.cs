using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace SmartCharging.Api.Filters
{
    public class ErrorDetails
    {
        public int StatusCode { get; internal set; }
        public string Message { get; internal set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
