using System.Windows;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Tetris;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Media;
using System.ComponentModel;

namespace TetrisFrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<List<Kolory>> Lsts = new List<List<Kolory>>();
        public Kolory[,] planszaa = new Kolory[5, 5];
        Random rnd = new Random();

        public MainWindow()
        {
            for (int i = 0; i < 20; i++)
            {
                Lsts.Add(new List<Kolory>());
                for (int j = 0; j < 10; j++)
                {
                    Lsts[i].Add(new Kolory(PickRandomBrush(rnd)));
                }
            }

            for (int i = 0; i < planszaa.GetLength(0); i++)
            {
                for (int j = 0; j < planszaa.GetLength(1); j++)
                {
                    planszaa[i, j] = new Kolory(PickRandomBrush(rnd));
                }
            }

            InitializeComponent();

            Klocki.ItemsSource = Lsts;
        }

        private Brush PickRandomBrush(Random rnd)
        {
            Brush result = Brushes.Transparent;
            Type brushesType = typeof(Brushes);
            PropertyInfo[] properties = brushesType.GetProperties();
            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);
            return result;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Lsts[0][0].Szczotka = Brushes.Black;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Lsts[i][j].Szczotka = PickRandomBrush(rnd);
                }
            }
        }
    }

    public class Kolory : INotifyPropertyChanged
    {
        private Brush szczotka;

        public event PropertyChangedEventHandler PropertyChanged;

        public Brush Szczotka
        {
            get { return szczotka; }
            set
            {
                if (szczotka != value)
                {
                    szczotka = value;
                    OnPropertyChanged("Szczotka");
                }
            }
        }

        public Kolory(Brush szczotka)
        {
            this.Szczotka = szczotka;
        }

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}

