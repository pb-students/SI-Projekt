﻿using Algorithm.Data;
using SingleNeuronVisualisation.MVVM.View;
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

namespace SingleNeuronVisualisation.MVVM
{
    /// <summary>
    /// Logika interakcji dla klasy Charts.xaml
    /// </summary>
    public partial class Charts : Page
    {
        public MLData ml { get; set; }
        public static Charts instance { get; set; }
        public ChartsContext context;

        public Charts()
        {
            InitializeComponent();
            context = new();
            DataContext = context;
            instance = this;
        }

        int DataPointsCount = 0;

        public static void AddResultsWrapper(float train, float test) => instance.AddResults(train, test);

        public void AddResults(float train, float test)
        {
            listTraining.AddLast(train);
            listTesting.AddLast(test);
            DataPointsCount++;

            Line_train.Points.Add(new Point(DataPointsCount/10, (1-train) * 400));
            Line_test.Points.Add(new Point(DataPointsCount/10, (1-test) * 400));
        }

        LinkedList<float> listTraining = new ();
        LinkedList<float> listTesting = new ();

        public class ChartsContext
        {
            public string StrokeLineWidth { get; set; }
            // Jeszcze nie wiem co to robi.
            public List<Dataset> FileStore { get; set; }

            public ChartsContext()
            {
                StrokeLineWidth = "4";
            }
        }
    }
}
