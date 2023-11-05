import os

# Directorio de la carpeta que deseas listar
directorioBase = 'C:/Users/MARCELO/RiderProjects/Akira.API/Akira.API/Akira/Domain'

# Obtener una lista de todos los archivos en el directorio
archivos = os.listdir(directorioBase + "/Models")
first = []
last = []
for element in archivos:
    element = element[:-3]
    first.append("""CreateMap<"""+element+""", """+element+"""Resource>();""")
    last.append("""CreateMap<Save"""+element+"""Resource, """+element+""">();""")
for element in first:
    print(element)
print(" ")
print(" ")
for element in last:
    print(element)