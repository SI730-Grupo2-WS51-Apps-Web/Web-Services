using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Resources {
    public class AccountResource
    {
        public int Id { get; set; }
        
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
        public bool Genre { get; set; }
        
        
        public string Email { get; set; }
        public string Password { get; set; }
        
        
        public string Address { get; set; }
        
        public string DistrictId { get; set; }
        public District? District { get; set; }
        
        public string ProvinceId { get; set; }
        public Province? Province { get; set; }
        
        public string DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}