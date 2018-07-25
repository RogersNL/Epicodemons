using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Epicodemon.Models
{
  public class Message
  {
    private int _messageId;
    private string _messageName;

    public Message(string MessageName, int MessageId = 0)
    {
      _messageId = MessageId;
      _messageName = MessageName;
    }
    public int GetMessageId()
    {
      return _messageId;
    }
    public string GetMessageName()
    {
      return _messageName;
    }

    public override bool Equals(System.Object otherMessage)
    {
      if(!(otherMessage is Message))
      {
        return false;
      }
      else
      {
        Message newMessage = (Message) otherMessage;
        bool idEquality = this.GetMessageId().Equals(newMessage.GetMessageId());
        bool messageEquality = this.GetMessageName().Equals(newMessage.GetMessageName());
        return (idEquality && messageEquality);
      }
    }
    public override int GetHashCode()
    {
      return this.GetMessageId().GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO messages (message) VALUES (@messageName);";

      cmd.Parameters.Add(new MySqlParameter("@messageName", _messageName));

      cmd.ExecuteNonQuery();
      _messageId = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Message> GetAllMessages()
    {
      List<Message> allMessages = new List<Message> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM messages;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int MessageId = rdr.GetInt32(0);
        string MessageName = rdr.GetString(1);
        Message newMessage = new Message(MessageName, MessageId);
        allMessages.Add(newMessage);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allMessages;
      // return new List<Message>{};
    }
    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM messages;";

      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }
}
