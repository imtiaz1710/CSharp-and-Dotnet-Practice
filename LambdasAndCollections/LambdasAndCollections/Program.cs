using System;
using System.Collections.Generic;
using System.Linq;


//Hero x = new("", "", "", false);
var heroes = new List<Hero>
{
    new("Imtiaz", "Mehedi", "Imtiaz", false),
    new("Khalid", "bin Walid", "Khalid Bin Walid", false),
    new("Jibrail", "Ruhul Kudus", "Jibrail", true),
    new("Jibrail", "Ruhul Kudus", "Jibrail", true)
};

var heroesWhoCanFly = string.Join(",", FilterHeroesWhoCanFly(heroes));

Console.WriteLine(heroesWhoCanFly);

List<Hero> FilterHeroesWhoCanFly(List<Hero> heroes)
{
    return heroes.Where(h => h.CanFly == true).ToList();
}

record Hero(string FirstName, string LastName, string HeroName, bool CanFly);



