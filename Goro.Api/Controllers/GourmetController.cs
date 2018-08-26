using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Goro.Api.Infrastructure;
using Goro.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Goro.Api.Controllers
{
    /// <summary>
    /// Person API Controller
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GourmetController : ControllerBase
    {
        private readonly GourmetRepository _repository;
        private readonly IMapper _mapper;

        public GourmetController(GourmetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Gourmet>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var result = await GourmetClient.Search();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("{keyword}")]
        [ProducesResponseType(typeof(IEnumerable<Gourmet>), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(string keyword)
        {
//			var geocode = await GeocodeClient.GetGeocodeAsync(HttpUtility.UrlDecode(keyword));
//			var result = await GourmetClient.SearchAsync(new Location { lat = geocode.results[0].geometry.location.lat, lng = geocode.results[0].geometry.location.lng });

            return Ok(new List<Gourmet>());
        }

       /// <summary>
        /// 
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("{lat:float}/{lng:float}")]
        [ProducesResponseType(typeof(IEnumerable<Gourmet>), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(float lat, float lng)
        {
//			var result = await GourmetClient.SearchAsync(new Location { lat = lat, lng = lng });
           return Ok(new List<Gourmet>());
        }

    }
}