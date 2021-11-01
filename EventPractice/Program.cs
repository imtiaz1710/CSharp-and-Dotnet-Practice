using System;

namespace Answer1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string message = "Your area can be effected by Cyclone...\n";
            Notifier notifier = new Notifier();
            notifier.Clicked += new Notifier.SendNotification(new KhulnaMeteorologicalOffice().SendCycloneAlarm);
            notifier.Clicked += new Notifier.SendNotification(new DhakaMeteorologicalOffice().SendCycloneAlarm);
            notifier.Clicked += new Notifier.SendNotification(new ChittagongMeteorologicalOffice().SendCycloneAlarm);
            notifier.click(message);
        }
    }
}
