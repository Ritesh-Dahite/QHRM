# QHRM-Dapper
CRUD with Dapper in a .NET6 using SQL Server

Steps to Follow
---------------

1] Create Database using MSSQL.

create database QHRM_DB;

------------------------------------------------------------------

2] Use Database

use QHRM_DB;

------------------------------------------------------------------

3] Create Table

create table Product (
	Sr_No int not null identity (1, 1) constraint Sr_No primary key,
	Pro_Name varchar(100),
	Pro_Description varchar (100),
	Pro_Price int,
	Pro_Created datetime,
);

------------------------------------------------------------------

4] Create Stored Procedure (2 Stored Procedure)

i)
create procedure ProductAddEdit
(
	@Sr_No int,
	@Pro_Name varchar(100),
	@Pro_Description varchar(100),
	@Pro_Price int,
	@Pro_Created datetime
)
    
as
if @Sr_No = 0
begin
	insert into Product (Pro_Name, Pro_Description, Pro_Price, Pro_Created)
	values (@Pro_Name, @Pro_Description, @Pro_Price, GETDATE())
	
	select @@ROWCOUNT as TotalRowCount
end
else
begin
	update Product set
	Pro_Name = @Pro_Name,
	Pro_Description = @Pro_Description,
	Pro_Price = @Pro_Price,
	Pro_Created = @Pro_Created
	where Sr_No = @Sr_No

	select @@ROWCOUNT as TotalRowCount
end

------------------------------------------------------------------
ii)
create procedure ProductDelete
(
	@Sr_No int
)
    
as
begin
	delete from Product where Sr_No = @Sr_No;
	
	select @@ROWCOUNT as TotalRowCount
end

------------------------------------------------------------------

5] Need to change "server" in connection string.

Open solution. -> appsettings.json -> Change Server from
"RITESH-DAHITE-7\\SQLEXPRESS" to your server name.
Shared a screenshot for reference in Screenshot folder with name Server.jpg)

------------------------------------------------------------------

6] Need to download dependencies ie. NuGet Packages.

------------------------------------------------------------------

7]Execute.
