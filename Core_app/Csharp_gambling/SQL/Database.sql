-- Create CasinoDB database
CREATE DATABASE CasinoDB;
GO

-- Use CasinoDB database
USE CasinoDB;
GO

-- Create Stats table
CREATE TABLE Stats (
    statid INT PRIMARY KEY IDENTITY(1,1),
    totaldeposit MONEY DEFAULT 0.0,
    totalmoneyplayed INT DEFAULT 0, 
    crashwr INT DEFAULT 0,           
    blackjackwr INT DEFAULT 0,      
    roulettewr INT DEFAULT 0,       
    mines INT DEFAULT 0           
);

-- Create Main table with not null constraints and foreign key reference to Stats
CREATE TABLE Main (
    id INT PRIMARY KEY IDENTITY(1,1),
    balance MONEY DEFAULT 0.0,      
    username NVARCHAR(40) UNIQUE NOT NULL, 
    password NVARCHAR(50) NOT NULL,
    statid INT FOREIGN KEY REFERENCES Stats(statid)
);
