using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlugleCharts
{
    public class Series : List<DataPoint>
    {
        public string Legend { get; set; } //chdl
        public string Color { get; set; } //chco

        private double? _topRange; //chds
        private double? _lowRange;

        public double TopRange
        {
            get
            {
                if (_topRange.HasValue)
                    return _topRange.Value;

                return this.Max(d => d.Value);
            }
        }

        public double LowRange
        {
            get
            {
                if (_lowRange.HasValue)
                    return _lowRange.Value;

                return this.Min(d => d.Value);
            }
        }

        public string RenderValues()
        {
            var sb = new StringBuilder();

            foreach (var v in this)
            {
                sb.Append(v.Value.ToString() + ",");
            }

            var val = sb.ToString();
            return val.Substring(0, val.Length - 1);
        }

        public void Add(double value)
        {
            var dp = new DataPoint(value);
            base.Add(dp);
        }

        public void Add(string label, double value)
        {
            var dp = new DataPoint(label, value);
            base.Add(dp);
        }
    }
}
