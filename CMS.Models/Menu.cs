using CMS.Common.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class Menu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [MaxLength(ValidationConstants.MaxMenuName)]
        public string MenuName { get; set; }


        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Guid MenuPositionId { get; set; }

        public virtual MenuLocation MenuLocation { get; set; }
    }
}
