IF OBJECT_ID (N'LeaseApplicationStatus', N'U') IS NULL
BEGIN
CREATE TABLE dbo.LeaseApplicationStatus
	(
	Id int NOT NULL IDENTITY (1, 1),
	Label varchar(50) NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.LeaseApplicationStatus ADD CONSTRAINT
	PK_LeaseApplicationStatus PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.LeaseApplicationStatus SET (LOCK_ESCALATION = TABLE)

INSERT INTO dbo.LeaseApplicationStatus (Label) VALUES ('Active')
INSERT INTO dbo.LeaseApplicationStatus (Label) VALUES ('Approved')
INSERT INTO dbo.LeaseApplicationStatus (Label) VALUES ('Rejected')
INSERT INTO dbo.LeaseApplicationStatus (Label) VALUES ('Archived')
END
GO

IF COL_LENGTH('LeaseApplication', 'LeaseApplicationStatusId') IS NULL
BEGIN
    ALTER TABLE LeaseApplication
    ADD LeaseApplicationStatusId INT NOT NULL DEFAULT(1)
END

IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME = 'LeaseApplication' AND CONSTRAINT_NAME = 'FK_LeaseApplication_LeaseApplicationStatus')
BEGIN
	ALTER TABLE [dbo].[LeaseApplication] WITH CHECK ADD CONSTRAINT [FK_LeaseApplication_LeaseApplicationStatus] FOREIGN KEY([LeaseApplicationStatusId]) REFERENCES [dbo].[LeaseApplicationStatus] ([Id])
END