use CharacterManagementDB;

create table CharacterStatus
(
	CharacterName varchar(50)
		constraint CharacterStatus_pk
			primary key (CharacterName)
		constraint CharacterStatus_fk1
			foreign key (CharacterName)
			references CharacterDetails(CharacterName),
	CurrentHP int
		constraint currenthp_check
		check (CurrentHP >= 0)
		not null
		default 0,
	TempHP int
		constraint temphp_check
		check (TempHP >= 0)
		not null
		default 0,
	Gold int
		constraint gold_check
		check (Gold >= 0)
		not null
		default 0,
	Exhaustion int
		constraint exhaustion_check
		check (Exhaustion >= 0 and Exhaustion <= 6)
		not null
		default 0,
	Condition varchar(30)
		not null
		default 'Normal',
	Perception int
		constraint perception_check
		check (Perception >= 0)
		not null
		default 10
)
;