use CharacterManagementDB;

create index cDetails_Alignment
	on CharacterDetails (alignment);

create index cDetails_Background
	on CharacterDetails (background);

create index cDetails_CharacterClass
	on CharacterDetails (characterclass);
	
create index cDetails_HitDice
	on CharacterDetails (hitdice);

create index cDetails_Race
	on CharacterDetails (race);

create index cInventory_CharacterName
	on CharacterInventory (charactername);

create index cInventory_ItemName
	on CharacterInventory (itemname);

create index cSpells_CharacterName
	on CharacterSpells (charactername);

create index cSpells_SpellName
	on CharacterSpells (spellname);

create index spells_SchoolOfMagic
	on Spells (schoolofmagic);

create index cStatus_CharacterName
	on CharacterStatus (charactername);


