using System.Collections.Generic;

namespace FlugleCharts
{
    public class Axes
    {
        public string Position { get; set; }
        public int Index { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Step { get; set; }
        public string Title { get; set; }

        public List<string> Labels { get; set; }

        public Axes()
        {
            Labels = new List<string>();
        }
    }

    public enum AxesPosition
    {
        [FlugleCharts.EnumUtils.Code("y")]
        left,

        [FlugleCharts.EnumUtils.Code("r")]
        right,

        [FlugleCharts.EnumUtils.Code("t")]
        top,

        [FlugleCharts.EnumUtils.Code("x")]
        bottom
    }
}
