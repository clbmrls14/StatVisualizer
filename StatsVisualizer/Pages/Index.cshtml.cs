using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StatsVisualizer.Models;

namespace StatsVisualizer.Pages
{
    public class IndexModel : PageModel
    {
        //Replace the serverURL String with the URL of the person running the server. If you are then enter http://localhost.
        //http://144.17.24.145 is the URL for Jonathans machine
        private const string serverURL = "http://144.17.48.92/stats";
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Stats Stats { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            var request = WebRequest.CreateHttp(serverURL);
            var response = (HttpWebResponse)request.GetResponse();
            if(response.StatusCode == HttpStatusCode.OK)
            {
                //System.IO.Stream stream = response.GetResponseStream();
                //var reader = new StreamReader(stream);
                //var json = reader.ReadToEnd();
                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;
                //var x = JsonSerializer.Deserialize<Stats>(json, options);
                Stats = await JsonSerializer.DeserializeAsync<Stats>(response.GetResponseStream(), options);
                //response.GetResponseStream();
            }        
        }
    }
}
