using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Owl_Ops_Webserver.Model;

namespace Owl_Ops_Webserver.Pages.Measures
{
    public class IndexModel : PageModel
    {
        private readonly Owl_Ops_Webserver.Model.OwlDatabaseContext _context;
        private readonly HttpContext _httpContext;

        public IndexModel(Owl_Ops_Webserver.Model.OwlDatabaseContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext.HttpContext;
        }

        public IList<Measurement> Measurement { get;set; }

        public async Task OnGetAsync()
        {
            //User user = _httpContext.User.Identity;
            Measurement = await _context.Measurements
                .Include(m => m.Sensor).ToListAsync();
        }
    }
}
