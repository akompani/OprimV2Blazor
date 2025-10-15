namespace Oprim.Domain.Old.Models
{
    public class SummarizeTemplate
    {
        public SummarizeTemplate()
        {
            
        }

        public SummarizeTemplate(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public SummarizeTemplate(object id, string name)
        {
            Id = id.ToString();
            Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }

    public interface ISummarize
    {
        public SummarizeTemplate GetSummarize();
    }
}
