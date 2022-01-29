--Домашка

--Задание 1
--Вывести всю информацию из таблицы Sales.Customer 

SELECT *
FROM Sales.Customer
GO

--Задание 2
--Вывести всю информацию из таблицы Sales.Store отсортированную по Name в алфавитном порядке

SELECT *
FROM Sales.Store
ORDER BY Name
GO

--Задание 3
--Вывести из таблицы HumanResources.Employee всю информацию о десяти сотрудниках, которые родились позже 1989-09-28

SELECT TOP 10 *
FROM HumanResources.Employee
WHERE BirthDate > '1989-09-28' 
GO

--Задание 4
--Вывести из таблицы HumanResources.Employee сотрудников у которых последний символ LoginID является 0.
--Вывести только NationalIDNumber, LoginID, JobTitle.
--Данные должны быть отсортированы по JobTitle по убиванию

SELECT NationalIDNumber, LoginID, JobTitle
FROM HumanResources.Employee
WHERE LoginID like '%0'
ORDER BY JobTitle DESC
GO

--Задание 5
--Вывести из таблицы Person.Person всю информацию о записях, которые были обновлены в 2008 году (ModifiedDate) и MiddleName содержит значение и Title не содержит значение 

SELECT *
FROM Person.Person
WHERE (ModifiedDate BETWEEN '2008-1-1' AND '2009-1-1') 
AND Title IS NULL
AND MiddleName IS NOT NULL
GO

--Задание 6
--Вывести название отдела (HumanResources.Department.Name) БЕЗ повторений 
--в которых есть сотрудники
--Использовать таблицы HumanResources.EmployeeDepartmentHistory и HumanResources.Department

SELECT DISTINCT HumanResources.Department.Name
FROM HumanResources.EmployeeDepartmentHistory, HumanResources.Department
GO

--Задание 7
--Сгрупировать данные из таблицы Sales.SalesPerson по TerritoryID и вывести сумму CommissionPct, если она больше 0

SELECT TerritoryID, COUNT(*) as 'CommissionPct'
FROM Sales.SalesPerson
GROUP BY TerritoryID
HAVING COUNT(*) > 0
GO

--Задание 8
--Вывести всю информацию о сотрудниках (HumanResources.Employee) которые имеют самое большое кол-во отпуска (HumanResources.Employee.VacationHours)

SELECT COUNT(*) as 'HumanResources.Employee',
MAX(HumanResources.Employee.VacationHours) as 'Max Vacation Hours'
FROM HumanResources.Employee
GO

--Задание 9
--Вывести всю информацию о сотрудниках (HumanResources.Employee) которые имеют позицию (HumanResources.Employee.JobTitle) 'Sales Representative' или 'Network Administrator' или 'Network Manager'

SELECT *
FROM HumanResources.Employee
WHERE HumanResources.Employee.JobTitle like 'Sales Representative'
OR HumanResources.Employee.JobTitle like 'Network Administrator'
OR HumanResources.Employee.JobTitle like 'Network Manager'
GO

--Задание 10
--Вывести всю информацию о сотрудниках (HumanResources.Employee) и их заказах (Purchasing.PurchaseOrderHeader). 
--ЕСЛИ У СОТРУДНИКА НЕТ ЗАКАЗОВ ОН ДОЛЖЕН БЫТЬ ВЫВЕДЕН ТОЖЕ!!!

SELECT h.LoginID, c.PurchaseOrderID
FROM HumanResources.Employee h
LEFT JOIN Purchasing.PurchaseOrderHeader c
ON h.BusinessEntityID = c.EmployeeID
GO