IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases
			WHERE name  = 'bikedb')
BEGIN
	DROP DATABASE bikedb
	print '' print '*** drop database bikedb'
END
GO
print '' print 'create bikedb'
GO
create database bikedb
GO

print '' print 'use bikedb'
GO

use bikedb
GO

print ''  print 'create client table'
go
create table client (	
	client_id	int	not null	identity(1000,1),
	client_first_name	nvarchar(255) not null,
	client_last_name 	nvarchar(255) not null,
	phone_number 		nvarchar(255) not null,
	email	     		nvarchar(255) not null,
	constraint pk_client_id primary key (client_id)


)
go

print '' print "create client address"
go

create table client_address (

	client_id 	int 	not null,
	line1 		nvarchar(255) not null,
	line2 		nvarchar(255) ,
	city 		nvarchar(255)	not null,
	state 		nvarchar(255)	not null,
	county		nvarchar(255)	not null,
	zipcode 	nvarchar(255)	not null,
	country		nvarchar(255)	not null,
constraint pk_client_addressid primary key (client_id),
constraint fk_client_address_id foreign key (client_id)
references client(client_id)
)
go

print '' print "create client_cc"
go

create table client_cc (	
	client_id	int	not null,	
	routing_number	nvarchar(255) not null,
	account_number	nvarchar(255) not null,
	bank_name 		nvarchar(255) not null,

	constraint pk_client_cc primary key (client_id),
	constraint fk_client_cc foreign key (client_id) 
	references client(client_id)


)
GO

print '' print  "create employee"
GO
create table employee (
	employee_id	int IDENTITY(100000,1)	not null,
	employee_firstname	nvarchar(255)	not null,
	employee_lastname	nvarchar(255)	not null,
	ssn			nvarchar(255)	not null,
	Active	bit default 1,
	constraint pk_emmployee primary key (employee_id),
	constraint fk_employee  foreign key (employee_id)
	references employee (employee_id)

)
go
print '' print'******** INSERT SAMPLE DATA IN EMPLOYEE'
GO
INSERT INTO employee 
		(employee_firstname,employee_lastname,ssn)
	values('Maiyada','Abbas','123456789'),
		('Akmal','Abdel','123456789'),
		('Siram','Moa','123456789')
GO
print '' print "create employee_address"
GO
create table employee_address (
	employee_id	int 	not null,
	line1	nvarchar(255)	not null,
	line2	nvarchar(255)	not null,
	city	nvarchar(255)	not null,
	state 	nvarchar(255)	not null,
	county	nvarchar(255)	not null,
	zipcode nvarchar(255)	not null,
	
	constraint pk_emmployee_address primary key (employee_id),
	constraint fk_employee_address  foreign key (employee_id)
	references employee (employee_id)

)
go
print '' print'******** INSERT SAMPLE DATA IN EMPLOYEE Address'
GO
INSERT INTO employee_address 
		(employee_id,line1,line2, city, state, county, zipcode)
	values(100000,'12 St Ave','Apt 111', 'Iowa City', 'Iowa', 'Johnson', '52404'),
		(100001,'12 St Ave','Apt 110', 'Iowa City', 'Iowa', 'Johnson', '52404'),
		(100002,'12 St Ave','Apt 109', 'Iowa City', 'Iowa', 'Johnson', '52404')
GO


print '' print "create table roles"
GO
create table roles (
	role_id	nvarchar(255) 	not null,
	description	nvarchar(255)	not null	
	constraint pk_roles primary key (role_id)
)
GO
print '' print'******** INSERT SAMPLE DATA IN roles'
GO
INSERT INTO roles 
		(role_id,description)
	values	("Admin", "respresent the admin feature"),
		("Manager","represent manager feature"),
		("process","represent process feature")
GO
print '' print "create employee_roles"
go
create table employee_roles (
	employee_id	int 	not null,
	role_id	nvarchar(255)	not null	
	constraint pk_emmployee_roles primary key (employee_id),
	constraint fk_employee_roles  foreign key (employee_id)
	references employee (employee_id),
	constraint fk_roles  foreign key (role_id)
	references roles (role_id)

)
print '' print'******** INSERT SAMPLE DATA IN employee_roles'
GO
INSERT INTO employee_roles
		(employee_id,role_id)
	values(100000,"Admin"),
		(100001,"Manager"),
		(100002,"process")
