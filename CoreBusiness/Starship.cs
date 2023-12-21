using System;
using System.ComponentModel.DataAnnotations;
using static CoreBusiness.ComponentEnums;

namespace CoreBusiness
{
    public class TestStarship
    {
        [Required]
        [Range(typeof(bool), "true", "true",
            ErrorMessage = "This form disallows unapproved ships.")]
        public bool IsValidatedDesign { get; set; }

        [Required]
        [Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX),
        nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
        public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

        [Required, EnumDataType(typeof(Color))]
        public Color? Color { get; set; } = null;


        [Required, EnumDataType(typeof(CombineParcels))]
        public CombineParcels CombineParcels { get; set; } = CombineParcels.SendWithoutUnit;
        // Я хочу отправить посылку сразу без объединения с другими посылками

    }
}
