use CharacterManagementDB;

create table Background
(
	Background varchar(15)
		constraint Background_pk
		primary key (Background)
)
;

insert into background values ('Acolyte');
insert into background values ('Charlatan');
insert into background values ('Criminal');
insert into background values ('Entertainer');
insert into background values ('Folk Hero');
insert into background values ('Guild Artisan');
insert into background values ('Noble');
insert into background values ('Outlander');
insert into background values ('Sage');
insert into background values ('Sailor');
insert into background values ('Soldier');
insert into background values ('Urchin');

alter table characterdetails
	drop constraint background_check
;

alter table characterdetails
	add constraint Background_fk foreign key (background)
		references dbo.background (background)
;
