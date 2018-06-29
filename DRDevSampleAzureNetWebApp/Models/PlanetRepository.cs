using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DRDevSampleAzureNetWebApp.Models {
  public class PlanetRepository : IPlanetRepository {

    private DRDBContext dbContext;

    public PlanetRepository(DRDBContext context) {
      this.dbContext = context;
    }

    public IQueryable<PlanetDetails> Planets => this.dbContext.Planets;

    public PlanetDetails GetPlanet(int? id) {
      var planetDetails = new PlanetDetails();
      planetDetails = this.dbContext.Planets.Where(p => p.Id == id).FirstOrDefault();
      return planetDetails;
    }

    public void InsertOrUpdate(PlanetDetails planetDetails) {
      if (planetDetails.Id == default(int)) {
        // New entity
        this.dbContext.Planets.Add(planetDetails);
      } else {
        // Existing entity
        this.dbContext.Entry(planetDetails).State = System.Data.Entity.EntityState.Modified;
      }
    }

    public void Save() {
      dbContext.SaveChanges();
    }

    public void Delete(int id) {
      var planetDetails = this.dbContext.Planets.Find(id);
      dbContext.Planets.Remove(planetDetails);
    }

    public void Dispose() {
      dbContext.Dispose();
    }
  }
}