using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DRDevSampleAzureNetWebApp.Models;

namespace WebApplicationNetTO.Controllers
{
  /// <summary>
  /// WebAPI Planet Controller
  /// </summary>
  /// <seealso cref="System.Web.Http.ApiController" />
  public class PlanetsApiController : ApiController
  {
    private readonly IPlanetRepository repository;

    public PlanetsApiController(IPlanetRepository repository){
      this.repository = repository;
    }

    /// <summary>
    /// Gets all planets of our solar system.
    /// </summary>
    /// <returns>An enumerable object of planets</returns>
    [Route("api/planets")]
    [HttpGet]
    public IEnumerable<PlanetDetails> Get(){
      return repository.Planets.ToList();
    }

    /// <summary>
    /// Gets the planet from a specified name.
    /// </summary>
    /// <param name="name">The planet name.</param>
    /// <returns>Planet details</returns>
    [Route("api/planets/{name}")]
    [HttpGet]
    public PlanetDetails Get(string name) {
      if (name.Length > 10)
        return null;
      if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
        return null;
      return repository.Planets.Where(item=>item.Name.Equals(name)).FirstOrDefault();
    }
  }
}
