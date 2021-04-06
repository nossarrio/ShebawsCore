using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceModel;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using ShebawsCoreLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Autofac;

namespace ShebawsCore.Pages
{
    public class IndexModel : PageModel
    {
        readonly ILogger<IndexModel> _logger;
        readonly IConfiguration _configuration;
        readonly IShebawsService _shebawsService;

        //todo: this should be a replica model defined in the ShebawsCore Project
        public ShebawsCoreLibrary.ObservationModel Observation;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            //todo: the IShebawsService interface should come through as parameter in the this constructor
            _shebawsService = ContainerConfig.Configure().Resolve<IShebawsService>();
        }

        public void OnGet()
        {
            try
            {
                Observation = _shebawsService.getObservation(_configuration);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching observation");
            }
        }
    }
}
