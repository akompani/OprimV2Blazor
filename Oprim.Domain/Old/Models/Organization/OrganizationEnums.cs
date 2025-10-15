namespace Oprim.Domain.Old.Models.Organization
{
    public enum ComponentTypes : byte
    {
        Organization = 0,
        Portfolio = 1,
        Program = 2,
        Project = 3,//==Contract
    }

    public enum PersonalityTypes : byte
    {
        Genuine=0,//حقیقی
        Legal=1//حقوقی
    }

    public enum StakeholderSituations : byte
    {
        Unaware=0,
        Resistant=1,
        Neutral=2,
        Supportive=3,
        Leading=4
    }

    public static class OrganizationGeneralFunctions
    {
        public const int SystemStakeholderId = -99;
        public const int OrganizationProjectId = -1;
    }
}
