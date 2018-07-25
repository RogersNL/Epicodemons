-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 25, 2018 at 11:54 PM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `epicodemons`
--
CREATE DATABASE IF NOT EXISTS `epicodemons` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `epicodemons`;

-- --------------------------------------------------------

--
-- Table structure for table `battle`
--

CREATE TABLE `battle` (
  `id` int(11) NOT NULL,
  `mon_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
  `totalhitpoints` int(11) NOT NULL,
  `hitpoints` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `defense` int(11) NOT NULL,
  `specialattack` int(11) NOT NULL,
  `specialdefense` int(11) NOT NULL,
  `speed` int(11) NOT NULL,
  `move1pp` int(11) NOT NULL,
  `move2pp` int(11) NOT NULL,
  `move3pp` int(11) NOT NULL,
  `move4pp` int(11) NOT NULL,
  `isplayer` tinyint(1) NOT NULL,
  `iscomputer` tinyint(1) NOT NULL,
  `isactive` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `battle`
--

INSERT INTO `battle` (`id`, `mon_id`, `name`, `level`, `totalhitpoints`, `hitpoints`, `attack`, `defense`, `specialattack`, `specialdefense`, `speed`, `move1pp`, `move2pp`, `move3pp`, `move4pp`, `isplayer`, `iscomputer`, `isactive`) VALUES
(283, 2, 'Hambirder', 5, 21, 6, 12, 10, 13, 11, 11, 0, 0, 0, 0, 1, 0, 1),
(284, 3, 'Seasharp', 5, 21, 10, 13, 11, 11, 11, 10, 0, 0, 0, 0, 0, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `message` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`id`, `message`) VALUES
(1, 'It\'s a Critical Hit!'),
(5, 'It\'s a Critical Hit!'),
(10, 'new message'),
(11, 'new message');

-- --------------------------------------------------------

--
-- Table structure for table `mons`
--

CREATE TABLE `mons` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
  `hitpoints` int(11) NOT NULL,
  `attack` int(11) NOT NULL,
  `defense` int(11) NOT NULL,
  `specialattack` int(11) NOT NULL,
  `specialdefense` int(11) NOT NULL,
  `speed` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mons`
--

INSERT INTO `mons` (`id`, `name`, `level`, `hitpoints`, `attack`, `defense`, `specialattack`, `specialdefense`, `speed`) VALUES
(1, 'Quombat', 5, 40, 45, 35, 65, 55, 70),
(2, 'Hambirder', 5, 45, 60, 40, 70, 50, 45),
(3, 'Seasharp', 5, 50, 70, 50, 50, 50, 40);

-- --------------------------------------------------------

--
-- Table structure for table `mons_battle`
--

CREATE TABLE `mons_battle` (
  `id` int(11) NOT NULL,
  `mons_id` int(11) NOT NULL,
  `battle_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mons_types`
--

CREATE TABLE `mons_types` (
  `id` int(11) NOT NULL,
  `mons_id` int(11) NOT NULL,
  `types_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mons_types`
--

INSERT INTO `mons_types` (`id`, `mons_id`, `types_id`) VALUES
(1, 1, 14),
(2, 2, 17),
(3, 2, 9),
(4, 3, 16);

-- --------------------------------------------------------

--
-- Table structure for table `moves`
--

CREATE TABLE `moves` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `basepower` int(11) NOT NULL,
  `attackstyle` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `secondaryeffect` varchar(255) NOT NULL,
  `powerpoints` int(11) NOT NULL,
  `accuracy` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `moves`
--

INSERT INTO `moves` (`id`, `name`, `basepower`, `attackstyle`, `description`, `secondaryeffect`, `powerpoints`, `accuracy`) VALUES
(1, 'Static Void', 210, 'special', 'OP', 'par 50', 5, 100),
(2, 'Attackle', 35, 'physical', 'none', 'none', 95, 100),
(3, 'scrape', 35, 'physical', 'none', 'none', 35, 100),
(4, 'poke', 35, 'physical', 'none', 'none', 35, 95),
(5, 'Hyper Splash', 0, 'special', 'better than splash', 'rcg', 5, 100),
(6, 'Shred', 80, 'special', 'has chance to make the opponent flinch', 'flc 30', 20, 95),
(7, 'Act', 40, 'physical', 'There is no escape from the madness that is coding', 'par 70', 10, 100),
(8, 'Arrange', 0, 'boost', 'boosts stats ', 'bst att spd', 20, 100),
(9, 'Assert', 100, 'physical', 'assert yo self!', 'none', 10, 80),
(10, 'Test Patty', 120, 'physical', 'attack at reckless un controllable speed', 'none', 15, 50),
(11, 'Cadence', 35, 'physical', 'moves in a calculated, repetitive way', 'bst def', 10, 100);

-- --------------------------------------------------------

--
-- Table structure for table `moves_mons`
--

CREATE TABLE `moves_mons` (
  `id` int(11) NOT NULL,
  `moves_id` int(11) NOT NULL,
  `mons_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `moves_mons`
--

INSERT INTO `moves_mons` (`id`, `moves_id`, `mons_id`) VALUES
(1, 2, 2),
(2, 3, 1),
(3, 4, 3),
(4, 7, 1),
(5, 7, 2),
(6, 7, 3),
(7, 10, 2);

-- --------------------------------------------------------

--
-- Table structure for table `moves_types`
--

CREATE TABLE `moves_types` (
  `id` int(11) NOT NULL,
  `moves_id` int(11) NOT NULL,
  `types_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `moves_types`
--

INSERT INTO `moves_types` (`id`, `moves_id`, `types_id`) VALUES
(1, 1, 15),
(2, 2, 18),
(3, 3, 18),
(4, 4, 18),
(5, 5, 16),
(6, 6, 6),
(7, 7, 16),
(8, 8, 16),
(9, 9, 16),
(10, 10, 17),
(11, 11, 14);

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

CREATE TABLE `types` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `fairy` int(11) NOT NULL,
  `steel` int(11) NOT NULL,
  `dark` int(11) NOT NULL,
  `dragon` int(11) NOT NULL,
  `ghost` int(11) NOT NULL,
  `rock` int(11) NOT NULL,
  `bug` int(11) NOT NULL,
  `psychic` int(11) NOT NULL,
  `flying` int(11) NOT NULL,
  `ground` int(11) NOT NULL,
  `poison` int(11) NOT NULL,
  `fighting` int(11) NOT NULL,
  `ice` int(11) NOT NULL,
  `grass` int(11) NOT NULL,
  `electric` int(11) NOT NULL,
  `water` int(11) NOT NULL,
  `fire` int(11) NOT NULL,
  `normal` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `name`, `fairy`, `steel`, `dark`, `dragon`, `ghost`, `rock`, `bug`, `psychic`, `flying`, `ground`, `poison`, `fighting`, `ice`, `grass`, `electric`, `water`, `fire`, `normal`) VALUES
(1, 'fairy', 0, 1, 2, 3, 0, 0, 2, 0, 0, 0, 1, 2, 0, 0, 0, 0, 0, 0),
(2, 'steel', 2, 2, 0, 2, 0, 2, 2, 2, 2, 1, 3, 1, 2, 2, 0, 0, 1, 2),
(3, 'dark', 1, 0, 2, 0, 2, 0, 1, 3, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0),
(4, 'dragon', 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2, 2, 2, 0),
(5, 'ghost', 0, 0, 1, 0, 1, 0, 2, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 3),
(6, 'rock', 0, 1, 0, 0, 0, 0, 0, 0, 2, 1, 2, 1, 0, 1, 0, 1, 2, 2),
(7, 'bug', 0, 0, 0, 0, 0, 1, 0, 0, 1, 2, 0, 2, 0, 2, 0, 0, 1, 0),
(8, 'psychic', 0, 0, 1, 0, 1, 0, 1, 2, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0),
(9, 'flying', 0, 0, 0, 0, 0, 1, 2, 0, 0, 3, 0, 2, 1, 2, 1, 0, 0, 0),
(10, 'ground', 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 2, 0, 1, 1, 3, 1, 0, 0),
(11, 'poison', 2, 0, 0, 0, 0, 0, 2, 0, 0, 1, 2, 2, 0, 2, 0, 0, 0, 0),
(12, 'fighting', 1, 0, 2, 0, 0, 2, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0),
(13, 'ice', 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 1, 0),
(14, 'grass', 0, 0, 0, 0, 0, 0, 1, 0, 1, 2, 1, 0, 1, 2, 2, 2, 1, 0),
(15, 'electric', 0, 2, 0, 0, 0, 0, 0, 0, 2, 1, 0, 0, 0, 0, 2, 0, 0, 0),
(16, 'water', 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 2, 2, 0),
(17, 'fire', 2, 2, 0, 0, 0, 1, 2, 0, 0, 1, 0, 0, 2, 2, 0, 1, 2, 0),
(18, 'normal', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `battle`
--
ALTER TABLE `battle`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mons`
--
ALTER TABLE `mons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mons_battle`
--
ALTER TABLE `mons_battle`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `mons_types`
--
ALTER TABLE `mons_types`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `moves`
--
ALTER TABLE `moves`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `moves_mons`
--
ALTER TABLE `moves_mons`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `moves_types`
--
ALTER TABLE `moves_types`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `battle`
--
ALTER TABLE `battle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=285;
--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `mons`
--
ALTER TABLE `mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `mons_battle`
--
ALTER TABLE `mons_battle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `mons_types`
--
ALTER TABLE `mons_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `moves`
--
ALTER TABLE `moves`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `moves_mons`
--
ALTER TABLE `moves_mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `moves_types`
--
ALTER TABLE `moves_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
