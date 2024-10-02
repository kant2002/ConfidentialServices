using AutoMapper;

namespace RazorSample
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            this.CreateMap<OrganizationInfo, PublicOrganizationInfo>();
            this.CreateMap<OrganizationProperty, PublicOrganizationProperty>();
        }
    }
}
