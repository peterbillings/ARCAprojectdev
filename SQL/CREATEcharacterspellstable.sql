CREATE TABLE CharacterSpells
  (
  CharacterName varchar(50)
    CONSTRAINT CharacterSpells_fk1
	  FOREIGN KEY (CharacterName)
	  REFERENCES CharacterDetails(CharacterName)
	NOT NULL,
  SpellName varchar(50)
    CONSTRAINT CharacterSpells_fk2
	  FOREIGN KEY (SpellName)
	  REFERENCES Spells(SpellName)
	NOT NULL,
  CONSTRAINT CharacterSpells_pk
    PRIMARY KEY (CharacterName, SpellName)
  );