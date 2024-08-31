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

SELECT 
    * 
FROM users
;

