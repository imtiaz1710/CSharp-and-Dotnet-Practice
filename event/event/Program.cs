using System;

namespace Event
{
    class Program
    {
        public delegate void Notify(string address, string message);
        public event Notify Notification;
        static void Main(string[] args)
        {
            Program instance = new Program();
            instance.Notification += instance.EmailNotification;
            instance.Notification += instance.SMSNotification;
            instance.Notification("abc", "Imtiaz");
            instance.EmailNotification("33","34");
        }
        public void EmailNotification(string address,string message)
        {
            Console.WriteLine("Email Sending to:");
            Console.WriteLine(address);
            Console.WriteLine(message);
        }
        public void SMSNotification(string address, string message)
        {
            Console.WriteLine("SMS Sending to:");
            Console.WriteLine(address);
            Console.WriteLine(message);
        }
    }
}
