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
      Get["/stylists/ClearAll"] = _ => {
        stylists.DeleteAll();
        return View ["Second_Sadness_page.cshtml"];
      };
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
        return View["Second_Sadness_page.cshtml", newClients];
      };

      Get["/sadness_page"] =_=>{
        List<stylists> allstylists = stylists.GetAll();
        return View["sadness_page.cshtml", allstylists];
      };
      Get["/stylists/edit/{id}"] = Parameters => {
        stylists Selectedstylists = stylists.Find(Parameters.id);
        return View["stylist_edit.cshtml", Selectedstylists];
      };

      Patch["/stylists/edit/{id}"]=Parameters=>{
      stylists newstylists = stylists.Find(Parameters.id);
      newstylists.Update(Request.Form["stylist-name"]);
      return View ["Second_Sadness_page.cshtml"];
      };

      Get["/stylists/delete/{id}"] = parameters => {
        stylists Selectedstylists = stylists.Find(parameters.id);
        return View["stylist_edit.cshtml", Selectedstylists];
      };
      Delete["/stylists/delete/{id}"] = parameters => {
        stylists Selectedstylists = stylists.Find(parameters.id);
        Selectedstylists.Delete();
        return View["Second_Sadness_page.cshtml"];
      };
      Get["/clients/edit/{id}"] = Parameters => {

        Clients Selectedclients = Clients.Find(Parameters.id);
        return View["client_edit.cshtml", Selectedclients];
      };

      Patch["/clients/edit/{id}"]=Parameters=>{
      Clients newClients = Clients.Find(Parameters.id);
      newClients.UpdateName(Request.Form["client-name"], newClients.GetStylistId());
      return View ["Second_Sadness_page.cshtml"];
      };

      Get["/clients/delete/{id}"] = parameters => {
        Clients Selectedclients = Clients.Find(parameters.id);
        return View["client_edit.cshtml", Selectedclients];
      };
      Delete["/clients/delete/{id}"] = parameters => {
        Clients Selectedclients = Clients.Find(parameters.id);
        Selectedclients.Delete();
        return View["Second_Sadness_page.cshtml"];
      };
    }
  }
}
