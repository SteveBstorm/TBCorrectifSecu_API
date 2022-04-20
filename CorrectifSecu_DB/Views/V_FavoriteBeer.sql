CREATE VIEW [dbo].[V_FavoriteBeer]
	AS SELECT b.Id as Id, b.Name as Name, b.Degree as Degree, b.Origin as Origin, f.AppUserId AS 'uid' FROM Beer b 
	JOIN FavoriteBeer f ON b.Id = f.BeerId
