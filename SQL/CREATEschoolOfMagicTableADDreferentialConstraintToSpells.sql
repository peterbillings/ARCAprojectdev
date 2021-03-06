use CharacterManagementDB;

create table SchoolOfMagic
(
	SchoolOfMagic varchar(15)
		constraint SchoolOfMagic_pk
		primary key (SchoolOfMagic)
)
;

insert into schoolofmagic values ('Abjuration');
insert into schoolofmagic values ('Conjuration');
insert into schoolofmagic values ('Divination');
insert into schoolofmagic values ('Enchantment');
insert into schoolofmagic values ('Evocation');
insert into schoolofmagic values ('Illusion');
insert into schoolofmagic values ('Necromancy');
insert into schoolofmagic values ('Transmutation');

alter table spells
	drop constraint schoolofmagic_check
;

alter table spells
	add constraint SchoolOfMagic_fk foreign key (SchoolOfMagic)
	references dbo.SchoolOfMagic (SchoolOfMagic)
;
		