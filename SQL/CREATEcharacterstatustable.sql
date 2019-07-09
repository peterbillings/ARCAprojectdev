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
	ExhaustionLevel int
		constraint exhaustionlevel_check
		check (ExhaustionLevel >= 0 and ExhaustionLevel <= 6)
		not null
		default 0,
	Buff varchar(30)
		not null
		default 'None',
	Debuff
		varchar(30)
		not null
		default 'None'
)
;