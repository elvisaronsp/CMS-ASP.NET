using CMS.Common.Constants;
using CMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class MenuLocation
    {
        public Guid Id { get; set; }


        [MaxLength(ValidationConstants.MaxMenuLocationName)]
        public string Position { get; set; }



    }
}
