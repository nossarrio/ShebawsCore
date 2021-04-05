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

namespace ShebawsCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        ShebawsService ShebawsService;
        public ObservationModel Observation;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            ShebawsService = new ShebawsService(_configuration.GetSection("AppSettings").GetSection("ServiceUrl").Value);
        }

        public void OnGet()
        {
            try
            {
                 Observation = JsonConvert.DeserializeObject<ObservationModel>(ShebawsService.getObservation());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching observation");
            }
        }
    }
}
