using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerRepairShop.Domain
{
    public class EntityBase : ITrackableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public long Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime ModifiedOn { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string ModifiedBy { get; set; } = string.Empty;
    }
}