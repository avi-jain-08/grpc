using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;

namespace gRPC_Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var serverAddress = "http://localhost:8099";//docker hosted url
          //  var serverAddress = "http://localhost:32812";//docker hosted url

            var httpHandler = new HttpClientHandler();
            // Return `true` to allow certificates that are untrusted/invalid
            //httpHandler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            using var channel = GrpcChannel.ForAddress(serverAddress);
            //using var channel = GrpcChannel.ForAddress(serverAddress,new GrpcChannelOptions { HttpHandler= httpHandler });
            var client = new SampleService.SampleServiceClient(channel);
            // unary
            var reply = await client.LoadDetailsAsync(
                new RequestDetails()
                {
                    Address = "",
                    Email = "",
                    EmployeeName = "",
                    Phone = 0,
                    Status = false
                });
            Console.WriteLine("Name: " + reply.EmployeeName);
            Console.WriteLine("Address: " + reply.Address);
            Console.WriteLine("Phone: " + reply.Phone);
            Console.WriteLine("Email: " + reply.Email);
            Console.WriteLine("Status: " + reply.Status);
            Console.WriteLine();
            Console.WriteLine("Stream object");
            Console.WriteLine();
        }
    }
}
