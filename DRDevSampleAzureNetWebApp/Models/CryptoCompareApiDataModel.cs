using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.Models {
  public class BTC {
    public double USD { get; set; }
    public double EUR { get; set; }
  }

  public class ETH {
    public double USD { get; set; }
    public double EUR { get; set; }
  }

  public class XMR {
    public double USD { get; set; }
    public double EUR { get; set; }
  }

  public class CryptoCompareDataModel {
    public BTC BTC { get; set; }
    public ETH ETH { get; set; }
    public XMR XMR { get; set; }
  }
}