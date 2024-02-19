using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFDependencyProperty
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal _value4;
        [ObservableProperty]
        private decimal _value2;
        [ObservableProperty]
        private string _operator;

        public MainViewModel()
        {
            Value4 = 1000;
            Value2 = 2000;
            Operator = "-";

            var timer = new DispatcherTimer() {Interval = TimeSpan.FromSeconds(1)};
            timer.Tick += (s, e) =>
            {
                Value4 += 1;
                Value2 += 2;
            };
            timer.Start();
        }
    }
}
