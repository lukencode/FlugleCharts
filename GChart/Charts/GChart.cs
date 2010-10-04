using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FlugleCharts
{
    public abstract class GChart<TChart> where TChart : GChart<TChart>
    {
        protected static string _baseUrl = "http://chart.apis.google.com/chart?";

        protected string _chartType;

        protected string _title;
        protected string _titleColor;
        protected int _titleFontSize;

        protected string _format = "gif";
        protected int _width = 300;
        protected int _height = 150;

        protected bool _showLegend;
        protected string _legendPosition;

        protected List<Series> _data { get; set; }
        protected List<Axes> _axesList { get; set; }

        internal GChart()
        {
            _data = new List<Series>();
            _axesList = new List<Axes>();
        }

        public TChart Size(int width, int height)
        {
            //todo validate max/min values

            _width = width;
            _height = height;

            return (TChart)this;
        }

        public TChart Title(string title, string color = "", int fontsize = 12)
        {
            _title = title;
            _titleColor = color;
            _titleFontSize = fontsize;

            return (TChart)this;
        }

        public TChart AddSeries(Series series)
        {
            if (_data == null)
                _data = new List<Series>();

            _data.Add(series);
            return (TChart)this;
        }

        public TChart ShowLegend(Position position)
        {
            _showLegend = true;
            _legendPosition = position.GetCode();

            return (TChart)this;
        }

        public TChart HideAxes()
        {
            _chartType += ":nda";

            return (TChart)this;
        }

        public TChart AddAxes(Position position, int min, int max, int step, string title = "")
        {
            string pos = position.GetCode();
            var index = (_axesList.Count() == 0) ? 0 : _axesList.Max(a => a.Index) + 1;

            var axes = new Axes
            {
                Position = pos,
                Min = min,
                Max = max,
                Step = step,
                Index = index
            };

            _axesList.Add(axes);

            if (!title.IsNullOrEmpty())
            {
                //add axes title
                var axesTitle = new Axes
                {
                    Position = pos,
                    Index = index + 1,
                    Labels = new List<string> { title }
                };

                _axesList.Add(axesTitle);
            }

            return (TChart)this;
        }

        public TChart AddAxes(Position position, List<string> labels, string title = "")
        {
            string pos = position.GetCode();
            var index = (_axesList.Count() == 0) ? 0 : _axesList.Max(a => a.Index) + 1;

            var axes = new Axes
            {
                Position = pos,
                Labels = labels,
                Index = index
            };

            _axesList.Add(axes);

            if (!title.IsNullOrEmpty())
            {
                //add axes title
                var axesTitle = new Axes
                {
                    Position = pos,
                    Index = index + 1,
                    Labels = new List<string> { title }
                };

                _axesList.Add(axesTitle);
            }

            return (TChart)this;
        }

        //probs not worth having VV

        //public TChart AddAxes(Position position, string title)
        //{
        //    string pos = position.GetCode();

        //    var firstSeries = _data.FirstOrDefault();
        //    int max = 100;
        //    int min = 0;
        //    int step = 20;

        //    if (firstSeries != null)
        //    {
        //        var maxVal = _data.Max(s => s.Max(d => d.Value));
        //        max = Convert.ToInt32(maxVal);

        //        min = 0; //Convert.ToInt32(_data.Min(s => s.Min(d => d.Value))); //or just zero?

        //        var roundedStep = (double)max / 5d;
        //        roundedStep = Math.Floor(roundedStep / 5);
        //        step = (int)(roundedStep * 5);
        //    }

        //    var axes = new Axes
        //    {
        //        Position = pos,
        //        Min = min,
        //        Max = max,
        //        Step = step,
        //        Title = title,
        //        Index = (_axesList.Count() == 0) ? 0 : _axesList.Max(a => a.Index) + 1
        //    };

        //    _axesList.Add(axes);
        //    return (TChart)this;
        //}

        public virtual string GetUrl()
        {
            var sb = new StringBuilder();
            sb.Append(_baseUrl);

            //build common options
            sb.Append(string.Format("cht={0}", GetChartType()));
            sb.Append(string.Format("&chs={0}x{1}", _width, _height));
            if (!string.IsNullOrWhiteSpace(_title))
            {
                sb.Append(string.Format("&chtt={0}", HttpUtility.UrlEncode(_title)));
            }

            //render options
            sb.Append("&" + RenderChartOptions());
            sb.Append(BuildColors());
            sb.Append(BuildData());

            if (_data.Any(d => d.Any(p => !p.Label.IsNullOrEmpty())))
                sb.Append(BuildLabels());

            //build legend
            if (_showLegend)
                sb.Append("&" + BuildLegend());

            //build axes
            if (_axesList.Count > 0)
                sb.Append("&" + BuildAxes());

            return cleanUrl(sb.ToString());
        }

        protected virtual string BuildLegend()
        {
            var sb = new StringBuilder();
            sb.Append("chdlp=" + _legendPosition + "&"); //position

            sb.Append("chdl=");
            foreach (var s in _data.Where(ds => !string.IsNullOrWhiteSpace(ds.Legend)))
            {
                sb.Append(HttpUtility.UrlEncode(s.Legend) + "|");
            }

            var stringData = sb.ToString();
            return sb.ToString().Take(stringData.Length - 1);
        }

        protected virtual string BuildData()
        {
            var sb = new StringBuilder();

            //todo encoding options
            sb.Append("&chd=t:");
            foreach (var s in _data)
            {
                sb.Append(s.RenderValues() + "|");
            }

            var stringData = sb.ToString();
            return sb.ToString().Take(stringData.Length - 1);
        }

        protected virtual string BuildLabels()
        {
            //render chart labels
            var sb = new StringBuilder();

            sb.Append("&chl=");
            foreach (var ds in _data)
            {
                foreach (var p in ds.Where(p1 => !string.IsNullOrWhiteSpace(p1.Label)))
                {
                    sb.Append(HttpUtility.UrlEncode(p.Label) + "|");
                }
            }

            var stringData = sb.ToString();
            return sb.ToString().Take(stringData.Length - 1);
        }

        protected virtual string BuildAxes()
        {
            string types = "chxt=";
            string labels = "chxl=";
            string range = "chxr=";
            string position = "chxp=";

            bool hasLabels = false;
            bool hasRange = false;
            bool hasPosition = false;

            for (int i = 0; i < _axesList.Count; i++)
            {
                var axes = _axesList[i];
                bool isLast = (i == _axesList.Count - 1);

                types += axes.Position;
                if (!isLast)
                    types += ",";

                if (axes.StepSet)
                {
                    hasRange = true;

                    range += "{0},{1},{2},{3}".With(axes.Index, axes.Min, axes.Max, axes.Step);
                    if (!isLast)
                        range += "|";
                }

                //custom labels
                if (axes.Labels.Count > 0)
                {
                    hasLabels = true;
                    labels += axes.Index + ":|";

                    for (int k = 0; k < axes.Labels.Count; k++)
                    {
                        bool lastLabel = (k == axes.Labels.Count - 1);
                        var label = axes.Labels[k];
                        labels += HttpUtility.UrlEncode(label);

                        if (!lastLabel || !isLast)
                            labels += "|";
                    }
                }

                //centre titles (maybe extend later to space all labels)
                if (axes.Labels.Count == 1)
                {
                    if (hasPosition)
                        position += "&";
                    else
                        hasPosition = true;

                    position += axes.Index + ",50";
                }
            }

            var sb = new StringBuilder();
            sb.Append(types);

            if (hasRange)
                sb.Append("&" + range);

            if (hasLabels)
                sb.Append("&" + labels);

            if (hasPosition)
                sb.Append("&" + position);

            return sb.ToString();
        }

        protected virtual string BuildColors()
        {
            //Check if there are any colors set
            var colors = _data.Where(s => s.Color != null).Select(s => s.Color);

            if (colors.Count() == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();

            sb.Append("&chco=");
            foreach (var c in colors)
            {
                sb.Append("{0:X2}{1:X2}{2:X2}".With(c.Value.R, c.Value.G, c.Value.B) + ","); //converts color to hex
            }

            var stringColor = sb.ToString();
            //Remove final Comma
            return sb.ToString().Take(stringColor.Length - 1);
        }

        private static string cleanUrl(string url)
        {
            if (url.EndsWith("|") || url.EndsWith("&") || url.EndsWith(","))
                url = url.Take(url.Length - 1);

            return url.Replace("&&", "&").Replace("||", "|").Replace(",,", ",");
        }

        protected abstract string RenderChartOptions();
        protected abstract string GetChartType();
    }
}
