using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class DepartmentResponse: BaseResponse<Department>
{
    public DepartmentResponse(string message) : base(message)
    {
     
    }
    
    public DepartmentResponse(Department resource) : base(resource)
    {
     
    }
}
