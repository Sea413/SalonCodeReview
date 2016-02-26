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
       DBConfiguration.ConnectionString = "Data Source = (localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test; Integrated Security=SSPI;";
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
     public void Dispose()
     {
       stylists.DeleteAll();
       Clients.DeleteAll();
     }
   }
 }
