exec sp_rename 'Employee_PayRoll.Salary','BasicPay','column'
select*from Employee_PayRoll;



alter PROCEDURE spAddNewEmployee
@Name nvarchar(200),
@basic_Pay float,
@Phone_Number bigInt,
@Emp_Address varchar(20)
AS
insert into Employee_PayRoll(Name,Basic_Pay,Phone_Number,Emp_Address)values (@Name,@basic_Pay,@Phone_Number,@Emp_Address);