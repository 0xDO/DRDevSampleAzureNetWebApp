using DRDevSampleAzureNetWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using DRDevSampleAzureNetWebApp.FrameworkExtensions;
using DRDevSampleAzureNetWebApp.ExtensionMethods;
using System.Net;

namespace DRDevSampleAzureNetWebApp.Controllers {
  /// <summary>
  /// The Main/Home Asp.Net MVC Controller
  /// </summary>
  /// <seealso cref="System.Web.Mvc.Controller" />
  public class HomeController : Controller {
    /// <summary>
    /// The Asp.Net Index function.
    /// </summary>
    /// <returns></returns>
    public ActionResult Index() {
      return View();
    }

    /// <summary>
    /// The About page.
    /// </summary>
    /// <returns></returns>
    public ActionResult About() {
      ViewBag.Message = "This site demonstrates various technologies hosted in the Azure cloud.\n See GitHub for all sources";

      return View();
    }

    /// <summary>
    /// The Contact page.
    /// </summary>
    /// <returns></returns>
    public ActionResult Contact() {
      ViewBag.Message = "Contact information to be added.";

      return View();
    }

    /// <summary>
    /// Fetches some asset prices from the web.
    /// </summary>
    /// <returns>A JSON formatted List of Assets</returns>
    [HttpPost]
    public async Task<JsonResult> GetAssetPrices() {
      var client = new HttpClient();
      var assets = new List<AssetModel>();
      var now = DateTime.UtcNow.ToString("HH:mm:ss");
      var jsonResult = Json(new object[] { new object() }, JsonRequestBehavior.AllowGet);
      using (client = new HttpClient()) {
        HttpResponseMessage response = await client.GetAsync("https://min-api.cryptocompare.com/data/pricemulti?fsyms=BTC,ETH,XMR&tsyms=USD,EUR&extraParams=0xDoPriceFetcherDemo");
        if (response.IsSuccessStatusCode) {
          var rawData = await response.Content.ReadAsStringAsync();
          var data = await response.Content.ReadAsJsonAsync<CryptoCompareDataModel>();
          assets = data.ToAssetModelList();
          jsonResult = Json(assets, JsonRequestBehavior.AllowGet);
        }
      }
      return jsonResult;
    }

    /// <summary>
    /// GetJsonResponseSample
    /// </summary>
    /// <returns>A JSON formatted List of Assets</returns>
    [HttpPost]
    public JsonResult GetJsonResponseSample() {
      List<AssetModel> assets = new List<AssetModel>();
      var now = DateTime.UtcNow.ToString("HH:mm:ss");
      assets.Add(new AssetModel() { Id = 0, Name = "BTC/USD", Value = 3.1415, LastUpdate = now });
      assets.Add(new AssetModel() { Id = 1, Name = "BTC/EUR", Value = 2.8765, LastUpdate = now });
      var asJson = Json(assets, JsonRequestBehavior.AllowGet);
      return asJson;
    }

  }
}