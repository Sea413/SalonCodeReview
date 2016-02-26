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
    public void Test_SavingaStylistToDatabase()
    {
      stylists newStylist = new stylists("Sarah");
      newStylist.Save();

      List<stylists> testing = new List<stylists> {newStylist};
      List<stylists> result = stylists.GetAll();

      Assert.Equal(testing, result);
    }
    [Fact]
    public void Test_FindingDatabaseId()
    {
      stylists newStylist = new stylists("Sarah");
      newStylist.Save();

      List<stylists> testing = new List<stylists> {newStylist};
      List<stylists> result = newStylist.Find();

      Assert.Equal(testing, result);
    }
    public void Dispose()
    {
      stylists.DeleteAll();
    }
  }
}
