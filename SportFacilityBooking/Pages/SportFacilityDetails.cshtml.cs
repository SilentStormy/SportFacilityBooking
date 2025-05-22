using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportFacilityBooking.Pages
{
    public class SportFacilityDetailsModel : PageModel
    {
        private readonly ISportFacilityView _sportfacilityView;

        public SportFacilityDetailsModel(ISportFacilityView sportfacilityView)
        {
            _sportfacilityView = sportfacilityView;
        }

        [BindProperty]
        public SportFacility SportFacilityview { get; set; }    

        public void OnGet(int id)
        {
            SportFacilityview=_sportfacilityView.GetFacilityDetails(new SportFacility { SportFacilityId=id});
            
        }
    }
}
