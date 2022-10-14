namespace TPIntegradorProgIII.Models
{
    public class SwimmerDto
    {
        public int SwimmerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Document { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Birth { get; set; }

        public string CompleteName
        {
            get 
            { 
                return Name + " " + Surname; 
            }
        }
    }
}
