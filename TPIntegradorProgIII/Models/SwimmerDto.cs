namespace TPIntegradorProgIII.Models
{
    public class SwimmerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public string CompleteName
        {
            get 
            { 
                return Name + " " + Surname; 
            }
        }
    }
}
