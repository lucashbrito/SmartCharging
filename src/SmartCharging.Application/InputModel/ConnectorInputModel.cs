using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class ConnectorInputModel
    {
        public int MaxCurrentAmps { get;  set; }
        public string ChargeStationId { get;  set; }
    }
}
