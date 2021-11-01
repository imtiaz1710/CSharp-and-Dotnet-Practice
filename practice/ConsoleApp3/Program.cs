using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            /* int y = int.Parse(Console.ReadLine());
             try
             {
                 int x = 3 / (y);
             }
             catch (Exception ex)
             {

                 Console.WriteLine(ex.Message);
             }*/

            /*  var obj1 = new Pond();
              obj1.AccessStatic();
              obj1.AccessStatic();
              var obj2 = new Pond();
              obj2.AccessStatic();
              obj2.AccessStatic();*/
            /*
                        Fish fish = new Fish();
                        fish.FishId = 1;
                        fish.Name = "eik";

                        ChangeValue(fish);
                        Console.WriteLine(fish.Name);*/

            var s = Solution.ReverseWords("  the    sky is blue");

            Console.WriteLine(s);

            var a = 3;
            changeVal(ref a);
            Console.WriteLine(a);

        }

        public static void changeVal(ref int x)
        {
            x = 10;
        }

        /*public static void ChangeValue(Fish fish)
        {
            var newFish = new Fish();
            newFish.Name = "New-fish";

            fish = newFish;
        }*/
    }
}
