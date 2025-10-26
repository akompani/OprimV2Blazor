namespace Oprim.Domain.Enums.WorkFlow;

public enum WorkFlowRepeatTypes : byte
{
    None = 0,
    Daily = 1,
    SelectedDays = 2,
    Weekly = 3,
    Monthly = 4,
    Yearly = 5
}