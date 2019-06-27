use CharacterManagementDB;

CREATE TABLE CharacterDetails
  (
  CharacterName varchar(50)
    CONSTRAINT CharacterDetails_pk
      PRIMARY KEY (CharacterName)
	NOT NULL,
  PlayerName varchar(50) 
    NOT NULL,
  Race varchar(15)
    CONSTRAINT Race_check
	  CHECK (Race IN ('Dragonborn',
	  'Dwarf', 'Elf', 'Gnome', 'Half Elf',
	  'Half Orc', 'Halfling', 'Human',
	  'Tiefling'))
	NOT NULL,
  CharacterClass varchar(15)
    CONSTRAINT CharacterClass_Check
	  CHECK (CharacterClass IN ('Barbarian', 'Bard',
	  'Cleric', 'Druid', 'Fighter', 'Monk', 'Paladin',
	  'Ranger', 'Rogue', 'Sorcerer', 'Warlock', 'Wizard'))
	NOT NULL,
  Background varchar(15)
    CONSTRAINT Background_Check
	  CHECK (Background IN ('Acolyte', 'Charlatan', 'Criminal',
	  'Entertainer', 'Folk Hero', 'Guild Artisan', 'Noble',
	  'Outlander', 'Sage', 'Sailor', 'Soldier', 'Urchin'))
	NOT NULL,
  Alignment varchar(15)
    CONSTRAINT Alignment_Check
	  CHECK (Alignment IN ('Lawful Good', 'Neutral Good', 'Chaotic Good',
	  'Lawful Neutral', 'Neutral', 'Chaotic Neutral', 'Lawful Evil',
	  'Neutral Evil', 'Chaotic Evil'))
	NOT NULL,
  CharacterLevel smallint
    CONSTRAINT CharacterLevel_Check
	  CHECK (CharacterLevel >= 1 AND CharacterLevel <= 20)
	NOT NULL,
  Experience int
    CONSTRAINT Experience_Check
	  CHECK (Experience >= 0 AND Experience <= 355000)
    NOT NULL,
  Strength smallint
    CONSTRAINT Strength_Check
	  CHECK (Strength >= 1 AND Strength <= 20)
	NOT NULL,
  StrengthMod smallint
    CONSTRAINT StrengthMod_Check
	  CHECK (StrengthMod >= -10 AND StrengthMod <= 10)
	NOT NULL,
  Dexterity smallint
    CONSTRAINT Dexterity_Check
	  CHECK (Dexterity >= 1 AND Dexterity <= 20)
	NOT NULL,
  DexterityMod smallint
    CONSTRAINT DexterityMod_Check
	  CHECK (DexterityMod >= -10 AND DexterityMod <= 10)
	NOT NULL,
  Constitution smallint
    CONSTRAINT Constitution_Check
	  CHECK (Constitution >= 1 AND Constitution <= 20)
	NOT NULL,
  ConstitutionMod smallint
    CONSTRAINT ConstitutionMod_Check
	  CHECK (ConstitutionMod >= -10 AND ConstitutionMod <= 10)
	NOT NULL,
  Intelligence smallint
    CONSTRAINT Intelligence_Check
	  CHECK (Intelligence >= 1 AND Intelligence <= 20)
	NOT NULL,
  IntelligenceMod smallint
    CONSTRAINT IntelligenceMod_Check
	  CHECK (IntelligenceMod >= -10 AND IntelligenceMod <= 10)
	NOT NULL,
  Wisdom smallint
    CONSTRAINT Wisdom_Check
	  CHECK (Wisdom >= 1 AND Wisdom <= 20)
	NOT NULL,
  WisdomMod smallint
    CONSTRAINT WisdomMod_Check
	  CHECK (WisdomMod >= -10 AND WisdomMod <= 10)
	NOT NULL,
  Charisma smallint
    CONSTRAINT Charisma_Check
	  CHECK (Charisma >= 1 AND Charisma <= 20)
	NOT NULL,
  CharismaMod smallint
    CONSTRAINT CharismaMod_Check
	  CHECK (CharismaMod >= -10 AND CharismaMod <= 10)
	NOT NULL,
  MaxHp smallint
    CONSTRAINT MaxHp_Check
	  CHECK (MaxHp >= 1 AND MaxHp <= 440)
	NOT NULL,
  ArmorClass smallint
    CONSTRAINT ArmorClass_Check
	  CHECK (ArmorClass >= 0 AND ArmorClass <= 31)
	NOT NULL,
  HitDice varchar(4)
    CONSTRAINT HitDice_Check
	  CHECK (HitDice IN ('1d4', '1d6', '1d8', '1d10', '1d12'))
	NOT NULL,
  HitDiceTotal smallint
    CONSTRAINT HitDiceTotal_Check
	  CHECK (HitDiceTotal >= 1 AND HitDiceTotal <= 20)
	NOT NULL,
  ProficiencyBonus smallint
    CONSTRAINT ProficiencyBonus_Check
	  CHECK (ProficiencyBonus IN (2, 4, 6))
	NOT NULL,
  PassivePerception smallint
    CONSTRAINT PassivePerception_Check
	  CHECK (PassivePerception >= 0 AND PassivePerception <= 30)
	NOT NULL,
  Initiative smallint
    CONSTRAINT Initiative_Check
	  CHECK (Initiative >= -10 AND Initiative <= 10)
	NOT NULL,
  Speed smallint
    CONSTRAINT Speed_Check
	  CHECK (Speed >= 0)
	NOT NULL,
  PersonalityTraits varchar(300)
    NOT NULL,
  Ideals varchar(300)
    NOT NULL,
  Bonds varchar(300)
    NOT NULL,
  Flaws varchar(300)
    NOT NULL,
  AdditionalFeatures varchar(300)
    NOT NULL,
  Languages varchar(300)
    NOT NULL,
  Acrobatics bit
    NOT NULL,
  AnimalHandling bit
    NOT NULL,
  Arcana bit
    NOT NULL,
  Athletics bit
    NOT NULL,
  Deception bit
    NOT NULL,
  History bit
    NOT NULL,
  Insight bit
    NOT NULL,
  Intimidation bit
    NOT NULL,
  Investigation bit
    NOT NULL,
  Medicine bit
    NOT NULL,
  Nature bit
    NOT NULL,
  Perception bit
    NOT NULL,
  Performance bit
    NOT NULL,
  Persuasion bit
    NOT NULL,
  Religion bit
    NOT NULL,
  SleightOfHand bit
    NOT NULL,
  Stealth bit
    NOT NULL,
  Survival bit
    NOT NULL,
  StrengthSave bit
    NOT NULL,
  DexteritySave bit
    NOT NULL,
  ConstitutionSave bit
    NOT NULL,
  IntelligenceSave bit
    NOT NULL,
  WisdomSave bit
    NOT NULL,
  CharismaSave bit
    NOT NULL
  );