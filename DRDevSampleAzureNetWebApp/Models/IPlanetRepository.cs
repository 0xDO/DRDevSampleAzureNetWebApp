using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.Models {
  public interface IPlanetRepository : IDisposable {

    IQueryable<PlanetDetails> Planets { get; }
    PlanetDetails GetPlanet(int? id);
    void InsertOrUpdate(PlanetDetails planetDetails);
    void Delete(int id);
    void Save();
  }
}