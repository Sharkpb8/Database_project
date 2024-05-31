create table genre(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(20)
);

create table autor(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(30),
last_name varchar(30),
birth_date date
);

create table publisher(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(50),
location varchar(50)
);

create table book(
id int IDENTITY(1,1) PRIMARY KEY,
genre_id   int FOREIGN KEY REFERENCES genre(id),
autor_id   int FOREIGN KEY REFERENCES autor(id),
publisher_id int foreign key references publisher(id),
name varchar(50),
release_date date,
);

create table customer(
id int IDENTITY(1,1) PRIMARY KEY,
name varchar(20),
last_name varchar(20),
email varchar(50),
);

create table basket(
id int IDENTITY(1,1) PRIMARY KEY,
customer_id   int FOREIGN KEY REFERENCES customer(id),
book_id   int FOREIGN KEY REFERENCES book(id),
borrow_date date,
extended_borrow_time bit
);