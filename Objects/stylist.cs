using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace salon
{
  public class stylists
  {
      private string _name;
      private int _id;

    public stylists(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }

    public override bool Equals(System.Object otherStylists)
    {
      if(!(otherStylists is stylists))
      {
        return false;
      }
      else
      {
        stylists newStylists = (stylists) otherStylists;
        bool idEquality = this.GetId() == newStylists.GetId();
        bool nameEquality = this.GetName() == newStylists.GetName();
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

    public static List<stylists> GetAll()
    {
    List<stylists> allstylists = new List<stylists> {};
    SqlConnection conn = DB.Connection();
    SqlDataReader rdr = null;
    conn.Open();

    SqlCommand cmd = new SqlCommand("SELECT * FROM stylists;", conn);
    rdr = cmd.ExecuteReader();

    while(rdr.Read())
    {
      int stylistsid = rdr.GetInt32(0);
      string stylistsName = rdr.GetString(1);
      stylists newstylists = new stylists(stylistsName, stylistsid);
      allstylists.Add(newstylists);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return allstylists;
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
    public static stylists Find(int id)
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
      stylists foundstylists = new stylists(foundStylistName, foundStylistID);

      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn != null)
      {
        conn.Close();
      }
      return foundstylists;
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
