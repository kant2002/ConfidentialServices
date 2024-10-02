using ConfidentialServices;

namespace RazorSample
{
    public static class Database
    {
        public static IEnumerable<OrganizationInfo> GetOrganizations()
        {
            yield return new(1, "Microsoft");
            yield return new(2, "Google");
            yield return new(3, "Amazon");
            yield return new(4, "Netflix");
        }

        public static IEnumerable<OrganizationProperty> GetProperties(int organizationId)
        {
            if (organizationId == 1)
            {
                yield return new(11, "Windows");
                yield return new(12, "Azure");
                yield return new(13, "MS 365");
                yield return new(14, "MS Teams");
            }
            if (organizationId == 2)
            {
                yield return new(21, "Google Search");
                yield return new(22, "AdSense");
                yield return new(23, "Google Workplace");
            }
            if (organizationId == 3)
            {
                yield return new(31, "Amazon");
                yield return new(32, "AWS");
            }
            if (organizationId == 4)
            {
                yield return new(41, "Movie Studio");
                yield return new(42, "Streaming service");
            }
        }

        public static OrganizationProperty? GetPropertyById(int organizationId, int propertyId)
        {
            return GetProperties(organizationId).FirstOrDefault(_ => _.Id == propertyId);
        }
    }

    public record OrganizationInfo(int Id, string Name);
    public record OrganizationProperty(int Id, string Name);

    public record PublicOrganizationInfo(ConfidentialId Id, string Name);
    public record PublicOrganizationProperty(ConfidentialId Id, string Name);
}
