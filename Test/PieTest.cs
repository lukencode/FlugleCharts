using System;
using GChart;
using GCharts.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class PieTest
    {
        [TestMethod]
        public void TestPie1()
        {
            var s1 = new Series()
            {
                Legend = "data"
            };

            s1.Add("Field1", 80);
            s1.Add("Field2", 40);
            s1.Add("Field3", 110);
            s1.Add("Field4", 30);

            var pie = ChartBuilder.Pie()
                                  .Title("bar yo")
                                  .Size(400, 200)
                                  .ShowLegend("r")
                                  .AddSeries(s1)
                                  .AddAxes(GChart.Charts.AxesPosition.left, 0, 170, 30, "left data")
                                  .AddAxes(GChart.Charts.AxesPosition.bottom, 1, 4, 1, "number");

            Debug.WriteLine(pie.GetUrl());

        }
    }
}
