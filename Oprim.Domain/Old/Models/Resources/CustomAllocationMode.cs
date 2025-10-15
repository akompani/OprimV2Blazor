using System.ComponentModel.DataAnnotations;

namespace Oprim.Domain.Old.Models.Resources
{
    public class CustomAllocationMode : ICacheModel
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public bool LinearBetweenArticles { get; set; }

        public List<CustomAllocationModeArticle> Articles { get; set; }

        public double CalculateProgressValue(decimal progress)
        {
            if (Articles.Count == 0) return 0;

            double result = 0;

            if (Articles.Count == 1) LinearBetweenArticles = false;

            Articles.Add(new CustomAllocationModeArticle(0, 0));

            Articles = Articles.OrderBy(a => a.Progress).ToList();

            for (int i = 1; i < Articles.Count; i++)
            {
                if (progress > Articles[i - 1].Progress)
                {
                    if (progress < Articles[i].Progress)
                    {
                        if (LinearBetweenArticles)
                        {
                            result += (Articles[i].Value - Articles[i - 1].Value) *
                                      (double)((progress - Articles[i - 1].Progress) /
                                               (Articles[i].Progress - Articles[i - 1].Progress));
                        }
                    }
                    else
                    {
                        result += Articles[i - 1].Value;
                    }
                }
            }

            return result;
        }

        public string[] DefaultCacheNames()
        {
            return new[] { nameof(CustomAllocationMode) };
        }
    }
}
