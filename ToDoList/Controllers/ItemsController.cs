using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [HttpPost("/items/completed")]
    public ActionResult Completed()
    {
      Item.Completed();
      return View("Show");
    }

    [HttpGet("/categories/{categoryId}/items/{itemId}/edit")]
    public ActionResult Edit(int categoryId, int itemId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("category", category);
      Item item = Item.Find(itemId);
      model.Add("item", item);
      return View(model);
    }

    [HttpPost("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Update(int categoryId, int itemId, string newDescription)
    {
      Item item = Item.Find(itemId);
      item.Edit(newDescription);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      model.Add("category", category);
      model.Add("item", item);
      return View("Show", model);
    }

    // [HttpPost("/categories/{categoryId}/items/{itemId}/delete-item")]
    // public ActionResult DeleteItem(int categoryId, int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   item.Delete();
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category foundCategory = Category.Find(categoryId);
    //   List<Item> categoryItems = foundCategory.GetItems();
    //   model.Add("item", categoryItems);
    //   model.Add("category", foundCategory);
    //   // return View(model);
    //   return RedirectToAction("Show", "Categories");
    //   //return RedirectToAction("actionName", "controllerName"); goes to a cshtml page in a different controller.
    // }


  }
}
