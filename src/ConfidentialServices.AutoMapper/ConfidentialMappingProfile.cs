namespace ConfidentialServices;

using AutoMapper;
using Microsoft.AspNetCore.Http;

internal class ConfidentialMappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfidentialMappingProfile"/> class.
    /// </summary>
    /// <param name="httpContextAccessor">Http context accossor for use.</param>
    public ConfidentialMappingProfile(IHttpContextAccessor httpContextAccessor)
    {
        this.CreateMap<ConfidentialId, string>()
            .ConvertUsing(new ConfidentialIdTypeConverter(httpContextAccessor));
    }
}