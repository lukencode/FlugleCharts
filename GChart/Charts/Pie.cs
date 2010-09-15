using System.Text;

namespace GChart.Charts
{
    public class Pie : GChart<Pie>
    {
        private string _chartType;
        private bool _showLabels;

        internal Pie(string chartType)
        {
            _chartType = chartType;
            _showLabels = true;
        }

        protected override string RenderChartOptions()
        {
            return "";
        }

        protected override string BuildLegend()
        {
            var sb = new StringBuilder();

            sb.Append("chdlp=" + _legendPosition + "&"); //position

            sb.Append("chdl=");
            foreach (var ds in _data)
            {
                foreach (var p in ds)
                {
                    sb.Append(p.Label + "|");
                }
            }

            var stringData = sb.ToString();
            return sb.ToString().Take(stringData.Length - 1);
        }

        public Pie UseLabels(bool showLabel)
        {
            _showLabels = showLabel;
            return this;
        }

        protected override string BuildLabels()
        {
            if (_showLabels)
                return base.BuildLabels();

            return "";
        }

        protected override string GetChartType()
        {
            //todo allow other types
            return _chartType;
        }
    }

    public enum PieType
    {
        TwoDimensional,
        ThreeDimensional,
        Concentric
    }
}
