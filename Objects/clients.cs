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

     public Clients (string name, int stylistId, int Id =0)
     {
       _id = Id;
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
        bool idCuisineEquality= this.GetStylistId() == newClients.GetStylistId();
        bool nameEquality = this.GetName() == newClients.GetName();
        return (idEquality && nameEquality);
      }
    }
      public int GetId()
     {
       return _id;
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
     public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM clients;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
