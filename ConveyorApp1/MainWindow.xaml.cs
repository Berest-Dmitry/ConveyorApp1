using System;
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
        List<ProcessModel> resultProcessModels;
        string ListOfCommands = "";
        public string MyText
        {
            get { return ListOfCommands; }
            set { ListOfCommands = value; }
        }
        public static int ProcessCount = 0;

        public static ProcessorProperties Processor;
        public MainWindow()
        {
            InitializeComponent();
            Processor = new ProcessorProperties()
            {
                MicroProcessorFreq = 0,
                SystemBusFreq = 0,
                MemoryFormula = 0
            };
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
            TextBox1.Background = Brushes.Transparent;
            if (MainWindow.ProcessCount > 1)
            {
                processModels = new List<ProcessModel>(MainWindow.ProcessCount);
                List<int> types = new List<int>(MainWindow.ProcessCount);
                List<int> durations = new List<int>(MainWindow.ProcessCount); 
                List<int> cases = new List<int>(MainWindow.ProcessCount);
                for (int i = 0; i < ProcessCount; i++)
                {
                    var type = Functions.Events();
                    types.Add(type);
                    durations.Add(Functions.Duration(type));
                    cases.Add(Functions.InCache());
                }

                    for (int i = 0; i < ProcessCount; i++)
                {                   
                    processModels.Add(new ProcessModel
                    {
                        TypeOfEvent = types[i],
                        Duration = durations[i],
                        InCache = cases[i]
                    });
                    
                }      
                
                for(int i = 0; i < processModels.Count; i++)
                {
                    if (i < ProcessCount - 1)
                        TextBox1.Text += Functions.Commands(processModels[i].Duration, processModels[i].TypeOfEvent, processModels[i].InCache) + ";";
                    else TextBox1.Text += Functions.Commands(processModels[i].Duration, processModels[i].TypeOfEvent, processModels[i].InCache);
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
        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox1.Background = Brushes.Transparent;
                resultProcessModels = new List<ProcessModel>(MainWindow.ProcessCount);
                MyText = TextBox1.Text.ToUpper();
                
                bool check = MyText.Contains("Т") && MyText.Contains("(") && MyText.Contains(")") && MyText.Contains(",") && MyText.Contains(";");
                if (!check)
                {
                    TextBox1.Clear();
                    resultProcessModels = null;
                    throw new Exception("Строка введена некорректно!");                   
                }
                else
                {
                    string[] commands = MyText.Split(';');
                    foreach (var c in commands)
                    {
                        resultProcessModels.Add(Functions.ConvertStringToProcessModel(c));
                    }
                    MessageBox.Show("Все хорошо");
                    // рисование 
                }
                
            }
            catch
            {
                TextBox1.Background = Brushes.DarkRed;
                MessageBox.Show("Произошла ошибка");
            }

            
        }

        private void cmdUp_Click_MP(object sender, RoutedEventArgs e)
        {
            MainWindow.Processor.MicroProcessorFreq++;
            txtNum_MP.Text = Convert.ToString(MainWindow.Processor.MicroProcessorFreq);
        }

        private void cmdDown_Click_MP(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Processor.MicroProcessorFreq > 1)
            {
                MainWindow.Processor.MicroProcessorFreq--;
                txtNum_MP.Text = Convert.ToString(MainWindow.Processor.MicroProcessorFreq);
            }
        }

        private void cmdUp_Click_SB(object sender, RoutedEventArgs e)
        {
            MainWindow.Processor.SystemBusFreq++;
            txtNum_SB.Text = Convert.ToString(MainWindow.Processor.SystemBusFreq);
        }

        private void cmdDown_Click_SB(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Processor.SystemBusFreq > 1)
            {
                MainWindow.Processor.SystemBusFreq--;
                txtNum_SB.Text = Convert.ToString(MainWindow.Processor.SystemBusFreq);
            }
        }
    }
}
