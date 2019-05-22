using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public int Completed { get; set; }
        public int Existe { get; set; }
    }
}
