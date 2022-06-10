﻿/*
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
    [HttpPut]
    public async Task<string> TakeMoney()
    {
        if (Authorized(Response)==false)
        {
            Response.StatusCode = 401;
        }
        var item = await Request.ReadFromJsonAsync<Item>();
        _db.Items.Add(item);
        _db.SaveChanges();
        return "Code 1";
    }
    public string PutMoney()
    {
        return "";
    }

    public string AddItem()
    {
        return "";
    }

    public string RemoveItem()
    {
        return "";
    }
}
