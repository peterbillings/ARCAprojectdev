use CharacterManagementDB;

create table QuestLog
(
	LogEntry_ID int identity(1, 1) primary key,
	EntryDate date not null,
	EntryText varchar(1000) not null,
);