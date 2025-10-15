using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oprim.Domain.Old.Models.Contracting.ListPrices;
using Oprim.Domain.Old.Models.Resources;

namespace Oprim.Domain.Old.Models.PMO.Schedules
{
    public class ScheduleActivityEarn: ICacheModel
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("ScheduleActivityId")] public ScheduleActivity? ScheduleActivity { get; set; }
        public long ScheduleActivityId { get; set; }

        [ForeignKey("ContractItemId")] public ContractItem? ContractItem { get; set; }
        public int ContractItemId { get; set; }

        public AllocationModes AllocationMode { get; set; }

        [ForeignKey("CustomAllocationModeId")] public CustomAllocationMode? CustomAllocationMode { get; set; }
        public int CustomAllocationModeId { get; set; }

        public double Quantity { get; set; }

        public long Allocate(decimal prevProgress, decimal thisDayProgress)
        {
            double quantity = 0;


            decimal cumProgress = prevProgress + thisDayProgress;

            if (CustomAllocationModeId == 0)
            {
                switch (AllocationMode)
                {
                    case AllocationModes.OnStart:
                        if (prevProgress == 0 & cumProgress > 0) quantity = Quantity;
                        break;

                    case AllocationModes.OnFinish:
                        if (prevProgress < 100 & cumProgress == 100) quantity = Quantity;
                        break;

                    default:
                        quantity = (double)(cumProgress - prevProgress) * Quantity / 100;
                        break;
                }
            }
            else
            {
                var cumQuantity = CustomAllocationMode.CalculateProgressValue(cumProgress);
                var prevQuantity = CustomAllocationMode.CalculateProgressValue(prevProgress);

                quantity = (cumQuantity - prevQuantity) * Quantity / 100;
            }

            return (long)(quantity * (ContractItem?.Price ?? 0));
        }

        public string[] DefaultCacheNames()
        {
            return new []{ ICacheModel.CreateCacheName(nameof(ScheduleActivityEarn), ScheduleActivityId)};
        }
    }
}
