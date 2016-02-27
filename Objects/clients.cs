using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace salon
{
  public class Clients
   {
     private int _id;
     private int _stylistId;
     private string _name;

     public Clients (string name, int stylistId, int id = 0)
     {
       _id = id;
       _stylistId = stylistId;
       _name = name;
     }

     public override bool Equals(System.Object otherClients)
    {
      if (!(otherClients is Clients)) {
        return false;
      }
      else
      {
        Clients newClients = (Clients) otherClients;
        bool idEquality = this.GetId() == newClients.GetId();
        bool idSytlistEquality= this.GetStylistId() == newClients.GetStylistId();
        bool nameEquality = this.GetName() == newClients.GetName();
        return (idEquality && nameEquality && idSytlistEquality);
      }
    }
      public int GetId()
     {
       return _id;
     }
     public void SetId(int newId)
     {
       _id =newId;
     }
     public string GetName()
     {
       return _name;
     }
     public void SetName(string newName)
     {
       _name = newName;
     }

     public int GetStylistId()
     {
       return _stylistId;
     }

     public void SetStylistId(int newStylistId)
     {
       _stylistId = newStylistId;
     }

     public static List<Clients> GetAll()
     {
       List<Clients> allClients = new List<Clients>{};

       SqlConnection conn = DB.Connection();
       SqlDataReader rdr = null;
       conn.Open();

       SqlCommand cmd = new SqlCommand("Select * FROM clients ORDER BY name DESC;",conn);
       rdr = cmd.ExecuteReader();

       while(rdr.Read())
       {
         int ClientId = rdr.GetInt32(0);
         string ClientName = rdr.GetString(1);
         int StylistID = rdr.GetInt32(2);

         Clients newClients = new Clients(ClientName, StylistID, ClientId);
         allClients.Add(newClients);

       }
       if (rdr != null)
       {
         rdr.Close();
       }
       if (conn != null)
       {
         conn.Close();
       }
       return allClients;
     }
     public void Save()
     {
       SqlConnection conn = DB.Connection();
       SqlDataReader rdr;
       conn.Open();

       SqlCommand cmd = new SqlCommand("Insert INTO clients (name, styleid) OUTPUT INSERTED.id VALUES (@CName, @SId);",conn);

       SqlParameter nameParameter = new SqlParameter();
       nameParameter.ParameterName = "@CName";
       nameParameter.Value = this.GetName();

       SqlParameter StylistIdParameter = new SqlParameter();
       StylistIdParameter.ParameterName = "@SId";
       StylistIdParameter.Value = this.GetStylistId();

       cmd.Parameters.Add(nameParameter);
       cmd.Parameters.Add(StylistIdParameter);
       rdr = cmd.ExecuteReader();

       while(rdr.Read())
       {
         this._id = rdr.GetInt32(0);
       }
       if (rdr != null)
       {
         rdr.Close();
       }
       if (conn != null)
       {
         conn.Close();
       }
     }
     public static Clients Find(int id)
        {
          SqlConnection conn = DB.Connection();
          SqlDataReader rdr = null;
          conn.Open();

          SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientID;", conn);
          SqlParameter ClientsIDParameter = new SqlParameter();
          ClientsIDParameter.ParameterName = "@ClientID";
          ClientsIDParameter.Value = id.ToString();
          cmd.Parameters.Add(ClientsIDParameter);
          rdr = cmd.ExecuteReader();

          int foundClientID = 0;
          string foundClientName = null;
          int foundStylistID = 0;

          while(rdr.Read())
          {
            foundClientID = rdr.GetInt32(0);
            foundClientName = rdr.GetString(1);
            foundStylistID = rdr.GetInt32(2);
          }
          Clients foundClients = new Clients( foundClientName, foundStylistID, foundClientID);

          if(rdr != null)
          {
            rdr.Close();
          }
          if(conn != null)
          {
            conn.Close();
          }
          return foundClients;
        }
 public void UpdateName (string newName, int newStylistId)
   {
     SqlConnection conn = DB.Connection();
     SqlDataReader rdr;
     conn.Open();

     SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName2, styleid = @StyistID OUTPUT INSERTED.name WHERE id = @CId;", conn);

     SqlParameter newNameParameter = new SqlParameter();
     newNameParameter.ParameterName = "@NewName2";
     newNameParameter.Value = newName;
     cmd.Parameters.Add(newNameParameter);

     SqlParameter StylistIdParameter2 = new SqlParameter ();
     StylistIdParameter2.ParameterName = "@StyistID";
     StylistIdParameter2.Value= this.GetStylistId();
     cmd.Parameters.Add(StylistIdParameter2);

     SqlParameter ClientsIDParameter = new SqlParameter ();
     ClientsIDParameter.ParameterName = "@CId";
     ClientsIDParameter.Value= this.GetId();
     cmd.Parameters.Add(ClientsIDParameter);
     rdr = cmd.ExecuteReader();

     while(rdr.Read())
     {
       this._name = rdr.GetString(0);
     }

     if (rdr != null)
     {
       rdr.Close();
     }

     if (conn != null)
     {
       conn.Close();
     }
   }
   public void Delete()
   {
     SqlConnection conn = DB.Connection();
     conn.Open();

     SqlCommand cmd = new SqlCommand("DELETE FROM clients WHERE id = @CId;", conn);

     SqlParameter ClientsIDParameter = new SqlParameter();
     ClientsIDParameter.ParameterName = "@CId";
     ClientsIDParameter.Value = this.GetId();

     cmd.Parameters.Add(ClientsIDParameter);
     cmd.ExecuteNonQuery();

     if (conn != null)
     {
       conn.Close();
     }
   }
  //  public void UpdateStyleId (string newName, int newStylistId)
  //    {
  //      SqlConnection conn = DB.Connection();
  //      SqlDataReader rdr;
  //      conn.Open();
   //
  //      SqlCommand cmd = new SqlCommand("UPDATE clients SET styleid = @StyistID OUTPUT INSERTED.styleid WHERE id = @CId;", conn);
   //
  //      SqlParameter newNameParameter = new SqlParameter();
  //      newNameParameter.ParameterName = "@NewName2";
  //      newNameParameter.Value = newName;
  //      cmd.Parameters.Add(newNameParameter);
   //
  //      SqlParameter StylistIdParameter2 = new SqlParameter ();
  //      StylistIdParameter2.ParameterName = "@StyistID";
  //      StylistIdParameter2.Value= this.GetStylistId();
  //      cmd.Parameters.Add(StylistIdParameter2);
   //
  //      SqlParameter ClientsIDParameter = new SqlParameter ();
  //      ClientsIDParameter.ParameterName = "@CId";
  //      ClientsIDParameter.Value= this.GetId();
  //      cmd.Parameters.Add(ClientsIDParameter);
  //      rdr = cmd.ExecuteReader();
   //
  //      while(rdr.Read())
  //      {
  //        this._name = rdr.GetString(0);
  //        this._stylistId = rdr.GetInt32(1);
  //      }
   //
  //      if (rdr != null)
  //      {
  //        rdr.Close();
  //      }
   //
  //      if (conn != null)
  //      {
  //        conn.Close();
  //      }
  //    }
     public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
