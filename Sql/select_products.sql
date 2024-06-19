SELECT P.Name,
       C.Name
FROM Products P
LEFT JOIN ProductsCategories PC ON P.Id = PC.ProductId
LEFT JOIN Categories C ON C.Id = PC.CategoryId;