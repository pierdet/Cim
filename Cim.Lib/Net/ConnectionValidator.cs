using Cim.Lib.Data.Entities;
using Cim.Lib.Models;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cim.Lib.Net
{
    public class ConnectionValidator : IConnectionValidator
    {
        public ConnectionValidationResponse Validate(string connection)
        {
            var pinger = new Ping();
            try
            {
                var reply = pinger.Send(connection, 1000);

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
            finally
            {
                pinger.Dispose();
            }
        }
        private async Task<ConnectionValidationResponse> ValidateAsync(string hostName)
        {
            var pinger = new Ping();
            try
            {
                var reply = await pinger.SendPingAsync(hostName, 1000);

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
            finally
            {
                pinger.Dispose();
            }
        }

        public async Task<IEnumerable<ConnectionValidationResponse>> ValidateParallelAsync(List<string> hostNames)
        {
            var tasks = new List<Task<ConnectionValidationResponse>>();
            foreach (var hostName in hostNames)
            {
                tasks.Add(ValidateAsync(hostName));
            }
            var result = await Task.WhenAll(tasks);
            return new List<ConnectionValidationResponse>(result);
        }
    }
}
