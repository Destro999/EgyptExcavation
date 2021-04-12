using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavation.Models
{
    public class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string FileType { get; set; }
        public string BurialId { get; set; }
        [MaxLength]
        public byte[] DataFiles { get; set; }


        public string GetImageFromByteArray()
        {
            string imreBase64Data = Convert.ToBase64String(DataFiles);
            string imgDataUrl = string.Format($"data:image/{FileType.Replace(".", string.Empty)};base64,{{0}}", imreBase64Data);

            return imgDataUrl;
        }

    }
}
