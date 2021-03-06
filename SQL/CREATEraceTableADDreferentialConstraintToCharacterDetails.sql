use CharacterManagementDB;


create table Race
(
	Race varchar(15)
		CONSTRAINT Race_pk
		PRIMARY KEY (Race)
)
;

insert into race values ('Dragonborn');
insert into race values ('Dwarf');
insert into race values ('Elf');
insert into race values ('Gnome');
insert into race values ('Half Elf');
insert into race values ('Half Orc');
insert into race values ('Halfling');
insert into race values ('Human');
insert into race values ('Tiefling');

alter table characterdetails
	drop constraint race_check
;

alter table characterdetails
	add constraint Race_fk foreign key (race)
		references dbo.race (race)
;
	