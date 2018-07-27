
IF NOT EXISTS (SELECT * FROM ResposibleParty where ResponsibleParty = 'Property Owner')
begin
	INSERT INTO [dbo].[ResposibleParty]
           ([ResponsibleParty])
     VALUES
           ('Property Owner')
end

IF NOT EXISTS (SELECT * FROM ResposibleParty where ResponsibleParty = 'Tenant')
begin
	INSERT INTO [dbo].[ResposibleParty]
           ([ResponsibleParty])
     VALUES
           ('Tenant')
end

IF NOT EXISTS (SELECT * FROM ResposibleParty where ResponsibleParty = 'Other')
begin
	INSERT INTO [dbo].[ResposibleParty]
           ([ResponsibleParty])
     VALUES
           ('Other')
end