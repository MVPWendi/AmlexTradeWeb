/*
 * Licensed under the Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0)
 * See https://github.com/aspnet-contrib/AspNet.Security.OpenId.Providers
 * for more information concerning the license and the contributors participating to this project.
 */

using AmlexTradeWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class ApiController : Controller
{
    private ForumDB _db;
    public ApiController(ForumDB DB)
    {
        _db = DB;
    }

    private bool Authorized(HttpResponse Response)
    {

        string authHeader = Request.Headers["Authorization"];
        if (authHeader != null && authHeader.StartsWith("Basic"))
        {
            //Extract credentials
            string encodedUsernamePassword = authHeader.Substring("Basic".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int seperatorIndex = usernamePassword.IndexOf(':');

            var username = usernamePassword.Substring(0, seperatorIndex);
            var password = usernamePassword.Substring(seperatorIndex + 1);

            if (username == "test" && password == "test")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    [HttpPost]
    public string TakeMoney(ulong steam, double money)
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }
        var user = _db.Users.ToList().Find(x => x.SteamID == steam);
        if(user==null)
        {
            return "Code 2";
        }
        user.MoneyAmount -= money;

        _db.SaveChanges();
        return "Code 1";
    }
    [HttpPost]
    public async Task<string> PutMoney(ulong steam, double money)
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }
        var user = _db.Users.ToList().Find(x => x.SteamID == steam);
        if (user == null)
        {
            user = new User { MoneyAmount = 0, SteamID = steam };
            _db.Users.Add(user);
        }
        
        user.MoneyAmount += money;
        await _db.SaveChangesAsync();
        return "Code 1";
    }
    [HttpPost]
    public async Task<string> AddItem()
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }
        
        var item = await Request.ReadFromJsonAsync<Item>();
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return "Code 1";
    }
    [HttpPost]
    public async Task<string> AddCar()
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }

        var car = await Request.ReadFromJsonAsync<Car>();
        _db.Cars.Add(car);
        await _db.SaveChangesAsync();
        return "Code 1";
    }

    [HttpPost]
    public async Task<string> TakeCar(ulong steam, int number)
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }
        TakeData datatoreturn = new TakeData { Car = true, Code = "Code 1", ItemID = 0 };
        var user = _db.Users.ToList().Find(x => x.SteamID == steam);
        if (user == null)
        {
            datatoreturn.Code = "Code 2";
            return JsonSerializer.Serialize(datatoreturn);
        }
        var boughtcars = (from car in _db.BoughtCars where car.OwnerID == steam && car.Taken == false select car).ToList();
        if(boughtcars.Count == 0)
        {
            datatoreturn.Code = "Code 3";
            return JsonSerializer.Serialize(datatoreturn);
        }
        var selectedcar = boughtcars[number];
        if(selectedcar == null)
        {
            datatoreturn.Code = "Code 4";
            return JsonSerializer.Serialize(datatoreturn);
        }
        selectedcar.Taken = true;
        
        await _db.SaveChangesAsync();
        datatoreturn.ItemID = (int)_db.Cars.ToList().Find(x => x.ID == selectedcar.CarKey).VehicleInstanceID;
        return JsonSerializer.Serialize(datatoreturn);
    }

    [HttpPost]
    public string TakeItem(ulong steam, int number)
    {
        if (Authorized(Response) == false)
        {
            Response.StatusCode = 401;
        }
        TakeData datatoreturn = new TakeData { Car = false, Code = "Code 1", ItemID = 0 };
        var user = _db.Users.ToList().Find(x => x.SteamID == steam);
        if (user == null)
        {
            datatoreturn.Code = "Code 2";
            return JsonSerializer.Serialize(datatoreturn);
        }
        var boughtitems = (from item in _db.BoughtItems where item.OwnerID == steam && item.Taken == false select item).ToList();
        if (boughtitems.Count == 0)
        {
            datatoreturn.Code = "Code 3";
            return JsonSerializer.Serialize(datatoreturn);
        }
        var selecteditem = boughtitems[number];
        if (selecteditem == null)
        {
            datatoreturn.Code = "Code 4";
            return JsonSerializer.Serialize(datatoreturn);
        }
        selecteditem.Taken = true;

        _db.SaveChanges();
        datatoreturn.ItemID = _db.Items.ToList().Find(x => x.ID == selecteditem.ItemKey).ItemID;
        return JsonSerializer.Serialize(datatoreturn);
    }
}
