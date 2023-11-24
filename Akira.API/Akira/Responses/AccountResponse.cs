using Akira.API.Akira.Domain.Models;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Akira.API.Akira.Responses {
    public class AccountResponse
    {
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public Image? ImageName { get; set; }

        public Personal Personal { get; set; }
        public Login Login { get; set; }
        public Shipping Shipping { get; set; }
        public Shop Shop { get; set; }

        public Payment Payment { get; set; }
    }
    public class Personal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Genre { get; set; }
    }
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Shipping
    {
        public string Address { get; set; }
        public string DistrictId { get; set; }
        public District? District { get; set; }
        public string ProvinceId { get; set; }
        public Province? Province { get; set; }
        public string DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
    public class Shop
    {
        public int? CartId { get; set; }
        public Order? Cart { get; set; }
        public IList<int>? Orders { get; set; }
        public IList<Order>? OrdersData { get; set; }
    }

    public class Payment
    {
        public int? WalletId { get; set; }
        public Wallet? Wallet { get; set; }
        public Card? Card { get; set; }
        public int? SelectedMethod { get; set; } 
        public PaymentMethod? PaymentMethod { get; set; }
        public MethodSummarizedData? MethodData { get; set; }
    }

    public class MethodSummarizedData
    {
        public float MaxCost { get; set; }
        public string Name { get; set; }
    }
}