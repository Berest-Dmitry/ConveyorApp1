﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ConveyorApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ProcessModel> processModels;
        public static int ProcessCount = 0;
        public MainWindow()
        {
            InitializeComponent();
           // ListBox1.ItemsSource = MainWindow.ProcessCount;
            
            
           
        }   
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();

            if (MainWindow.ProcessCount > 1)
            {
                processModels = new List<ProcessModel>(MainWindow.ProcessCount);

                for (int i = 0; i < ProcessCount; i++)
                {
                    var typeOfEvent = Functions.Events();
                    var duration = Functions.Duration(typeOfEvent);
                    var inCache = Functions.InCache();

                    processModels.Add(new ProcessModel
                    {
                        TypeOfEvent = typeOfEvent,
                        Duration = duration,
                        InCache = inCache
                    });
                }      
                
                foreach(var model in processModels)
                {
                    TextBox1.Text += Functions.Commands(model.Duration, model.TypeOfEvent, model.InCache) + ",";
                }
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ProcessCount++;
            txtNum.Text = Convert.ToString(MainWindow.ProcessCount);
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.ProcessCount > 1)
            {
                MainWindow.ProcessCount--;
                txtNum.Text = Convert.ToString(MainWindow.ProcessCount);
            }
        }

        private void txtNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum == null)
            {
                return;
            }

            if (!int.TryParse(txtNum.Text, out ProcessCount))
                txtNum.Text = ProcessCount.ToString();
        }
    }
}
