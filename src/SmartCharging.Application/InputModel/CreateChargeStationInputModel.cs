using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCharging.Application.InputModel
{
    public class CreateChargeStationInputModel
    {        
        public string Name { get; set; }
        public IList<CreateConnectorInputModel> Connectors { get; set; }
    }
}
