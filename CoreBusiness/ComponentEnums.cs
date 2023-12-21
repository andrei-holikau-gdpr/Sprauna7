using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class ComponentEnums
    {
        public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
        public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
        public enum Engine { Ion, Plasma, Fusion, Warp }

        public enum CombineParcels { SendWithUnit, SendWithoutUnit }
        }
}
