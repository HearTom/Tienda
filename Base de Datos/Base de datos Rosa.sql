use master
go

create database Tienda_Rosa

use Tienda_Rosa

Create Table Categoria(
	idcategoria int identity(1,1) not null,
	nombre nVarChar(50),
	descripcion nVarChar(50),
	Primary Key (idcategoria))

Create Table Cliente(
	idcliente int identity(1,1) not null,
	nombre nVarChar(50),
	apellidos nVarChar(50),
	telefono nvarchar(15),
	Primary Key (idcliente))


Create Table Compra_Detalles(
	idcompra int,
	idproducto int,
	importe decimal(18,2),
	cantidad int,)

Create Table Compras(
	idcompra int identity(1,1) not null,
	fecha date ,
	idtipocomprobante int,
	idfactura nvarchar(50),
	idproveedor int,
	importe_total decimal(18,2),
	retencion decimal(18,2),
	Primary Key (idcompra))

Create Table Empleado(
	idempleado int identity(1,1) not null,
	nombre nVarChar(50),
	apellido nVarChar(50),
	contraseña nvarchar(255),
	idrol int,
	usuario nvarchar(255),
	Primary Key (idempleado))

Create Table Pagos(
	idpagos int identity(1,1) not null,
	idcliente int,
	monto decimal(18,2),
	fecha datetime,
	Primary Key (idpagos))

Create Table Producto(
	idproducto int identity(1,1) not null,
	nombre nVarChar(100),
	idcategoria int,
	precio decimal(18,2),
	stock int,
	idproveedor int,
	foto nvarchar(255),
	Primary Key (idproducto))

Create Table Proveedor(
	idproveedor int identity(1,1) not null,
	nombre nVarChar(100),
	RUC nVarChar(12),
	representante nvarchar(150),
	direccion nvarchar(60),
	Telefono nvarchar(50),
	Primary Key (idproveedor))


Create Table Tipo_venta(
	idtipoventa int identity(1,1) not null,
	descripcion nvarchar(255),
	Primary Key (idtipoventa))

Create Table Venta(
	idventa int identity(1,1) not null,
	idcliente int,
	idempleado int,
	fecha datetime,
	idtipoventa int,
	Primary Key (idventa))

Create Table Venta_Detalle(	
	idventa int,
	idproducto int,
	precio decimal(18,2),
	cantidad int,
	importe decimal(18,2),
	montopagado decimal(18,2),
	cancelado int)

alter table Compra_Detalles add constraint fk_Compra_Detalles_Compras  foreign key(idcompra)
references Compras(idcompra)

alter table Compra_Detalles add constraint fk_Compra_Detalles_Producto  foreign key(idproducto)
references Producto(idproducto)

alter table Compras add constraint fk_Compras_proveedor foreign key(idproveedor)
references Proveedor(idproveedor)

alter table Pagos add constraint fk_Pagos_Cliente foreign key(idcliente)
references Cliente(idcliente)

alter table Producto add constraint fk_Producto_Categoria foreign key(idcategoria)
references Categoria(idcategoria)

alter table Producto add constraint fk_Producto_Proveedor foreign key(idproveedor)
references Proveedor(idproveedor)

alter table Venta add constraint fk_Venta_Cliente foreign key(idcliente)
references Cliente(idcliente)

alter table Venta add constraint fk_Venta_Empleado foreign key(idempleado)
references Empleado(idempleado)

alter Table Venta add constraint fk_venta_idtipoventa foreign key(idtipoventa)
references Tipo_venta(idtipoventa)

alter table Venta_Detalle add constraint fk_Venta_detalle_Venta foreign key(idventa)
references Venta(idventa)

alter table Venta_Detalle add constraint fk_Venta_detalle_producto foreign key(idproducto)
references Producto(idproducto)

insert into Tipo_Venta(descripcion) values('Contado')
insert into Tipo_Venta(descripcion) values('Credito')

go

create procedure actualizastock
@stock int,
@idproducto int
as
update producto set stock=@stock where idproducto=@idproducto
go

create procedure agregarcompra
@idtipocomprobante int,
@idfactura nvarchar(50),
@idproveedor int,
@importe_total decimal(18,2),
@retencion decimal(18,2),
@fecha as nvarchar(25)
as
insert into Compras(fecha,idtipocomprobante,idfactura,idproveedor,importe_total,retencion)
values(@fecha,@idtipocomprobante,@idfactura,@idproveedor,@importe_total,@retencion)
go

