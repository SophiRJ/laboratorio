--Calcular la edad del alumno y renombrarla
select * from Alumnos
select Nombre + ' '+ Apellido as AlumnoCompleto from Alumnos
 
--edad calculamos segun su fecha nacimiento 
select Nombre + ' '+ Apellido as AlumnoCompleto,
datediff(year,FechaNacimiento,getdate()) as edad from Alumnos
 
 
select A.Nombre, A.Apellido from Alumnos as A
 
select A.Nombre as [Nombre del Alumno],A.Apellido as [Apellido del Alumno] from Alumnos as A
--'Navacerrada'
--'Peter O''Tool'
--like: (%): coincidencia en cualquier subcadena
-- like Nava%  like %cer% like ___ tres caracteres
 
select * from Alumnos where Nombre like 'A%'
select * from Alumnos where Apellido like '%ez'
--coincidencias en cualquier parte
select * from Alumnos where Nombre like '%r%'
 
select * from Alumnos where Apellido like 'g%'
 
 
select * from Alumnos where Nombre like '_____'
--Mostrar nombre y paelidos mayusculas
Select upper(Nombre) as[Nombre en Mayusculas],upper(Apellido) as[Apellido en Mayusculas]from Alumnos
Select lower(Nombre) as[Nombre en Mayusculas],lower(Apellido) as[Apellido en Mayusculas]from Alumnos
 
--Mostrar nombre y cuantas letra tiene
select Nombre, len(Nombre) as [Cantidad en letras] from Alumnos
 
--alumnos ordenador por apellido
select Nombre, Apellido,FechaNacimiento from Alumnos 
order by Apellido desc
 
--Ordenar por apellido y luego por nombre
select Nombre, Apellido, FechaNacimiento from Alumnos order by Apellido desc, Nombre asc
 
--alumnos ordenados por l longitud de su nombre
select Nombre, len(Nombre) as LargoNombre from Alumnos order by LargoNombre desc
 
select upper(Nombre) as Nombre_Mayus, len(Nombre) as LargoNombre from Alumnos order by Nombre_Mayus desc
--Mostrar nombre y paelidos mayusculas
Select upper(Nombre) as[Nombre en Mayusculas],upper(Apellido) as[Apellido en Mayusculas]from Alumnos
Select lower(Nombre) as[Nombre en Mayusculas],lower(Apellido) as[Apellido en Mayusculas]from Alumnos
 
--Mostrar nombre y cuantas letra tiene
select Nombre, len(Nombre) as [Cantidad en letras] from Alumnos
 
--alumnos ordenador por apellido
select Nombre, Apellido,FechaNacimiento from Alumnos 
order by Apellido desc
 
--Ordenar por apellido y luego por nombre
select Nombre, Apellido, FechaNacimiento from Alumnos order by Apellido desc, Nombre asc
 
--alumnos ordenados por l longitud de su nombre
select Nombre, len(Nombre) as LargoNombre from Alumnos order by LargoNombre desc
 
select upper(Nombre) as Nombre_Mayus, len(Nombre) as LargoNombre from Alumnos order by Nombre_Mayus desc
--mostrar cada alumno y la cantidad de cursos en los que esta inscrito
select Nombre, Apellido, (select count(*) from Inscripciones 
where Inscripciones.IdAlumno= alumnos.IdAlumno) as totalCursos from Alumnos 
order by Alumnos.Apellido desc