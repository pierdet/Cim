using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.Models
{
    public class ConnectionValidationResponse
    {
        public string Connection { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
