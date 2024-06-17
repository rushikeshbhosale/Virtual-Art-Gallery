CREATE DATABASE VAGDB

USE VAGDB

CREATE TABLE ARTWORK
(ArtworkID int identity(1,1) NOT NULL primary key,
Title varchar(100),
[Description] text,
CreationDate date,
[Medium] varchar(100),
ImageURL varchar(100))

CREATE TABLE ARTIST
(ArtistID int identity(1,1) not null primary key,
[Name] varchar(50),
Biography text,
BirthDate date,
Nationality varchar(50),
Website varchar(100),
[Contact Information] varchar(150))

CREATE TABLE [USER]
(UserID int identity(1,1) not null primary key,
Username varchar(50),
[Password] varchar(50),
Email varchar(50) unique,
[First Name] varchar(50),
[Last Name] varchar(50),
[Date of Birth] date,
[Profile Picture] varchar(50),
FavoriteArtworks int,
Foreign key (FavoriteArtworks) references ARTWORK(ArtworkID) on delete cascade) 

CREATE TABLE GALLERY
(GalleryID int identity(1,1) not null primary key,
[Name] varchar(50),
[Description] text,
Location varchar(100),
Curator int,
Foreign key (Curator) references ARTIST(ArtistID) on delete cascade,
OpeningHours time)

alter table ARTWORK add ArtistID int foreign key(ArtistID) references ARTIST(ArtistID) on delete cascade

alter table GALLERY add ArtistID int foreign key (ArtistID) references ARTIST(ArtistID)

CREATE TABLE USER_FAVORITE_ARTWORK (
    UserID INT,
    ArtworkID INT,
    FOREIGN KEY (UserID) REFERENCES [USER](UserID),
    FOREIGN KEY (ArtworkID) REFERENCES ARTWORK(ArtworkID),
    CONSTRAINT PK_USER_FAVORITE_ARTWORK PRIMARY KEY (UserID, ArtworkID)
)

CREATE TABLE ARTWORK_GALLERY
(ArtworkID int,
foreign key (ArtworkID) references ARTWORK(ArtworkID),
GalleryID int,
foreign key (GalleryID) references GALLERY(GalleryID),
primary key(ArtworkID,GalleryID))

alter table USER_FAVORITE_ARTWORK alter column UserID int not null

ALTER TABLE [USER] ADD CONSTRAINT UQ_USER_EMAIL UNIQUE(EMAIL)
select * from [USER]
--Insertion

INSERT INTO ARTWORK (Title, [Description], CreationDate, [Medium], ImageURL)
VALUES 
  ('Untitled (Lamp/Bear)', 'A giant sculpture of a bear holding a lamp.', '2020-06-01', 'Stainless Steel', 'https://example.com/untitled_lamp_bear.jpg'),
  ('The Sun', 'An abstract painting depicting the sun in vibrant colors.', '2021-03-15', 'Acrylic on Canvas', 'https://example.com/the_sun.jpg'),
  ('Echoes of Existence', 'A multimedia installation exploring themes of identity and existence.', '2022-09-10', 'Mixed Media', 'https://example.com/echoes_of_existence.jpg'),
  ('Digital Dreamscape', 'A digital artwork created using generative algorithms.', '2023-05-20', 'Digital Media', 'https://example.com/digital_dreamscape.jpg'),
  ('Resilience', 'A sculpture representing strength and endurance in the face of adversity.', '2024-02-29', 'Bronze', 'https://example.com/resilience.jpg')

INSERT INTO ARTIST ([Name], Biography, BirthDate, Nationality, Website, [Contact Information])
VALUES 
  ('John Smith', 'John Smith is a contemporary artist known for his innovative sculptures and installations. He explores themes of nature, technology, and human existence in his work.', '1975-08-15', 'American', 'https://www.johnsmithart.com/', 'johnsmithart@gmail.com'),
  ('Emily Johnson', 'Emily Johnson is a talented painter who specializes in abstract and vibrant compositions. Her work often reflects her fascination with nature and the cosmos.', '1982-03-21', 'British', 'https://www.emilyjohnsonart.co.uk/', 'emilyjohnsonart@gmail.com'),
  ('Michael Chen', 'Michael Chen is an emerging multimedia artist who experiments with various materials and techniques. His installations provoke thought and reflection on contemporary issues.', '1990-11-10', 'Canadian', 'https://www.michaelchenart.ca/', 'michaelchenart@gmail.com'),
  ('Sophia Rodriguez', 'Sophia Rodriguez is a digital artist renowned for her captivating digital artworks created using advanced algorithms and techniques. Her work often blurs the line between reality and imagination.', '1987-05-04', 'Spanish', 'https://www.sophiarodriguezart.es/', 'sophiarodriguezart@gmail.com'),
  ('David Nguyen', 'David Nguyen is a sculptor known for his dynamic and expressive sculptures. His work often explores themes of resilience, identity, and cultural heritage.', '1978-12-30', 'Vietnamese', 'https://www.davidnguyenart.vn/', 'davidnguyenart@gmail.com')

