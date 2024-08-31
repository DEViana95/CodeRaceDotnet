DROP TABLE IF EXISTS users;
CREATE TABLE IF NOT EXISTS users(
	id SERIAL PRIMARY KEY,
	login varchar(30) UNIQUE,
	"password" TEXT NOT NULL,
	"type" bigint NOT null
);

INSERT INTO users VALUES
    (DEFAULT, 'gabriel.viana', '112233', 1),
    (DEFAULT, 'aline.rossine', '112233', 1),
    (DEFAULT, 'jose.grotto', '112233', 1),
    (DEFAULT, 'wezer.carvalho', '112233', 1),
    (DEFAULT, 'frederico.hartmann', '112233', 1)
;

DROP TABLE IF EXISTS incident_types;
CREATE TABLE IF NOT EXISTS incident_types(
	id SERIAL PRIMARY KEY,
	title TEXT NOT NULL,
	active BOOLEAN NOT NULL
);

INSERT INTO incident_types VALUES
    (DEFAULT, 'Inundações', true),
    (DEFAULT, 'Deslizamentos de Terra' , true),
    (DEFAULT, 'Tempestades', true),
    (DEFAULT, 'Tornados', true),
    (DEFAULT, 'Incêndios Florestais', true)
;

DROP TABLE IF EXISTS parameters;
CREATE TABLE IF NOT EXISTS parameters(
	id SERIAL PRIMARY KEY,
	cellphone TEXT NOT NULL,
	phone TEXT NOT NULL,
	telegram TEXT NULL
);

INSERT INTO parameters VALUES
	(DEFAULT, '55997011812', '5533333333',  '55999009900');

DROP TABLE IF EXISTS cities;
CREATE TABLE IF NOT EXISTS cities(
	id SERIAL PRIMARY KEY,
	title TEXT NOT NULL,
	lat DECIMAL(9, 6) NOT NULL,
	lng DECIMAL(9, 6) NOT NULL
);

INSERT INTO cities VALUES
	(DEFAULT, 'Santa Maria', -29.6914, -53.8008),
	(DEFAULT, 'Itaara', -29.6086, -53.7652)
;

DROP TABLE IF EXISTS report_disaster;
CREATE TABLE IF NOT EXISTS report_disaster(
	id SERIAL PRIMARY KEY,
	lat DECIMAL(9, 6) NOT NULL,
	lng DECIMAL(9, 6) NOT NULL,
	cellphone_number TEXT NULL,
	tx_id varchar(11) NULL,
	gravity INTEGER NOT NULL DEFAULT 1,
	"type" INTEGER NOT NULL,
	"status" BIGINT NOT NULL DEFAULT 1,
	created TIMESTAMP WITH TIME ZONE NOT NULL,
	finish TIMESTAMP WITH TIME ZONE NULL,
	motive TEXT NULL
);

INSERT INTO report_disaster (id, lat, lng, cellphone_number, tx_id, gravity, "type", "status", created) VALUES
	(DEFAULT, -29.7143032, -53.780295, '55997011812', '03241824063', 1, 1, 1, now()),
	(DEFAULT, -29.683651, -53.859078, '55997011812', '03241824063', 1, 1, 1, now()),
	(DEFAULT, -29.702615, -53.862094, '55997011812', '03241824063', 1, 1, 1, now()),
	(DEFAULT, -29.712120, -53.824844, '55997011812', '03241824063', 1, 1, 1, now()),
	(DEFAULT, -29.697322, -53.794631, '55997011812', '03241824063', 1, 1, 1, now()),
	(DEFAULT, -29.703472, -53.734464, '55997011812', '03241824063', 1, 1, 1, now())
;