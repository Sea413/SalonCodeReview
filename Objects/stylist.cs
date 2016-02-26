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

    public  void SetName(string Name)
    {
      _name=Name;
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
      allCuisines.Add(newstylists);
    }
    if (rdr != null)
    {
      rdr.Close();
    }
    if (conn != null)
    {
      conn.Close();
    }
    return allCuisines;
  }

  // public void Save()
  //  {
  //    SqlConnection conn = DB.Connection();
  //    SqlDataReader rdr;
  //    conn.Open();
