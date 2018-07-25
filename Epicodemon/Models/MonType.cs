using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class MonType
  {
    private int _monTypeId;
    private string _monTypeName;
    private int _fairy;
    private int _steel;
    private int _dark;
    private int _dragon;
    private int _ghost;
    private int _rock;
    private int _bug;
    private int _psychic;
    private int _flying;
    private int _ground;
    private int _poison;
    private int _fighting;
    private int _ice;
    private int _grass;
    private int _electric;
    private int _water;
    private int _fire;
    private int _normal;

    public MonType(string MonTypeName, int Fairy = 0, int Steel = 0, int Dark = 0, int Dragon = 0, int Ghost = 0, int Rock = 0, int Bug = 0, int Psychic = 0, int Flying = 0, int Ground = 0, int Poison = 0, int Fighting = 0, int Ice = 0, int Grass = 0, int Electric = 0, int Water = 0, int Fire = 0, int Normal = 0, int MonTypeId = 0)
    {
      _monTypeId = MonTypeId;
      _monTypeName = MonTypeName;
      _fairy = Fairy;
      _steel = Steel;
      _dark = Dark;
      _dragon = Dragon;
      _ghost = Ghost;
      _rock = Rock;
      _bug = Bug;
      _psychic = Psychic;
      _flying = Flying;
      _ground = Ground;
      _poison = Poison;
      _fighting = Fighting;
      _ice = Ice;
      _grass = Grass;
      _electric = Electric;
      _water = Water;
      _fire = Fire;
      _normal = Normal;
    }
    public int GetMonTypeId()
    {
      return _monTypeId;
    }
    public string GetMonTypeName()
    {
      return _monTypeName;
    }
    public int GetFairy()
    {
      return _fairy;
    }
    public int GetSteel()
    {
      return _steel;
    }
    public int GetDark()
    {
      return _dark;
    }
    public int GetDragon()
    {
      return _dragon;
    }
    public int GetGhost()
    {
      return _ghost;
    }
    public int GetRock()
    {
      return _rock;
    }
    public int GetBug()
    {
      return _bug;
    }
    public int GetPsychic()
    {
      return _psychic;
    }
    public int GetFlying()
    {
      return _flying;
    }
    public int GetGround()
    {
      return _ground;
    }
    public int GetPoison()
    {
      return _poison;
    }
    public int GetFighting()
    {
      return _fighting;
    }
    public int GetIce()
    {
      return _ice;
    }
    public int GetGrass()
    {
      return _grass;
    }
    public int GetElectric()
    {
      return _electric;
    }
    public int GetWater()
    {
      return _water;
    }
    public int GetFire()
    {
      return _fire;
    }
    public int GetNormal()
    {
      return _normal;
    }
    public override bool Equals(System.Object otherMonType)
    {
      if(!(otherMonType is MonType))
      {
        return false;
      }
      else
      {
        MonType newMonType = (MonType) otherMonType;
        bool idEquality = this.GetMonTypeId().Equals(newMonType.GetMonTypeId());
        bool nameEquality = this.GetMonTypeName().Equals(newMonType.GetMonTypeName());
        return (idEquality && nameEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetMonTypeId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO types (name) VALUES (@monTypeName);";

      cmd.Parameters.Add(new MySqlParameter("@monTypeName", _monTypeName));

      cmd.ExecuteNonQuery();
      _monTypeId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<MonType> GetAllMonTypes()
    {
      List<MonType> allMonTypes = new List<MonType> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM types;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int MonTypeId = rdr.GetInt32(0);
        string MonTypeName = rdr.GetString(1);
        MonType newMonType = new MonType(MonTypeName, MonTypeId);
        allMonTypes.Add(newMonType);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMonTypes;
      // return new List<MonType>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM types;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static MonType Find(string monTypeName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM types WHERE name = (@typeName);";

      cmd.Parameters.Add(new MySqlParameter("@typeName", monTypeName));

      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      int MonTypeId = 0;
      string MonTypeName = "";
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
        MonTypeId = rdr.GetInt32(0);
        MonTypeName = rdr.GetString(1);
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
      MonType newMonType = new MonType(MonTypeName, fairy, steel, dark, dragon, ghost, rock, bug, psychic, flying, ground, poison, fighting, ice, grass, electric, water, fire, normal, MonTypeId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      // return new MonType("", "", 0);
      return newMonType;
    }

    public void Edit(string newMonTypeName)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE types SET name = @newMonTypeName WHERE id = @searchId;";

      cmd.Parameters.Add(new MySqlParameter("@searchId", _monTypeId));
      cmd.Parameters.Add(new MySqlParameter("@newMonTypeName", newMonTypeName));

      cmd.ExecuteNonQuery();
      _monTypeName = newMonTypeName;

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
      cmd.CommandText = @"DELETE FROM types WHERE id = @MonTypeId;";

      cmd.Parameters.Add(new MySqlParameter("@MonTypeId", this.GetMonTypeId()));

      cmd.ExecuteNonQuery();
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static double TypeMultiplier(Mon defendingMon, Move attackingMove)
    {
      Dictionary<int, double> multiplier = new Dictionary<int, double>()
      {
        {0,1},
        {1,2},
        {2,0.5},
        {3,0}
      };
      MonType attackType = attackingMove.GetMonType();

      List<MonType> types = defendingMon.GetMonTypes();
      double multiply = 1;
      foreach(MonType type in types)
      {
        Dictionary<string, int> typeCompare = new Dictionary<string, int>()
        {
          {"fairy", type.GetFairy()},
          {"steel", type.GetSteel()},
          {"dark", type.GetDark()},
          {"dragon", type.GetDragon()},
          {"ghost", type.GetGhost()},
          {"rock", type.GetRock()},
          {"bug", type.GetBug()},
          {"psychic", type.GetPsychic()},
          {"flying", type.GetFlying()},
          {"ground", type.GetGround()},
          {"poison", type.GetPoison()},
          {"fighting", type.GetFighting()},
          {"ice", type.GetIce()},
          {"grass", type.GetGrass()},
          {"electric", type.GetElectric()},
          {"water", type.GetWater()},
          {"fire", type.GetFire()},
          {"normal", type.GetNormal()},
        };
        double newMultiplier = multiplier[typeCompare[attackType.GetMonTypeName()]];
        multiply = multiply * newMultiplier;
      }
      return multiply;
    }
  }
}
