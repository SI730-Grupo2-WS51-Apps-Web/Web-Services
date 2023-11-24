using Akira.API.Akira.Domain.Models;
namespace Akira.API.Akira.Responses;

public class OrderResponse
{
    public int Id {get;set;}
    
    
    public int UserId {get;set;}
    public Account Account {get;set;}
    
    public IList<ProductPerOrderResponse> ProductPerOrders {get;set;} = new List<ProductPerOrderResponse>();

    public string Address { get; set; }
    
    public string DistrictId { get; set; }
    public District? District { get; set; }
    
    public string ProvinceId { get; set; }
    public Province? Province { get; set; }
    
    public string DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    public int SelectedMethod {get;set;}
    public PaymentMethod? PaymentMethod {get; set;}
    
    public int StatusId {get;set;}
    public OrderStatus? Status {get; set;}
    
    public class stringData{
        public string Name {get;set;}
        public string Value {get;set;}
    }
}