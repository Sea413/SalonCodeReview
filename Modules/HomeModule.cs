using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Salon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        List<Stylist> allStylist = Stylist.GetAll();
        return View ["index.cshtml", allStylist];
      };

      Post["/"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
        newStylist.Save();
        List<Stylist> allStylist = Stylist.GetAll();
        return View["index.cshtml", allStylist];
      };

      Get["/stylists/ClearAll"] = _ => {
        Stylist.DeleteAll();
        return View ["success.cshtml"];
      };

      Get["/stylists/{id}"] =Parameters=> {
        Dictionary <string, object> model = new Dictionary <string, object>();
        var selectedstylist = Stylist.Find(Parameters.id);
        var stylistclients = selectedstylist.GetClient();
        model.Add ("Stylist", selectedstylist);
        model.Add("clients", stylistclients);
        return View["clientadd.cshtml", model];
      };

      Post["/stylists/viewClient"] = Parameters => {
        Client newClient = new Client(Request.Form["name"], Request.Form["stylist-id"]);
        newClient.Save();
        return View["success.cshtml", newClient];
      };

      Get["/stylists/client_add"] =_=>{
        List<Stylist> allStylist = Stylist.GetAll();
        return View["stylist_client_view.cshtml", allStylist];
      };

      Get["/stylists/edit/{id}"] = Parameters => {
        Stylist SelectedStylist = Stylist.Find(Parameters.id);
        return View["stylist_edit.cshtml", SelectedStylist];
      };

      Patch["/stylists/edit/{id}"]=Parameters=>{
        Stylist newStylist = Stylist.Find(Parameters.id);
        newStylist.Update(Request.Form["stylist-name"]);
        return View ["success.cshtml"];
      };

      Get["/stylists/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        return View["stylist_edit.cshtml", SelectedStylist];
      };

      Delete["/stylists/delete/{id}"] = parameters => {
        Stylist SelectedStylist = Stylist.Find(parameters.id);
        SelectedStylist.Delete();
        return View["success.cshtml"];
      };

      Get["/clients/edit/{id}"] = Parameters => {
        Client Selectedclients = Client.Find(Parameters.id);
        return View["client_edit.cshtml", Selectedclients];
      };

      Patch["/clients/edit/{id}"]=Parameters=>{
        Client newClient = Client.Find(Parameters.id);
        newClient.UpdateName(Request.Form["client-name"], newClient.GetStylistId());
        return View ["success.cshtml"];
      };

      Get["/clients/delete/{id}"] = parameters => {
        Client Selectedclients = Client.Find(parameters.id);
        return View["client_edit.cshtml", Selectedclients];
      };

      Delete["/clients/delete/{id}"] = parameters => {
        Client Selectedclients = Client.Find(parameters.id);
        Selectedclients.Delete();
        return View["success.cshtml"];
      };
    }
  }
}
