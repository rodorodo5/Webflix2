-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2017-05-07 20:29:09.167

-- tables
-- Table: Actor
CREATE TABLE Actor (
    Id bigint  NOT NULL IDENTITY,
    name varchar(50)  NOT NULL,
    path_image varchar(max)  NOT NULL,
    CONSTRAINT Actor_pk PRIMARY KEY  (Id)
);

-- Table: Country
CREATE TABLE Country (
    Id bigint  NOT NULL IDENTITY,
    name varchar(50)  NULL,
    abbv varchar(3)  NULL,
    CONSTRAINT Country_pk PRIMARY KEY  (Id)
);

-- Table: Director
CREATE TABLE Director (
    Id bigint  NOT NULL IDENTITY,
    name nvarchar(50)  NOT NULL,
    CONSTRAINT Director_pk PRIMARY KEY  (Id)
);

-- Table: Genre
CREATE TABLE Genre (
    Id bigint  NOT NULL IDENTITY,
    name varchar(50)  NOT NULL,
    CONSTRAINT Genre_pk PRIMARY KEY  (Id)
);

-- Table: Movie
CREATE TABLE Movie (
    Id bigint  NOT NULL IDENTITY,
    title nvarchar(255)  NULL,
    year smallint  NULL,
    lenght int  NULL,
    sinopsis varchar(max)  NOT NULL,
    description varchar(max)  NOT NULL,
    Country_Id bigint  NOT NULL,
    Director_Id bigint  NOT NULL,
    CONSTRAINT Movie_pk PRIMARY KEY  (Id)
);

-- Table: Movie_Actor
CREATE TABLE Movie_Actor (
    Id bigint  NOT NULL IDENTITY,
    Movie_Id bigint  NOT NULL,
    character_name varchar(50)  NOT NULL,
    character_description varchar(max)  NOT NULL,
    protagonist bit  NOT NULL,
    voice_only bit  NOT NULL,
    Actor_Id bigint  NOT NULL,
    CONSTRAINT Movie_Actor_pk PRIMARY KEY  (Id)
);

-- Table: Movie_Genre
CREATE TABLE Movie_Genre (
    Id bigint  NOT NULL IDENTITY,
    Genre_Id bigint  NOT NULL,
    Movie_Id bigint  NOT NULL,
    CONSTRAINT Movie_Genre_pk PRIMARY KEY  (Id)
);

-- Table: Poster
CREATE TABLE Poster (
    Id bigint  NOT NULL IDENTITY,
    path_image varchar(max)  NOT NULL,
    Movie_Id bigint  NOT NULL,
    CONSTRAINT Poster_pk PRIMARY KEY  (Id)
);

-- Table: Review
CREATE TABLE Review (
    Id bigint  NOT NULL IDENTITY,
    comment varchar(max)  NULL,
    rank tinyint  NOT NULL,
    watched bit  NOT NULL,
    wished bit  NOT NULL,
    Movie_Id bigint  NOT NULL,
    User_Id bigint  NOT NULL,
    Date date  NOT NULL,
    CONSTRAINT Review_pk PRIMARY KEY  (Id)
);

-- Table: Trailer
CREATE TABLE Trailer (
    Id bigint  NOT NULL IDENTITY,
    url varchar(max)  NOT NULL,
    Movie_Id bigint  NOT NULL,
    CONSTRAINT Trailer_pk PRIMARY KEY  (Id)
);

-- Table: User
CREATE TABLE "User" (
    Id bigint  NOT NULL IDENTITY,
    name varchar(max)  NOT NULL,
    last_name varchar(max)  NOT NULL,
    username varchar(max)  NOT NULL,
    email varchar(max)  NOT NULL,
    password varchar(max) NOT NULL,
    image varchar(max)  NOT NULL,
    age smallint  NOT NULL,
    User_Genre_Id int  NOT NULL,
    CONSTRAINT User_pk PRIMARY KEY  (Id)
);

-- Table: User_Genre
CREATE TABLE User_Genre (
    Id int  NOT NULL IDENTITY,
    name varchar(max)  NOT NULL,
    CONSTRAINT User_Genre_pk PRIMARY KEY  (Id)
);

-- foreign keys
-- Reference: Movie_Actor_Actor (table: Movie_Actor)
ALTER TABLE Movie_Actor ADD CONSTRAINT Movie_Actor_Actor
    FOREIGN KEY (Actor_Id)
    REFERENCES Actor (Id);

-- Reference: Movie_Actor_Movie (table: Movie_Actor)
ALTER TABLE Movie_Actor ADD CONSTRAINT Movie_Actor_Movie
    FOREIGN KEY (Movie_Id)
    REFERENCES Movie (Id);

-- Reference: Movie_Country (table: Movie)
ALTER TABLE Movie ADD CONSTRAINT Movie_Country
    FOREIGN KEY (Country_Id)
    REFERENCES Country (Id);

-- Reference: Movie_Director (table: Movie)
ALTER TABLE Movie ADD CONSTRAINT Movie_Director
    FOREIGN KEY (Director_Id)
    REFERENCES Director (Id);

-- Reference: Movie_Genre_Genre (table: Movie_Genre)
ALTER TABLE Movie_Genre ADD CONSTRAINT Movie_Genre_Genre
    FOREIGN KEY (Genre_Id)
    REFERENCES Genre (Id);

-- Reference: Movie_Genre_Movie (table: Movie_Genre)
ALTER TABLE Movie_Genre ADD CONSTRAINT Movie_Genre_Movie
    FOREIGN KEY (Movie_Id)
    REFERENCES Movie (Id);

-- Reference: Poster_Movie (table: Poster)
ALTER TABLE Poster ADD CONSTRAINT Poster_Movie
    FOREIGN KEY (Movie_Id)
    REFERENCES Movie (Id);

-- Reference: Review_Movie (table: Review)
ALTER TABLE Review ADD CONSTRAINT Review_Movie
    FOREIGN KEY (Movie_Id)
    REFERENCES Movie (Id);

-- Reference: Review_User (table: Review)
ALTER TABLE Review ADD CONSTRAINT Review_User
    FOREIGN KEY (User_Id)
    REFERENCES "User" (Id);

-- Reference: Trailer_Movie (table: Trailer)
ALTER TABLE Trailer ADD CONSTRAINT Trailer_Movie
    FOREIGN KEY (Movie_Id)
    REFERENCES Movie (Id);

-- Reference: User_User_Genre (table: User)
ALTER TABLE "User" ADD CONSTRAINT User_User_Genre
    FOREIGN KEY (User_Genre_Id)
    REFERENCES User_Genre (Id);

-- End of file.

