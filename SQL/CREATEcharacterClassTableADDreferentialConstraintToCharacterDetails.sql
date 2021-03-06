use CharacterManagementDB;

create table CharacterClass
(
	CharacterClass varchar(15)
		constraint CharacterClass_pk
		primary key (CharacterClass)
)
;

insert into characterclass values ('Barbarian');
insert into characterclass values ('Bard');
insert into characterclass values ('Cleric');
insert into characterclass values ('Druid');
insert into characterclass values ('Fighter');
insert into characterclass values ('Monk');
insert into characterclass values ('Paladin');
insert into characterclass values ('Ranger');
insert into characterclass values ('Rogue');
insert into characterclass values ('Sorcerer');
insert into characterclass values ('Warlock');
insert into characterclass values ('Wizard');

alter table characterdetails
	drop constraint characterclass_check
;

alter table characterdetails
	add constraint CharacterClass_fk foreign key (characterclass)
		references dbo.characterclass (characterclass)
;
