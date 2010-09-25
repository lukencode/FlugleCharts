
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
            return "";
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
