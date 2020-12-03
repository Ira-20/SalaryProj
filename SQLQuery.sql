Drop Database PayScaleDb
Create Database PayScaleDb
Use PayScaleDb
Create table SalBand
(PayBand nvarchar(10) primary key,
BasicSalary float not null)

insert into SalBand values
('Grade-A' , 30000.90),
('Grade-B' , 20000.80),
('Grade-C' , 10000.50)