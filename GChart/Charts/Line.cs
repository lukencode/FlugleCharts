
namespace GChart.Charts
{
    public class Line : GChart<Line>
    {
        private string _chartType;

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
        LineChart,
        SparkLine
    }
}
