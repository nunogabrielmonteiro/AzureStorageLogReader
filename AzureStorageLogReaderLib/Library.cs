using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureStorageLogReaderLib
{
    /// <summary>
    /// Library to read Event Hub without Event Processor client, instead we use EventHubConsumerClient !
    /// Example link:
    /// https://docs.microsoft.com/en-us/dotnet/api/overview/azure/messaging.eventhubs-readme-pre
    /// 
    /// Nuget packages:
    /// managment:Azure.ResourceManager.EventHubs (Only works with AAD)
    /// data access: Microsoft.Azure.EventHubs and Microsoft.Azure.EventHubs.Processor
    /// </summary>
    public class Library
    {

        public static async void GetEvents(string connectionString, string eventHubName)
        {

            eventHubName = eventHubName.Trim();
            
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            ReadEventOptions reo = new ReadEventOptions();

            reo.MaximumWaitTime = new TimeSpan(0, 0, 5);
            reo.TrackLastEnqueuedEventProperties = false;

            await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
            {
       
                using var cancellationSource = new CancellationTokenSource();
               
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(60));

         
                await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(true,reo,cancellationSource.Token))
                {
                    //Encoding.UTF8.GetBytes()

                    string msg  = Encoding.Default.GetString(receivedEvent.Data.Body.ToArray());
                    // At this point, the loop will wait for events to be available in the Event Hub.  When an event
                    // is available, the loop will iterate with the event that was received.  Because we did not
                    // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                    // the cancellation token.
                }
            }

        }
    }
}
