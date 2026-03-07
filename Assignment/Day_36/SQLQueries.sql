--1. List all Product Names along with their Category Names.
Select p.ProductName, c.CategoryName
from Products p Join Categories c on p.CategoryID=c.CategoryID;

--2. Display every Order ID alongside the Company Name of the customer who placed it.
Select o.OrderID, c.CompanyName
from Orders o Join Customers c on o.CustomerID=c.CustomerID;

--3. Show all Product Names and the Company Name of their respective suppliers.
Select p.ProductName, s.CompanyName
from Products p Join Suppliers s on p.SupplierID=s.SupplierID;

--4. List all Orders (ID and Date) and the First/Last Name of the employee who processed them.
Select o.OrderID, o.OrderDate, e.FirstName+' '+e.LastName As FullName
from Orders o Join Employees e on o.EmployeeID=e.EmployeeID;

--5. Find all Orders shipped to "France," showing the Order ID and the Company Name of the Shipper (from the Shippers table).
Select o.OrderID, s.CompanyName
from Orders o Join Shippers s on o.ShipVia=s.ShipperID where o.ShipCountry='France';

--6. Show the Category Name and the total number of units in stock for that category.
Select c.CategoryName, SUM(p.UnitsInStock) As TotalUnitsInStock
from Categories c join Products p  on c.CategoryID=p.CategoryID Group BY c. CategoryName;

--7. List the Company Name and the total amount of money (Price $\times$ Quantity) they have spent across all orders.
Select c.CompanyName,SUM(od.UnitPrice * od.Quantity) AS TotalSpent
fROM Customers c JOIN Orders o on c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID Group BY c.CompanyName;

--8. Display the Last Name of each employee and the total number of orders they have taken.
Select e.LastName,COUNT(o.OrderID) AS TotalOrders
from Employees e LEFT JOIN Orders o on e.EmployeeID = o.EmployeeID Group BY e.LastName;

--9.Find the total Freight charges paid to each Shipper company.
Select s.CompanyName,SUM(o.Freight) AS TotalFreight
from Shippers s JOIN Orders o on s.ShipperID = o.ShipVia Group BY s.CompanyName;

--10. List the top 5 Product Names based on total quantity sold.
Select TOP 5 p.ProductName,SUM(od.Quantity) AS TotalSold
from Products p JOIN [Order Details] od on p.ProductID = od.ProductID Group BY p.ProductName Order BY TotalSold DESC;

--11.List all Product Names whose UnitPrice is greater than the average price of all products.
Select ProductName
from Products
WHERE UnitPrice > (
    Select AVG(UnitPrice)
    from Products
);

--12. Use a Self-Join on the Employees table to show each employee's name and their manager's name.
SELECT e.FirstName + ' ' + e.LastName AS EmployeeName,m.FirstName + ' ' + m.LastName AS ManagerName
from Employees e LEFT JOIN Employees m on e.ReportsTo = m.EmployeeID;

--13. Find all Customers (Company Name) who have never placed an order (Use NOT IN or NOT EXISTS).
SELECT CompanyName
FROM Customers
WHERE CustomerID NOT IN (
    SELECT CustomerID
    FROM Orders
);

--14. Identify Order IDs where the total order value is higher than the average order value of the entire database.
SELECT OrderID
FROM [Order Details] GROUP BY OrderID HAVING SUM(UnitPrice * Quantity) >
(
    SELECT AVG(OrderTotal)
    FROM (
        SELECT SUM(UnitPrice * Quantity) AS OrderTotal
        FROM [Order Details] GROUP BY OrderID
    ) AS AvgTable
);

--15.Select Product Names that have never been ordered after the year 1997.
SELECT ProductName
FROM Products
WHERE ProductID NOT IN (
    SELECT od.ProductID
    FROM [Order Details] od JOIN Orders o on od.OrderID = o.OrderID WHERE YEAR(o.OrderDate) > 1997
);

--16. List all Employees and the names of the Regions they cover (requires joining Employees, EmployeeTerritories, Territories, and Region).
SELECT e.FirstName, e.LastName, r.RegionDescription
FROM Employees e JOIN EmployeeTerritories et on e.EmployeeID = et.EmployeeID JOIN Territories t on et.TerritoryID = t.TerritoryID JOIN Region r on t.RegionID = r.RegionID;

--17.Find Customers and Suppliers who are located in the same city.
SELECT c.CompanyName AS Customer,s.CompanyName AS Supplier,c.City
FROM Customers c JOIN Suppliers s on c.City = s.City;

--18.List Customers who have purchased products from more than 3 different categories.
SELECT c.CompanyName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID JOIN Products p ON od.ProductID = p.ProductID
GROUP BY c.CompanyName HAVING COUNT(DISTINCT p.CategoryID) > 3;

--19. Calculate the total revenue generated only by products that are currently Discontinued.
SELECT SUM(od.UnitPrice * od.Quantity) AS DiscontinuedRevenue
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID WHERE p.Discontinued = 1;

--20.For each Category, list the most expensive product name and its price.
SELECT c.CategoryName,p.ProductName,p.UnitPrice
FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID
WHERE p.UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products p2 WHERE p2.CategoryID = p.CategoryID
);