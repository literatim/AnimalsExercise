using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AnimalExercisev2.DAL;
using AnimalExercisev2.Models;

namespace AnimalExerciseV2.Controllers
{
    public class AnimalsController : ApiController
    {
        private readonly AnimalExercisev2Context Db = new AnimalExercisev2Context();

        // GET: api/Animals
        public IQueryable<Animal> GetAnimals()
        {
            return Db.Animals;
        }

        // GET: api/Animals/5
        [ResponseType(typeof(Animal))]
        public IHttpActionResult GetAnimal(int id)
        {
            Animal animal = Db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            var test = Db.Animals.Where(x => x.Id == id).ToList();

            return Ok(animal);
        }

        // PUT: api/Animals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != animal.Id)
            {
                return BadRequest();
            }

            Db.Entry(animal).State = EntityState.Modified;

            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Animals
        [ResponseType(typeof(Animal))]
        public IHttpActionResult PostAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Db.Animals.Add(animal);
            Db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = animal.Id }, animal);
        }

        // DELETE: api/Animals/5
        [ResponseType(typeof(Animal))]
        public IHttpActionResult DeleteAnimal(int id)
        {
            Animal animal = Db.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }

            Db.Animals.Remove(animal);
            Db.SaveChanges();

            return Ok(animal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnimalExists(int id)
        {
            return Db.Animals.Count(e => e.Id == id) > 0;
        }
    }
}