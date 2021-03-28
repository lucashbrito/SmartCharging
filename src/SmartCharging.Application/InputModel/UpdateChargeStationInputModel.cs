using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class UpdateChargeStationInputModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<UpdateConnectorInputModel> Connectors { get; set; }
    }
}
