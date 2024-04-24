CREATE TABLE Characters (
    id           INTEGER  PRIMARY KEY
                          UNIQUE,
    name         TEXT,
    height       TEXT,
    mass         TEXT,
    hair_color   TEXT,
    skin_color   TEXT,
    eye_color    TEXT,
    birth_year   TEXT,
    gender       TEXT,
    homeworld_id INTEGER,
    created      DATETIME,
    edited       DATETIME,
    url          TEXT
);