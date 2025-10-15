namespace Oprim.Domain.Old.Models.Payroll
{
    public enum PayrollCalculationMode : byte
    {
        None = 0,
        ByHours = 1,
        ByDays = 2,
        Fix = 4
    }
  public enum PayrollCloseCalculationMode : byte
    {
        Month = 0,
        Week = 1,
        Days = 2
    }

    public enum PayrollPaymentTypes : byte
    {
        Normal=0,
        OnAccount=1,
        Loan=2,
        Reward=3
    }

   
}
