CREATE TABLE Category (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Description TEXT NOT NULL
);
CREATE TABLE Product (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
	CategoryId INTEGER NOT NULL,
    Name TEXT NOT NULL,                   
    ProductCode TEXT UNIQUE NOT NULL,     
    Price REAL NOT NULL,                  
    SKU TEXT NOT NULL,                    
    StockQuantity INTEGER NOT NULL,      
    DateAdded TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP ,
	
	FOREIGN KEY (CategoryId) REFERENCES Category(Id)
);
