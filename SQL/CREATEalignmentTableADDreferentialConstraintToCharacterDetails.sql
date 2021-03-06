use CharacterManagementDB;

create table Alignment
(
	Alignment varchar(15)
		constraint Alignment_pk
		primary key (Alignment)
)
;

insert into alignment values ('Lawful Good');
insert into alignment values ('Neutral Good');
insert into alignment values ('Chaotic Good');
insert into alignment values ('Lawful Neutral');
insert into alignment values ('Neutral');
insert into alignment values ('Chaotic Neutral');
insert into alignment values ('Lawful Evil');
insert into alignment values ('Neutral Evil');
insert into alignment values ('Chaotic Evil');

alter table characterdetails
	drop constraint alignment_check
;

alter table characterdetails
	add constraint Alignment_fk foreign key (alignment)
		references dbo.alignment (alignment)
;