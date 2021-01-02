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
    /// </summary>
    public class Library
    {

        public async void GetEvents()
        {
            string connectionString = "Endpoint=sb://duplicatedmessageseh.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=1tT8sRAvJLdk3NzVeIjjrZ/MoptNot8/fQspEr0gjA8=";
            
            string eventHubName = "testeh";
           
            string consumerGroup = EventHubConsumerClient.DefaultConsumerGroupName;

            ReadEventOptions reo = new ReadEventOptions();

            reo.MaximumWaitTime = new TimeSpan(0, 0, 5);

            reo.TrackLastEnqueuedEventProperties = false;


            await using (var consumer = new EventHubConsumerClient(consumerGroup, connectionString, eventHubName))
            {
                using var cancellationSource = new CancellationTokenSource();
               
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(5));

                await foreach (PartitionEvent receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    // At this point, the loop will wait for events to be available in the Event Hub.  When an event
                    // is available, the loop will iterate with the event that was received.  Because we did not
                    // specify a maximum wait time, the loop will wait forever unless cancellation is requested using
                    // the cancellation token.
                }
            }

        }
    }
}
