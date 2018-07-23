using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class Battle
  {
    private int _battleId;
    private string _battleName;
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

    public Battle(string BattleName, int Hitpoints, int Attack, int Defense, int Specialattack, int Specialdefense, int Speed, int Move1pp, int Move2pp, int Move3pp, int Move4pp, int BattleId = 0)
    {
      _battleId = BattleId;
      _battleName = BattleName;
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
    }
    public int GetBattleId()
    {
      return _battleId;
    }
    public string GetBattleName()
    {
      return _battleName;
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
        bool nameEquality = this.GetBattleName().Equals(newBattle.GetBattleName());
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

        return (idEquality && nameEquality && hitpointsEquality && attackEquality && defenseEquality && spattackEquality && spdefenseEquality && speedEquality && pp1Equality && pp2Equality && pp3Equality && pp4Equality);
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
      cmd.CommandText = @"INSERT INTO battle (name, hitpoints, attack, defense, specialattack, specialdefense, speed, move1pp, move2pp, move3pp, move4pp) VALUES (@battleName, @hitpoints, @attack, @defense, @specialattack, @specialdefense, @speed, @move1pp, @move2pp, @move3pp, @move4pp);";

      cmd.Parameters.Add(new MySqlParameter("@battleName", _battleName));
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
        string BattleName = rdr.GetString(1);
        int Hitpoints = rdr.GetInt32(2);
        int Attack = rdr.GetInt32(3);
        int Defense = rdr.GetInt32(4);
        int Specialattack = rdr.GetInt32(5);
        int Specialdefense = rdr.GetInt32(6);
        int Speed = rdr.GetInt32(7);
        int Move1pp = rdr.GetInt32(8);
        int Move2pp = rdr.GetInt32(9);
        int Move3pp = rdr.GetInt32(10);
        int Move4pp = rdr.GetInt32(11);

        Battle newBattle = new Battle(BattleName, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, BattleId);
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
      cmd.CommandText = @"DELETE FROM battle;";

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
      string BattleName = "";
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

      while(rdr.Read())
      {
        BattleId = rdr.GetInt32(0);
        BattleName = rdr.GetString(1);
        Hitpoints = rdr.GetInt32(2);
        Attack = rdr.GetInt32(3);
        Defense = rdr.GetInt32(4);
        Specialattack = rdr.GetInt32(5);
        Specialdefense = rdr.GetInt32(6);
        Speed = rdr.GetInt32(7);
        Move1pp = rdr.GetInt32(8);
        Move2pp = rdr.GetInt32(9);
        Move3pp = rdr.GetInt32(10);
        Move4pp = rdr.GetInt32(11);
      }
      Battle newBattle = new Battle(BattleName, Hitpoints, Attack, Defense, Specialattack, Specialdefense, Speed, Move1pp, Move2pp, Move3pp, Move4pp, BattleId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Battle("", "", 0);
      return newBattle;
    }
    public void Edit(string newBattleName, int newHitpoints, int newAttack, int newDefense, int newSpecialattack, int newSpecialdefense, int newSpeed, int newMove1pp, int newMove2pp, int newMove3pp, int newMove4pp)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE battle SET name = @newBattleName, hitpoints = @newHitpoints, attack = @newAttack, defense = @newDefense, specialattack = @newSpecialattack, specialdefense = @newSpecialdefense, speed = @newSpeed WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _battleId));
      cmd.Parameters.Add(new MySqlParameter("@newBattleName", newBattleName));
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

      cmd.ExecuteNonQuery();
      _battleName = newBattleName;
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
  }
}
