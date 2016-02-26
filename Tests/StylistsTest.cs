using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace salon
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
      int result = stylists.GetAll().Count;
      Assert.Equal(0, result);
    }
    [Fact]
    public void Test_SavingaStylistToDatabase()
    {
      stylists newStylist = new stylists("Sarah");
      newStylist.Save();

      List<stylists> testing = new List<stylists> {newStylist};
      List<stylists> result = stylists.GetAll();

      Assert.Equal(testing, result);
    }
    [Fact]
    public void Test_Update_UpdatingaStylistName()
    {
      stylists newStylist = new stylists("Sarah");
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
      stylists testingStylist1 = new stylists(name1);
      testingStylist1.Save();

      string name2 = "Josiah";
      stylists testingStylist2 = new stylists(name2);
      testingStylist2.Save();

      testingStylist1.Delete();
      List<stylists> resultstylists = stylists.GetAll();
      List<stylists> testStyleList = new List<stylists> {testingStylist2};

      Assert.Equal(resultstylists, testStyleList);
    }
    public void Dispose()
    {
      stylists.DeleteAll();
    }
  }
}
