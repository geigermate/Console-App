using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class CarModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]  
        public string Name { get; set; }

        public int? Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual CarBrand CarBrand { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Owner> Owners { get; set; }

        [ForeignKey(nameof(CarBrand))]
        public int CarBrandId { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }

        public CarModel()
        {
                this.Owners = new HashSet<Owner>();
        }
    }
}
