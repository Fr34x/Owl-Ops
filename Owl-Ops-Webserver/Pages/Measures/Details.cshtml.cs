using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Owl_Ops_Webserver.Model;

namespace Owl_Ops_Webserver.Pages.Measures
{
    public class DetailsModel : PageModel
    {
        private readonly Owl_Ops_Webserver.Model.OwlDatabaseContext _context;

        public DetailsModel(Owl_Ops_Webserver.Model.OwlDatabaseContext context)
        {
            _context = context;
        }

        public Measurement Measurement { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.ID == id);

                //.Include(m => m.Sensor).FirstOrDefaultAsync(m => m.ID == id);

            if (Measurement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
