using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using UseCases.PackagesUseCases;
using UseCases.UseCaseInterfaces;

namespace SpraunaApi2.Controllers
{
    
    public class TrackForApi
    {
        public int IdSbs { get; set; }
        public StatusesPackage Status { get; set; }
    }

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TrackController : ControllerBase
    {
        private readonly ILogger<TrackController> _logger;
        private readonly IViewPackagesUseCase viewPackagesUseCase;
        private readonly IGetPackageByIdUseCase getPackageByIdUseCase;
        private readonly IEditPackageUseCase editPackageUseCase;

        public TrackController(
            ILogger<TrackController> logger, 
            IViewPackagesUseCase viewPackagesUseCase,
            IGetPackageByIdUseCase getPackageByIdUseCase,
            IEditPackageUseCase editPackageUseCase)
        {
            _logger = logger;
            this.viewPackagesUseCase = viewPackagesUseCase;
            this.getPackageByIdUseCase = getPackageByIdUseCase;
            this.editPackageUseCase = editPackageUseCase;
        }

        // GET: track
        [Authorize]
        [HttpGet]
        public IEnumerable<TrackForApi> GetTracks()
        {
             var packages = viewPackagesUseCase.Execute();

            List<TrackForApi> tracks = new ();

            foreach (var package in packages)
            {
                tracks.Add(new TrackForApi()
                {
                    IdSbs = package.PackageId,
                    Status = package.Status
                });
            }

            return tracks;
        }

        // GET: track/5
        [Authorize]
        [HttpGet("{id}")]
        public TrackForApi GetTrack(int id)
        {
            var package = getPackageByIdUseCase.Execute(id);

            TrackForApi trackForApi = new TrackForApi()
            {
                IdSbs = package.PackageId,
                Status = package.Status
            };

            return trackForApi;
        }

        // PUT: track/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public TrackForApi UpdateTrack(int id, int status)
        {
            Console.WriteLine(id);
            //if (id != trackForApi.IdSbs)
            //{
            //    throw new ArgumentException("id ArgumentException");
            //}

             Package package = getPackageByIdUseCase.Execute(id);
            // if (package == null) return BadRequest();

            // package.PackageId = trackForApi.IdSbs;
            package.Status = (StatusesPackage)Enum.Parse(typeof(StatusesPackage), status.ToString()); 

            editPackageUseCase.Execute(package);
            // await _context.SaveChangesAsync();

            package = getPackageByIdUseCase.Execute(id);
          //  TrackForApi trackForApi = new TrackForApi();
            TrackForApi newTrack = new TrackForApi() { 
                IdSbs= package.PackageId,
                Status = package.Status
            };
           
           // return trackForApi;
            return newTrack;
        }
    }
}