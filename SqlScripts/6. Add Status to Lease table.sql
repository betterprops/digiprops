IF OBJECT_ID (N'LeaseStatus', N'U') IS NULL
BEGIN
CREATE TABLE dbo.LeaseStatus
	(
	Id int NOT NULL IDENTITY (1, 1),
	Label varchar(50) NOT NULL
	)  ON [PRIMARY]
ALTER TABLE dbo.LeaseStatus ADD CONSTRAINT
	PK_LeaseStatus PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

ALTER TABLE dbo.LeaseStatus SET (LOCK_ESCALATION = TABLE)

INSERT INTO dbo.LeaseStatus (Label) VALUES ('Pending Signature')
INSERT INTO dbo.LeaseStatus (Label) VALUES ('Active')
INSERT INTO dbo.LeaseStatus (Label) VALUES ('Expired')
INSERT INTO dbo.LeaseStatus (Label) VALUES ('Archived')
END
GO

IF COL_LENGTH('Lease', 'LeaseStatusId') IS NULL
BEGIN
    ALTER TABLE Lease
    ADD LeaseStatusId INT NOT NULL DEFAULT(1)
END

IF NOT EXISTS (SELECT TOP 1 1 FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE TABLE_NAME = 'Lease' AND CONSTRAINT_NAME = 'FK_Lease_LeaseStatus')
BEGIN
	ALTER TABLE [dbo].[Lease] WITH CHECK ADD CONSTRAINT [FK_Lease_LeaseStatus] FOREIGN KEY([LeaseStatusId]) REFERENCES [dbo].[LeaseStatus] ([Id])
END
