using System;
using System.Windows.Controls;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Client.Charts
{
    /// <summary>
    /// Interaction logic for SinrChartControl.xaml
    /// </summary>
    public partial class UpChartControl : UserControl
    {
        public UpChartControl()
        {
            InitializeComponent();

            var dayConfig = Mappers.Xy<DateModel>()
                .X(dayModel => (double)dayModel.DateTime.Ticks / TimeSpan.FromMinutes(10).Ticks)
                .Y(dayModel => dayModel.Value);

            SeriesCollection = new SeriesCollection(dayConfig)
            {
                new LineSeries
                {
                    Title = "Up",
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
