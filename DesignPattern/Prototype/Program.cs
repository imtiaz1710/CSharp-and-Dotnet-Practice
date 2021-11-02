using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = new Email
            {
                To = "xyz@mail.com",
                From = "abc@mail.com",
                Subject = "prototype",
                Body = "implementing prototype pattern"
            };

            var copyEmail =(Email) email.Clone();
            copyEmail.Body = "Body has modified";
        }
    }
}
