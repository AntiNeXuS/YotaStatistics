using System;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Client.Charts
{
    /// <summary>
    /// Interaction logic for RsrpChartControl.xaml
    /// </summary>
    public partial class RsrpChartControl : UserControl
    {
        public RsrpChartControl()
        {
            InitializeComponent();

            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromMinutes(10).Ticks)
                .Y(dayModel => dayModel.Value);

            SeriesCollection = new SeriesCollection(dayConfig)
            {
                new LineSeries
                {
                    Title = "RSRP",
                    Values = new ChartValues<DateModel>(),
                    Fill = Brushes.Transparent

                }
            };

            Formatter = value => new DateTime((long)(value * TimeSpan.FromMinutes(10).Ticks)).ToString("t");
            
            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
