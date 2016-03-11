 using System;
 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using System.Linq;
 using Xunit;

 namespace Salon
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
       int result = Client.GetAll().Count;
       Assert.Equal(0,result);
     }

     [Fact]
     public void Test_SavingaClientToDatabase()
     {

       Client newClient = new Client("Dazzle", 2);
       newClient.Save();


       List<Client> testing = new List<Client> {newClient};
       List<Client> result = Client.GetAll();

       Assert.Equal(testing, result);
     }

     [Fact]
     public void Test_UsingGetAll()
     {

       Client newClient = new Client("Dazzle", 2);
       newClient.Save();


       List<Client> testing = new List<Client> {newClient};
       List<Client> result = Client.GetAll();

       Assert.Equal(testing, result);
     }

     [Fact]
     public void Test_DetermingFind()
     {
       Client newClient = new Client("Greg", 1);
       newClient.Save();

       Client result = Client.Find(newClient.GetId());

       Assert.Equal(newClient, result);
     }

     [Fact]
     public void Test_UpdateName_ChangeClientName()
     {
       Client newClient = new Client("Dave", 5);
       newClient.Save();
       string testingClient = "Josh";
       int testingSID = 3;

       newClient.UpdateName(testingClient,testingSID);
       string result = newClient.GetName();

       Assert.Equal(testingClient, result);
     }

     [Fact]
     public void Test_Delete_Delete()
     {
       Client newClient = new Client("Dave", 5);
       newClient.Save();
       Client newClient2 = new Client("Josh", 6);
       newClient2.Save();

       newClient.Delete();
       List<Client> resultClient = Client.GetAll();
       List<Client> testClient = new List<Client> {newClient2};

       Assert.Equal(resultClient, testClient);
     }

     public void Dispose()
     {
       Stylist.DeleteAll();
       Client.DeleteAll();
     }
   }
 }
