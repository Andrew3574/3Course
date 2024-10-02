create table Users(
UserId int identity(1,1) primary key,
[Login] varchar(32) unique not null,
[Password] varchar(32) not null,
[Email] varchar(32) unique not null
);

create table Muscles(
MuscleId int identity(1,1) primary key,
[Name] varchar(32) unique not null
);

create table [Sets](
SetId int identity(1,1) primary key,
[Name] varchar(32) not null,
[UserId] int references Users (UserId) on delete cascade
);

create table [Excercises](
ExcerciseId int identity(1,1) primary key,
[Name] varchar(32) unique not null,
[MuscleId] int references Muscles (MuscleId) on delete cascade,
[Description] varchar(50)
);

create table [SetExcercises](
Id int identity(1,1) primary key,
[ExcerciseId] int references [Excercises] (ExcerciseId) on delete cascade,
[SetId] int references [Sets] (SetId) on delete cascade,
[RepeatsNumber] int not null,
[IterationNumber] int not null,
[RepeatsDelay] time(0) not null,
[RestTimeAfter] time(0) not null
);
