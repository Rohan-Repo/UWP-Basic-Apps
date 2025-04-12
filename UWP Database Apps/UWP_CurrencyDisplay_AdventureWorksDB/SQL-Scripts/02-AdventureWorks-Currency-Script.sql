USE AdventureWorks2022;

-- Currency Table Data
SELECT * FROM Sales.Currency;

-- CurrencyRate Table Data
SELECT * FROM Sales.CurrencyRate;

-- Aggregate Functions
SELECT 
	ToCurrencyCode, 
	MAX(AverageRate) AS maxAvgRate, 
	MAX(EndOfDayRate) AS maxEndOfDayRate 
FROM 
	Sales.CurrencyRate
GROUP BY
	ToCurrencyCode 
ORDER BY
MAX(AverageRate);

-- Simple Join 
SELECT * FROM Sales.Currency 
INNER JOIN Sales.CurrencyRate
ON Sales.Currency.CurrencyCode =
Sales.CurrencyRate.ToCurrencyCode;

-- From,To Currency Data
SELECT DISTINCT
	FromCurrencyCode,
	'US Dollars' AS fromCurrencyStr,
	ToCurrencyCode, 
	Name AS toCurrencyStr,
	AverageRate,
	EndOfDayRate
FROM
	Sales.Currency
INNER JOIN 
	Sales.CurrencyRate
ON
	Sales.Currency.CurrencyCode =
	Sales.CurrencyRate.ToCurrencyCode
ORDER BY
	AverageRate ASC;

-- Max of From,To Currency Data
SELECT DISTINCT
	FromCurrencyCode,
	'US Dollars' AS fromCurrencyStr,
	ToCurrencyCode, 
	Name AS toCurrencyStr,
	AverageRate,
	EndOfDayRate
FROM
	Sales.Currency
INNER JOIN 
	Sales.CurrencyRate
ON
	Sales.Currency.CurrencyCode =
	Sales.CurrencyRate.ToCurrencyCode
WHERE
	AverageRate =
	( 
		SELECT MAX(AverageRate)
		FROM Sales.CurrencyRate
		WHERE
		Sales.CurrencyRate.ToCurrencyCode
		=
		Sales.Currency.CurrencyCode
	)
AND
	EndOfDayRate =
	( 
		SELECT MAX(EndOfDayRate)
		FROM Sales.CurrencyRate
		WHERE
		Sales.CurrencyRate.ToCurrencyCode
		=
		Sales.Currency.CurrencyCode
	)
ORDER BY
	AverageRate ASC;

-- Above Query in One line
SELECT DISTINCT FromCurrencyCode, 'US Dollars' AS fromCurrencyStr, ToCurrencyCode, Name AS toCurrencyStr, AverageRate, EndOfDayRate FROM Sales.Currency INNER JOIN Sales.CurrencyRate ON Sales.Currency.CurrencyCode = Sales.CurrencyRate.ToCurrencyCode WHERE AverageRate = ( SELECT MAX(AverageRate) FROM Sales.CurrencyRate WHERE Sales.CurrencyRate.ToCurrencyCode = Sales.Currency.CurrencyCode ) AND EndOfDayRate = ( SELECT MAX(EndOfDayRate) FROM Sales.CurrencyRate WHERE Sales.CurrencyRate.ToCurrencyCode = Sales.Currency.CurrencyCode ) ORDER BY AverageRate ASC;