create database human_friends;

use human_friends;

CREATE TABLE `animal_classes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
PRIMARY KEY(id)
);

INSERT INTO `animal_classes` (`id`, `name`) VALUES
(1, 'Домашние животные'),
(2, 'Вьючные животные');

CREATE TABLE `animals_types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `animal_classes_id` int NOT NULL,
   PRIMARY KEY(id),
   FOREIGN KEY (animal_classes_id) REFERENCES animal_classes (id) on DELETE CASCADE on UPDATE CASCADE
);

INSERT INTO `animals_types` (`id`, `name`, `animal_classes_id`) VALUES
(1, 'Кошка', 1),
(2, 'Собака', 1),
(3, 'Хомяк', 1),
(4, 'Лошадь', 2),
(5, 'Верблюд', 2),
(6, 'Осёл', 2);

CREATE TABLE `colors` (
  `id` int NOT NULL AUTO_INCREMENT,
  `color` varchar(50) NOT NULL,
PRIMARY KEY (id)
);

INSERT INTO `colors` (`id`, `color`) VALUES
(1, 'Белый'),
(2, 'Серый'),
(3, 'Черный'),
(4, 'Белый с черными пятнами'),
(5, 'Рыжий'),
(6, 'Коричневый'),
(7, 'Черный с белыми пятнами'),
(8, 'Серый с белыми пятнами'),
(9, 'Светло-жёлтый'),
(10, 'Бурый');

CREATE TABLE `commands` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
   PRIMARY KEY(id)
);

INSERT INTO `commands` (`id`, `name`) VALUES
(1, 'Лежать'),
(2, 'Сидеть'),
(3, 'Голос'),
(4, 'Вперед'),
(5, 'Стоять'),
(6, 'Ждать'),
(7, 'Место'),
(8, 'Дай лапу');

CREATE TABLE `animals_to_commands` (
 `id` INT NOT NULL AUTO_INCREMENT ,
 `animal_id` INT NOT NULL,
 `animal_type` INT NOT NULL,
 `command_id` INT NOT NULL ,
PRIMARY KEY (`id`));

CREATE TABLE `camels` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` INT,
  `animal_types_id` int NOT NULL DEFAULT '5',
   PRIMARY KEY(id),
   FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
);

INSERT INTO `camels` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Агата', '1998-01-08', 9, 5),
(2, 'Чайна', '2001-11-22', 10, 5),
(3, 'Мария', '2012-12-13', 10, 5),
(4, 'Твист', '2020-02-21', 9, 5),
(5, 'Ланцелот', '2018-03-13', 10, 5);

CREATE TABLE `cats` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` INT,
  `animal_types_id` int NOT NULL DEFAULT '1',
PRIMARY KEY(id),
FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
);

INSERT INTO `cats` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Барсик', '2018-12-12', 1, 1),
(2, 'Ириска', '2015-08-12', 2, 1),
(3, 'Муська', '2011-08-14', 4, 1),
(4, 'Мотя', '2013-04-18', 7, 1),
(5, 'Масяня', '2021-12-09', 8, 1);

CREATE TABLE `dogs` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` INT,
  `animal_types_id` int NOT NULL DEFAULT '2',
PRIMARY KEY(id),
FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
);

INSERT INTO `dogs` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Бобик', '2018-12-12', 1, 2),
(2, 'Майк', '2015-05-08', 2, 2),
(3, 'Локи', '2019-08-14', 4, 2),
(4, 'Герда', '2023-04-28', 7, 2),
(5, 'Лесси', '2022-10-16', 8, 2);

CREATE TABLE `donkeys` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` INT,
  `animal_types_id` int NOT NULL DEFAULT '6',
PRIMARY KEY(id),
FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
);

INSERT INTO `donkeys` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Иа', '2015-03-15', 2, 6),
(2, 'Ослик', '2020-05-17', 6, 6),
(3, 'Чита', '2011-07-11', 2, 6),
(4, 'Элиос', '2013-05-19', 2, 6),
(5, 'Лунтик', '2018-07-22', 2, 6);

CREATE TABLE `hamsters` (
  `id` int NOT NULL  AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` int,
  `animal_types_id` int NOT NULL DEFAULT '3',
PRIMARY KEY(id),
FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
) ;

INSERT INTO `hamsters` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Хомик', '2022-12-18', 5, 3),
(2, 'Ириска', '2020-08-14', 5, 3),
(3, 'Бубус', '2021-11-16', 2, 3),
(4, 'Баззи', '2022-04-18', 2, 3),
(5, 'Жоржик', '2021-12-22', 8, 3);

CREATE TABLE `horses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `Birthday` date NOT NULL,
  `Color` int,
  `animal_types_id` int NOT NULL DEFAULT '4',
PRIMARY KEY(id),
FOREIGN KEY (animal_types_id) REFERENCES animals_types (id) on DELETE CASCADE on UPDATE CASCADE
) ;

INSERT INTO `horses` (`id`, `name`, `Birthday`, `Color`, `animal_types_id`) VALUES
(1, 'Ярость', '2000-07-18', 5, 4),
(2, 'Рысак', '2018-01-18', 6, 4),
(3, 'Лиса', '2010-10-06', 2, 4),
(4, 'Коршун', '2014-04-12', 3, 4),
(5, 'Тигрица', '2021-02-12', 8, 4);