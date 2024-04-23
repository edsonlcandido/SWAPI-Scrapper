CREATE TABLE Film (
    episode_id    INTEGER PRIMARY KEY
                          UNIQUE,
    title         TEXT,
    opening_crawl TEXT,
    director      TEXT,
    producer      TEXT,
    release_date  TEXT,
    created       TEXT,
    edited        TEXT,
    url           TEXT
);
