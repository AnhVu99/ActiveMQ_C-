using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS.ActiveMQ;


namespace Listener
{
    class Program
    {
        private const string URI = "tcp://localhost:61616";
        private const string DESTINATION = "test.queue";

        static void Main(string[] args)
        {
            try
            {
                ConnectionFactory connectionFactory = new ConnectionFactory(URI);

                using (SimpleMessageListenerContainer listenerContainer = new SimpleMessageListenerContainer())
                {
                    listenerContainer.ConnectionFactory = connectionFactory;
                    listenerContainer.DestinationName = DESTINATION;
                    listenerContainer.MessageListener = new Listener();
                    listenerContainer.AfterPropertiesSet();
                    Console.WriteLine("Listener started.");
                    Console.WriteLine("Press <ENTER> to exit.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Press <ENTER> to exit.");
                Console.Read();
            }

        }
    }
}
