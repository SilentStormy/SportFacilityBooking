using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages.SportFacility
{
    public class SearchResultsModel : PageModel
    {
        private readonly ISportFacilityView _sportFacilityView;

        public SearchResultsModel(ISportFacilityView sportFacilityView)
        {
            _sportFacilityView = sportFacilityView;
        }

        public List<SportFacility> Facilities { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string SearchedQuert { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchedQuert))
            {
                Facilities = _sportFacilityView.SearchFacility(new SportFacility(0, SearchedQuert, "", "", 0));
            }
        }
    }
}
