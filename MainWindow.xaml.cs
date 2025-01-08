﻿using logsmith.TagParsers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace logsmith
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string temp = "{{date yyyy-mm-dd}} - {{loglevel}}";

            Parser.ParseTemplateString(ref temp);

            Console.WriteLine(temp);

            InitializeComponent();

        }
    }
}