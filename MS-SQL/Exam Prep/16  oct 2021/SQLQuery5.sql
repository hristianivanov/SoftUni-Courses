USE CigarShop
GO

--5
	SELECT 
			CigarName,
			PriceForSingleCigar,
			ImageURL
	  FROM Cigars
  ORDER BY PriceForSingleCigar,
		   CigarName DESC

--6
	SELECT 
			c.Id,
			CigarName,
			PriceForSingleCigar,
			t.TasteType,
			t.TasteStrength
	  FROM Cigars
		AS c
		JOIN Tastes
		AS t
		ON t.Id = c.TastId
	 WHERE TastId IN 
						(
							SELECT Id
							  FROM Tastes
							 WHERE TasteType IN ('Earthy','Woody')
						)
  ORDER BY PriceForSingleCigar DESC

--7
	SELECT 
			c.Id,
			CONCAT_WS(' ',c.FirstName,c.LastName)
		AS [ClientName],
			Email
	  FROM Clients
		AS c
	LEFT JOIN ClientsCigars
		AS clc
		ON clc.ClientId = c.Id
	 WHERE clc.ClientId IS NULL
  ORDER BY ClientName

--8
	SELECT TOP 5
			CigarName,
			PriceForSingleCigar,
			ImageURL
	  FROM Cigars
		AS c
	INNER JOIN Sizes
		AS s
		ON s.Id = c.SizeId
	 WHERE s.Length >= 12 AND
		   (c.CigarName LIKE '%ci%' OR c.PriceForSingleCigar > 50) AND
		   s.RingRange > 2.55
  ORDER BY c.CigarName,
		   c.PriceForSingleCigar DESC

--9
	SELECT
			CONCAT_WS(' ',cl.FirstName,cl.LastName)
		AS [FullName],
			a.Country,
			a.ZIP,
			'$' + CAST(MAX(c.PriceForSingleCigar) AS VARCHAR)
		AS [CigarPrice]
	  FROM Clients
		AS cl
		JOIN Addresses
		AS a
		ON a.Id = cl.AddressId
	LEFT JOIN ClientsCigars
		AS clc
		ON clc.ClientId = cl.Id
	LEFT JOIN Cigars
		AS c
		ON c.Id = clc.CigarId
	 WHERE a.ZIP NOT LIKE '%[A-Z]%'
  GROUP BY cl.FirstName,cl.LastName,a.Country,a.ZIP
  ORDER BY FullName, CigarPrice DESC

--10
	SELECT 
			cl.LastName,
			AVG(s.Length)
		AS [CiagrLength],
			CEILING(AVG(s.RingRange))
		AS [CiagrRingRange]
      FROM Clients
		AS cl
	 JOIN ClientsCigars
		AS cc
		ON cc.ClientId = cl.Id
	 JOIN Cigars
		AS c
		ON c.Id = cc.CigarId
	 JOIN Sizes
		AS s
		ON s.Id = c.SizeId
  GROUP BY cl.LastName
  ORDER BY CiagrLength DESC

GO
--11
	CREATE FUNCTION udf_ClientWithCigars (@name NVARCHAR(30)) 
	RETURNS INT
		AS
		BEGIN
				DECLARE @cigrCnt INT
				SET @cigrCnt = 
								(
									SELECT COUNT(*)
									  FROM Clients
										AS c
									LEFT JOIN ClientsCigars
										AS cc
										ON cc.ClientId = c.Id
									 WHERE c.FirstName = @name
								)
				RETURN @cigrCnt
		  END
GO

SELECT dbo.udf_ClientWithCigars('Betty')

GO
--12
CREATE PROCEDURE usp_SearchByTaste (@taste NVARCHAR(20))
AS
BEGIN 
	SELECT 
			c.CigarName,
			'$'+CAST(c.PriceForSingleCigar AS VARCHAR),
			t.TasteType,
			b.BrandName,
			CAST(s.Length AS VARCHAR)+' cm',
			CAST(s.RingRange AS VARCHAR)+' cm'
	  FROM Cigars
		AS c
	LEFT JOIN Tastes
		AS t
		ON c.TastId = t.Id
	LEFT JOIN Brands
		AS b
		ON b.Id = c.BrandId
	LEFT JOIN Sizes
		AS s
		ON s.Id = c.SizeId
	 WHERE t.TasteType = @taste
  ORDER BY s.Length,
		   s.RingRange DESC
END

GO
EXEC usp_SearchByTaste 'Woody'

		







	