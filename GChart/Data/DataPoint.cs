
namespace FlugleCharts
{
    public class DataPoint
    {
        public string Label { get; set; }
        public double Value { get; set; }

        public DataPoint(double value)
        {
            Value = value;
        }


        public DataPoint(string label, double value)
        {
            Label = label;
            Value = value;
        }
    }
}
