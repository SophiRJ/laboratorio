exec [dbo].[ObtenerProductosCliente]@ClienteId='ALFKI'
exec [dbo].[ActualizarStockProducto]@ProductoId= 4,@CantidadVendida=3
exec[dbo].[ReporteVentas]
--Con valores de salida
declare @Total int
exec[dbo].[ObtenerTotalPedidosCliente]@ClienteId='ALFKI', @TotalVendido= @Total output
select @Total as CantidadTotal

DECLARE @TotalOrders INT;
-- Ejecutamos el procedimiento pasando un cliente específico 
--y obtenemos el número de pedidos en @TotalOrders
EXEC GetOrderCountByCustomer 'ALFKI', @TotalOrders OUTPUT;
-- Mostramos el valor devuelto
SELECT @TotalOrders AS TotalOrders;


exec [dbo].[GetEmployeByCountry]'USA'
exec [dbo].[GetAllEmployees]'Janet','Leverling'

declare @texto varchar(70)
exec [dbo].[MensajeSegunPedidosCliente]'ALFKI',@texto output
select @texto as MensajeSegunPedidos

exec [dbo].[ReducirGastos] 3
exec [dbo].[TransladarEmpleado]
exec[dbo].[RecuperarFechasPedidosAño]1997

select *from Orders where CustomerID='ALFKI'
select * from EmployeeTerritories

select * from Products
update Products set UnitsInStock= UnitsInStock-2 where ProductID=1
select * from HistorialStock