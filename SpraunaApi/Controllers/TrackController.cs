using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET: tracks
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

        // GET: tracks/5
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

        // PUT: tracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize]
        [HttpPut("{id}")]
        public TrackForApi UpdateTrack(int id, TrackForApi trackForApi)
        {
            throw new ArgumentException("id ArgumentException");

            if (id != trackForApi.IdSbs)
            {
                throw new ArgumentException("id ArgumentException");
            }

            Package package = getPackageByIdUseCase.Execute(trackForApi.IdSbs);
            // if (package == null) return BadRequest();

            package.PackageId = trackForApi.IdSbs;
            package.Status = trackForApi.Status;

            editPackageUseCase.Execute(package);
            // await _context.SaveChangesAsync();

            package = getPackageByIdUseCase.Execute(trackForApi.IdSbs);

            TrackForApi newTrack = new TrackForApi() { 
                IdSbs= package.PackageId,
                Status = package.Status
            };

            return newTrack;
        }
    }
}