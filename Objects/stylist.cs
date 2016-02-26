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

      SqlParameter CuisinesIdParameter = new SqlParameter ();
      CuisinesIdParameter.ParameterName = "@SId";
      CuisinesIdParameter.Value= this.GetId();
      cmd.Parameters.Add(CuisinesIdParameter);
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
  public static void DeleteAll()
  {
    SqlConnection conn = DB.Connection();
    conn.Open();
    SqlCommand cmd = new SqlCommand("DELETE FROM stylists", conn);
    cmd.ExecuteNonQuery();
  }
}
}
