using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace salon
{
  public class StylistsTest : IDisposable
  {
    public StylistsTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=hair_salon;Integrated Security=SSPI;";
    }

//     [Fact]
//     public void Test_StylistsEmptyAtFirst()
//     {
//       int result = stylists.GetAll().Count;
//       Assert.Equal(0, result);
//     }
//     public void Dispose()
//     {
//       stylists.DeleteAll();
//     }
  }
}


    // [Fact]
    // public void Test_CuisinesReturnTrueForSameName()
    // {
    //   Cuisines firstCuisines = new Cuisines("Chinese");
    //   Cuisines secondCuisines = new Cuisines("Chinese");
    //   Assert.Equal(firstCuisines, secondCuisines);
    // }
