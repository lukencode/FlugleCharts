using System.Collections.Generic;

namespace FlugleCharts
{
    public class Axes
    {
        public string Position { get; set; }
        public int Index { get; set; }
        public int? Max { get; set; }
        public int? Min { get; set; }
        public int? Step { get; set; }

        public List<string> Labels { get; set; }

        public bool StepSet
        {
            get
            {
                return Max.HasValue && Min.HasValue && Step.HasValue;
            }
        }

        public Axes()
        {
            Labels = new List<string>();
        }
    }
}
