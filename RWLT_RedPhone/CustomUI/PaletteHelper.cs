using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWLT_RedPhone.CustomUI
{
    public static class PaletteHelper
    {
        #region Properties

        static int idx = 0;

        static List<Color> palette = new List<Color>()
        {
            Color.DarkRed,
            Color.DarkOrange, 
            Color.Green,
            Color.Purple,

            Color.Blue,

            Color.Red,
            Color.Black,
            Color.Orange,                        
            Color.Salmon,
            Color.Gold,
            Color.MediumSpringGreen,
            Color.SkyBlue,
        };

        #endregion

        #region Methods

        public static Color GetColor()
        {
            Color result = palette[idx];
            idx = (idx + 1) % palette.Count;
            return result;
        }

        #endregion

    }
}
