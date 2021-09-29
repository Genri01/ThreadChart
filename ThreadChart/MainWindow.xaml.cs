
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Wpf;

namespace ThreadChart
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            Series = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {20, 30, 35, 45, 65, 85},
                    Title = "Electricity"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {10, 12, 18, 20, 38, 40},
                    Title = "Water"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {5, 8, 12, 15, 22, 25},
                    Title = "Solar"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {10, 12, 18, 20, 38, 40},
                    Title = "Gas"

                }
             };


            // Series = new SeriesCollection
            // {
            //     new StackedAreaSeries
            //     {
            //         Values = new ChartValues<double> {20, 30, 35, 45, 65, 85},
            //         Title = "Electricity"
            //     }
            //};



            DataContext = this;

        }
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string _propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_propertyName));
        }

       

        private void ListBox_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(ListBox, (DependencyObject)e.OriginalSource) as ListBoxItem;
            if (item == null) return;

            var series = (StackedAreaSeries)item.Content;
            series.Visibility = series.Visibility == Visibility.Visible
                ? Visibility.Hidden
                : Visibility.Visible;
        }


        //public SeriesCollection Series { get; set; }

        //private ObservableCollection<SeriesCollection> _series = new ObservableCollection<SeriesCollection>();

        //public SeriesCollection Test
        //{
        //    get { return _series.First(); }
        //    set
        //    {
        //        _series.Add(value);
        //        OnPropertyChanged();
        //    }
        //}

        public SeriesCollection Series { get; set; }
        public SeriesCollection Test
        {
            get { return Series; }
            set
            {
                Series = value ;
                OnPropertyChanged();
            }
        }

        private void addSeria(object sender, RoutedEventArgs e)
        {
            Series.Add(new StackedAreaSeries
            {
                Title = "Новая серия",
                Values = new ChartValues<double> { 20, 20, 27, 29, 45, 40 },

            });

            Test = Series;

        }
    }
}