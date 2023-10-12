using Cars.Extensions;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [Route("cars")]
    [ApiController]
    public class CarController : Controller
    {
        public CarContext ctx = new();

        [HttpPost]
        public IActionResult Post(CreateCarDto car)
        {
            var thecar = new Car
            {
                Name = car.Name,
                Description = car.Description,
                CreatedTime = DateTime.Now,
                Id = Guid.NewGuid()
            };

            ctx.Cars.Add(thecar);
            ctx.SaveChanges();

            return Ok(thecar.AsDto());
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ctx.Cars);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var car = ctx.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPut]
        public IActionResult Put(UpdateCarDto update)
        {
            var car = ctx.Cars.Find(update.Id);
            if (car == null)
            {
                return NotFound();
            }
            
            car.Name = update.Name;
            car.Description = update.Description;
            ctx.SaveChanges();

            return Ok(car);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var car = ctx.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            ctx.Cars.Remove(car);
            ctx.SaveChanges();

            return Ok();
        }
    }
}
