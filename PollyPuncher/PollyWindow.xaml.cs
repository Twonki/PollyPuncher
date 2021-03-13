﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PollyPuncher
{
    /// <summary>
    /// Interaction logic for PollyWindow.xaml
    /// </summary>
    public partial class PollyWindow : Window
    {
        public PollyProperties pollyProps { get; set; }
        public AudioDeviceProperties audioProps  { get; set; }

        private PollyCaller pc;
        public PollyWindow()
        {
            this.pollyProps = App._pollyProperties;
            this.audioProps = App._audioDeviceProperties;

            pc = new PollyCaller(pollyProps, audioProps);
            
            InitializeComponent();
            
            this.DataContext = this;
        }

        private void PlayButton_OnClick(object sender, RoutedEventArgs e)
        {
            pc.Call(pollyProps.textToPlay);
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var result = saveFileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    throw new NotImplementedException();
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    throw new InvalidDataException("This is not a file bro");
                    break;
            }
        }
        
        private void BtnKeyFileOpen_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new System.Windows.Forms.OpenFileDialog();
            var result = fileDialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    var file = fileDialog.FileName;
                    pollyProps.apiKey = file;
                    break;
                case System.Windows.Forms.DialogResult.Cancel:
                default:
                    throw new InvalidDataException("This is not a file bro");
                    break;
            }
        }
    }
}