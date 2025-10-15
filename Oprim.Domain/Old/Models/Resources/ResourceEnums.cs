namespace Oprim.Domain.Old.Models.Resources
{
    public enum OprimResourceTypes : byte
    {
        All = 0,
        Human = 1,
        Machinery = 2
    }

    public enum ResourceCategories : byte
    {
        //Human
        Engineering = 11,
        MasterWorker = 12,
        TechnicianWorker = 13,
        Worker = 14,
        //Machinery
        Tools = 21,
        LightMachine = 22,
        HeavyMachine = 23,
        TransportMachine = 24,
        ConstructionEquipment = 25,
        SurveyingEquipment = 26,
        SafetyEquipment = 27,
        SpecialEquipment = 28
    }

    public enum HumanCategories
    {
        //Human
        Engineering = 11,
        MasterWorker = 12,
        TechnicianWorker = 13,
        Worker = 14,
    }

    public enum MachineCategories
    {
        //Machinery
        Tools = 21,
        LightMachine = 22,
        HeavyMachine = 23,
        TransportMachine = 24,
        ConstructionEquipment = 25,
        SurveyingEquipment = 26,
        SafetyEquipment = 27,
        SpecialEquipment = 28
    }

    public enum AllocationModes : byte
    {
        Linear = 0,
        OnStart = 1,
        OnFinish = 2
    }

    public enum ResourceEffects : byte
    {
        Direct = 0,
        InDirect = 1
    }

    public enum ResourceOwnerships : byte
    {
        Owner = 0,
        Rent = 1,
        Dept = 2
    }

    public enum ResourceShareTypes : byte
    {
        ProjectBase = 0,
        ProgramBase = 1,
        PortfolioBase = 2,
        Overall = 3

    }

    public enum DealModes : byte
    {
        Buy = 1,
        Importation = 2,
        Utilize = 3,
        Return = 4,
        Exportation = 5,
        Sale = 6
    }

    public enum SpecificationTypes:byte
    {
        String = 0,
        Long=1,
        Double=2
    }
}
