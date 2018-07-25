using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class Battle
  {
    private int _battleId;
    private int _mon_Id;
    private string _battleName;
    private int _level;
    private int _totalHitpoints;
    private int _hitpoints;
    private int _attack;
    private int _defense;
    private int _specialattack;
    private int _specialdefense;
    private int _speed;
    private int _move1pp;
    private int _move2pp;
    private int _move3pp;
    private int _move4pp;
    private bool _isPlayer;
    private bool _isComputer;
    private bool _isActive;

    public Battle(int Mon_Id, string BattleName, int Level,int TotalHitpoints, int Hitpoints, int Attack, int Defense, int Specialattack, int Specialdefense, int Speed, int Move1pp = 0, int Move2pp = 0, int Move3pp = 0, int Move4pp = 0, bool IsPlayer = false, bool IsComputer = false, bool IsActive = false, int BattleId = 0)
    {
      _mon_Id = Mon_Id;
      _battleId = BattleId;
      _battleName = BattleName;
      _level = Level;
      _totalHitpoints = TotalHitpoints;
      _hitpoints = Hitpoints;
      _attack = Attack;
      _defense = Defense;
      _specialattack = Specialattack;
      _specialdefense = Specialdefense;
      _speed = Speed;
      _move1pp = Move1pp;
      _move2pp = Move2pp;
      _move3pp = Move3pp;
      _move4pp = Move4pp;
      _isPlayer = IsPlayer;
      _isComputer = IsComputer;
      _isActive = IsActive;
    }
    public int GetMon_Id()
    {
      return _mon_Id;
    }
    public int GetBattleId()
    {
      return _battleId;
    }
    public string GetBattleName()
    {
      return _battleName;
    }
    public int GetLevel()
    {
      return _level;
    }
    public int GetTotalHitpoints()
    {
      return _totalHitpoints;
    }
    public int GetHitpoints()
    {
      return _hitpoints;
    }
    public int GetAttack()
    {
      return _attack;
    }
    public int GetDefense()
    {
      return _defense;
    }
    public int GetSpecialattack()
    {
      return _specialattack;
    }
    public int GetSpecialdefense()
    {
      return _specialdefense;
    }
    public int GetSpeed()
    {
      return _speed;
    }
    public int GetMove1pp()
    {
      return _move1pp;
    }
    public int GetMove2pp()
    {
      return _move2pp;
    }
    public int GetMove3pp()
    {
      return _move3pp;
    }
    public int GetMove4pp()
    {
      return _move4pp;
    }
    public bool GetIsPlayer()
    {
      return _isPlayer;
    }
    public bool GetIsComputer()
    {
      return _isComputer;
    }
    public bool GetIsActive()
    {
      return _isActive;
    }
    public override bool Equals(System.Object otherBattle)
    {
      if(!(otherBattle is Battle))
      {
        return false;
      }
      else
      {
        Battle newBattle = (Battle) otherBattle;
        bool idEquality = this.GetBattleId().Equals(newBattle.GetBattleId());
        bool mon_idEquality = this.GetMon_Id().Equals(newBattle.GetMon_Id());
        bool nameEquality = this.GetBattleName().Equals(newBattle.GetBattleName());
        bool levelEquality = this.GetLevel().Equals(newBattle.GetLevel());
        bool totalHitpointsEquality = this.GetTotalHitpoints().Equals(newBattle.GetTotalHitpoints());
        bool hitpointsEquality = this.GetHitpoints().Equals(newBattle.GetHitpoints());
        bool attackEquality = this.GetAttack().Equals(newBattle.GetAttack());
        bool defenseEquality = this.GetDefense().Equals(newBattle.GetDefense());
        bool spattackEquality = this.GetSpecialattack().Equals(newBattle.GetSpecialattack());
        bool spdefenseEquality = this.GetSpecialdefense().Equals(newBattle.GetSpecialdefense());
        bool speedEquality = this.GetSpeed().Equals(newBattle.GetSpeed());
        bool pp1Equality = this.GetMove1pp().Equals(newBattle.GetMove1pp());
        bool pp2Equality = this.GetMove2pp().Equals(newBattle.GetMove2pp());
        bool pp3Equality = this.GetMove3pp().Equals(newBattle.GetMove3pp());
        bool pp4Equality = this.GetMove4pp().Equals(newBattle.GetMove4pp());
        bool playerEquality = this.GetIsPlayer().Equals(newBattle.GetIsPlayer());
        bool computerEquality = this.GetIsComputer().Equals(newBattle.GetIsComputer());
        bool activeEquality = this.GetIsActive().Equals(newBattle.GetIsActive());
        return (idEquality && mon_idEquality && nameEquality && levelEquality && totalHitpointsEquality && hitpointsEquality && attackEquality && defenseEquality && spattackEquality && spdefenseEquality && speedEquality && pp1Equality && pp2Equality && pp3Equality && pp4Equality && playerEquality && computerEquality && activeEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetBattleId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO battle (mon_id, name, level,totalhitpoints, hitpoints, attack, defense, specialattack, specialdefense, speed, move1pp, move2pp, move3pp, move4pp, isplayer, iscomputer, isactive) VALUES (@mon_Id, @battleName, @level,@totalhitpoints, @hitpoints, @attack, @defense, @specialattack, @specialdefense, @speed, @move1pp, @move2pp, @move3pp, @move4pp, @isPlayer, @isComputer, @isActive);";

      cmd.Parameters.Add(new MySqlParameter("@mon_Id", _mon_Id));
      cmd.Parameters.Add(new MySqlParameter("@battleName", _battleName));
      cmd.Parameters.Add(new MySqlParameter("@level", _level));
      cmd.Parameters.Add(new MySqlParameter("@totalhitpoints", _totalHitpoints));
      cmd.Parameters.Add(new MySqlParameter("@hitpoints", _hitpoints));
      cmd.Parameters.Add(new MySqlParameter("@attack", _attack));
      cmd.Parameters.Add(new MySqlParameter("@defense", _defense));
      cmd.Parameters.Add(new MySqlParameter("@specialattack", _specialattack));
      cmd.Parameters.Add(new MySqlParameter("@specialdefense", _specialdefense));
      cmd.Parameters.Add(new MySqlParameter("@speed", _speed));
      cmd.Parameters.Add(new MySqlParameter("@move1pp", _move1pp));
      cmd.Parameters.Add(new MySqlParameter("@move2pp", _move2pp));
      cmd.Parameters.Add(new MySqlParameter("@move3pp", _move3pp));
      cmd.Parameters.Add(new MySqlParameter("@move4pp", _move4pp));
      cmd.Parameters.Add(new MySqlParameter("@isPlayer", _isPlayer));
      cmd.Parameters.Add(new MySqlParameter("@isComputer", _isComputer));
      cmd.Parameters.Add(new MySqlParameter("@isActive", _isActive));

      cmd.ExecuteNonQuery();
      _battleId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Battle> GetAllBattles()
    {
      List<Battle> allBattles = new List<Battle> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM battle;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int BattleId = rdr.GetInt32(0);
        int Mon_Id = rdr.GetInt32(1);
        string BattleName = rdr.GetString(2);
        int Level = rdr.GetInt32(3);
        int TotalHitpoints= rdr.GetInt32(4);
        int Hitpoints = rdr.GetInt32(5);
        int Attack = rdr.GetInt32(6);
        int Defense = rdr.GetInt32(7);
        int Specialattack = rdr.GetInt32(8);
        int Specialdefense = rdr.GetInt32(9);
        int Speed = rdr.GetInt32(10);
        int Move1pp = rdr.GetInt32(11);
        int Move2pp = rdr.GetInt32(12);
        int Move3pp = rdr.GetInt32(13);
        int Move4pp = rdr.GetInt32(14);
        bool IsPlayer = rdr.GetBoolean(15);
        bool IsComputer = rdr.GetBoolean(16);
        bool IsActive = rdr.GetBoolean(17);

        Battle newBattle = new Battle(Mon_Id, BattleName, Level,TotalHitpoints, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, IsPlayer, IsComputer, IsActive, BattleId);
        allBattles.Add(newBattle);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allBattles;
      // return new List<Battle>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM battle; DELETE FROM mons_battle;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Battle Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM battle WHERE id = (@searchId);";

      cmd.Parameters.Add(new MySqlParameter("@searchId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BattleId = 0;
      int Mon_Id = 0;
      string BattleName = "";
      int Level = 0;
      int TotalHitpoints = 0;
      int Hitpoints = 0;
      int Attack = 0;
      int Defense = 0;
      int Specialattack = 0;
      int Specialdefense = 0;
      int Speed = 0;
      int Move1pp = 0;
      int Move2pp = 0;
      int Move3pp = 0;
      int Move4pp = 0;
      bool IsPlayer = false;
      bool IsComputer = false;
      bool IsActive = false;

      while(rdr.Read())
      {
        BattleId = rdr.GetInt32(0);
        Mon_Id = rdr.GetInt32(1);
        BattleName = rdr.GetString(2);
        Level = rdr.GetInt32(3);
        TotalHitpoints = rdr.GetInt32(4);
        Hitpoints = rdr.GetInt32(5);
        Attack = rdr.GetInt32(6);
        Defense = rdr.GetInt32(7);
        Specialattack = rdr.GetInt32(8);
        Specialdefense = rdr.GetInt32(9);
        Speed = rdr.GetInt32(10);
        Move1pp = rdr.GetInt32(11);
        Move2pp = rdr.GetInt32(12);
        Move3pp = rdr.GetInt32(13);
        Move4pp = rdr.GetInt32(14);
        IsPlayer = rdr.GetBoolean(15);
        IsComputer = rdr.GetBoolean(16);
        IsActive = rdr.GetBoolean(17);
      }
      Battle newBattle = new Battle(Mon_Id, BattleName, Level, TotalHitpoints, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, IsPlayer, IsComputer, IsActive, BattleId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Battle("", "", 0);
      return newBattle;
    }
    public static Battle FindPlayer()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM battle WHERE isplayer = @IsPlayer AND isactive = @IsActive;";

      cmd.Parameters.Add(new MySqlParameter("@IsPlayer", true));
      cmd.Parameters.Add(new MySqlParameter("@IsActive", true));


      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BattleId = 0;
      int Mon_Id = 0;
      string BattleName = "";
      int Level = 0;
      int TotalHitpoints = 0;
      int Hitpoints = 0;
      int Attack = 0;
      int Defense = 0;
      int Specialattack = 0;
      int Specialdefense = 0;
      int Speed = 0;
      int Move1pp = 0;
      int Move2pp = 0;
      int Move3pp = 0;
      int Move4pp = 0;
      bool IsPlayer = false;
      bool IsComputer = false;
      bool IsActive = false;

      while(rdr.Read())
      {
        BattleId = rdr.GetInt32(0);
        Mon_Id = rdr.GetInt32(1);
        BattleName = rdr.GetString(2);
        Level = rdr.GetInt32(3);
        TotalHitpoints = rdr.GetInt32(4);
        Hitpoints = rdr.GetInt32(5);
        Attack = rdr.GetInt32(6);
        Defense = rdr.GetInt32(7);
        Specialattack = rdr.GetInt32(8);
        Specialdefense = rdr.GetInt32(9);
        Speed = rdr.GetInt32(10);
        Move1pp = rdr.GetInt32(11);
        Move2pp = rdr.GetInt32(12);
        Move3pp = rdr.GetInt32(13);
        Move4pp = rdr.GetInt32(14);
        IsPlayer = rdr.GetBoolean(15);
        IsComputer = rdr.GetBoolean(16);
        IsActive = rdr.GetBoolean(17);
      }
      Battle newBattle = new Battle(Mon_Id, BattleName, Level, TotalHitpoints, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, IsPlayer, IsComputer, IsActive, BattleId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Battle("", "", 0);
      return newBattle;
    }
    public static Battle FindComputer()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM battle WHERE iscomputer = @IsComputer AND isactive = @IsActive;";

      cmd.Parameters.Add(new MySqlParameter("@IsComputer", true));
      cmd.Parameters.Add(new MySqlParameter("@IsActive", true));


      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int BattleId = 0;
      int Mon_Id = 0;
      string BattleName = "";
      int Level = 0;
      int TotalHitpoints = 0;
      int Hitpoints = 0;
      int Attack = 0;
      int Defense = 0;
      int Specialattack = 0;
      int Specialdefense = 0;
      int Speed = 0;
      int Move1pp = 0;
      int Move2pp = 0;
      int Move3pp = 0;
      int Move4pp = 0;
      bool IsPlayer = false;
      bool IsComputer = false;
      bool IsActive = false;

      while(rdr.Read())
      {
        BattleId = rdr.GetInt32(0);
        Mon_Id = rdr.GetInt32(1);
        BattleName = rdr.GetString(2);
        Level = rdr.GetInt32(3);
        TotalHitpoints = rdr.GetInt32(4);
        Hitpoints = rdr.GetInt32(5);
        Attack = rdr.GetInt32(6);
        Defense = rdr.GetInt32(7);
        Specialattack = rdr.GetInt32(8);
        Specialdefense = rdr.GetInt32(9);
        Speed = rdr.GetInt32(10);
        Move1pp = rdr.GetInt32(11);
        Move2pp = rdr.GetInt32(12);
        Move3pp = rdr.GetInt32(13);
        Move4pp = rdr.GetInt32(14);
        IsPlayer = rdr.GetBoolean(15);
        IsComputer = rdr.GetBoolean(16);
        IsActive = rdr.GetBoolean(17);
      }
      Battle newBattle = new Battle(Mon_Id, BattleName, Level, TotalHitpoints, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, IsPlayer, IsComputer, IsActive, BattleId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Battle("", "", 0);
      return newBattle;
    }
    public int GetHitpointsPercent()
    {
      float percent = (float)_hitpoints * 100 / (float)_totalHitpoints;
      int rounded = (int)percent;
      return rounded;
    }
    public void Edit(int newMon_Id, string newBattleName, int newLevel, int newTotalHitpoints, int newHitpoints, int newAttack, int newDefense, int newSpecialattack, int newSpecialdefense, int newSpeed, int newMove1pp, int newMove2pp, int newMove3pp, int newMove4pp, bool newIsPlayer, bool newIsComputer, bool newIsActive)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET mon_id = @newMon_Id name = @newBattleName, level = @newLevel, totalhitpoints = @newTotalHitpoints, hitpoints = @newHitpoints, attack = @newAttack, defense = @newDefense, specialattack = @newSpecialattack, specialdefense = @newSpecialdefense, speed = @newSpeed, move1pp = @newMove1pp, move2pp = @newMove2pp, move3pp = @newMove4pp, isplayer = @newIsPlayer, iscomputer = @newIsComputer, isactive = @newIsActive WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newMon_Id", newMon_Id));
      cmd.Parameters.Add(new MySqlParameter("@newBattleName", newBattleName));
      cmd.Parameters.Add(new MySqlParameter("@newLevel", newLevel));
      cmd.Parameters.Add(new MySqlParameter("@newTotalHitpoints", newTotalHitpoints));
      cmd.Parameters.Add(new MySqlParameter("@newHitpoints", newHitpoints));
      cmd.Parameters.Add(new MySqlParameter("@newAttack", newAttack));
      cmd.Parameters.Add(new MySqlParameter("@newDefense", newDefense));
      cmd.Parameters.Add(new MySqlParameter("@newSpecialattack", newSpecialattack));
      cmd.Parameters.Add(new MySqlParameter("@newSpecialdefense", newSpecialdefense));
      cmd.Parameters.Add(new MySqlParameter("@newSpeed", newSpeed));
      cmd.Parameters.Add(new MySqlParameter("@newMove1pp", newMove1pp));
      cmd.Parameters.Add(new MySqlParameter("@newMove2pp", newMove2pp));
      cmd.Parameters.Add(new MySqlParameter("@newMove3pp", newMove3pp));
      cmd.Parameters.Add(new MySqlParameter("@newMove4pp", newMove4pp));
      cmd.Parameters.Add(new MySqlParameter("@newIsPlayer", newIsPlayer));
      cmd.Parameters.Add(new MySqlParameter("@newIsComputer", newIsComputer));
      cmd.Parameters.Add(new MySqlParameter("@newIsActive", newIsActive));

      cmd.ExecuteNonQuery();
      _mon_Id = newMon_Id;
      _battleName = newBattleName;
      _level = newLevel;
      _totalHitpoints = newTotalHitpoints;
      _hitpoints = newHitpoints;
      _attack = newAttack;
      _defense = newDefense;
      _specialattack = newSpecialattack;
      _specialdefense = newSpecialdefense;
      _speed = newSpeed;
      _move1pp = newMove1pp;
      _move2pp = newMove2pp;
      _move3pp = newMove3pp;
      _move4pp = newMove4pp;
      _isPlayer = newIsPlayer;
      _isComputer = newIsComputer;
      _isActive = newIsActive;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void Delete()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM battle WHERE id = @BattleId;";

      cmd.Parameters.Add(new MySqlParameter("@BattleId", this.GetBattleId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
    public void AddMon(Mon newMon)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO mons_battle (mons_id, battle_id) VALUES (@MonsId, @BattleId);";

      cmd.Parameters.Add(new MySqlParameter("@MonsId", newMon.GetMonId()));
      cmd.Parameters.Add(new MySqlParameter("@BattleId", _battleId));

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public List<Mon> GetMons()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT mons.* FROM battle
      JOIN mons_battle ON (battle.id = mons_battle.battle_id)
      JOIN mons ON (mons_battle.mons_id = mons.id)
      WHERE battle.id = @BattleId;";

      cmd.Parameters.Add(new MySqlParameter("@BattleId", _battleId));

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      List<Mon> mons = new List<Mon>{};

      while(rdr.Read())
      {
        int monId = rdr.GetInt32(0);
        string monName = rdr.GetString(1);
        int level = rdr.GetInt32(2);
        int hitpoints = rdr.GetInt32(3);
        int attack = rdr.GetInt32(4);
        int defense = rdr.GetInt32(5);
        int specialattack = rdr.GetInt32(6);
        int specialdefense = rdr.GetInt32(7);
        int speed = rdr.GetInt32(8);

        Mon newMon = new Mon(monName, level, hitpoints, attack, defense, specialattack, specialdefense, speed, monId);
        mons.Add(newMon);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return mons;
    }
    public void SetPlayerMon()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET isplayer = @newIsPlayer WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newIsPlayer", true));

      cmd.ExecuteNonQuery();
      _isPlayer = true;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void SetComputerMon()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET iscomputer = @newIsComputer WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newIsComputer", true));

      cmd.ExecuteNonQuery();
      _isComputer = true;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void SetActiveMon()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET isactive = @newIsActive WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newIsActive", true));

      cmd.ExecuteNonQuery();
      _isPlayer = true;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public void SetNewHP(int newHp)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET hitpoints = @newHp WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newHp", newHp));

      cmd.ExecuteNonQuery();
      _hitpoints = newHp;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static void ComputerChoice(int MonId)
    {
      if(MonId == 1)
      {
        Mon mon2 = Mon.Find(2);
        Battle computer = mon2.GetAllTrueStats();
        computer.Save();
        computer.SetComputerMon();
        computer.SetActiveMon();
      }
      else if(MonId == 2)
      {
        Mon mon3 = Mon.Find(3);
        Battle computer = mon3.GetAllTrueStats();
        computer.Save();
        computer.SetComputerMon();
        computer.SetActiveMon();
      }
      else if(MonId == 3)
      {
        Mon mon1 = Mon.Find(1);
        Battle computer = mon1.GetAllTrueStats();
        computer.Save();
        computer.SetComputerMon();
        computer.SetActiveMon();
      }
    }
    public static int BaseDamage(int attackerId, Move usedMove)
    {
      List<Battle> twoBattles = new List<Battle> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM battle WHERE isactive = @isActive;";
      cmd.Parameters.Add(new MySqlParameter("@isActive", true));
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int BattleId = rdr.GetInt32(0);
        int Mon_Id = rdr.GetInt32(1);
        string BattleName = rdr.GetString(2);
        int Level = rdr.GetInt32(3);
        int TotalHitpoints = rdr.GetInt32(4);
        int Hitpoints = rdr.GetInt32(5);
        int Attack = rdr.GetInt32(6);
        int Defense = rdr.GetInt32(7);
        int Specialattack = rdr.GetInt32(8);
        int Specialdefense = rdr.GetInt32(9);
        int Speed = rdr.GetInt32(10);
        int Move1pp = rdr.GetInt32(11);
        int Move2pp = rdr.GetInt32(12);
        int Move3pp = rdr.GetInt32(13);
        int Move4pp = rdr.GetInt32(14);
        bool IsPlayer = rdr.GetBoolean(15);
        bool IsComputer = rdr.GetBoolean(16);
        bool IsActive = rdr.GetBoolean(17);

        Battle newBattle = new Battle(Mon_Id, BattleName, Level, TotalHitpoints, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, IsPlayer, IsComputer, IsActive, BattleId);
        twoBattles.Add(newBattle);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      //Player Attack
      if (attackerId == twoBattles[0].GetBattleId() && twoBattles[0].GetIsPlayer())
      {
        if (usedMove.GetAttackStyle().Equals("physical"))
        {
          float baseDamage = (((((2 * (float)twoBattles[0].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[0].GetAttack()/(float)twoBattles[1].GetDefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
        else if (usedMove.GetAttackStyle().Equals("special"))
        {
          float baseDamage = (((((2 * (float)twoBattles[0].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[0].GetSpecialattack()/(float)twoBattles[1].GetSpecialdefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
      }
      else if (attackerId == twoBattles[1].GetBattleId() && twoBattles[1].GetIsPlayer())
      {
        if (usedMove.GetAttackStyle().Equals("physical"))
        {
          float baseDamage = (((((2 * (float)twoBattles[1].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[1].GetAttack()/(float)twoBattles[0].GetDefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
        else if (usedMove.GetAttackStyle().Equals("special"))
        {
          float baseDamage = (((((2 * (float)twoBattles[1].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[1].GetSpecialattack()/(float)twoBattles[0].GetSpecialdefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
      }
      //Computer Attack
      else if (attackerId == twoBattles[0].GetBattleId() && twoBattles[0].GetIsComputer())
      {
        if (usedMove.GetAttackStyle().Equals("physical"))
        {
          float baseDamage = (((((2 * (float)twoBattles[0].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[0].GetAttack()/(float)twoBattles[1].GetDefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
        else if (usedMove.GetAttackStyle().Equals("special"))
        {
          float baseDamage = (((((2 * (float)twoBattles[0].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[0].GetSpecialattack()/(float)twoBattles[1].GetSpecialdefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
          // return (((((2 * twoBattles[0].GetLevel()) / 5) + 2) * usedMove.GetBasePower() * (twoBattles[0].GetSpecialattack()/twoBattles[1].GetSpecialdefense())) / 50) + 2;
        }
      }
      else if (attackerId == twoBattles[1].GetBattleId() && twoBattles[1].GetIsComputer())
      {
        if (usedMove.GetAttackStyle().Equals("physical"))
        {
          float baseDamage = (((((2 * (float)twoBattles[1].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[1].GetAttack()/(float)twoBattles[0].GetDefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
        else if (usedMove.GetAttackStyle().Equals("special"))
        {
          float baseDamage = (((((2 * (float)twoBattles[1].GetLevel()) / 5) + 2) * (float)usedMove.GetBasePower() * ((float)twoBattles[1].GetSpecialattack()/(float)twoBattles[0].GetSpecialdefense())) / 50) + 2;
          int rounded = (int)baseDamage;
          return rounded;
        }
      }
      return 0;
    }
    public static void PlayerAttack(int id)
    {
      Battle player = Battle.FindPlayer();
      Battle computer = Battle.FindComputer();
      Move playerMove = Move.Find(id);
      List<Move> computerMoves = Mon.Find(computer.GetMon_Id()).GetMoves();

      //Speed Check
      int tie = 0;
      if (computer.GetSpeed() == player.GetSpeed())
      {
        Random speedTie = new Random();
        tie = speedTie.Next(1,3);
      }
      if(player.GetSpeed() > computer.GetSpeed() || tie == 1)
      {
        int newHP = computer.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), playerMove);
        if(newHP > 0)
        {
          computer.SetNewHP(newHP);
          Random move = new Random();
          Move computerMove = computerMoves[move.Next(computerMoves.Count - 1)];
          int otherHP = player.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), computerMove);
          if(otherHP > 0)
          {
            player.SetNewHP(otherHP);
          }
        }
        else
        {
          computer.SetNewHP(0);
        }
      }
      else if (player.GetSpeed() < computer.GetSpeed() || tie == 2)
      {
        Random move = new Random();
        Move computerMove = computerMoves[move.Next(computerMoves.Count - 1)];
        int otherHP = player.GetHitpoints() - Battle.BaseDamage(computer.GetBattleId(), computerMove);
        if(otherHP > 0)
        {
          player.SetNewHP(otherHP);
          int newHP = computer.GetHitpoints() - Battle.BaseDamage(player.GetBattleId(), playerMove);
          if(newHP > 0)
          {
            computer.SetNewHP(newHP);
          }
          else
          {
            computer.SetNewHP(0);
          }
        }
        else
        {
          player.SetNewHP(0);
        }
      }
    }
  }
}
