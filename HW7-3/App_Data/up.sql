CREATE TABLE dbo.Logs(
	id				int				IDENTITY(1,1) NOT NULL PRIMARY KEY,
	searched		varchar(128)	NOT NULL,
	dateSearched	dateTime		NOT NULL,
	requestorIP     varchar(128)	NOT NULL,
	requestorAgent  varchar(808)	NOT NULL
)