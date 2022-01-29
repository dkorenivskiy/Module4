--�������

--������� 1
--������� ��� ���������� �� ������� Sales.Customer 

SELECT *
FROM Sales.Customer
GO

--������� 2
--������� ��� ���������� �� ������� Sales.Store ��������������� �� Name � ���������� �������

SELECT *
FROM Sales.Store
ORDER BY Name
GO

--������� 3
--������� �� ������� HumanResources.Employee ��� ���������� � ������ �����������, ������� �������� ����� 1989-09-28

SELECT TOP 10 *
FROM HumanResources.Employee
WHERE BirthDate > '1989-09-28' 
GO

--������� 4
--������� �� ������� HumanResources.Employee ����������� � ������� ��������� ������ LoginID �������� 0.
--������� ������ NationalIDNumber, LoginID, JobTitle.
--������ ������ ���� ������������� �� JobTitle �� ��������

SELECT NationalIDNumber, LoginID, JobTitle
FROM HumanResources.Employee
WHERE LoginID like '%0'
ORDER BY JobTitle DESC
GO

--������� 5
--������� �� ������� Person.Person ��� ���������� � �������, ������� ���� ��������� � 2008 ���� (ModifiedDate) � MiddleName �������� �������� � Title �� �������� �������� 

SELECT *
FROM Person.Person
WHERE (ModifiedDate BETWEEN '2008-1-1' AND '2009-1-1') 
AND Title IS NULL
AND MiddleName IS NOT NULL
GO

--������� 6
--������� �������� ������ (HumanResources.Department.Name) ��� ���������� 
--� ������� ���� ����������
--������������ ������� HumanResources.EmployeeDepartmentHistory � HumanResources.Department

SELECT DISTINCT HumanResources.Department.Name
FROM HumanResources.EmployeeDepartmentHistory, HumanResources.Department
GO

--������� 7
--������������ ������ �� ������� Sales.SalesPerson �� TerritoryID � ������� ����� CommissionPct, ���� ��� ������ 0

SELECT TerritoryID, COUNT(*) as 'CommissionPct'
FROM Sales.SalesPerson
GROUP BY TerritoryID
HAVING COUNT(*) > 0
GO

--������� 8
--������� ��� ���������� � ����������� (HumanResources.Employee) ������� ����� ����� ������� ���-�� ������� (HumanResources.Employee.VacationHours)

SELECT COUNT(*) as 'HumanResources.Employee',
MAX(HumanResources.Employee.VacationHours) as 'Max Vacation Hours'
FROM HumanResources.Employee
GO

--������� 9
--������� ��� ���������� � ����������� (HumanResources.Employee) ������� ����� ������� (HumanResources.Employee.JobTitle) 'Sales Representative' ��� 'Network Administrator' ��� 'Network Manager'

SELECT *
FROM HumanResources.Employee
WHERE HumanResources.Employee.JobTitle like 'Sales Representative'
OR HumanResources.Employee.JobTitle like 'Network Administrator'
OR HumanResources.Employee.JobTitle like 'Network Manager'
GO

--������� 10
--������� ��� ���������� � ����������� (HumanResources.Employee) � �� ������� (Purchasing.PurchaseOrderHeader). 
--���� � ���������� ��� ������� �� ������ ���� ������� ����!!!

SELECT h.LoginID, c.PurchaseOrderID
FROM HumanResources.Employee h
LEFT JOIN Purchasing.PurchaseOrderHeader c
ON h.BusinessEntityID = c.EmployeeID
GO