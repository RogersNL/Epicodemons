-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 24, 2018 at 06:29 AM
-- Server version: 5.6.34-log
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `epicodemons_test`
--
CREATE DATABASE IF NOT EXISTS `epicodemons_test` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `epicodemons_test`;

-- --------------------------------------------------------

--
-- Table structure for table `battle`
--

CREATE TABLE `battle` (
  `id` int(11) NOT NULL,
  `mon_id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `level` int(11) NOT NULL,
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
-- Table structure for table `moves`
--

CREATE TABLE `moves` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `basepower` int(11) NOT NULL,
  `attackstyle` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `secondaryeffect` varchar(255) NOT NULL,
  `powerpoints` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
-- Indexes for dumped tables
--

--
-- Indexes for table `battle`
--
ALTER TABLE `battle`
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
-- Indexes for table `moves`
--
ALTER TABLE `moves`
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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=253;
--
-- AUTO_INCREMENT for table `mons`
--
ALTER TABLE `mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=408;
--
-- AUTO_INCREMENT for table `mons_battle`
--
ALTER TABLE `mons_battle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `moves`
--
ALTER TABLE `moves`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=223;
--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=242;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
