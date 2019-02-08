using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalExercisev2.Models
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public int AnimalAge { get; set; }
        public string AnimalColor { get; set; }
    }
}