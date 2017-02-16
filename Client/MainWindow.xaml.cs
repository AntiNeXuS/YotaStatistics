using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Client.Charts;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var loader = new DataLoader.DataLoader();
            loader.OnGetData = (data) =>
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate()
                {
                    SinrChart.SeriesCollection[0].Values.Add(new DateModel
                    {
                        DateTime = data.Date,
                        Value = data.SINR
                    });

                    RsrpChart.SeriesCollection[0].Values.Add(new DateModel
                    {
                        DateTime = data.Date,
                        Value = data.RSRP
                    });

                    DlChart.SeriesCollection[0].Values.Add(new DateModel
                    {
                        DateTime = data.Date,
                        Value = data.CurDownlinkThroughput
                    });

                    UpChart.SeriesCollection[0].Values.Add(new DateModel
                    {
                        DateTime = data.Date,
                        Value = data.CurUplinkThroughput
                    });
                });
            };

            loader.Start();

            
        }
    }
}