GO
print '' print " create employee_bank"
GO
create table employee_bank( 
	employee_id 	int	 not null,
	accountnumber	nvarchar(255)	not null,
	routinnumber	nvarchar(255)	not null,
	bankname	nvarchar(255)	not null,
	constraint pk_emmployee_bank primary key (employee_id),
	constraint fk_employee_bank  foreign key (employee_id)
	references employee (employee_id)
)
GO
print '' print'******** INSERT SAMPLE DATA IN employee_bank'
GO
INSERT INTO employee_bank 
		(employee_id,accountnumber,routinnumber, bankname)
	values(100000,'123456789','123456789', 'Wells Fargo'),
		(100001,'987654321','9878765432', 'US Bank'),
		(100002,'897656543','9876765432', 'CR Bank')
GO
print '' print "create employee_salary"
GO
create table employee_salary(
	employee_id	int	not null,
	salary_type	nvarchar(255)	not null,
	salary_amount	nvarchar(255)	not null,
	constraint pk_emmployee_salary primary key (employee_id),
	constraint fk_employee_salary  foreign key (employee_id)
	references employee (employee_id)

)
GO
print '' print'******** INSERT SAMPLE DATA IN employee_salary'
GO
INSERT INTO employee_salary 
		(employee_id,salary_type,salary_amount)
	values(100000,'typ1','10000'),
		(100001,'type2','920000'),
		(100002,'type3','100000')
GO
print '' print "create employee_verification"
go
create table employee_verification(
	employee_id	int	not null,
	email	nvarchar(255)	not null,
	passwordHash	nvarchar(255)	not null DEFAULT '5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',
	constraint pk_emmployee_verification primary key (employee_id),
	constraint fk_employee_verification  foreign key (employee_id)
	references employee (employee_id)
)
GO
print '' print'******** INSERT SAMPLE DATA IN employee_verification'
GO
INSERT INTO employee_verification 
		(employee_id,email)
	values(100000,'miyada@compnay.com'),
		(100001,'Akmal@compnay.com'),
		(100002,'Siram@compnay.com')
GO

print '' print "create bike" 
GO
create table bike (
	
	bike_id		int IDENTITY(100000,1)	not null,
	bike_name	nvarchar(255)	not null,
	bike_type	nvarchar(255)	not null,
	bike_price	decimal		not null,
	bike_quality	int		not null,
	bike_model	nvarchar(255)	not null,
	constraint pk_bike primary key (bike_id)
)
go
print '' print'******** INSERT SAMPLE DATA IN bike'
GO
INSERT INTO bike 
		(bike_name,bike_type,bike_price,bike_quality,bike_model)
	values('bike1','type1',1.1,1,'model1'),
		('bike2','type2',2.2,2,'model2'),
		('bike3','type3',3.3,3,'model3')
GO
print '' print "create total_bike"
GO
create table totale_bike(
	bike_id	 int		not null,
	total_bike	int	not null,
	constraint pk_bike_total primary key (bike_id),
	constraint fk_bike_total  foreign key (bike_id)
	references bike (bike_id)	

)
go 
print '' print'******** INSERT SAMPLE DATA IN totale_bike'
GO
INSERT INTO totale_bike 
		(bike_id,total_bike)
	values(100000,1),
		(100001,2),
		(100002,3)
GO
print '' print "create transaction_type"
GO
create table transaction_type(
	transaction_type_id	int IDENTITY(100000,1)	not null,
	bike_status_name	nvarchar(255)	not null,
	bike_status_description	nvarchar(255)	not null,
	constraint pk_transaction_type_id primary key (transaction_type_id)
	

)
go

print '' print "bike_status"
create table bike_status(

	bike_status_id		int IDENTITY(100000,1)	not null,
	describtion		nvarchar(255)	not null,
	constraint pk_bike_status_id  primary key (bike_status_id)
)
go

print '' print "bike_rent"

create table bike_rent(
	bike_rent_id	int IDENTITY(100000,1)	not null,
	bike_rent_date	nvarchar(255)	not null,
	return_date	nvarchar(255)	not null,
	actual_return_date	nvarchar(255)	,
	bike_status_id	int			not null,
	fees		decimal	
	constraint pk_bike_rent_id primary key (bike_rent_id)
)
GO
print '' print "create transactions"
GO
create table transactions(
	transactions_id	int	IDENTITY(100000,1) not null,
	client_id	int	not null,
	bike_id		int	not null,
	transaction_type_id	int	not null,
	transaction_date	nvarchar(255)	not null,
	bike_status_id		int		not null,
	bike_rent_id		int,
	constraint pk_transactions_id primary key (transactions_id),
	constraint fk_transactions_client_id  foreign key (client_id)
	references client (client_id),
	constraint fk_bike_id  foreign key (bike_id)
	references bike (bike_id),
	constraint fk_transaction_type_id  foreign key (transaction_type_id)
	references  transaction_type ( transaction_type_id),
	constraint fk_bike_status_id  foreign key (bike_status_id)
	references  bike_status ( bike_status_id),
	constraint fk_bike_rent foreign key (bike_rent_id)
	references  bike_rent (bike_rent_id)
)
GO

