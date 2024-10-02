using AutoMapper;
using ConfidentialServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IMapper mapper;

        public DetailsModel(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets or sets id of the inventory which should be edited.
        /// </summary>
        [BindProperty(Name = "propertyId", SupportsGet = true)]
        public ConfidentialId? PropertyId { get; set; }

        /// <summary>
        /// Gets or sets id of the selected organization.
        /// </summary>
        [BindProperty(Name = "organizationId", SupportsGet = true)]
        public ConfidentialId? OrganizationId { get; set; }

        public PublicOrganizationProperty Property { get; set; }

        public void OnGet()
        {
            if (PropertyId == null || OrganizationId == null)
            {
                return;
            }

            var propertyId = (int)PropertyId;
            var organizationId = (int)OrganizationId;
            var property = Database.GetPropertyById(organizationId, propertyId);
            Property = this.mapper.Map<PublicOrganizationProperty>(property);
        }
    }
}
