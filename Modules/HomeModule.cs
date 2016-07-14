using Nancy;

namespace RestaurantList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => View ["index.cshtml"];
      Get ["/cuisine/list"] = _ => View ["cuisine_list.cshtml", Cuisine.GetAll()];
      Get ["/cuisine/list/cleared"] = _ => {
        Cuisine.DeleteAll();
        return View ["cuisine_list.cshtml", Cuisine.GetAll()];
      };
      Post ["/cuisine/created"] = _ => {
        Cuisine newCuisine = new Cuisine (Request.Form["cuisine-name"]);
        newCuisine.Save();
        return View ["cuisine_created.cshtml"];
      };
      Get ["/restaurant/new"] = _ => View ["restaurant_form.cshtml", Cuisine.GetAll()];
      Post ["/restaurant/created"] = _ => {
        Restaurant newRestaurant = new Restaurant
        (
          Request.Form ["restaurant-name"],
          Request.Form ["restaurant-address"],
          Request.Form ["restaurant-phone-number"],
          Request.Form ["restaurant-description"],
          Request.Form ["cuisine-id"]
        );
        newRestaurant.Save();
        return View ["restaurant_created.cshtml"];
      };
    }
  }
}