print '' print "create buy_bike"
GO
create table buy_bike(
	buy_bike_id	int	IDENTITY(100000,1) not null,
	client_id	int	not null,
	bike_id		int	not null,
	price	nvarchar(255)	not null,
	constraint pk_buy_bike_id primary key (buy_bike_id),
	constraint fk_buy_bike_client_id  foreign key (client_id)
	references client (client_id),
	constraint fk_buy_bike_id  foreign key (bike_id)
	references bike (bike_id)
)
GO
print '' print "return_buy"
GO
create table return_buy(
	return_buy_id	int	IDENTITY(100000,1) not null,
	transactions_id	int	not null,
	return_date	nvarchar(255)	not null,
	bike_status_id	int	not null,
	fees	decimal,
	constraint pk_return_buy_id  primary key (return_buy_id),
	constraint fk_return_buy_transactions_id  foreign key (transactions_id)
	references transactions (transactions_id),
	constraint fk_return_buy_status_id  foreign key (bike_status_id)
	references employee (employee_id)

)
GO












print '' print '*** creating sp_verify_employee'
GO
CREATE PROCEDURE [dbo].[sp_verify_employee](
@email nvarchar(255), @passwordHash nvarchar(255)
)
AS
	BEGIN
		SELECT employee_id
		FROM employee_verification
		WHERE
		    email = @email
		AND
		   passwordHash = @passwordHash
	END
GO
print '' print '*** creating sp_select_employee_roles'
GO
CREATE PROCEDURE [dbo].[sp_select_employee_roles](
@employee_id int
)
AS
	BEGIN
		SELECT role_id
		FROM employee_roles
		WHERE
		    employee_id = @employee_id
	END
GO
print '' print '*** creating sp_select_all_employees'
GO
CREATE PROCEDURE [dbo].[sp_select_all_employees]
AS
	BEGIN
		SELECT [dbo].[employee].[employee_id],[dbo].[employee].[employee_firstname],[dbo].[employee].[employee_lastname],[dbo].[employee].[ssn],
		[dbo].[employee_address].[line1],[dbo].[employee_address].[line2],[dbo].[employee_address].[city],[dbo].[employee_address].[state], [dbo].[employee_address].[county], 			[dbo].[employee_address].[zipcode],
			[dbo].[employee_bank].[bankname],[employee_bank].[accountnumber],[dbo].[employee_bank].[routinnumber],
			[dbo].[employee_roles].[role_id],[dbo].[employee_salary].[salary_amount],[dbo].[employee_salary].[salary_type],
			[dbo].[employee_verification].[email],[dbo].[employee_verification].[passwordHash]
		FROM [dbo].[employee]
		JOIN [dbo].[employee_address] ON [dbo].[employee_address].[employee_id] = [dbo].[employee].[employee_id]
		JOIN [dbo].[employee_bank] ON [dbo].[employee_bank].[employee_id] = [dbo].[employee].[employee_id]
		JOIN [dbo].[employee_roles] ON [dbo].[employee_roles].[employee_id]= [dbo].[employee].[employee_id]
		JOIN [dbo].[employee_salary] ON [dbo].[employee_salary].[employee_id] = [dbo].[employee].[employee_id]
		JOIN [dbo].[employee_verification] ON [dbo].[employee_verification].[employee_id] = [dbo].[employee].[employee_id]
		WHERE Active = 1;
	END


