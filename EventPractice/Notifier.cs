using System;
using System.Collections.Generic;
using System.Text;
namespace Answer1
{
    public class Notifier
    {
        public delegate void SendNotification(string x);
        public event SendNotification Clicked;

        public void click(string x)
        {
            Clicked(x);
        }
    }
}
