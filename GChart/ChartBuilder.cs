
namespace FlugleCharts
{
    public static class ChartBuilder
    {
        public static Pie Pie()
        {
            return new Pie("p");
        }

        public static Pie Pie(PieType type)
        {
            string typeCode = type.GetCode();
            return new Pie(typeCode);
        }

        public static Line Line()
        {
            return new Line("lc");
        }

        public static Line Line(LineType type)
        {
            string typeCode = type.GetCode();
            return new Line(typeCode);
        }

        public static Bar Bar()
        {
            return new Bar("v", "g");
        }

        public static Bar Bar(BarType type)
        {
            string typeCode = type.GetCode();

            return new Bar(typeCode, "g");
        }

        public static Bar Bar(BarType type, BarGroupType grouping)
        {
            string typeCode = type.GetCode();
            string group = grouping.GetCode();

            return new Bar(typeCode, group);
        }
    }
}
