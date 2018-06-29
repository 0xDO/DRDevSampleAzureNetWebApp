using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.Models {
  /// <summary>
  /// Represents a very generic asset data container class
  /// </summary>
  public class AssetModel {
    public int Id { get; set; }
    public string LastUpdate { get; set; }
    public string Name { get; set; }
    public double Value { get; set; }
  }
}