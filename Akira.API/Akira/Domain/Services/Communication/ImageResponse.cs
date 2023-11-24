using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class ImageResponse: BaseResponse<Image>
{
    public ImageResponse(string message) : base(message)
    {
        
    }
    
    public ImageResponse(Image resource) : base(resource)
    {
        
    }
}