GO
print '' print '*** creating sp_select_all_employees'
GO
CREATE PROCEDURE [dbo].[sp_insert_employees]
(@Firstname nvarchar(255),
@Lastname nvarchar(255),
@SSN nvarchar(255),
@Line1 nvarchar(255),
@Line2 nvarchar(255),
@City nvarchar(255),
@State nvarchar(255),
@County nvarchar(255),
@Zipcode nvarchar(255),
@Role_id nvarchar(255),
@AccountNumber nvarchar(255),
@RoutinNumber nvarchar(255),
@bankName nvarchar(255),
@salaryType nvarchar(255),
@salaryAmount nvarchar(255),
@email nvarchar(255),
@passwordHash nvarchar(255))
AS
	BEGIN
		DECLARE @employeeId AS INT
		INSERT INTO employee
		(employee_firstname, employee_lastname, ssn)
		VALUES (@Firstname,@Lastname,@SSN);
		
		SET @employeeId = (
			SELECT employee_id
			FROM employee
			WHERE employee_firstname = @Firstname
			AND employee_lastname = @Lastname
			AND ssn = @SSN
		);

		INSERT INTO [dbo].[employee_bank]
		(employee_id,[bankname],[accountnumber],[routinnumber])
		VALUES(@employeeId,@bankName,@AccountNumber,@RoutinNumber);

		INSERT INTO [dbo].[employee_roles]
		(employee_id, [role_id])
		VALUES(@employeeId,@Role_id);

		INSERT INTO [dbo].[employee_salary]
		(employee_id, [salary_amount],[salary_type])
		VALUES(@employeeId,@salaryAmount,@salaryType);
		
		INSERT INTO [dbo].[employee_verification]
		(employee_id, [email],[passwordHash])
		VALUES(@employeeId,@email,@passwordHash);

		INSERT INTO [dbo].[employee_address]
		(employee_id, [line1],[line2],[city],[state],[county],[zipcode])
		VALUES(@employeeId,@Line1,@Line2,@City,@State,@County,@Zipcode);
		
		Return  @@ROWCOUNT
	END
GO
print '' print '*** creating sp_update_employee'
GO
CREATE PROCEDURE [dbo].[sp_update_employee]
(
@Employee_id nvarchar(255),
@Firstname nvarchar(255),
@Lastname nvarchar(255),
@SSN nvarchar(255),
@Line1 nvarchar(255),
@Line2 nvarchar(255),
@City nvarchar(255),
@State nvarchar(255),
@County nvarchar(255),
@Zipcode nvarchar(255),
@Role_id nvarchar(255),
@AccountNumber nvarchar(255),
@RoutinNumber nvarchar(255),
@bankName nvarchar(255),
@salaryType nvarchar(255),
@salaryAmount nvarchar(255),
@email nvarchar(255),
@passwordHash nvarchar(255))
AS
	BEGIN
		UPDATE employee
		SET employee_firstname = @Firstname, employee_lastname = @Lastname, ssn = @SSN
		WHERE employee_id = @Employee_id;

		UPDATE [dbo].[employee_bank]
		SET [bankname] = @bankName, [accountnumber] = @AccountNumber,[routinnumber] = @RoutinNumber
		WHERE employee_id = @Employee_id;

		UPDATE [dbo].[employee_roles]
		SET [role_id]= @Role_id
		WHERE employee_id = @Employee_id;

		UPDATE [dbo].[employee_salary]
		SET [salary_amount]= @salaryAmount,[salary_type]= @salaryType
		WHERE employee_id = @Employee_id;
		
		UPDATE [dbo].[employee_verification]
		SET [email]= @email,[passwordHash]= @passwordHash
		WHERE employee_id = @Employee_id;

		UPDATE [dbo].[employee_address]
		SET [line1]=@Line1,[line2]= @Line2,[city]= @City,[state]= @State,[county]= @County,[zipcode]=@Zipcode
		WHERE employee_id = @Employee_id;
		
		Return  @@ROWCOUNT
	END
GO
print '' print '*** creating sp_delete_employee'
GO
CREATE PROCEDURE [dbo].[sp_delete_employee]
( @Employee_id int)
AS
  BEGIN
	UPDATE employee
	SET Active = 0
	WHERE employee_id = @Employee_id;
  	Return  @@ROWCOUNT
  END
GO
print '' print '*** creating sp_select_all_bikes'
GO
CREATE PROCEDURE [dbo].[sp_select_all_bikes]
AS
  BEGIN
	SELECT bike.[bike_id],[bike_name],[bike_type],[bike_price],[bike_quality]
,[bike_model],	[total_bike]
	FROM totale_bike
	JOIN bike ON totale_bike.[bike_id] =  bike.[bike_id]
  END
GO
print '' print '*** creating sp_insert_bike'
GO
CREATE PROCEDURE [dbo].[sp_insert_bike]
(@Name nvarchar(255),@Type nvarchar(255),@Price decimal	,@Quality int,@Model nvarchar(255),@Total int)
AS
  BEGIN
	INSERT INTO bike 
		(bike_name,bike_type,bike_price,bike_quality,bike_model)
	values(@Name,@Type,@Price,@Quality,@Model);
	DECLARE @bikeId AS INT
	SET @bikeId = (
		SELECT bike.[bike_id] FROM bike
		WHERE bike_name = @Name
		AND bike_type = @Type
		AND bike_price = @Price
		AND bike_quality = @Quality
		AND bike_model = @Model
	);
	INSERT INTO totale_bike 
		(bike_id,total_bike)
	values(@bikeId ,@Total);

	Return  @@ROWCOUNT
  END