INSERT INTO [USER] (Username, [Password], Email, [First Name], [Last Name], [Date of Birth], [Profile Picture], FavoriteArtworks)
VALUES 
  ('john_doe', 'password123', 'john.doe@gmail.com', 'John', 'Doe', '1990-05-15', 'john_doe_profile.jpg', 1),
  ('jane_smith', 'pass123', 'jane.smith@gmail.com', 'Jane', 'Smith', '1988-09-20', 'jane_smith_profile.jpg', 2),
  ('michael_johnson', 'michaelpass', 'michael.johnson@gmail.com', 'Michael', 'Johnson', '1995-03-05', 'michael_johnson_profile.jpg', 3),
  ('emily_brown', 'emily123', 'emily.brown@gmail.com', 'Emily', 'Brown', '1983-11-10', 'emily_brown_profile.jpg', 4),
  ('sophia_lee', 'sophia123', 'sophia.lee@gmail.com', 'Sophia', 'Lee', '1992-07-25', 'sophia_lee_profile.jpg', 5),
   ('ann_paul', 'ann123', 'ann@gmail.com', 'Ann', 'Paul', '2002-12-05', 'ann_paul_profile.jpg', 2),
   ('rohanc', 'rohan2543', 'rohanchougule9374@gmail.com', 'Rohan', 'Chougule', '2002-06-25', 'rohan_chougule_profile.jpg', 1)

INSERT INTO GALLERY ([Name], [Description], Location, Curator, OpeningHours)
VALUES 
  ('kjhg', 'Contemporary art gallery showcasing works from emerging artists.', 'New York City', 1, '09:00:00'),
  ('ModernArt Gallery', 'Exhibiting modern and abstract artworks from renowned artists.', 'London', 3, '10:00:00'),
  ('Creative Hub Gallery', 'A vibrant space promoting creativity and innovation in art.', 'Paris', 2, '08:30:00'),
  ('City Art Center', 'Showcasing a diverse collection of traditional and contemporary art.', 'Tokyo', 4, '09:30:00'),
  ('Gallery of Dreams', 'A gallery dedicated to surreal and dreamlike artworks.', 'Berlin', 5, '10:30:00');


INSERT INTO USER_FAVORITE_ARTWORK VALUES
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,2),
(7,7)

INSERT INTO ARTWORK_GALLERY VALUES
(1,1),
(2,2),
(3,3),
(4,5),
(5,4)

--Artwork Management

--1 addArtwork()
insert into ARTWORK values
('The Starry Night', 'A night sky with swirling clouds and bright stars above a quiet village.', '1889-06-01', 'Oil on Canvas', 'https:the_starry_night.jpg',5)

--2 updateArtwork()
update ARTWORK set  Description='Starry Night is a famous oil painting by Vincent van Gogh, created in June 1889. 'where ArtworkID=15
update ARTWORK set  ArtistID=2 where ArtworkID=4
update ARTWORK set  ArtistID=4 where ArtworkID=5

--3 removeArtwork()
delete from ARTWORK where ArtworkID=19

--4 getArtworkById()
select * from ARTWORK where ArtworkID=5

--5 searchArtworks()
select * from ARTWORK


select * from [USER]
select * from ARTIST


select * from ARTWORK_GALLERY
select * from GALLERY
select * from ARTWORK
select * from USER_FAVORITE_ARTWORK


ALTER TABLE GALLERY DROP constraint FK__GALLERY__ArtistI__5629CD9C
ALTER TABLE GALLERY DROP COLUMN ArtistID
