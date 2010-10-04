using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using FlugleCharts;

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
                                  .ShowLegend(Position.right)
                                  .AddSeries(s1)
                                  .AddAxes(Position.left, 0, 170, 30, "left data")
                                  .AddAxes(Position.bottom, 1, 4, 1, "number");


            var url = pie.GetUrl();
            Debug.WriteLine(url);

            Assert.AreEqual(url, "http://chart.apis.google.com/chart?cht=p&chs=400x200&chtt=bar+yo&chd=t:80,40,110,30&chl=Field1|Field2|Field3|Field4&chdlp=r&chdl=Field1|Field2|Field3|Field4&chxt=y,y,x,x&chxr=0,0,170,30|2,1,4,1|&chxl=1:|left+data|3:|number&chxp=1,50&3,50");


        }

        [TestMethod]
        public void TestPie2()
        {
            var s1 = new Series();

            s1.Add("Hello", 60);
            s1.Add("World", 40);

            var pie = ChartBuilder.Pie(PieType.ThreeDimensional)
                                  .Size(250, 100)
                                  .AddSeries(s1);


            var url = pie.GetUrl();
            Debug.WriteLine(url);

            Assert.AreEqual(url, "http://chart.apis.google.com/chart?cht=p3&chs=250x100&chd=t:60,40&chl=Hello|World");
        }

        [TestMethod]
        public void TestPie3()
        {
            var s1 = new Series();
            s1.Add(10);
            s1.Add(-10);
            s1.Add(10);
            s1.Add(-10);

            var s2 = new Series();
            s2.Add(5); s2.Add(-5);
            s2.Add(5); s2.Add(-5);
            s2.Add(5); s2.Add(-5);
            s2.Add(5); s2.Add(-5);
            s2.Add(5); s2.Add(-5);

            var pie = ChartBuilder.Pie(PieType.Concentric)
                                  .Size(150, 150)
                                  .AddSeries(s1)
                                  .AddSeries(s2);


            var url = pie.GetUrl();
            Debug.WriteLine(url);

            Assert.AreEqual(url, "http://chart.apis.google.com/chart?cht=pc&chs=150x150&chd=t:10,-10,10,-10|5,-5,5,-5,5,-5,5,-5,5,-5");
        }

    }
}
