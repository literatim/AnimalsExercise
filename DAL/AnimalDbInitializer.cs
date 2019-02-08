using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using AnimalExercisev2.Models;

namespace AnimalExercisev2.DAL
{
    public class AnimalDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<AnimalExercisev2Context>
    {
        protected override void Seed(AnimalExercisev2Context context)
        {
            var animals = new List<Animal>
            {
                new Animal {AnimalName = "Dog", AnimalAge = 100, AnimalColor ="Brindle"},
            };

            animals.ForEach(s => context.Animals.AddOrUpdate(s));

            context.SaveChanges();

        }

    }
}