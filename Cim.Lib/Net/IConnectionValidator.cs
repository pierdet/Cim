using Cim.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cim.Lib.Net
{
    public interface IConnectionValidator
    {
        public ConnectionValidationResponse Validate(string hostName);
        //Todo Implement ValidateParallel
    }
}
