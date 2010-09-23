using System;
using GChart;
using GCharts.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Test
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void TestLine1()
        {
            var s1 = new Series()
            {
                Legend = "data",
                Color = "00FF00"
            };

            s1.Add(80);
            s1.Add(40);
            s1.Add(110);
            s1.Add(30);

            var s2 = new Series()
            {
                Legend = "data 2",
                Color = "FF0000"
            };

            s2.Add(170);
            s2.Add(150);
            s2.Add("oh snap", 80);
            s2.Add(30);

            var line = ChartBuilder.Line()
                                  .Title("bar yo")
                                  .Size(400, 200)
                                  .ShowLegend("r")
                                  .AddSeries(s1)
                                  .AddSeries(s2)
                                  .AddAxes(GChart.Charts.AxesPosition.left, 0, 170, 30, "left data")
                                  .AddAxes(GChart.Charts.AxesPosition.bottom, 1, 4, 1, "number");

            Debug.WriteLine(line.GetUrl());


        }



        [TestMethod]
        public void TestLine2()
        {
            var s1 = new Series()
            {
                Legend = "Data"
            };
            s1.Add(40);
            s1.Add(60);
            s1.Add(60);
            s1.Add(45);
            s1.Add(47);
            s1.Add(75);
            s1.Add(70);
            s1.Add(72);

            var line = ChartBuilder.Line()
                                  .Size(200, 125)
                                  .AddSeries(s1);

            var url = line.GetUrl();
            Debug.WriteLine(url);

            Assert.AreEqual(url, "http://chart.apis.google.com/chart?cht=lc&chs=200x125&chd=t:40,60,60,45,47,75,70,72");

        }


        [TestMethod]
        public void TestLine3()
        {
            var s1 = new Series()
            {
                Legend = "Data",
                Color = "0077CC"
            };
            s1.Add(27); s1.Add(25);
            s1.Add(60); s1.Add(31);
            s1.Add(25); s1.Add(39);
            s1.Add(25); s1.Add(31);
            s1.Add(26); s1.Add(28);
            s1.Add(80); s1.Add(28);
            s1.Add(27); s1.Add(31);
            s1.Add(27); s1.Add(29);
            s1.Add(26); s1.Add(35);
            s1.Add(70); s1.Add(25);

            var line = ChartBuilder.Line(GChart.Charts.LineType.SparkLine)
                                  .Size(200, 125)
                                  .AddSeries(s1);

            var url = line.GetUrl();
            Debug.WriteLine(url);

            Assert.AreEqual(url, "http://chart.apis.google.com/chart?cht=ls&chs=200x125&chco=0077CC&chd=t:27,25,60,31,25,39,25,31,26,28,80,28,27,31,27,29,26,35,70,25");

        }

    }
}
