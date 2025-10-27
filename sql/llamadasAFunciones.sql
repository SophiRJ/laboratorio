--Llamadas a funciones escalares
SELECT c.CompanyName, dbo.ClienteTienePedido(c.CustomerID) AS TienePedidos
FROM Customers c WHERE c.CustomerID = 'FOLKO';

select ProductName, [dbo].[ValorStock](4) as TotalValorAlmacen 
from Products p where ProductID=4

SELECT FirstName, LastName, Convert(NCHAR,BirthDate,103) AS FechaNacimiento,
dbo.edad(BirthDate) AS Edad FROM Employees;

select e.FirstName,[dbo].[TelefonoEmpleado](e.EmployeeID)  
from Employees e where e.EmployeeID=4

select e.FirstName, [dbo].[CantidadPedidosEmpleado](e.EmployeeID) as TotalPedidos
from Employees e where e.EmployeeID=2

--Llamadas a funciones con valor de tabla en linea
select * from [dbo].[ProductosConStockBajo](20)
select * from [dbo].[GetCustomerOrders]('ALFKI')
select * from [dbo].[CustomerNamesInRegion]('SP')
select * from [dbo].[ClientesRegion]('London')


--Llamadas a  funciones multiinstruccion
select * from [dbo].[EmpleadoNombreCortoOLargo]('shortName')
select * from [dbo].[GetCustomerOrderByYear]('VINET',1996)
select * from [dbo].[GetOrderTotalByCustomer]('ALFKI')

select * from Orders