using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.Models {
  public class PlanetDetails {
    public int Id { get; set; }
    public string Name { get; set; }
    public string AstronomicalSymbol { get; set; }
    public decimal DistanceToSun { get; set; }
    public decimal EquatorialRadius { get; set; }
    public decimal EquatorialGravity { get; set; }
    public string Comment { get; set; }
  }
}