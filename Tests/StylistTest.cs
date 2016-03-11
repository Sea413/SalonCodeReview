using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Salon
{
  public class SylistTesting : IDisposable
  {
    public SylistTesting()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon_test;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_StylistsEmptyAtFirst()
    {
      int result = Stylist.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_SavingaStylistToDatabase()
    {
      Stylist newStylist = new Stylist("Sarah");
      newStylist.Save();

      List<Stylist> testing = new List<Stylist> {newStylist};
      List<Stylist> result = Stylist.GetAll();

      Assert.Equal(testing, result);
    }

    [Fact]
    public void Test_DetermingGetAll()
    {
      Stylist newStylist = new Stylist("Sarah");
      newStylist.Save();
      Stylist newStylist2 = new Stylist("Jane");
      newStylist2.Save();

      List<Stylist> testing = new List<Stylist> {newStylist, newStylist2};
      List<Stylist> result = Stylist.GetAll();

      Assert.Equal(testing, result);
    }

    [Fact]
    public void Test_DetermingFind()
    {
      Stylist newStylist = new Stylist("Sarah");
      newStylist.Save();

      Stylist result = Stylist.Find(newStylist.GetId());

      Assert.Equal(newStylist, result);
    }

    public void Test_DetermingGetClient()
    {
      Stylist newStylist = new Stylist("Sarah");
      newStylist.Save();
      Client newClient = new Client("Greg", 1);
      newClient.Save();

      List<Client> result = newStylist.GetClient();
      List<Client> test = new List <Client> {newClient};

      Assert.Equal(test, result);
    }

    [Fact]
    public void Test_Update_UpdatingaStylistName()
    {
      Stylist newStylist = new Stylist("Sarah");
      newStylist.Save();
      string testingStylist = "David";

      newStylist.Update(testingStylist);
      string result = newStylist.GetName();

      Assert.Equal(testingStylist, result);
    }

    [Fact]
    public void Test_Delete_DeleteStylist()
    {
      string name1 = "Sarah";
      Stylist testingStylist1 = new Stylist(name1);
      testingStylist1.Save();

      string name2 = "Josiah";
      Stylist testingStylist2 = new Stylist(name2);
      testingStylist2.Save();

      testingStylist1.Delete();
      List<Stylist> resultStylist = Stylist.GetAll();
      List<Stylist> testStyleList = new List<Stylist> {testingStylist2};

      Assert.Equal(resultStylist, testStyleList);
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }
  }
}
