using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDependencyProperty
{
    /// <summary>
    /// CalculateControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CalculateControl : UserControl, INotifyPropertyChanged
    {
        public CalculateControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty Value1Property =
            DependencyProperty.Register("Value1", typeof(decimal), typeof(CalculateControl), new PropertyMetadata(0m, OnValueChanged));

        public static readonly DependencyProperty Value2Property =
            DependencyProperty.Register("Value2", typeof(decimal), typeof(CalculateControl), new PropertyMetadata(0m, OnValueChanged));

        public static readonly DependencyProperty OperatorProperty =
            DependencyProperty.Register("Operator", typeof(string), typeof(CalculateControl), new PropertyMetadata("+", OnValueChanged));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CalculateControl calculateControl = (CalculateControl)d;
            calculateControl.OnPropertyChanged(nameof(Result));
        }

        public string Operator
        {
            get { return (string)GetValue(OperatorProperty); }
            set { SetValue(OperatorProperty, value); }
        }

        public decimal Value1
        {
            get { return (decimal)GetValue(Value1Property); }
            set { SetValue(Value1Property, value); }
        }


        public decimal Value2
        {
            get { return (decimal)GetValue(Value2Property); }
            set { SetValue(Value2Property, value); }
        }

        public decimal Result => Operator switch
        {
            "+" => Value1 + Value2,
            "-" => Value1 - Value2,
            "*" => Value1 * Value2,
            "/" => Value2 == 0
                ? 0
                : Math.Round(Value1 / Value2, 2),
            _ => 0m
        };

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
