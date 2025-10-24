--1.Seleccionar Nombre y Apellido de los empleados de la 
--zonasde ‘Nueva York’ y ‘Westboro’
select e.FirstName, e.LastName, t.TerritoryDescription from Employees e 
inner join EmployeeTerritories et on e.EmployeeID=et.EmployeeID 
inner join Territories t on t.TerritoryID = et.TerritoryID
where t.TerritoryDescription= 'New York' or t.TerritoryDescription='Westboro'

select * from Territories
--2.Seleccionar Id, Nombre y Precio de los productos 
--que hayan tenido pedido
select p.ProductID, p.ProductName, od.UnitPrice from [Order Details] od 
inner join Products p on p.ProductID = od.ProductID
where od.Quantity>0 order by ProductName desc



--3.Seleccionar Nombre,Apellido y Fecha de Pedido para los 
--empleados a los que se les haya hecho pedidos con unos gastos 
--de envio(Freight) inferiores a 32$.
select e.FirstName,e.LastName,Convert(varchar,o.OrderDate,103) as f_pedido from Employees e 
inner join Orders o on e.EmployeeID= o.EmployeeID
where o.Freight<32



--4.Seleccionar Nombre de producto, Precio Unitario y 
--Nombre de la Compañía suministradora para aquellos productos 
--cuyas unidades en stock sean inferiores a 20.
select p.ProductName, od.UnitPrice,c.CompanyName, p.UnitsInStock from Products p 
inner join [Order Details] od on p.ProductID = od.ProductID
inner join Orders o on o.OrderID=od.OrderID
inner join Customers c on c.CustomerID=o.CustomerID
where p.UnitsInStock<20


--RANK
select ProductName,UnitPrice, rank() over (order by UnitPrice) Price_Rank 
from Products

select ProductName,UnitPrice,UnitsInStock, 
RANK() over(partition by UnitsInStock 
order by UnitPrice) Price_rank from Products