--Seleccionar todos los registros de la tabla ‘Empleados’.
select * from Employees
--Seleccionar todos los paises de ‘Empleados’ sin repetir
select distinct Country from Employees
--Seleccionar aquellos ‘Empleados’ cuyo  nombre='Nancy'
select * from Employees where FirstName ='Nancy'
--Seleccionar todos los ‘Clientes’(Customer)
select * from Customers
--Seleccionar todos los clientes de 'Mexico‘
select * from Customers where Country ='Mexico'
--Seleccionar todas las ciudades de ‘Clientes’ sin repetir;
select distinct City from Customers
--Seleccionar ‘Compañías’(CompanyName ) de ‘Clientes’  cuya ciudad de residencia sea london
select CompanyName from Customers where City ='London'

--1.Seleccionar ‘Compañía’(CompanyName), Persona de Contacto’(ContactName) y 
--‘Categorias’(CategoryName) de las tablas: ‘Clientes ‘como C y ‘Categorias’ 
--como S de la ciudad de Londres
select C.CompanyName, C.ContactName, S.CategoryName  from Customers as C, Categories as S
 
--1.SeleccionarCargo del Contacto(ContactTitle), Nombre del Contacto(ContactName),
--Apellido del empleado de las tablas : Clientes (C) y Empleados(E).
--Para clientes y empleados de la ciudad de Londres
 
select * from Employees
select * from Customers
 
select c.ContactTitle, c.ContactName, E.LastName from Customers as C, Employees as E where c.City='London'
--Apellido, nombre y fecha de nac de empleados de usa ordenados por fecha nac en orden desc
select LastName,FirstName,convert(Varchar, BirthDate,103)as BirthDate from Employees
where Country='USA' order by BirthDate desc
 
--union : combina resultados de 2 consultas y elimina duplicados
-- union all: no elimina duplicados
-- intersect: devuelve los reistros que aparecen en las 2
-- exept: devuelve los registro de la primera que no estan en la segunda
 
--clientes que hyan realizado algun pedido
select Customers.CustomerID from Customers
intersect
select Orders.CustomerID from Orders
 
--selccionar el id del producto cuyas unidades  en stock sean menos de 5 
--y hayan recibido pedidos superiores a esa cantidad
select ProductID from Products where UnitsInStock<5
intersect
select [Order Details].ProductID from [Order Details] where Quantity>5
 
--seleccionar todos los ids de clientes excepto los que tienen fecha de pedido superioir al 4 de julio de 1996
Select Customers.CustomerID from Customers
except
select CustomerId from Orders where OrderDate > '1996-07-04'
 
--promedio del campo Cantidad(Quantity)
--en la tabla detalle de pedidos(OrdersDetails)
select avg(Quantity) as Media from [Order Details]
 
--Min y max en los gastos de transporte (Freight)
--en pedidios(Orders) realizados por el empleado con id 5
select min(Freight) as Minimo, max(Freight) as Maximo from Orders where EmployeeID=5
 
--cliente agrupados por pais-> primero hago el group by y despues le digo que cuente
select count(CustomerID) as numeroClients, Country from Customers 
group by Country order by numeroClients desc
 
--agrupar x uniddes en stock 
select UnitsInStock, count(*) as Products from Products 
group by UnitsInStock order by UnitsInStock desc
 
select ProductID, min(UnitPrice) as Minimo, max(UnitPrice) as Maximo, 
avg(UnitPrice) as Media from [Order Details] group by ProductID 
order by ProductID
 
--Seleccionar pais de origen (ShipCountry),
--promedio de gastos de envio (Freight) de pedidos
--agrupados y ordenados por el paisde origen
 
select ShipCountry, avg(Freight) as MediaGastosEnvio from Orders 
group by ShipCountry order by ShipCountry
 
--seleccionar idproducto, promedio de descuento(Discount) de 
--DEtalle de pedidos agrupados y ordenados por ID de producto
-- SELECT CAST(Precio AS DECIMAL(10,2)) AS PrecioConDosDecimales
--FROM Productos;
--para hacer un where de ungroup by usar having
select ProductId, avg(Discount) as mediaDescuento from [Order Details] 
group by ProductID order by ProductID
--obtener una lista de categorias de productos que tienen mas de 10 productos agrupados
select CategoryID, count(*) as ProductCount from Products 
group by CategoryID having count(*)>10
 
--lista de clientes que han hecho mas de 5 pedidos y ademas que el total de 
--dinero gastado en esos pedidso sea mayor a 10000 ordenado por el total de 
--dinero gastado de mayor a menor
 
--Valores null: is null, is not null