import os

# Directorio de la carpeta que deseas listar
directorioBase = 'C:/Users/MARCELO/RiderProjects/Akira.API/Akira.API/Akira/Domain'

# Obtener una lista de todos los archivos en el directorio
archivos = os.listdir(directorioBase + "/Models")
for element in archivos:
    element = element[:-3]
    with open(directorioBase + "/Services/Communication/" + element + "Response.cs", 'w') as archivo:
        archivo.write("""using Akira.API.Akira.Domain.Models;
using Akira.API.Shared.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services.Communication;

public class """+element+"""Response: BaseResponse<"""+element+""">
{
    public """+element+"""Response(string message) : base(message)
    {
     
    }
    
    public """+element+"""Response("""+element+""" resource) : base(resource)
    {
     
    }
}""" + '\n')