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
     public void Test_Delete_Delete()
     {
       Clients newClients = new Clients("Dave", 5);
       newClients.Save();
       Clients newClients2 = new Clients("Josh", 6);
       newClients2.Save();

       newClients.Delete();
       List<Clients> resultClients = Clients.GetAll();
       List<Clients> testClients = new List<Clients> {newClients2};

       Assert.Equal(resultClients, testClients);
     }

     public void Dispose()
     {
       stylists.DeleteAll();
       Clients.DeleteAll();
     }
   }
 }
