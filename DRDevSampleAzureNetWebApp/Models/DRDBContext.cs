using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DRDevSampleAzureNetWebApp.Models {
  public class DRDBContext : DbContext {
    public DRDBContext()
      : base("AzureSqlConnection") {
    }
    public DbSet<PlanetDetails> Planets { get; set; }
  }
}