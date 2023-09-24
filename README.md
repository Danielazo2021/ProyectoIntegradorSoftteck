# ProyectoIntegradorSoftteck

Sistema de control de horas de servicio

📌 Premisa
Nuestro equipo funcional ha recibido un requerimiento por parte de la
empresa TechOil, líder en el sector Oil & Gas en latinoamerica.
Actualmente todo el proceso de control, registro y archivo de las horas de
servicio, dedicadas a diferentes proyectos, lo dirige de forma manual
mediante el llenado orgánico de documentos físicos, lo que resulta en un
proceso laborioso, complejo y propenso a errores que consume tiempo y
limita la capacidad operativa de su equipo de logística. En este sentido,
TechOil busca mejorar sus procesos operativos digitalizando sus
operaciones.

Nuestro objetivo en este contexto, es proporcionarles una solución moderna
y efectiva para digitalizar y automatizar su proceso de control de horas de
servicio. La propuesta del equipo funcional será desarrollar una aplicación
que permita llevar un seguimiento preciso de las horas de servicio
dedicadas a cada proyecto de manera eficiente y confiable.
Para llevar a cabo esta tarea, requerimos un desarrollador con sólidos
conocimientos en .NET Core 6, ágil, creativo y resolutivo. Su meta será crear
una aplicación de dos fases: en la primera fase, se enfocará en el desarrollo
del backend, estableciendo una estructura que permita el procesamiento y
almacenamiento adecuado de los datos relacionados con las horas de
servicio. En la segunda fase, será responsable del diseño frontend,
asegurando una interfaz amigable e intuitiva que permita a los usuarios
gestionar eficientemente la información y obtener una visión clara del
tiempo dedicado a cada proyecto.

📝 Requerimientos generales
Con base en lo anterior, el desarrollador dispondrá de la siguiente
información: (todos los campos son mandatorios)

● SERVICIOS: aquí guardan la información de los servicios ofrecidos
por la empresa. Cada uno de ellos cuenta con los siguientes datos:
○ codServicio: valor numérico que identifica al servicio
○ descr: es un texto con la descripción del servicio

2
○ estado: es un indicador binario que indica si el servicio se
encuentra activo o no (en caso de no estar activo, la empresa
no ofrece ese servicio)
○ valorHora: valor decimal que indica el costo por hora de ese
servicio

● PROYECTOS: aquí guardan la información de los proyectos que la
empresa tiene en cartera. Cada uno de ellos cuenta con los
siguientes datos:
○ codProyecto: valor numérico que identifica al proyecto
○ nombre: es un texto con el nombre del proyecto
○ dirección: es un texto con la dirección física de donde se realiza
el proyecto
○ estado: es un valor numérico que indica el estado del proyecto
(pueden ser diferentes: 1 – Pendiente, 2 – Confirmado, 3 –
Terminado)

● TRABAJOS: aquí guardan la información sobre los diferentes
servicios ofrecidos a cada proyecto. Cada uno de ellos cuenta con los
siguientes datos:
○ codTrabajo: valor numérico que identifica el trabajo realizado
○ fecha: representa la fecha del trabajo realizado
○ codProyecto: es un valor numérico que relaciona el proyecto
con el trabajo realizado
○ codServicio: es el código del servicio realizado
○ cantHoras: valor numérico que representa la cantidad de
horas solicitadas de un servicio (siempre es por hora entera)
○ valorHora: valor decimal que indica el costo por hora de ese
servicio al momento de contratarlo
○ costo: valor decimal calculado en base a la cantidad de horas
x el valorHora


● USUARIO: Aquí se guardará la información de los usuarios que
tendrán acceso a la aplicación. De los mismos se conocerá lo
siguiente:
○ codUsuario: valor numérico que identifica al usuario
○ nombre: un texto con el nombre y apellido del usuario
○ dni: valor numérico con el dni del usuario
○ tipo: valor numérico con dos posibilidades (1 – Administrador,
2 – Consultor)
○ contraseña: un texto con la contraseña del usuario
(encriptado)

SECCIÓN BACKEND
La primera parte de este proyecto se enfocará en el desarrollo backend de
la aplicación, por lo que el desafío será construir un sólido y completo
sistema de gestión con funcionalidades clave para el manejo de datos y la
interacción con la base de información del sistema, que permita a la
empresa TechOil mejorar su control operativo de forma segura y aumentar
su productividad.
Con base en este propósito se definen a continuación cada una de las
acciones y requerimientos que deberá presentar la aplicación para cumplir
con lo esperado. No obstante será muy valorado cualquier propuesta
adicional para mejorar la calidad del producto final.
Esta primera sección deberá completarse, al menos con un MVP funcional,
antes de poder dar comienzo al diseño del frontend.


🧱Acciones:
La aplicación deberá permitir las siguientes operaciones:
1. Definir un nombre para la aplicación
2. Realizar un ABM (alta, baja, modificación) de cada una de las
entidades (servicios, proyectos, trabajos, usuarios).

○ 📍Condición: Esta opción solo podrán realizarla los usuarios
administradores.

4. Realizar un listado (GET ALL) de cada una de las entidades
(servicios, proyectos, trabajos, usuarios).

○ 📍Condición: Esta opción puede realizarla cualquier tipo de
usuario (Administrador o Consultor)
6. Obtener el detalle (GET BY ID) de algún registro particular de cada
una de las entidades (servicios, proyectos, trabajos, usuarios).

○ 📍Condición: Esta opción puede realizarla cualquier tipo de
usuario (Administrador o Consultor)
4
7. Emitir un listado de los servicios en estado activo que tiene la
empresa.

○ 📍Condición: Esta opción puede realizarla cualquier tipo de
usuario (Administrador o Consultor)
8. Emitir un listado los proyectos que tiene la empresa, permitiendo
filtrar por estado. Por ejemplo, emitir listado de todos los proyectos
que se encuentren en estado “Terminado”.

○ 📍Condición: Esta opción puede realizarla cualquier tipo de
usuario (Administrador o Consultor)
9. Login de usuario (mediante su código de usuario y contraseña).
⚙Requerimientos técnicos

✓ Crear una aplicación de tipo Asp Net Core Web API, utilizando Net
Core 6.
✓ Utilizar entity framework core con enfoque model first para crear la
base de datos.
✓ Utilizar el patrón repositorio.
✓ Dividir en capas la solución. No es obligatorio seguir este modelo,
pero podría incluir las siguientes:
○ Controllers
○ Services
○ Models
○ Repository
○ DataAccess
✓ Utilizar seguridad basada en roles, aplicando Json Web Tokens
(JWT).
✓ La contraseña del usuario debe guardarse encriptada.


🎁Bonus
Si bien no es obligatorio, será un plus investigar y poder aplicar un
paginado a los endpoints que devuelvan un listado (GET ALL).
Normalmente se suele utilizar un tamaño de página de 10 registros,
pudiendo ser configurable en la petición

5
⚠Aclaraciones
Seguir las buenas prácticas de desarrollo mencionadas en cada uno
de los módulos. Mantener una sintaxis clara y homogénea, comentar
todo aquello que considere necesario y sea relevante.
