import os

# Directorio de la carpeta que deseas listar
directorioBase = 'C:/Users/MARCELO/RiderProjects/Akira.API/Akira.API/Akira/Domain'

# Obtener una lista de todos los archivos en el directorio
archivos = os.listdir(directorioBase + "/Models")
for element in archivos:
    element = element[:-3]
    with open(directorioBase + "/Services/I" + element + "Service.cs", 'w') as archivo:
        archivo.write("""using Akira.API.Akira.Domain.Models;
using Akira.API.Akira.Domain.Services.Communication;
namespace Akira.API.Akira.Domain.Services;

public interface I"""+element+"""Service
{
    Task<IEnumerable<"""+element+""">> ListAsync();
    Task<"""+element+"""Response> SaveAsync("""+element+""" """ + element.lower() +""");
    Task<"""+element+"""Response> UpdateAsync(int id, """+element+""" """ + element.lower() +""");
    Task<"""+element+"""Response> DeleteAsync(int id);
}
""" + '\n')