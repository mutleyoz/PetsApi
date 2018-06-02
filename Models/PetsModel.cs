namespace PetApi.Models 
{
    public enum Diet 
    {
        Herbivore,
        Omnivore,
        Carnivore
    }
    public class PetModel
    {
        public string Type { get; set; }
        public string Name {get; set;}
        public int Age {get; set;}
        public Diet Diet { get; set;}
    }
}