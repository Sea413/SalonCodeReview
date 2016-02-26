 using System;
 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using System.Linq;
 using Xunit;

 namespace salon
 {
   public class ClientTesting : IDisposable
   {
     public ClientTesting()
     {
       DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
     }
     [Fact]
     public void Test_DetermineifDBisEmpty()
     {
       int result = Clients.GetAll().Count;
       Assert.Equal(0,result);
     }
     [Fact]
     public void Test_SavingaClientToDatabase()
     {

       Clients newClients = new Clients("Dazzle", 2);
       newClients.Save();


       List<Clients> testing = new List<Clients> {newClients};
       List<Clients> result = Clients.GetAll();

       Assert.Equal(testing, result);
     }
     [Fact]
     public void Test_UpdateName_ChangeClientName()
     {
       Clients newClients = new Clients("Dave", 5);
       newClients.Save();
       string testingClient = "Josh";
       int testingSID = 3;

       newClients.UpdateName(testingClient,testingSID);
       string result = newClients.GetName();

       Assert.Equal(testingClient, result);
     }
    //  [Fact]
    //  public void Test_UpdateStyleID_ChangeStylistId()
    //  {
    //    Clients newClients = new Clients("Doug", 2);
    //    newClients.Save();
    //    string testingClient = "Josh";
    //    int testingSID = 3;
     //
    //    newClients.UpdateStyleId(testingClient, testingSID);
    //    int result = newClients.GetStylistId();
     //
    //    Assert.Equal(testingSID, result);
    //  }
     public void Dispose()
     {
       stylists.DeleteAll();
       Clients.DeleteAll();
     }
   }
 }
