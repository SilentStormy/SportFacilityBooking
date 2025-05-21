using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISportFacilityView _sportFacilityView;

        public IndexModel(ILogger<IndexModel> logger,ISportFacilityView sportFacilityView)
        {
            _logger = logger;
          _sportFacilityView = sportFacilityView;
        }
        [BindProperty]

        public List<SportFacility> SportFacilities { get; set; }

        public void OnGet()
        {
            SportFacilities=_sportFacilityView.GetAllFacilities();
        }
    }
}
