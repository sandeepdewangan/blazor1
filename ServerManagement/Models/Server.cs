using System.ComponentModel.DataAnnotations;

namespace ServerManagement.Models
{
    public class Server
    {
        public Server()
        {
            Random rand = new Random();
            int randNum = rand.Next(0, 2);
            IsOnline = randNum == 0 ? false : true;
        }

        public int ServerId { get; set; }
        public bool IsOnline { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? City { get; set; }
    }
}
