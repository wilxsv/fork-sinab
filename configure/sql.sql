CREATE USER 'c44t'@'localhost' IDENTIFIED BY 'w1ouP81mJ0UA14H1u97y4pg830MXzv';

GRANT USAGE ON *.* TO 'c44t'@'localhost' IDENTIFIED BY '' WITH MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;

CREATE DATABASE IF NOT EXISTS 'c44t';

GRANT ALL PRIVILEGES ON 'c44t'.* TO 'c44t'@'localhost'