GO
print '' print '*** creating sp_update_bike'
GO
CREATE PROCEDURE [dbo].[sp_update_bike]
(@ID int,@Name nvarchar(255),@Type nvarchar(255),@Price decimal	,@Quality int,@Model nvarchar(255),@Total int)
AS
  BEGIN
	UPDATE	bike 
	SET 	bike_name=@Name,
		bike_type=@Type,
		bike_price=@Price,
		bike_quality=@Quality,
		bike_model=@Model
	WHERE	bike.[bike_id]= @ID;
	UPDATE	totale_bike 
	SET	total_bike= @Total
	WHERE	bike_id= @ID;
	Return  @@ROWCOUNT
  END
GO
print '' print '*** creating sp_insert_client'
GO
CREATE PROCEDURE [dbo].[sp_insert_client]
(@client_first_name nvarchar(255),@client_last_name nvarchar(255),@email nvarchar(255),@phone_number nvarchar(255),@line1 nvarchar(255),@line2 nvarchar(255),@city nvarchar(255),
@state nvarchar(255),@county nvarchar(255),@zipcode nvarchar(255),@country nvarchar(255),@routing_number nvarchar(255),@account_number nvarchar(255),@bank_name nvarchar(255))
AS
  BEGIN
	INSERT INTO	client 
		(client_first_name,client_last_name,phone_number, email)
	VALUES (@client_first_name,@client_last_name,@phone_number, @email);
	DECLARE @client_id as INT
	SET  @client_id = (
		SELECT client_id
		FROM client 
		WHERE client_first_name = @client_first_name
		AND client_last_name = @client_last_name
		AND phone_number = @phone_number
		AND email = @email
	);
	INSERT INTO client_address
		(client_id,line1,line2,city,state,county,zipcode,country)
	VALUES (@client_id,@line1,@line2,@city,@state,@county,@zipcode,@country);
	INSERT INTO client_cc
		(client_id,routing_number,account_number,bank_name)
	VALUES (@client_id,@routing_number,@account_number,@bank_name)
	Return  @@ROWCOUNT
  END
GO
print '' print '*** creating sp_select_all_clients'
GO
CREATE PROCEDURE [dbo].[sp_select_all_clients]
AS
  BEGIN
	SELECT [dbo].[client].client_id,client_first_name,client_last_name,phone_number,email,
			line1,line2,city ,state,county,zipcode,country,
			routing_number, account_number, bank_name
	FROM [dbo].[client]
	JOIN [dbo].[client_address] ON [dbo].[client].[client_id] = [dbo].[client_address].[client_id]
	JOIN [dbo].[client_cc] ON [dbo].[client].[client_id] = [dbo].[client_cc].[client_id]
  END
GO
print '' print '*** creating sp_update_client'
GO
CREATE PROCEDURE [dbo].[sp_update_client]
(@client_id int,@client_first_name nvarchar(255),@client_last_name nvarchar(255),@email nvarchar(255),@phone_number nvarchar(255),@line1 nvarchar(255),@line2 nvarchar(255),@city nvarchar(255),
@state nvarchar(255),@county nvarchar(255),@zipcode nvarchar(255),@country nvarchar(255),@routing_number nvarchar(255),@account_number nvarchar(255),@bank_name nvarchar(255))
AS
  BEGIN
	UPDATE client 
	SET client_first_name= @client_first_name,
		client_last_name= @client_last_name,
		phone_number= @phone_number, 
		email= @email
	WHERE  client_id = @client_id;
	UPDATE client_address
	SET line1= @line1,
		line2= @line2,
		city= @city,
		state= @state,
		county= @county,
		zipcode= @zipcode,
		country= @country
	WHERE  client_id = @client_id;
	UPDATE client_cc
	SET routing_number= @routing_number,
		account_number=  @account_number,
		bank_name= @bank_name
	WHERE  client_id = @client_id;
	Return  @@ROWCOUNT
  END
GO
print '' print '*** creating sp_buy_bike'
GO
CREATE PROCEDURE [dbo].[sp_buy_bike]
(@client_first_name nvarchar(255),@client_last_name nvarchar(255),@email nvarchar(255),@phone_number nvarchar(255),
@bike_ID int, @Price nvarchar(255))
AS
  BEGIN
 	DECLARE @client_id as INT
	SET  @client_id = (
		SELECT client_id
		FROM client 
		WHERE client_first_name = @client_first_name
		AND client_last_name = @client_last_name
		AND phone_number = @phone_number
		AND email = @email
	);
	INSERT INTO buy_bike 
		(client_id,bike_id,price)
	VALUES (@client_id,@bike_ID,@Price)
	Return  @@ROWCOUNT
  END
GO
