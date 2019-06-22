CREATE TABLE Items
  (
  ItemName varchar(50)
    CONSTRAINT Items_pk
	  PRIMARY KEY (ItemName)
	NOT NULL,
  ItemDescription varchar(300)
    NOT NULL,
  ItemValue int
    CONSTRAINT ItemValue_Check
	  CHECK (ItemValue >= 0)
    NOT NULL,
  );