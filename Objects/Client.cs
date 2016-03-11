using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Salon
{
  public class Client
   {
     private int _id;
     private int _stylistId;
     private string _name;

     public Client (string name, int stylistId, int id = 0)
     {
       _id = id;
       _stylistId = stylistId;
       _name = name;
     }

     public override bool Equals(System.Object otherClient)
     {
      if (!(otherClient is Client))
      {
        return false;
      }
      else
      {
        Client newClient = (Client) otherClient;
        bool idEquality = this.GetId() == newClient.GetId();
        bool idSytlistEquality= this.GetStylistId() == newClient.GetStylistId();
        bool nameEquality = this.GetName() == newClient.GetName();
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

     public static List<Client> GetAll()
     {
       List<Client> allClient = new List<Client>{};

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

         Client newClient = new Client(ClientName, StylistID, ClientId);
         allClient.Add(newClient);

       }
       if (rdr != null)
       {
         rdr.Close();
       }
       if (conn != null)
       {
         conn.Close();
       }
       return allClient;
     }

     public void Save()
     {
       SqlConnection conn = DB.Connection();
       SqlDataReader rdr;
       conn.Open();

       SqlCommand cmd = new SqlCommand("Insert INTO clients (name, stylist_id) OUTPUT INSERTED.id VALUES (@CName, @SId);",conn);

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

     public static Client Find(int id)
      {
        SqlConnection conn = DB.Connection();
        SqlDataReader rdr = null;
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE id = @ClientID;", conn);
        SqlParameter ClientIDParameter = new SqlParameter();
        ClientIDParameter.ParameterName = "@ClientID";
        ClientIDParameter.Value = id.ToString();
        cmd.Parameters.Add(ClientIDParameter);
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
        Client foundClient = new Client( foundClientName, foundStylistID, foundClientID);

        if(rdr != null)
        {
          rdr.Close();
        }
        if(conn != null)
        {
          conn.Close();
        }
        return foundClient;
      }

     public void UpdateName (string newName, int newStylistId)
     {
       SqlConnection conn = DB.Connection();
       SqlDataReader rdr;
       conn.Open();

       SqlCommand cmd = new SqlCommand("UPDATE clients SET name = @NewName2, stylist_id = @StyistID OUTPUT INSERTED.name WHERE id = @CId;", conn);

       SqlParameter newNameParameter = new SqlParameter();
       newNameParameter.ParameterName = "@NewName2";
       newNameParameter.Value = newName;
       cmd.Parameters.Add(newNameParameter);

       SqlParameter StylistIdParameter2 = new SqlParameter ();
       StylistIdParameter2.ParameterName = "@StyistID";
       StylistIdParameter2.Value= this.GetStylistId();
       cmd.Parameters.Add(StylistIdParameter2);

       SqlParameter ClientIDParameter = new SqlParameter ();
       ClientIDParameter.ParameterName = "@CId";
       ClientIDParameter.Value= this.GetId();
       cmd.Parameters.Add(ClientIDParameter);
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

       SqlParameter ClientIDParameter = new SqlParameter();
       ClientIDParameter.ParameterName = "@CId";
       ClientIDParameter.Value = this.GetId();

       cmd.Parameters.Add(ClientIDParameter);
       cmd.ExecuteNonQuery();

       if (conn != null)
       {
         conn.Close();
       }
     }

     public static void DeleteAll()
     {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
