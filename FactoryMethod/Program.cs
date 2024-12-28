namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductStockManagement manager = 
                new ProductStockManagement(MessageSenderFactory.Create(MessageTypes.PushNotification));

            manager.NotifyAboutStock();
        }
    }

    //Step 1: Define the IMessageSender interface
    interface IMessageSender
    {
        void SendMessage(string message);
    }

    //Step 2: Implement different message sender types
    class SmsSender : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"SMS Sent: {message}");
    }

    class EmailSender : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"Email Sent: {message}");
    }

    class PushNotificationSender : IMessageSender
    {
        public void SendMessage(string message) => Console.WriteLine($"Push Notification Sent: {message}");
    }

    //Step 3: Define message types as enum
    enum MessageTypes{
        SMS,
        Email,
        PushNotification
    }

    //Step 4: Create a Factory to handle object creation
    class MessageSenderFactory
    {
        public static IMessageSender Create(MessageTypes messageType)
        {
            return messageType switch
            {
                MessageTypes.SMS => new SmsSender(),
                MessageTypes.Email => new EmailSender(),
                MessageTypes.PushNotification => new PushNotificationSender(),
                _ => throw new ArgumentException("Invalid sender types")
            };
        }
    }

    //Usage
    class ProductStockManagement
    {
        private readonly IMessageSender _messageSender;

        public ProductStockManagement(IMessageSender messageSender) => _messageSender = messageSender;
        public void NotifyAboutStock()
        {
            _messageSender.SendMessage("Out of stock");
        }
    }


}
