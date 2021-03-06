use CharacterManagementDB;

create table HitDice
(
	HitDice varchar(4)
		constraint HitDice_pk
		primary key (HitDice)
)
;

insert into hitdice values ('1d4');
insert into hitdice values ('1d6');
insert into hitdice values ('1d8');
insert into hitdice values ('1d10');
insert into hitdice values ('1d12');

alter table characterdetails
	drop constraint hitdice_check
;

alter table characterdetails
	add constraint HitDice_fk foreign key (HitDice)
	references dbo.HitDice (HitDice)
;