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

public class WikiController : Controller
{
    private ForumDB _db;
    public WikiController(ForumDB DB)
    {
        _db = DB;
    }

    public async void Plugin(string Name)
    {

       await HttpContext.Response.WriteAsync(Name);
    }
}
