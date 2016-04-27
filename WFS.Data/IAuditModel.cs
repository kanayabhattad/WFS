using System.ComponentModel.DataAnnotations;

namespace WFS.Data
{
    public interface IAuditModel
    {
        [Required]
        [MaxLength(128)]
        string CreatedBy { get; set; }
        [Required]
        long CreatedOn { get; set; }
        long? UpdatedOn { get; set; }
        bool? IsDeleted { get; set; }
        string UpdatedBy { get; set; }
    }
}
