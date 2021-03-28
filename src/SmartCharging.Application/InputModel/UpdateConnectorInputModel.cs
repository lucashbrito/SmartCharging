using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class UpdateConnectorInputModel
    {
        public string ChargeStationId { get; set; }
        public int MaxCurrentAmps { get; set; }
    }
}
