using Microsoft.AspNetCore.Mvc;
using PetApi.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
namespace PetsApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
    public class PetsController : ControllerBase
    {
        List<PetModel> _pets = new List<PetModel>();
        public PetsController()
        {
            Debug.WriteLine("Populating pet model");
            _pets.Add( new PetModel {Type = "Dog", Age = 2, Name = "Fifo", Diet = Diet.Carnivore });
            _pets.Add( new PetModel {Type = "Cat", Age = 2, Name = "Octo", Diet = Diet.Omnivore });
            _pets.Add( new PetModel {Type = "Bird", Age = 2, Name = "Tweet", Diet = Diet.Herbivore });
        } 

        [HttpGet("version")]
        public ActionResult<string> GetVersion()
        {
            var assembly = Assembly.GetExecutingAssembly(); 
            var assemblyVersion = FileVersionInfo.GetVersionInfo(assembly.Location);
            return assemblyVersion.FileVersion;
        }

        [HttpGet]
        public ActionResult<List<PetModel>> GetAll()
        {
            return _pets;
        }

        [HttpGet("{name}")]
        public ActionResult<PetModel> Get(string name)
        {
            return _pets.SingleOrDefault(p => p.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }

        [HttpPost]
        public void Create([FromBody] PetModel petModel)
        {
            _pets.Add(petModel);
        }
    }
}
