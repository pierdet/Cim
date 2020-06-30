using Cim.Lib.Models;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cim.Lib.Net
{
    public class ConnectionValidator : IConnectionValidator, IDisposable
    {
        private readonly Ping _pinger;
        public ConnectionValidator()
        {
            _pinger = new Ping();
        }

        public ConnectionValidationResponse Validate(string connection)
        {
            try
            {
                var reply = _pinger.Send(connection, 1000);

                if (reply == null)
                {
                    return new ConnectionValidationResponse
                    {
                        Connection = connection,
                        Success = false,
                        ErrorMessage = "could not receive a reply"
                    };
                }

                return new ConnectionValidationResponse
                {
                    Connection = connection,
                    Success = reply.Status == IPStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ConnectionValidationResponse
                {
                    Connection = connection,
                    Success = false,
                    ErrorMessage = $"unexpected error occurred: {e.Message}"
                };
            }
        }
        private async Task<ConnectionValidationResponse> ValidateAsync(string hostName)
        {
            try
            {
                var reply = await _pinger.SendPingAsync(hostName, 1000);

                if (reply == null)
                {
                    return new ConnectionValidationResponse
                    {
                        Connection = hostName,
                        Success = false,
                        ErrorMessage = "could not receive a reply"
                    };
                }

                return new ConnectionValidationResponse
                {
                    Connection = hostName,
                    Success = reply.Status == IPStatus.Success
                };
            }
            catch (Exception e)
            {
                return new ConnectionValidationResponse
                {
                    Connection = hostName,
                    Success = false,
                    ErrorMessage = $"unexpected error occurred: {e.Message}"
                };
            }
        }

        public async Task<IEnumerable<ConnectionValidationResponse>> ValidateParallelAsync(List<string> hostNames)
        {
            var tasks = new List<Task<ConnectionValidationResponse>>();
            var instance = new ConnectionValidator();
            foreach (var hostName in hostNames)
            {
                tasks.Add(Task.Run(() => instance.Validate(hostName)));
            }
            // TODO fix, result is null
            var result = await Task.WhenAll(tasks);
            return new List<ConnectionValidationResponse>(result);
        }
        public void Dispose()
        {
            _pinger.Dispose();
        }
    }
}
