using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS9908R_App
{
    public class VinculacionRequest
    {
        public string CodigoBarras { get; set; }
        public string Rfid { get; set; }
        public string HojaMarcacion { get; set; }
        public string CodTrabajador { get; set; }
        public string Empresa { get; set; }
    }
}
