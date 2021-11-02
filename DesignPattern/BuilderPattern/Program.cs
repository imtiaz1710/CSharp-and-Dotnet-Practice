using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var cv = new CVBuilder()
                .AddName("imtiaz")
                .AddAddress("62 shilmoon")
                .AddSkill("C#")
                .AddSkill(".Net");

            cv.AddPhoneNo(01746798621);
        }
    }
}
