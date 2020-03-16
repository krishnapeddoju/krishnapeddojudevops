﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class ApplicationModuleEntityDTO
    {
        public string ModuleId { get;  set; }
        public string ApplicationEntityId { get;  set; }
        public int Order { get;  set; }
        public string RecordStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}