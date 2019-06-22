CREATE TABLE Spells
  (
  SpellName varchar(50)
    CONSTRAINT SpellName_pk
	  PRIMARY KEY (SpellName)
	NOT NULL,
  SpellLevel smallint
    CONSTRAINT SpellLevel_Check
	  CHECK (SpellLevel >= 0 AND SpellLevel <= 9)
	NOT NULL,
  SchoolOfMagic varchar(15)
    CONSTRAINT SchoolOfMagic_Check
	  CHECK (SchoolOfMagic IN ('Abjuration', 'Conjuration',
	  'Divination', 'Enchantment', 'Evocation', 'Illusion',
	  'Necromancy', 'Transmutation'))
	NOT NULL,
  SpellCastingTime varchar(20)
    NOT NULL,
  Ritual bit
    NOT NULL,
  SpellRange varchar(50)
    NOT NULL,
  SpellComponents varchar (100)
    NOT NULL,
  SpellDuration varchar(50)
    NOT NULL,
  SpellDescription varchar(300)
    NOT NULL
  );