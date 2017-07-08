USE [TurtleBarrel]
GO
SET IDENTITY_INSERT [Identity].[Roles] ON 

INSERT [Identity].[Roles] ([Id], [Name]) VALUES (1, N'Administrator')
INSERT [Identity].[Roles] ([Id], [Name]) VALUES (2, N'Moderator')
SET IDENTITY_INSERT [Identity].[Roles] OFF
SET IDENTITY_INSERT [Identity].[Users] ON 

INSERT [Identity].[Users] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (2, N'admin@januszmarcinik.pl', 0, N'AI7xG8ljvzq7z4NpaTcXQ8rObzn1IRIHttmzPtMorNZUbWjI7wJcyBq9nhu/w+Lfbg==', N'fabafc02-6d40-4bc6-85fc-d80e0b093c19', NULL, 0, 0, NULL, 1, 0, N'admin@januszmarcinik.pl')
INSERT [Identity].[Users] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (3, N'marta@januszmarcinik.pl', 0, N'ALTvfudtu+JgYDW18XMaspfC/DunHbJNPcytEBJfjXLto8gW6CzDOMKM6GhYO5Ne/A==', N'11a8860c-e044-4316-8b14-70a7ae8eafe1', NULL, 0, 0, NULL, 1, 0, N'marta@januszmarcinik.pl')
SET IDENTITY_INSERT [Identity].[Users] OFF
SET IDENTITY_INSERT [Identity].[UserRoles] ON 

INSERT [Identity].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (1, 2, 1)
INSERT [Identity].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (2, 2, 2)
INSERT [Identity].[UserRoles] ([Id], [UserId], [RoleId]) VALUES (3, 3, 2)
SET IDENTITY_INSERT [Identity].[UserRoles] OFF
