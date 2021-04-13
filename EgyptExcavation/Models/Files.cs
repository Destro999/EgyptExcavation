using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavation.Models
{
    public partial class Files
    {
        //[Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string BurialId { get; set; }
        public byte[] DataFiles { get; set; }

        public string GetImageFromByteArray()
        {
            string imreBase64Data = Convert.ToBase64String(DataFiles);
            string imgDataUrl = string.Format($"data:image/{FileType.Replace(".", string.Empty)};base64,{{0}}", imreBase64Data);

            return imgDataUrl;
        }
    }
}
