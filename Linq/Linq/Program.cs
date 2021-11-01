using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81,
                60}},
                 new Student {First="Svetlana", Last="Omelchenko", ID=120, Scores= new List<int> {97, 92, 81,
                60}},
                  new Student {First="Svetlana", Last="Omelchenko", ID=117, Scores= new List<int> {97, 92, 81,
                60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=113, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}},
                new Student {First="Imtiaz", Last="Mehedi",ID=111,Scores=new List<int>{33,11,44,11,33,44}}
            };

            List<Student> students2 = new List<Student>
            {
         
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}},
                new Student {First="Imtiaz", Last="Mehedi",ID=111,Scores=new List<int>{33,11,44,11,33,44}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}}
            };

            /*var StudentQuery = from student in students
                               where student.Scores[0] > 90 && student.Scores[3] < 80
                               orderby student.Scores[0] ascending
                               orderby student.Scores[0] descending 
                               select student;*/

            /* var StudentQuery = students.Where(student => student.Scores[0] < 90).
                 OrderBy(student => student.ID).
                 ThenBy(student => student.Scores[0]);
            */

            /*  foreach (var item in StudentQuery)
              {
                  Console.WriteLine($"First={item.First}, Last={item.Last} ,ID={item.ID},FirstScore={item.Scores[0]}");
              }*/

            /*var studentGroups = from student in students
                               group student by student.First[0] into studentGroup
                               orderby studentGroup.Key
                               select studentGroup;*/

            /*  foreach (var item in studentGroups)
              {
                  Console.WriteLine(item.Key);
                  foreach (var student in item)
                  {
                      Console.WriteLine($"First={student.First}, Last={student.Last} ,ID={student.ID},FirstScore={student.Scores[0]}");
                  }
              }*/

            /*  var studentByGroup = from student in students
                                  let NewId = student.ID - 100
                                  where NewId <= 20
                                  orderby student.ID 
                                  group student by student.First[0] into studentGroup
                                  orderby studentGroup.Key
                                  select studentGroup;

              foreach (var item in studentByGroup)
              {
                  Console.WriteLine(item.Key);
                  foreach (var student in item)
                  {
                      Console.WriteLine($"First={student.First}, Last={student.Last} ,ID={student.ID},FirstScore={student.Scores[0]}");
                  }
              }*/

            /* var totalScore = from student in students
                             *//* let total=(student.Scores[0]+ student.Scores[1]+ student.Scores[2]+ student.Scores[3])*//*
                              select (student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]);
             Console.WriteLine(totalScore.Average());*/

            var FilteredStudent = from Student in students
                                  join student2 in students2 on Student.First[0] equals student2.First[0]
                                  //where Student.First[0] is 'M'
                                  orderby Student.ID descending
                                  select new { x = Student, y = student2 };
            foreach (var item in FilteredStudent)
            {
                Console.WriteLine($"{item.x.First}+{item.x.ID}----->{item.y.First}+{item.y.ID}");
            }
            

        }
    }
}
