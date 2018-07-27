USE [PropertyManagementDb]
GO

INSERT INTO [dbo].[ExpenseIncomeCategories] ([Label], [Description], [IsTaxDeductible]) VALUES('Insurance', 'Expense', 1)
INSERT INTO [dbo].[ExpenseIncomeCategories] ([Label], [Description], [IsTaxDeductible]) VALUES('Rent', 'Income', 0)
INSERT INTO [dbo].[ExpenseIncomeCategories] ([Label], [Description], [IsTaxDeductible]) VALUES('HOA', 'Home Owners Association', 1)
INSERT INTO [dbo].[ExpenseIncomeCategories] ([Label], [Description], [IsTaxDeductible]) VALUES('Maintenance', 'Expense', 1)
GO


