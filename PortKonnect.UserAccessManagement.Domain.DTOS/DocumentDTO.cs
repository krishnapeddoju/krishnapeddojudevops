using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortKonnect.UserAccessManagement.Domain.DTOS
{
    public class DocumentDTO
    {
        public string DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string OrginalFileName { get; set; }

        public DocumentDTO(string documentType,string documentName,string documentPath,string fileName,string fileType,string orginalFileName)
        {
            this.DocumentType = documentType;
            this.DocumentName = documentName;
            this.DocumentPath = documentPath;
            this.FileName = fileName;
            this.FileType = FileType;
            this.OrginalFileName = orginalFileName;

        }

    }
}
