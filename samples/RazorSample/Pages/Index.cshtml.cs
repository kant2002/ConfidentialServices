using AutoMapper;
using ConfidentialServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMapper mapper;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IMapper mapper, ILogger<IndexModel> logger)
        {
            this.mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets or sets id of the selected organization.
        /// </summary>
        [BindProperty(Name = "organizationId", SupportsGet = true)]
        public ConfidentialId? SelectedOrganizationId { get; set; }

        public PublicOrganizationInfo[] Organizations { get; set; }

        public PublicOrganizationProperty[] Properties { get; set; }

        public void OnGet()
        {
            Organizations = this.mapper.Map<PublicOrganizationInfo[]>(Database.GetOrganizations());
            var selectedOrganization = (int?)this.SelectedOrganizationId;
            if (selectedOrganization == null)
            {
                Properties = Array.Empty<PublicOrganizationProperty>();
            }
            else
            {
                Properties = this.mapper.Map<PublicOrganizationProperty[]>(Database.GetProperties(selectedOrganization.Value));
            }
        }
    }
}
