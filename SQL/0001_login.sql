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
	coordinate_one DECIMAL NOT NULL,
	coordinate_two DECIMAL NOT NULL,
	coordinate_three DECIMAL NOT NULL,
	coordinate_four DECIMAL NOT NULL,
	cellphone TEXT NOT NULL,
	administrator_id BIGINT NOT NULL,
	CONSTRAINT fk_nome FOREIGN KEY (administrator_id) REFERENCES users(id)
);