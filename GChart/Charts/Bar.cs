using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlugleCharts
{
    public class Bar : GChart<Bar>
    {
        private string _barGroup;

        private List<string> _customLabels;

        public Bar(string type, string barGroup)
        {
            _barGroup = barGroup;
            _chartType = type;

            _customLabels = new List<string>();
        }

        public Bar AddCustomLabel(List<string> labels)
        {
            _customLabels = labels;
            return this;
        }

        public Bar AddCustomLabel(string label)
        {
            _customLabels.Add(label);
            return this;
        }

        protected override string BuildLabels()
        {
            //render chart labels
            var sb = new StringBuilder();

            if (_customLabels.Count == 0)
            {
                var firstSeries = _data.FirstOrDefault(); //only take first series
                if (firstSeries != null)
                {
                    sb.Append("chl=");
                    foreach (var p in firstSeries)
                    {
                        sb.Append(p.Label + "|");
                    }
                }
            }
            else
            {
                sb.Append("chl=");
                foreach (var s in _customLabels)
                {
                    sb.Append(s + "|");
                }
            }

            var stringData = sb.ToString();
            return sb.ToString().Take(stringData.Length - 1);
        }

        protected override string RenderChartOptions()
        {
            return "";
        }

        protected override string GetChartType()
        {
            return "b" + _chartType + _barGroup;
        }
    }

    public enum BarGroupType
    {
        [FlugleCharts.EnumUtils.Code("g")]
        Grouped,

        [FlugleCharts.EnumUtils.Code("s")]
        Stacked,

        [FlugleCharts.EnumUtils.Code("o")]
        Overlapped
    }

    public enum BarType
    {
        [FlugleCharts.EnumUtils.Code("h")]
        Horizontal,

        [FlugleCharts.EnumUtils.Code("v")]
        Vertical
    }
}
