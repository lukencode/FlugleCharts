
using System.Text;
namespace FlugleCharts
{
    public class Line : GChart<Line>
    {
        internal Line(string chartType)
        {
            _chartType = chartType;
        }

        protected override string RenderChartOptions()
        {
            //Check the series for LineStyles
            var sb = new StringBuilder();
            sb.Append("&chls=");

            bool hasStyles = false;
            foreach (var ds in _data)
            {
                if (!ds.LineThickness.HasValue) continue;

                hasStyles = true;
                sb.Append(ds.LineThickness.Value);

                if (ds.DashLength.HasValue)
                {
                    sb.Append("," + ds.DashLength.Value);
                }

                if (ds.SpaceLength.HasValue)
                {
                    sb.Append("," + ds.SpaceLength.Value);
                }

                sb.Append("|");
            }

            if (hasStyles)
            {
                var stringData = sb.ToString();
                return sb.ToString().Take(stringData.Length - 1);
            }
            else
            {
                return string.Empty;
            }
        }

        protected override string GetChartType()
        {
            return _chartType;
        }
    }

    public enum LineType
    {
        [FlugleCharts.EnumUtils.Code("lc")]
        LineChart,

        [FlugleCharts.EnumUtils.Code("ls")]
        SparkLine,

        [FlugleCharts.EnumUtils.Code("lxy")]
        LineXY
    }
}
