using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Akira.API.Akira.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Genre { get; set; }
        
        
        public string Email { get; set; }
        public string Password { get; set; }
        
        public string? Address { get; set; }
        public string? DistrictId { get; set; }
        public District? District { get; set; }
        public string? ProvinceId { get; set; }
        public Province? Province { get; set; }
        public string? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public int? SelectedPaymentMethod { get; set; } 
        public PaymentMethod? PaymentMethod { get; set; }
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public Card? Card { get; set; }
        public int? ImageId { get; set; }
        public Image? ImageName { get; set; }
        public int? CartId { get; set; }
        public Order? Cart { get; set; }
        
        public IList<int>? Orders { get; set; }
        public IList<Order>? OrdersData { get; set; }
    }
}
