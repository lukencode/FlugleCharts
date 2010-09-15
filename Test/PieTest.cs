using System;
using GChart;
using GCharts.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PieTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s1 = new Series()
            {
                Legend = "data"
            };

            s1.Add(80);
            s1.Add(40);
            s1.Add(110);
            s1.Add(30);

            var s2 = new Series()
            {
                Legend = "data 2"
            };

            s2.Add(170);
            s2.Add(150);
            s2.Add("oh snap", 80);
            s2.Add(30);

            var pie = ChartBuilder.Line()
                                  .Title("bar yo")
                                  .Size(400, 200)
                                  .ShowLegend("r")
                                  .AddSeries(s1)
                                  .AddSeries(s2)
                                  .AddAxes(GChart.Charts.AxesPosition.left, 0, 170, 30, "left data")
                                  .AddAxes(GChart.Charts.AxesPosition.bottom, 1, 4, 1, "number");

            Console.WriteLine(pie.GetUrl());
        }
    }
}
