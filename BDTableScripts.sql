CREATE DATABASE buildings_registry
GO

USE buildings_registry
GO

CREATE TABLE province(
	Id INT PRIMARY KEY IDENTITY(1,1),
	ProvinceCode INT UNIQUE,
	ProvinceName VARCHAR(80)
);

CREATE TABLE canton(
	Id INT PRIMARY KEY IDENTITY(1,1),
	CantonCode INT UNIQUE,
	ProvinceCode INT,
	CantonName VARCHAR(80),

	FOREIGN KEY (ProvinceCode) REFERENCES province(ProvinceCode)
);

CREATE TABLE area(
	Id INT PRIMARY KEY IDENTITY(1,1),
	AreaCode INT UNIQUE,
	CantonCode INT,
	AreaName VARCHAR(100),

	FOREIGN KEY (CantonCode) REFERENCES canton(CantonCode)
);

CREATE TABLE propertyStatus(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Status VARCHAR(50)
);

CREATE TABLE buildings(
	Id INT PRIMARY KEY IDENTITY(1,1),
	BuildingName VARCHAR(200),
	Capacity INT,
	ProvinceCode INT, 
	CantonCode INT,
	AreaCode INT,
	PropertyStatus INT,

	FOREIGN KEY (ProvinceCode) REFERENCES province(ProvinceCode),
	FOREIGN KEY (CantonCode) REFERENCES canton(CantonCode),
	FOREIGN KEY (AreaCode) REFERENCES area(AreaCode),
	FOREIGN KEY (PropertyStatus) REFERENCES propertyStatus(Id)
);

CREATE TABLE serviceType(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Type VARCHAR(50)
);

CREATE TABLE unit(
	Id INT PRIMARY KEY IDENTITY(1,1),
	UnitName VARCHAR(80)
);

CREATE TABLE publicServices(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NameService VARCHAR(200),
	TypeService INT,
	CompanyName VARCHAR(200),

	FOREIGN KEY (TypeService) REFERENCES  unit(Id)
);

CREATE TABLE servicesAssigned(
	Id INT PRIMARY KEY IDENTITY(1,1),
	BuildingId INT,
	ServiceId INT,

	FOREIGN KEY (BuildingId) REFERENCES  buildings(Id),
	FOREIGN KEY (ServiceId) REFERENCES  publicServices(Id)
);