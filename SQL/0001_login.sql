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
    (DEFAULT, 'Inundações', false),
    (DEFAULT, 'Deslizamentos de Terra' , false),
    (DEFAULT, 'Tempestades', false),
    (DEFAULT, 'Tornados', false),
    (DEFAULT, 'Incêndios Florestais', false),
    (DEFAULT, 'Cheias', false)
;

DROP TABLE IF EXISTS parameters;
CREATE TABLE IF NOT EXISTS parameters(
	id SERIAL PRIMARY KEY,
	cellphone TEXT NOT NULL,
	administrator_id BIGINT NOT NULL,
	CONSTRAINT fk_nome FOREIGN KEY (administrator_id) REFERENCES users(id)
);

INSERT INTO parameters VALUES
	(DEFAULT, '55997011812', 4);

DROP TABLE IF EXISTS cities;
CREATE TABLE IF NOT EXISTS cities(
	id SERIAL PRIMARY KEY,
	title TEXT NOT NULL,
	lat DECIMAL(9, 6) NOT NULL,
	lng DECIMAL(9, 6) NOT NULL
);

INSERT INTO cities VALUES
	(DEFAULT, 'Santa Maria', -29.6914, -53.8008);