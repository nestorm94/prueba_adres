using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ms_adquisicion.model
{
    public class ResultVoid
    {
        public ResultVoid() {
            description= string.Empty;
            operation= string.Empty;

        }

        public string description { get; set; }
        public string operation { get; set; }

    }
}
