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

    public IActionResult Plugin(string Name)
    {
        var plugin = _db.Plugins.FirstOrDefault(x => x.Name == Name);
        var commands = from com in _db.Commands where com.PluginName == Name select com;
        WikiPluginInfo WI = new WikiPluginInfo();
        WI.Commands = commands.ToList();
        WI.Plugin = plugin;
        return View(WI);
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Plugins()
    {
        var plugins = _db.Plugins.ToList();
        return View(plugins);

    }
}
