using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.Runtime.Serialization;

namespace WCF.Service.Library.Models
{
    [DataContract]
    public class AddArticleViewModel
    {
        [NotNullValidator]
        [StringLengthValidator(5, RangeBoundaryType.Inclusive, 30,
                                  RangeBoundaryType.Inclusive,
                                  MessageTemplate = "AddedBy field must have from 5 to 30 characters.",
                                  Ruleset = "Group1")] 
        [DataMember]
        public string AddedBy { get; set; }

        [NotNullValidator]
        [StringLengthValidator(5, RangeBoundaryType.Inclusive, 300,
                                  RangeBoundaryType.Inclusive,
                                  MessageTemplate = "Abstract field must have from 5 to 300 characters.",
                                  Ruleset = "Group1")]
        [DataMember]
        public string Abstract { get; set; }

        [NotNullValidator]
        [StringLengthValidator(5, RangeBoundaryType.Inclusive, 600,
                                  RangeBoundaryType.Inclusive,
                                  MessageTemplate = "Body field must have from 5 to 600 characters.",
                                  Ruleset = "Group1")]
        [DataMember]
        public string Body { get; set; }

        [RangeValidator(1, RangeBoundaryType.Inclusive, 5, RangeBoundaryType.Inclusive, Ruleset = "Group1", MessageTemplate = "Rating should be between 1 & 5")]
        [DataMember]
        public int Rating { get; set; }
    }
}
