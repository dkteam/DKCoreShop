using DKCoreShop.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DKCoreShop.Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string AnnouncementId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public bool? HasRead { get; set; }
        
        [ForeignKey("AnnouncementId")]
        public virtual Announcement Announcement { get; set; }
    }
}
