-- Create CasinoDB database
CREATE DATABASE CasinoDB;
GO

-- Use CasinoDB database
USE CasinoDB;
GO

-- Create Stats table
CREATE TABLE Stats (
    statid INT PRIMARY KEY IDENTITY(1,1),
    totaldeposit MONEY,
    totalmoneyplayed INT,
    crashwr INT,
    blackjackwr INT,
    roulettewr INT,
    mines INT
);
GO

-- Create Main table with foreign key reference to Stats
CREATE TABLE Main (
    id INT PRIMARY KEY IDENTITY(1,1),
    balance MONEY,
    username NVARCHAR(40) UNIQUE,
    password NVARCHAR(50),
    statid INT FOREIGN KEY REFERENCES Stats(statid)
);
GO