create procedure maxproductos
as
declare @correcto int
 
 select @correcto=count(*) from Producto
 
RETURN @correcto
go

create procedure mostrartodoproveedores
as
select idproveedor,nombre,RUC,representante,direccion,telefono from Proveedor
go

create procedure p_actualiventadetalle
@idventa int,
@idproducto int,
@cancelado int,
@montopagado decimal(18,2)
as
update Venta_Detalle set cancelado=@cancelado , montopagado=montopagado+@montopagado
where idventa=@idventa and idproducto=@idproducto
go

create procedure p_actualizasotckcompra
@stock int,
@idproducto int
as
update producto set stock=(stock+@stock) where idproducto=@idproducto
go

create procedure p_buscacliente
@nombre nvarchar(150)
as
 select idcliente,nombre,apellidos,telefono from cliente where nombre +' '+ apellidos like '%'+ @nombre +'%'
go

create procedure p_buscaproducto
@nombre nvarchar(255),
@idcategoria int
as
select idproducto,nombre,precio,stock from producto where idcategoria=@idcategoria and nombre like '%'+@nombre+'%'
go

create procedure p_buscarnomycat
@nombre nvarchar(255),
@idcategoria int
as
select idproducto,nombre,idcategoria,precio,stock,foto,idproveedor from Producto where nombre like '%'+ @nombre+ '%'
and idcategoria=@idcategoria
go

create procedure p_buscartodoproducto
@nombre nvarchar(255)
as
select idproducto,nombre,idcategoria,precio,stock,foto,idproveedor from Producto where nombre like '%'+ @nombre+ '%'
go

create procedure p_cliente
as
select idcliente,nombre + ' ' + apellidos from cliente
go

create procedure p_contarnomycate
@nombre nvarchar(255),
@idcategoria int
as
declare @correcto int
select @correcto=COUNT(*) from producto where nombre like '%' +@nombre+'%' and idcategoria=@idcategoria
RETURN @correcto 
go

create procedure p_contarproductosporcategoria
@idcategoria int
as
declare @correcto int
select @correcto=COUNT(*) from producto where idcategoria=@idcategoria
return @correcto
go

create procedure p_contarproductosporfiltro
@nombre nvarchar(255)
as
declare @correcto int
select @correcto=COUNT(*) from producto where nombre like '%' +@nombre+'%'
RETURN @correcto
go

create procedure p_idempleado
@usuario nvarchar(255)
as
select idempleado from Empleado where @usuario=usuario
go

create procedure p_insertarpagos
@idcliente int,
@monto decimal(18,2),
@fecha nvarchar(20)
as
insert Pagos (idcliente,monto,fecha)
values(@idcliente,@monto,@fecha)
go

create procedure p_listardeuda1
@idcliente int
as
select  vd.idventa,vd.idproducto,(vd.importe-vd.montopagado) from Venta v
inner join Venta_Detalle vd on v.idventa=vd.idventa
where v.idcliente=@idcliente and vd.cancelado=0
go

create procedure p_modificarcategoria
@nombre nvarchar(255),
@descripcion nvarchar(255),
@idcategoria int
as
update Categoria set nombre=@nombre ,descripcion=@descripcion 
where idcategoria=@idcategoria
go

create procedure p_modificarcliente
@nombre nvarchar(100),
@apellido nvarchar(100),
@telefono nvarchar(15),
@idcliente int
as
update Cliente set nombre=@nombre,apellidos=@apellido,telefono=@telefono
where idcliente=@idcliente
go


create procedure p_modificarproducto
@idproducto int,
@nombre nvarchar(100),
@idcategoria int,
@precio decimal(18,2),
@stock int,
@idproveedor int,
@foto nvarchar(255)
as
update Producto set nombre=@nombre,idcategoria=@idcategoria,precio=@precio,
stock=@stock,idproveedor=@idproveedor,foto=@foto where idproducto=@idproducto
go

create procedure p_modificarproveedor
@idproveedor int,
@nombre nvarchar(255),
@ruc nvarchar(12),
@representante nvarchar(150),
@direccion nvarchar(60),
@telefono nvarchar(50)
as
update Proveedor set nombre=@nombre,RUC=@ruc,representante=@representante,direccion=@direccion,telefono=@telefono
where idproveedor=@idproveedor
go

