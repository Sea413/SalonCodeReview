using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        List<stylists> allstylists = stylists.GetAll();
        return View ["index.cshtml", allstylists];
      };
      Post["/"] = _ => {
        stylists newstylists = new stylists(Request.Form["stylist-name"]);
        newstylists.Save();
        List<stylists> allstylists = stylists.GetAll();
        return View["index.cshtml", allstylists];
      };
      // Get["/cuisine/ClearAll"] = _ => {
      //   Cuisines.DeleteAll();
      //   return View ["cuisineClearAll.cshtml"];
      // };
      Get["/stylists/{id}"] =Parameters=> {
        Dictionary <string, object> model = new Dictionary <string, object>();
        var selectedstylist = stylists.Find(Parameters.id);
        var stylistclients = selectedstylist.GetClients();
        model.Add ("stylists", selectedstylist);
        model.Add("clients", stylistclients);
        return View["clientadd.cshtml", model];
      };

      Post["/stylists/ViewClient"] = Parameters => {
        Clients newClients = new Clients(Request.Form["name"], Request.Form["stylist-id"]);
        newClients.Save();
        return View["clientadd.cshtml", newClients];
      };
      // Get["cuisines/edit/{id}"] = Parameters => {
      //   Cuisines SelectedCuisines = Cuisines.Find(Parameters.id);
      //   return View["cuisines_edit.cshtml", SelectedCuisines];
      // };
      //
      // Patch["/cuisines/edit/{id}"]=Parameters=>{
      // Cuisines newCusisines = Cuisines.Find(Parameters.id);
      // newCusisines.Update(Request.Form["cuisine-name"]);
      // return View ["success.cshtml"];
      // };
      //
      // Get["cuisines/delete/{id}"] = parameters => {
      //   Cuisines SelectedCuisines = Cuisines.Find(parameters.id);
      //   return View["cuisineDelete.cshtml", SelectedCuisines];
      // };
      // Delete["cuisines/delete/{id}"] = parameters => {
      //   Cuisines SelectedCuisines = Cuisines.Find(parameters.id);
      //   SelectedCuisines.Delete();
      //   return View["success.cshtml"];
      // };
    }
  }
}
