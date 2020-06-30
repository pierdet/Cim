using Cim.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cim.Lib.Net
{
    public interface IConnectionValidator
    {
        public ConnectionValidationResponse Validate(string hostName);
        public Task<IEnumerable<ConnectionValidationResponse>> ValidateParallelAsync(List<string> hostNames);
    }
}
