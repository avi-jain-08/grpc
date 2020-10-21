using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcServer;
using Microsoft.Extensions.Logging;

namespace GrpcService.Services
{
    public class TestService : SampleService.SampleServiceBase
    {
        readonly ILogger _logger;
        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }
        public async override Task<ResponseDetails> LoadDetails(RequestDetails request, ServerCallContext context)
        {
            return await Task.FromResult(new ResponseDetails()
            {
                Address = "tester,usa",
                Email = "tester@gmail.com",
                EmployeeName = "test",
                Phone = 12345,
                Status = true
            });

            //return base.LoadDetails(request, context);
        }
        public override Task LoadEmployeeDetails(RequestEmployees request, IServerStreamWriter<ResponseDetails> responseStream, ServerCallContext context)
        {
            return base.LoadEmployeeDetails(request, responseStream, context);
        }
    }
}
