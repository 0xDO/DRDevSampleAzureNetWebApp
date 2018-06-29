using DRDevSampleAzureNetWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.ExtensionMethods {
  public static class AssetModelExtensions {

    /// <summary>
    /// Converts the remote API data object to our asset data model
    /// </summary>
    /// <param name="data">The data.</param>
    /// <returns></returns>
    public static List<AssetModel> ToAssetModelList(this CryptoCompareDataModel data) {
      List<AssetModel> assetModels = new List<AssetModel>();
      var now = DateTime.UtcNow.ToString("HH:mm:ss");
      //TODO: usually this would be dynamic, this is just bad code
      assetModels.Add(new AssetModel() { Name="BTC", Value=data.BTC.USD, LastUpdate=now });
      assetModels.Add(new AssetModel() { Name = "ETH", Value = data.ETH.USD, LastUpdate = now });
      assetModels.Add(new AssetModel() { Name = "XMR", Value = data.XMR.USD, LastUpdate = now });
      return assetModels;
    }

  }
}