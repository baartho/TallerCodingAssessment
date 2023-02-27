SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, c.Age, o.OrderId, o.DateCreated, o.MethodOfPurchase as [Purchase Method], od.ProductNumber, od.ProductOrigin FROM Orders o 
INNER JOIN OrdersDetails od on od.orderid = o.orderid	
INNER JOIN Customer c on c.PersonId = o.personid
WHERE ProductId = 1112222333