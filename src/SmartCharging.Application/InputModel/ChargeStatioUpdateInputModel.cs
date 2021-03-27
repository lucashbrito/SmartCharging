using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class ChargeStatioUpdateInputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<ConnectorInputModel> Connectors { get; set; }
    }
}
