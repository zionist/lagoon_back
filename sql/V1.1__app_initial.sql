CREATE SCHEMA app;

CREATE TABLE app.item_category (
  id serial  PRIMARY KEY,
  name varchar(2048) NOT NULL UNIQUE,
  image_path varchar(4096) NOT NULL UNIQUE
);

CREATE TABLE app.item (
  id serial PRIMARY KEY,
  name varchar(2048) NOT NULL UNIQUE ,
  specification text NOT NULL ,
  price int NOT NULL ,
  category_id int REFERENCES app.item_category(id) ON DELETE CASCADE NOT NULL,
  image_path varchar(4096) NOT NULL UNIQUE
);

--CREATE TABLE application_user(
--  id SERIAL PRIMARY KEY,
--  username VARCHAR(4096) NOT NULL UNIQUE,
--  password VARCHAR(4096) NOT NULL
--);

--CREATE TABLE app.application_user_role(
--  id SERIAL PRIMARY KEY,
--  name VARCHAR(4096) NOT NULL UNIQUE,
--  userId int REFERENCES application_user(id) ON DELETE CASCADE NOT NULL
-- );

-- USERS AND ROLES ---
--INSERT INTO app.application_user(username, password)
--VALUES ('testuser', 'testpass');

--INSERT INTO app.application_user_role (name, userId)
--VALUES ('ROLE_ADMIN', (SELECT id from application_user where username = 'testuser')),
--('ROLE_USER', (SELECT id from application_user where username = 'testuser'));

-- FILL TEST DATA --
INSERT INTO app.item_category
    (name, image_path)
  VALUES
    ('category1', '1499145852337.png'),
    ('category2', '1499229974454.png');

INSERT INTO app.item
 (name, specification, price, category_id, image_path)
VALUES
  ('товар 1', 'описание товара 1', 1000, (SELECT id FROM app.item_category WHERE name='category1'), '1499145852337.png'),
  ('товар 2', 'описание товара 2', 2000, (SELECT id FROM app.item_category WHERE name='category1'), '1499229974454.png');






