-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 26, 2018 at 11:42 PM
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
  `lasthitpoints` int(11) NOT NULL,
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

INSERT INTO `battle` (`id`, `mon_id`, `name`, `level`, `totalhitpoints`, `lasthitpoints`, `hitpoints`, `attack`, `defense`, `specialattack`, `specialdefense`, `speed`, `move1pp`, `move2pp`, `move3pp`, `move4pp`, `isplayer`, `iscomputer`, `isactive`) VALUES
(494, 7, 'Fatalerror', 50, 146, 146, 119, 140, 115, 140, 115, 119, 0, 0, 0, 0, 1, 0, 1),
(495, 4, 'Epicodachu', 50, 110, 16, 0, 75, 60, 70, 70, 110, 0, 0, 0, 0, 0, 1, 1);

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
(369, '<span class=\"animated wobble\">A beam of pure lightning fired at the opponent.</span>'),
(370, '<a href=\'/Battle/Combat\'>Continue</a>');

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
(1, 'Quombat', 50, 80, 82, 83, 100, 100, 80),
(2, 'Hambirder', 50, 78, 84, 78, 109, 85, 100),
(3, 'Seasharp', 50, 95, 125, 79, 60, 100, 81),
(4, 'Epicodachu', 50, 35, 55, 40, 50, 50, 90),
(5, 'Masterbranch', 50, 100, 150, 140, 100, 90, 90),
(6, 'Heatmink', 50, 85, 105, 55, 85, 50, 115),
(7, 'Fatalerror', 50, 71, 120, 95, 120, 95, 99),
(8, 'Marsupyoung', 50, 60, 62, 63, 80, 80, 60),
(9, 'MyBeeQL', 50, 65, 150, 40, 15, 80, 145),
(10, 'Rockasaurus', 50, 85, 60, 65, 135, 105, 100),
(11, 'Overclock', 50, 50, 92, 108, 92, 108, 35),
(12, 'Swampdonkey', 50, 65, 100, 70, 80, 80, 105),
(13, 'Thundeer', 50, 80, 100, 70, 60, 70, 95);

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
(4, 3, 16),
(5, 4, 15),
(6, 4, 3),
(7, 5, 17),
(8, 5, 14),
(9, 6, 2),
(10, 6, 13),
(11, 7, 7),
(12, 7, 4),
(13, 8, 14),
(14, 9, 7),
(15, 9, 9),
(16, 10, 6),
(17, 10, 17),
(18, 11, 17),
(19, 11, 2),
(20, 12, 11),
(21, 12, 1),
(22, 13, 15),
(23, 13, 18);

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
(1, 'Static Void', 210, 'special', '<span class=\"animated pulse\">NOTHING escapes the Static Void.</span>', 'par 50', 5, 100),
(2, 'Attackle', 35, 'physical', '<span class=\"animated flash\">The Epicodemon rushed the opponent.</span>', 'none', 35, 100),
(3, 'Scrape', 35, 'physical', '<span class=\"animated swing\">The Epicodemon attacked with its claws.</span>', 'none', 35, 100),
(4, 'Poke', 35, 'physical', '<span class=\"animated swing\">The Epicodemon poked opponent.</span>', 'none', 35, 95),
(5, 'Hyper Splash', 0, 'special', '<span class=\"animated flash\">Its better then Splash!!!!</span>', 'rcg', 5, 0),
(6, 'Shred', 80, 'special', '<span class=\"animated flash\">Rockasaurus played a sick power riff!</span>', 'flc 30', 20, 95),
(7, 'Act', 40, 'physical', '<span class=\"animated flash\">Seasharp acted on its opponents openings.</span>', 'par 70', 10, 100),
(8, 'Arrange', 0, 'boost', '<span class=\"animated flash\">Seasharp prepared itself.</span>', 'bst att spd', 20, 100),
(9, 'Assert', 100, 'physical', '<span class=\"animated wobble\">Seasharp asserted its dominance!!! </span>', 'none', 10, 80),
(10, 'Test Patty', 120, 'physical', '<span class=\"animated flash\">Hambirder all out charged its opponent.</span>', 'none', 15, 50),
(11, 'Cadence', 35, 'physical', '<span class=\"animated flash\">Quambat moved rhythmically boosting defense.</span>', 'bst def', 10, 100),
(12, 'Ice Thrower', 95, 'special', '<span class=\"animated wobble\">A flamethrower of ice shot at the opponent.</span>', 'none', 15, 100),
(13, 'Thunder Beam', 95, 'special', '<span class=\"animated wobble\">A beam of pure lightning fired at the opponent.</span>', 'none', 15, 100),
(14, 'Heat Release', 120, 'special', '<span class=\"animated flash\">Heatmink Dispelled its stored Heat.</span>', 'none', 5, 90),
(15, 'Merge Error', 135, 'special', '<span class=\"animated flipinX\">A FATAL mistake was made!!!!</span>', 'none', 10, 85),
(16, 'Bug Swarm', 90, 'physical', '<span class=\"animated zoomin\">A throng of Bugs swarms the opponent.</span>', 'none', 10, 500),
(17, 'Drag-On', 120, 'physical', '<span class=\"animated flash\">Fatal Error goes all out(code with outrage).</span>', 'none', 5, 100),
(18, 'Bug Splat', 100, 'physical', '<span class=\"animated bounceInDown\">Fatal error Drops on the Opponent with full force.</span>', 'none', 15, 75),
(19, 'Its A Feature', 5000, 'special', '<span class=\"animated jackInTheBox\">No mistakes were made!</span>', 'none', 5, 30),
(20, 'Megattackle', 70, 'physical', '<span class=\"animated rollIn\">The Epicodemon rushed the opponent with full force.</span>', 'none', 20, 100),
(22, 'Swamp Gas', 50, 'special', '<span class=\"animated jello\">What\'s that smell?</span>', 'none', 20, 100),
(23, 'Furment', 100, 'special', '<span class=\"animated jello\">What\'s that smell?</span>', 'none', 10, 95),
(24, 'Call Ogre', 150, 'physical', '<span class=\"animated jello\">What\'s that smell?</span>', 'none', 5, 45),
(25, 'Fire Beam', 95, 'special', '<span class=\"animated flash\">Fire engulfs the battlefield!</span>', 'brn 10', 15, 100);

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
(6, 7, 3),
(7, 10, 2),
(8, 1, 4),
(9, 20, 4),
(10, 13, 4),
(12, 19, 4),
(13, 15, 5),
(14, 20, 5),
(15, 3, 5),
(16, 25, 5),
(17, 14, 6),
(18, 20, 6),
(19, 12, 6),
(20, 25, 6),
(21, 16, 7),
(22, 17, 7),
(23, 18, 7),
(24, 25, 7),
(25, 3, 8),
(26, 11, 8),
(27, 16, 9),
(28, 18, 9),
(29, 20, 9),
(30, 4, 9),
(31, 5, 3),
(32, 8, 3),
(33, 9, 3),
(34, 20, 2),
(35, 25, 2),
(36, 11, 1),
(37, 20, 1),
(38, 25, 1),
(39, 6, 10),
(40, 25, 10),
(41, 3, 10),
(42, 20, 10),
(43, 25, 11),
(44, 13, 11),
(45, 20, 11),
(46, 4, 11),
(47, 22, 12),
(48, 23, 12),
(49, 24, 12),
(50, 3, 12),
(51, 20, 13),
(52, 13, 13),
(53, 2, 13),
(54, 12, 13);

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
(11, 11, 14),
(12, 12, 15),
(13, 13, 17),
(14, 14, 19),
(15, 15, 16),
(17, 16, 9),
(18, 17, 6),
(19, 18, 9),
(20, 19, 17),
(21, 20, 20),
(22, 22, 13),
(23, 23, 13),
(24, 24, 3),
(25, 25, 19);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=496;
--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=371;
--
-- AUTO_INCREMENT for table `mons`
--
ALTER TABLE `mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `mons_battle`
--
ALTER TABLE `mons_battle`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `mons_types`
--
ALTER TABLE `mons_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;
--
-- AUTO_INCREMENT for table `moves`
--
ALTER TABLE `moves`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT for table `moves_mons`
--
ALTER TABLE `moves_mons`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;
--
-- AUTO_INCREMENT for table `moves_types`
--
ALTER TABLE `moves_types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;
--
-- AUTO_INCREMENT for table `types`
--
ALTER TABLE `types`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