create procedure p_mostrarcategoria
as
select idcategoria,nombre,descripcion from Categoria
go

create procedure p_mostrarcuenta
@idcliente int
as
select  c.nombre+' '+ c.apellidos as 'cliente',p.nombre,vd.precio,vd.cantidad,(vd.importe-vd.montopagado) as 'importe',v.fecha from Venta v
inner join Venta_Detalle vd on v.idventa=vd.idventa
inner join Producto p on p.idproducto=vd.idproducto
inner join Cliente c on c.idcliente =v.idcliente
where v.idcliente=@idcliente and vd.cancelado=0
go

create procedure p_mostrartodocliente
as
select idcliente,nombre,apellidos,telefono from cliente
go

create procedure p_mostrartodoproductos
as
select idproducto,nombre,idcategoria,precio,stock,foto,idproveedor from Producto
go

create procedure p_nuevacategoria
@nombre nvarchar(255),
@descripcion nvarchar(255)
as
insert into Categoria (nombre,descripcion)
values (@nombre,@descripcion)
go

create procedure p_nuevocliente
@nombre nvarchar(100),
@apellido nvarchar(100),
@telefono nvarchar(15)
as
insert into Cliente (nombre,apellidos,telefono)
values(@nombre,@apellido,@telefono)
go

create procedure p_nuevoproducto
@nombre nvarchar(100),
@idcategoria int,
@precio decimal(18,2),
@stock int,
@idproveedor int,
@foto nvarchar(255)
as
insert into Producto(nombre,idcategoria,precio,stock,idproveedor,foto)
values(@nombre,@idcategoria,@precio,@stock,@idproveedor,@foto)
go

create procedure p_nuevoproveedor
@nombre nvarchar(255),
@ruc nvarchar(12),
@representante nvarchar(150),
@direccion nvarchar(60),
@telefono nvarchar(50)
as
insert into Proveedor (nombre,RUC,representante,direccion,telefono)
values(@nombre,@ruc,@representante,@direccion,@telefono)
go

create procedure p_preciostock
@idproducto int
as
select precio,stock from producto where idproducto=@idproducto
go

create procedure p_producto
@idcategoria int
as
select idproducto,nombre,idcategoria,precio,stock,foto,idproveedor from Producto where idcategoria=@idcategoria
go

create procedure p_registrarcompradetalle
@idproducto int,
@importe decimal(18,2),
@cantidad int
as
declare @idcompra integer
--agregamos el idpara ventadetalle lo obtenemos del maximo de compras
select @idcompra=MAX(idcompra) from Compras
--insertamos en venta detalle       
insert into Compra_Detalles(idcompra,idproducto,importe,cantidad)
values (@idcompra,@idproducto,@importe,@cantidad)
go

create procedure p_regitrarventadetalle
@idproducto int,
@precio decimal(18,2),
@cantidad int,
@cancelado int
as
declare @idventa integer
--agregamos el idpara ventadetalle
select @idventa=MAX(idventa) from venta
--insertamos en venta detalle       
insert into Venta_Detalle(idventa,idproducto,precio,cantidad,importe,cancelado,montopagado)
values (@idventa,@idproducto,@precio,@cantidad,@precio*@cantidad,@cancelado,0)
go

create PROCEDURE p_validar
@usuario nvarchar(255),
@clave nvarchar(255)
AS

declare @correcto int
if exists( select idempleado from Empleado
where  (usuario=@usuario)and(contraseña=@clave))
	set @correcto=1
else
	set @correcto=-1
RETURN @correcto
go

create procedure p_venta
@idcliente int,
@idempleado int,
@idtipoventa int,
@fecha nvarchar(30)
as
insert into Venta (idcliente,idempleado,fecha,idtipoventa)
values (@idcliente,@idempleado,@fecha,@idtipoventa)
go

create procedure sp_categoria
as
select idcategoria,nombre from categoria
go

create procedure p_calcularus
@fecha as nvarchar(10)
as
select SUM(importe_total-retencion),SUM(retencion) from Compras 
where datepart(month,fecha) = datepart(month,@fecha) and DATEPART(YEAR,fecha)=DATEPART(YEAR,@fecha)
go

create procedure productos_pa_comprar
as 
select nombre,stock,foto from Producto where stock <= 3
go