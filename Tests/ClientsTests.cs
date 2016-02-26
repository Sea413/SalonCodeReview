
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
        bool nameEquality = this.GetName() == newRestaurants.GetName();
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
