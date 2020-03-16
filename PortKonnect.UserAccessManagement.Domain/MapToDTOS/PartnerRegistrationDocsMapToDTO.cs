using System.Collections.Generic;
using System.Linq;
using PortKonnect.UserAccessManagement.Domain.DTOS;


namespace PortKonnect.UserAccessManagement.Domain.MapToDTOS
{
    public static class PartnerRegistrationDocsMapToDTO
    {
        public static List<PartnerRegistrationDocsDTO> MapToListDto(this IEnumerable<PartnerRegistrationDocs> documents)
        {
            List<PartnerRegistrationDocsDTO> documentDtos = new List<PartnerRegistrationDocsDTO>();

            if (documents == null) return documentDtos;

            documentDtos.AddRange(documents.Select(c => c.MapToDTO()));

            return documentDtos;
        }


        public static PartnerRegistrationDocsDTO MapToDTO(this PartnerRegistrationDocs partnerRegistrationDocument)
        {
            if (partnerRegistrationDocument == null) return null;

            PartnerRegistrationDocsDTO documentDto = new PartnerRegistrationDocsDTO
            {
                PDocumentId = partnerRegistrationDocument.PDocumentId,

                PartnerRegistrationId = partnerRegistrationDocument.PartnerRegistrationId,

                DocumentType = partnerRegistrationDocument.PDocumentType,

                FileName = partnerRegistrationDocument.PFileName,

                OriginalName = partnerRegistrationDocument.POriginalName,

                ValidTill = partnerRegistrationDocument.PValidDate,

                IsDeleted = partnerRegistrationDocument.IsDeleted
            };

            return documentDto;
        }
    }
}
