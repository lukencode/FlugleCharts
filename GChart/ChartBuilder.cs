using GChart.Charts;

namespace GChart
{
    public static class ChartBuilder
    {
        public static Pie Pie()
        {
            return new Pie("p");
        }

        public static Pie Pie(PieType type)
        {
            string typeCode = "p";

            switch (type)
            {
                case PieType.Concentric:
                    typeCode = "pc";
                    break;
                case PieType.ThreeDimensional:
                    typeCode = "p3";
                    break;
                case PieType.TwoDimensional:
                    typeCode = "p";
                    break;
            }

            return new Pie(typeCode);
        }

        public static Line Line()
        {
            return new Line("lc");
        }

        public static Line Line(LineType type)
        {
            string typeCode = "p";

            switch (type)
            {
                case LineType.LineChart:
                    typeCode = "lc";
                    break;
                case LineType.SparkLine:
                    typeCode = "ls";
                    break;
            }

            return new Line(typeCode);
        }

        public static Bar Bar()
        {
            return new Bar("v", "g");
        }

        public static Bar Bar(BarType type)
        {
            string typeCode = "v";

            switch (type)
            {
                case BarType.Horizontal:
                    typeCode = "h";
                    break;
                case BarType.Vertical:
                    typeCode = "v";
                    break;
            }

            return new Bar(typeCode, "g");
        }

        public static Bar Bar(BarType type, BarGroupType grouping)
        {
            string typeCode = "v";
            string group = "g";

            switch (type)
            {
                case BarType.Horizontal:
                    typeCode = "h";
                    break;
                case BarType.Vertical:
                    typeCode = "v";
                    break;
            }

            switch (grouping)
            {
                case BarGroupType.Grouped:
                    group = "g";
                    break;
                case BarGroupType.Overlapped:
                    group = "o";
                    break;
                case BarGroupType.Stacked:
                    group = "s";
                    break;
            }

            return new Bar(typeCode, group);
        }
    }
}
