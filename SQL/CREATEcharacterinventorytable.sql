CREATE TABLE CharacterInventory
  (
  CharacterName varchar(50)
    CONSTRAINT CharacterInventory_fk1
	  FOREIGN KEY (CharacterName)
	  REFERENCES CharacterDetails(CharacterName)
	NOT NULL,
  ItemName varchar(50)
    CONSTRAINT CharacterInventory_fk2
	  FOREIGN KEY (ItemName)
	  REFERENCES Items(ItemName)
	NOT NULL,
  ItemQuantity int
    CONSTRAINT ItemQuantity_Check
	  CHECK (ItemQuantity >= 0)
	NOT NULL,
  CONSTRAINT CharacterName_pk
    PRIMARY KEY (CharacterName, ItemName)
  );