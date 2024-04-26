CREATE TABLE Character (
    Id           INTEGER  PRIMARY KEY
                          UNIQUE,
    Name         TEXT,
    Height       TEXT,
    Weight         TEXT,
    HairColor   TEXT,
    SkinColor   TEXT,
    EyeColor    TEXT,
    BirthYear   TEXT,
    Gender       TEXT,
    PlanetId INTEGER
);