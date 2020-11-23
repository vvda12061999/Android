CREATE TABLE IF NOT EXISTS [Reviewed] (
[ID] INT NULL,
[Name] VARCHAR NULL,
[RestaurantType] VARCHAR NULL,
[TimeVisit] VARCHAR NULL,
[CleanessRating] INT NULL,
[ServicesRating] INT NULL,
[FoodQualityRating] INT NULL,
[OverallRating] INT NULL,
[Description] VARCHAR NULL,
[Reporter.ID] INT NULL,
[Reporter.FirstName] VARCHAR NULL,
[Reporter.LastName] VARCHAR NULL
);

INSERT INTO Reviewed VALUES
(-1,'asdsad','Street food','2020-11-23T00:57:48.7880781+07:00',3,3,4,4,'asdasd',0,'Firstname','Lastname'),
(0,'ASDASDSADSADSADAD','Cafeteria','2020-11-24T01:57:54.5533579+07:00',5,3,1,5,'Test',0,'Firstname','Lastname'),
(1,'asdsad','Sea food','2020-11-24T01:59:17.6366592+07:00',1,3,5,3,'',0,'Firstname','Lastname');