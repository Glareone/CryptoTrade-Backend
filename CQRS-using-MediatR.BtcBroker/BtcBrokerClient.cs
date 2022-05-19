using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CQRS_using_MediatR.Common.Infrastructure.BrokerClients;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient;

namespace CQRS_using_MediatR.BtcBroker
{
    public class BtcBrokerClient : IBtcBrokerClient
    {
        private string _address;

        public BtcBrokerClient()
        {
            _address = "https://localhost:5002";
        }

        public async Task<IList<HistoricalData>> GetDataAsync()
        {
            using var channel = GrpcChannel.ForAddress(_address);
             var client = new HistoricalFeed.HistoricalFeedClient(channel);
            
             var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
             using var streamingCall =
                 client.Subscribe(new SubscribeRequest { Currency = "USD", Exchange = ExchangeType.Coinbase });
            
             var grpcServerResponse = new List<HistoricalData>();
            
             try
             {
                await foreach (var reply in streamingCall.ResponseStream.ReadAllAsync(cts.Token))
                {
                    grpcServerResponse.Add(new HistoricalData
                    {
                        Close = reply.Close,
                        High = reply.High,
                        Low = reply.Low,
                        Open = reply.Open,
                        Timestamp = reply.Timestamp,
                        VolumeBTC = reply.VolumeBtc,
                        VolumeCur = reply.VolumeCur,
                        WeightedPrice = reply.WeightedPrice
                    });
                }
             }
             catch (RpcException ex) when (ex.StatusCode == StatusCode.Cancelled)
             {
                 Console.WriteLine("Stream cancelled.");
             }
            
             return grpcServerResponse;
        }
    }
}
