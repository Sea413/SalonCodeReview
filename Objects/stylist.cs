using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace salon
{
  public class Stylist
  {
      private string _name;
      private int _id;

    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public override bool Equals(System.Object otherStylist)
    {
      if(!(otherStylist is Stylist))
      {
        return false;
      }
      else
      {
        Stylist newStylist = (Stylist) otherStylist;
        bool idEquality = this.GetId() == newStylist.GetId();
        bool nameEquality = this.GetName() == newStylist.GetName();
        return(idEquality && nameEquality);
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

    public  void SetName(string newName)
    {
      _name= newName;
    }

    public static List<Stylist> GetAll()
    {
    List<Stylist> allStylist = new List<Stylist> {};
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr = null;
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int Stylistid = rdr.GetInt32(0);
      string StylistName = rdr.GetString(1);
      Stylist newStylist = new Stylist(StylistName, Stylistid);
      allStylist.Add(newStylist);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return allStylist;
   }

  public void Save()
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr;
    conn.Open();

    SqlCommand cmd = new SqlCommand("INSERT INTO stylists (name) OUTPUT INSERTED.id VALUES (@SName);", conn);

    SqlParameter nameParameter = new SqlParameter();
    nameParameter.ParameterName = "@SName";
    nameParameter.Value = this.GetName();
    cmd.Parameters.Add(nameParameter);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      this._id = rdr.GetInt32(0);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if(conn != null)
    {
      conn.Close();
    }
  }
  public static Stylist Find(int id)
  {
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr = null;
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM stylists WHERE id = @Sid;", conn);
    SqlParameter StylistIdParameter = new SqlParameter();
    StylistIdParameter.ParameterName = "@Sid";
    StylistIdParameter.Value = id.ToString();
    cmd.Parameters.Add(StylistIdParameter);
    rdr = cmd.ExecuteReader();

    int foundStylistID = 0;
    string foundStylistName = null;

    while(rdr.Read())
    {
      foundStylistID = rdr.GetInt32(0);
      foundStylistName = rdr.GetString(1);
    }
    Stylist foundStylist = new Stylist(foundStylistName, foundStylistID);

    if (rdr != null)
    {
      rdr.Close();
    }
    if(conn != null)
    {
      conn.Close();
    }
    return foundStylist;
  }
  public List<Client> GetClient()
   {
     SqlConnection conn = DB.Connection();
     SqlDataReader rdr = null;
     conn.Open();

     SqlCommand cmd = new SqlCommand("SELECT * FROM clients WHERE stylist_id = @StylistID ORDER BY name DESC;", conn);
     SqlParameter ClientIdParameter = new SqlParameter ();
     ClientIdParameter.ParameterName = "@StylistID";
     ClientIdParameter.Value = this.GetId();
     cmd.Parameters.Add(ClientIdParameter);
     rdr = cmd.ExecuteReader();

     List<Client> client = new List<Client> {};
     while(rdr.Read())
     {
       int ClientId = rdr.GetInt32(0);
       string ClientName = rdr.GetString(1);
       int styleistId = rdr.GetInt32(2);
       Client newClient = new Client(ClientName,styleistId,ClientId);
       client.Add(newClient);
     }
     if (rdr != null)
     {
       rdr.Close();
     }
     if (conn != null)
     {
       conn.Close();
     }
     return client;
   }

  public void Update (string newName)
    {
      SqlConnection conn = DB.Connection();
      SqlDataReader rdr;
      conn.Open();

      SqlCommand cmd = new SqlCommand("UPDATE stylists SET name=@NewName OUTPUT INSERTED.name WHERE id= @SId;", conn);

      SqlParameter newNameParameter = new SqlParameter();
      newNameParameter.ParameterName = "@NewName";
      newNameParameter.Value = newName;
      cmd.Parameters.Add(newNameParameter);

      SqlParameter StylistIdParameter = new SqlParameter ();
      StylistIdParameter.ParameterName = "@SId";
      StylistIdParameter.Value= this.GetId();
      cmd.Parameters.Add(StylistIdParameter);
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

      SqlCommand cmd = new SqlCommand("DELETE FROM stylists WHERE id = @SId;", conn);

      SqlParameter StylistIdParameter = new SqlParameter();
      StylistIdParameter.ParameterName = "@SId";
      StylistIdParameter.Value = this.GetId();

      cmd.Parameters.Add(StylistIdParameter);
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
    SqlCommand cmd = new SqlCommand("DELETE FROM stylists", conn);
    cmd.ExecuteNonQuery();
  }
}
}
