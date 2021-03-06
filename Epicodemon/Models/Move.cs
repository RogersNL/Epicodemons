using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class Move
  {
    private int _moveId;
    private string _moveName;
    private int _basePower;
    private string _attackStyle;
    private string _description;
    private string _secondaryEffect;
    private int _powerPoints;
    private int _accuracy;


    public Move(string MoveName, int BasePower, string AttackStyle, string Description, string SecondaryEffect, int PowerPoints, int Accuracy, int MoveId = 0)
    {
      _moveId = MoveId;
      _moveName = MoveName;
      _basePower = BasePower;
      _attackStyle = AttackStyle;
      _description = Description;
      _secondaryEffect = SecondaryEffect;
      _powerPoints = PowerPoints;
      _accuracy = Accuracy;
    }
    public int GetMoveId()
    {
      return _moveId;
    }
    public string GetMoveName()
    {
      return _moveName;
    }
    public int GetBasePower()
    {
      return _basePower;
    }
    public string GetAttackStyle()
    {
      return _attackStyle;
    }
    public string GetDescription()
    {
      return _description;
    }
    public string GetSecondaryEffect()
    {
      return _secondaryEffect;
    }
    public int GetPowerPoints()
    {
      return _powerPoints;
    }
    public int GetAccuracy()
    {
      return _accuracy;
    }

    public override bool Equals(System.Object otherMove)
    {
      if(!(otherMove is Move))
      {
        return false;
      }
      else
      {
        Move newMove = (Move) otherMove;
        bool idEquality = this.GetMoveId().Equals(newMove.GetMoveId());
        bool nameEquality = this.GetMoveName().Equals(newMove.GetMoveName());
        bool basePowerEquality = this.GetBasePower().Equals(newMove.GetBasePower());
        bool attackStyleEquality = this.GetAttackStyle().Equals(newMove.GetAttackStyle());
        bool descriptionEquality = this.GetDescription().Equals(newMove.GetDescription());
        bool secondaryEquality = this.GetSecondaryEffect().Equals(newMove.GetSecondaryEffect());
        bool powerPointsEquality = this.GetPowerPoints().Equals(newMove.GetPowerPoints());
        bool accuracyEquality = this.GetAccuracy().Equals(newMove.GetAccuracy());
        return (idEquality && nameEquality && basePowerEquality && attackStyleEquality && descriptionEquality && secondaryEquality && powerPointsEquality && accuracyEquality );
      }
    }
    public override int GetHashCode()
    {
      return this.GetMoveId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO moves (name, basepower, attackstyle, description, secondaryeffect, powerpoints, accuracy) VALUES (@moveName, @basePower, @attackStyle, @description, @secondaryEffect, @powerPoints, @accuracy);";

      cmd.Parameters.Add(new MySqlParameter("@moveName", _moveName));
      cmd.Parameters.Add(new MySqlParameter("@basePower", _basePower));
      cmd.Parameters.Add(new MySqlParameter("@attackStyle", _attackStyle));
      cmd.Parameters.Add(new MySqlParameter("@description", _description));
      cmd.Parameters.Add(new MySqlParameter("@secondaryEffect", _secondaryEffect));
      cmd.Parameters.Add(new MySqlParameter("@powerPoints", _powerPoints));
      cmd.Parameters.Add(new MySqlParameter("@accuracy", _accuracy));

      cmd.ExecuteNonQuery();
      _moveId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Move> GetAllMoves()
    {
      List<Move> allMoves = new List<Move> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM moves;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int MoveId = rdr.GetInt32(0);
        string MoveName = rdr.GetString(1);
        int BasePower = rdr.GetInt32(2);
        string AttackStyle = rdr.GetString(3);
        string Description = rdr.GetString(4);
        string SecondaryEffect = rdr.GetString(5);
        int PowerPoints = rdr.GetInt32(6);
        int Accuracy = rdr.GetInt32(7);
        Move newMove = new Move(MoveName, BasePower, AttackStyle, Description, SecondaryEffect, PowerPoints, Accuracy, MoveId);
        allMoves.Add(newMove);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMoves;
      // return new List<Move>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM moves;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static Move Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM moves WHERE id = (@searchId);";

      cmd.Parameters.Add(new MySqlParameter("@searchId", id));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int MoveId = 0;
      string MoveName = "";
      int BasePower = 0;
      string AttackStyle = "";
      string Description = "";
      string SecondaryEffect = "";
      int PowerPoints = 0;
      int Accuracy = 0;

      while(rdr.Read())
      {
        MoveId = rdr.GetInt32(0);
        MoveName = rdr.GetString(1);
        BasePower = rdr.GetInt32(2);
        AttackStyle = rdr.GetString(3);
        Description = rdr.GetString(4);
        SecondaryEffect = rdr.GetString(5);
        PowerPoints = rdr.GetInt32(6);
        Accuracy = rdr.GetInt32(7);
      }
      Move newMove = new Move(MoveName, BasePower, AttackStyle, Description, SecondaryEffect, PowerPoints, Accuracy, MoveId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new Move("", "", 0);
      return newMove;
    }

    public void Edit(string newMoveName, int newBasePower, string newAttackStyle, string newDescription, string newSecondaryEffect, int newPowerPoints, int newAccuracy)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE moves SET name = @newMoveName, basepower = @newBasePower, attackStyle = @newAttackStyle, description = @newDescription, secondaryEffect = @newSecondaryEffect, powerpoints = @newPowerPoints, accuracy= @newAccuracy WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _moveId));
      cmd.Parameters.Add(new MySqlParameter("@newMoveName", newMoveName));
      cmd.Parameters.Add(new MySqlParameter("@newBasePower", newBasePower));
      cmd.Parameters.Add(new MySqlParameter("@newAttackStyle", newAttackStyle));
      cmd.Parameters.Add(new MySqlParameter("@newDescription", newDescription));
      cmd.Parameters.Add(new MySqlParameter("@newSecondaryEffect", newSecondaryEffect));
      cmd.Parameters.Add(new MySqlParameter("@newPowerPoints", newPowerPoints));
      cmd.Parameters.Add(new MySqlParameter("@newAccuracy", newAccuracy));

      cmd.ExecuteNonQuery();
      _moveName = newMoveName;
      _basePower = newBasePower;
      _attackStyle = newAttackStyle;
      _description = newDescription;
      _secondaryEffect = newSecondaryEffect;
      _powerPoints = newPowerPoints;
      _accuracy = newAccuracy;

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
      cmd.CommandText = @"DELETE FROM moves WHERE id = @MoveId;";

      cmd.Parameters.Add(new MySqlParameter("@MoveId", this.GetMoveId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
    public void AddMonType(MonType newMonType)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO moves_types (moves_id, types_id) VALUES (@MoveId, @TypeId);";

      cmd.Parameters.Add(new MySqlParameter("@MoveId", _moveId));
      cmd.Parameters.Add(new MySqlParameter("@TypeId", newMonType.GetMonTypeId()));

      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public MonType GetMonType()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT types.* FROM moves
      JOIN moves_types ON (moves.id = moves_types.moves_id)
      JOIN types ON (moves_types.types_id = types.id)
      WHERE moves.id = @MoveId;";

      cmd.Parameters.Add(new MySqlParameter("@MoveId", _moveId));

      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int typesId = 0;
      string typesName = "";
      int fairy = 0;
      int steel = 0;
      int dark = 0;
      int dragon = 0;
      int ghost = 0;
      int rock = 0;
      int bug = 0;
      int psychic = 0;
      int flying = 0;
      int ground = 0;
      int poison = 0;
      int fighting = 0;
      int ice = 0;
      int grass = 0;
      int electric = 0;
      int water = 0;
      int fire = 0;
      int normal = 0;
      while(rdr.Read())
      {
        typesId = rdr.GetInt32(0);
        typesName = rdr.GetString(1);
        fairy = rdr.GetInt32(2);
        steel = rdr.GetInt32(3);
        dark = rdr.GetInt32(4);
        dragon = rdr.GetInt32(5);
        ghost = rdr.GetInt32(6);
        rock = rdr.GetInt32(7);
        bug = rdr.GetInt32(8);
        psychic = rdr.GetInt32(9);
        flying = rdr.GetInt32(10);
        ground = rdr.GetInt32(11);
        poison = rdr.GetInt32(12);
        fighting = rdr.GetInt32(13);
        ice = rdr.GetInt32(14);
        grass = rdr.GetInt32(15);
        electric = rdr.GetInt32(16);
        water = rdr.GetInt32(17);
        fire = rdr.GetInt32(18);
        normal = rdr.GetInt32(19);
      }
      MonType newMonType = new MonType(typesName, fairy, steel, dark, dragon, ghost, rock, bug, psychic, flying, ground, poison, fighting, ice, grass, electric, water, fire, normal, typesId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return newMonType;
      // return new List<MonType>{};
    }
    public double AccuracyMultiplier()
    {
      Random rand = new Random();
      if(rand.Next(101) >= _accuracy)
      {
        Message.DeleteAll();
        Message newMessage = new Message("<span class='animated fadeInDown'>But The Attack Missed!</span>");
        newMessage.Save();
        return 0;
      }
      else
      {
        return 1;
      }
    }
  }
}
