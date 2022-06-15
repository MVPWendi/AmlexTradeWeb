/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenId.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using AmlexTradeWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

public class HomeController : Controller
{
    private ForumDB db;

    public HomeController(ForumDB DB)
    {
        this.db = DB;
    }

    private ulong GetSteamID()
    {
        string SteamURL = User.Claims.ToList()[0].Value;
        Regex regex = new Regex(@"7\d*");
        var matches = regex.Matches(SteamURL);
        return ulong.Parse(matches[0].Value);
    }
    [HttpGet]
    public IActionResult BuyItem(int id)
    {
        Item item = db.Items.ToList().Find(x => x.ID == id);
        
        if (item == null || User.Identity.IsAuthenticated == false)
        {
            return RedirectToAction($"123", "Home");
        }
        var user = db.Users.ToList().Find(x => x.SteamID == GetSteamID());
        if (user.MoneyAmount < item.Cost)
        {
            return RedirectToAction($"123", "Home");
        }
        var seller = db.Users.ToList().Find(x => x.SteamID == item.OwnerID);
        if (seller == null)
        {
            seller = new AmlexTradeWeb.Models.User { MoneyAmount = 0, SteamID = item.OwnerID };
            db.Users.Add(seller);
        }
           
        user.MoneyAmount -= item.Cost;
        seller.MoneyAmount += item.Cost;
        item.Bought = true;
        db.BoughtItems.Add(new BoughtItem { ItemKey = item.ID, OwnerID = user.SteamID, SellerID = seller.SteamID, Taken = false});
        db.SaveChanges();
        return RedirectToAction($"Index", "Home");
    }
    [HttpGet]
    public ActionResult BuyCar(int id)
    {
        Car item = db.Cars.ToList().Find(x => x.ID == id);

        if (item == null || User.Identity.IsAuthenticated == false)
        {
            return RedirectToAction($"123", "Home");
        }
        var user = db.Users.ToList().Find(x => x.SteamID == GetSteamID());
        if (user.MoneyAmount < item.Cost)
        {
            return RedirectToAction($"123", "Home");
        }
        var seller = db.Users.ToList().Find(x => x.SteamID == item.OwnerID);
        if (seller == null)
        {
            seller = new AmlexTradeWeb.Models.User { MoneyAmount = 0, SteamID = item.OwnerID };
            db.Users.Add(seller);
        }
        user.MoneyAmount -= item.Cost;
        seller.MoneyAmount += item.Cost;
        item.Bought = true;
        db.BoughtCars.Add(new BoughtCar { CarKey = item.ID, OwnerID = user.SteamID, SellerID = seller.SteamID, Taken = false });
        db.SaveChanges();
        return RedirectToAction($"Index", "Home");
    }
    [HttpGet]
    public IActionResult Index(string Shop)
    {
        if (User.Identity.IsAuthenticated)
        {
            string SteamURL = User.Claims.ToList()[0].Value;
            Regex regex = new Regex(@"7\d*");
            var matches = regex.Matches(SteamURL);
            if (db.Users.Count() > 0)
            {
                var list = db.Users.ToList();
                if (list.Exists(x => x.SteamID == ulong.Parse(matches[0].Value)) == false)
                {
                    db.Users.Add(new AmlexTradeWeb.Models.User { SteamID = ulong.Parse(matches[0].Value), MoneyAmount = 0 });
                    db.SaveChanges();
                }
            }
            else
            {
                db.Users.Add(new AmlexTradeWeb.Models.User { SteamID = ulong.Parse(matches[0].Value), MoneyAmount = 0 });
                db.SaveChanges();
            }

            
            if(Shop=="Item")
            {
                var sortedlist = from item in db.Items where item.Bought == false select item;
                ViewBag.Items = sortedlist.ToList();
                return View();
            }
            if(Shop=="Car")
            {
                var carsorted = from car in db.Cars where car.Bought == false select car;
                ViewBag.Cars = carsorted.ToList();
                return View();
            }
        }
        return View();
    }

    [HttpGet]
    public IActionResult Carshop()
    {
        var carsorted = from car in db.Cars where car.Bought == false select car;
        return View(carsorted);
    }
    [HttpGet]
    public IActionResult ItemShop()
    {
        var sortedlist = from item in db.Items where item.Bought == false select item;
        return View(sortedlist);
    }
}
