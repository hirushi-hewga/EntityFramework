using System.ComponentModel.DataAnnotations;

namespace Airport_Data_Access.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
