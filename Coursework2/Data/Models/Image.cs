using System.ComponentModel.DataAnnotations;

namespace MANwork.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] image { get; set; }
    }
}
