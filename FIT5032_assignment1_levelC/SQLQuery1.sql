-- create table 'Locations'
create table [dbo].[Locations]
(
	[Location_id] int not null primary key identity(1,1),
	[Location_name] varchar(max) not null,
	[Latitude] numeric(10,8) not null,
	[Longitude] numeric(11,8) not null,
	constraint CK_Latitude check (Latitude >= -90 and Latitude <= 90),
	constraint CK_Longitude check (Longitude >= -90 and Longitude <= 90)
)

-- create table 'Hotel'
CREATE TABLE [dbo].[Hotel]
(
	[Hotel_id] INT  Identity(1,1) NOT NULL PRIMARY KEY, 
    [Hotel_name] NVARCHAR(max) NOT NULL, 
    [City] NVARCHAR(max) NOT NULL,
	[Location_id] int not null,
    [Location] NVARCHAR(50) NOT NULL, 
    [Total_room_num] INT NOT NULL, 
    [Available_num] INT NOT NULL, 
    [Available_date] DATE NOT NULL, 
    [Rating] INT NOT NULL, 
	foreign key (Location_id) references Locations(Location_id),
    CONSTRAINT [CK_Hotel_Rating] CHECK (Rating between 0 and 100), 
    CONSTRAINT [CK_Hotel_Available_num] CHECK (Available_num <= Total_room_num)
)

-- create table 'Room'
create table [dbo].[Room]
(
	[Room_id] int identity(1,1) not null,
	[Hotel_id] int not null,
	[Room_type] nvarchar(max) not null,
	[Room_status] nvarchar(max) not null,
	[Room_price] int not null,
	constraint [CK_Room_Room_status] check (Room_status in ('true','false')),
	primary key (Room_id, Hotel_id),
	foreign key (Hotel_id) references Hotel(Hotel_id)
)



-- create table 'Booking'
create table [dbo].[Booking]
(
	[Booking_id] int not null primary key identity(1,1),
	[Room_id] int not null,
	[Hotel_id] int not null,
	[Checkin_date] date not null,
	[Checkout_date] date not null,
	foreign key (Room_id,Hotel_id) references Room(Room_id,Hotel_id),
	constraint CK_Checkin_date check (Checkin_date <= Checkout_date)
)

-- create table 'Feedback'
create table [dbo].[Feedback]
(
	[Booking_id] int not null primary key,
	[Hotel_id] int not null,
	[Hotel_name] nvarchar(max) not null,
	[Score] int not null,
	foreign key (Hotel_id) references Hotel(Hotel_id),
	foreign key (Booking_id) references Booking(Booking_id),
	constraint CK_Score check (Score between 0 and 100)
)