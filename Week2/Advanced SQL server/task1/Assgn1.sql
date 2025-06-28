-- 1. Using ROW_NUMBER() to assign a unique rank within each category
WITH RankedProducts AS (
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        pc.Name AS Category,
        p.ListPrice AS Price,
        ROW_NUMBER() OVER (PARTITION BY pc.Name ORDER BY p.ListPrice DESC) AS RowNum
    FROM 
        [AdventureWorks2022].[Production].[Product] p
        INNER JOIN [AdventureWorks2022].[Production].[ProductSubcategory] psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
        INNER JOIN [AdventureWorks2022].[Production].[ProductCategory] pc ON psc.ProductCategoryID = pc.ProductCategoryID
    WHERE 
        p.ListPrice > 0
)
SELECT *
FROM RankedProducts
WHERE RowNum <= 3
ORDER BY Category, RowNum;

-- 2. Using RANK() to see how ties are handled
WITH RankedProducts AS (
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        pc.Name AS Category,
        p.ListPrice AS Price,
        RANK() OVER (PARTITION BY pc.Name ORDER BY p.ListPrice DESC) AS PriceRank
    FROM 
        [AdventureWorks2022].[Production].[Product] p
        INNER JOIN [AdventureWorks2022].[Production].[ProductSubcategory] psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
        INNER JOIN [AdventureWorks2022].[Production].[ProductCategory] pc ON psc.ProductCategoryID = pc.ProductCategoryID
    WHERE 
        p.ListPrice > 0
)
SELECT *
FROM RankedProducts
WHERE PriceRank <= 3
ORDER BY Category, PriceRank;

-- 3. Using DENSE_RANK() to see how ties are handled differently
WITH RankedProducts AS (
    SELECT 
        p.ProductID,
        p.Name AS ProductName,
        pc.Name AS Category,
        p.ListPrice AS Price,
        DENSE_RANK() OVER (PARTITION BY pc.Name ORDER BY p.ListPrice DESC) AS DensePriceRank
    FROM 
        [AdventureWorks2022].[Production].[Product] p
        INNER JOIN [AdventureWorks2022].[Production].[ProductSubcategory] psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
        INNER JOIN [AdventureWorks2022].[Production].[ProductCategory] pc ON psc.ProductCategoryID = pc.ProductCategoryID
    WHERE 
        p.ListPrice > 0
)
SELECT *
FROM RankedProducts
WHERE DensePriceRank <= 3
ORDER BY Category, DensePriceRank;