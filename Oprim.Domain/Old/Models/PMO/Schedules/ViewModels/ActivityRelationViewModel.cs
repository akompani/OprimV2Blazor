namespace Oprim.Domain.Old.Models.PMO.Schedules.ViewModels
{
    public enum RelationModes 
    {
        Predecessor,
        Successor
    }

    public class ActivityRelationViewModel
    {
        public ActivityRelationViewModel()
        {
            
        }

        public ActivityRelationViewModel(string relation,int identityNumber,RelationModes mode =RelationModes.Predecessor)
        {
            int linkIdentityNumber;

            relation = relation.ToUpper();
            RelationText = relation;

            if (relation.Contains("F") | relation.Contains("S"))
            {
                if (relation.Contains("FS"))
                {
                    RelationMode = ActivityRelationModes.FinishToStart;
                }
                else if (relation.Contains("FF"))
                {
                    RelationMode = ActivityRelationModes.FinishToFinish;

                }
                else if (relation.Contains("SF"))
                {
                    RelationMode = ActivityRelationModes.StartToFinish;
                }
                else if (relation.Contains("SS"))
                {
                    RelationMode = ActivityRelationModes.StartToStart;
                }
                else
                {
                    throw new Exception("RelationIsNotCorrect");
                }

                string idLinkActivity = relation.Replace("F", "").Replace("S", "");

                if (idLinkActivity.Contains("-") | idLinkActivity.Contains("+"))
                {
                    int lagTime = 1;
                    var predecessorLag = "";

                    string[] predecessorElements = new string[]{idLinkActivity};

                    if (relation.Contains("-"))
                    {
                        predecessorElements = idLinkActivity.Split('-').ToArray();

                        predecessorLag = predecessorElements[1];
                        lagTime = -1;
                    }

                    if (relation.Contains("+"))
                    {
                        predecessorElements = idLinkActivity.Split('+').ToArray();

                        predecessorLag = predecessorElements[1];
                    }

                    if (!string.IsNullOrEmpty(predecessorLag))
                    {
                        predecessorLag = predecessorLag.Replace(" ", "");
                        predecessorLag = predecessorLag.Replace("DAYS", "");
                        predecessorLag = predecessorLag.Replace("DAY", "");
                        predecessorLag = predecessorLag.Replace("D", "");

                        lagTime *= int.Parse(predecessorLag);
                    }
                    else
                    {
                        lagTime = 0;
                    }

                    Lag = lagTime;

                    idLinkActivity = predecessorElements[0];
                }

                linkIdentityNumber = int.Parse(idLinkActivity);
            }
            else
            {
                linkIdentityNumber = int.Parse(relation);
                RelationMode = ActivityRelationModes.FinishToStart;
            }

            if (mode == RelationModes.Predecessor)
            {
                SuccessorIdentityNumber = identityNumber;
                PredecessorIdentityNumber = linkIdentityNumber;
            }
            else
            {
                SuccessorIdentityNumber = linkIdentityNumber;
                PredecessorIdentityNumber = identityNumber;
            }
        }

        public int PredecessorIdentityNumber { get; set; }
        public int SuccessorIdentityNumber { get; set; }

        public ActivityRelationModes RelationMode { get; set; }

        public int Lag { get; set; }

        public string RelationText { get; set; }

        public override string ToString()
        {
            return $"{PredecessorIdentityNumber} ==> {Enum.GetName(RelationMode)} {Lag} == > {SuccessorIdentityNumber}";
        }
    }
}
