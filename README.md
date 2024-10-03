# Instrucciones:

# Base de datos:
- Se debe ejecutar la migración "InitialCreate" del proyecto "PruebaTecnicaPCA.Infrastructure" a fin de crear las tablas, para lo cual en el servidor se debe crear una base de datos con el nombre "PruebaTecnicaPCA".
- Desde Visual Studio en la consola de Administrador de Paquetes se debe seleccionar como proyecto predeterminado "PruebaTecnicaPCA.Infrastructure" y ejecutar la instrucción "Update-Database".

# Proyecto:
- Se debe tener presente que la versión utilizada para la solución es NET Core 8
- Se debe cambiar el nombre del servidor a utilizar en el archivo "appsettings.json", en la clave "ConnectionStrings" y "PruebaTecnicaPCA", en el apartado "Data Source". En caso de utilizar un servidor con conexión de usuario y clave sql se debe realizar el respectivo cambio y especificar estos datos en la cadena de conexión.
- Se debe establecer como proyecto de inicio "PruebaTecnicaPCA.Api", seleccionando el proyecto, clic derecho y seleccionar "Establecer como proyecto de inicio"

# Endpoints:
- /api/Vuelo => Corresponde a la gestión de vuelos (Creación, Actualización, Eliminación, Listado, Búsqueda)
- /api/Reserva => Corresponde a la gestión de la reserva del vuelo (Creación, Listado, Búsqueda)
- /api/Estadistica/cantidadAerolineas => Corresponde a la consulta de la cantidad de aerolineas registradas
- /api/Estadistica/reservasPorAerolinea => Corresponde a la consulta de la cantidad de reservas para cada aerolinea
