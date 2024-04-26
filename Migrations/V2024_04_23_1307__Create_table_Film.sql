CREATE TABLE Film (
    Id           INTEGER PRIMARY KEY UNIQUE,
    Title        VARCHAR NOT NULL,
    Episode      VARCHAR NOT NULL,
    OpeningCrawl TEXT    NOT NULL,
    Director     VARCHAR NOT NULL,
    Producer     VARCHAR NOT NULL,
    ReleaseDate  VARCHAR NOT NULL
);
