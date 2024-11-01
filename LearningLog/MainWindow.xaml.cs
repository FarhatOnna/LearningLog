using System.IO;
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
using System.Windows.Media;
using System.Media;

namespace LearningLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isRecording = false;
        FileInfo recordingFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonRecord_Click(object sender, RoutedEventArgs e)
        {
            if (!isRecording)
            {
                labelRecordText.Content = "Stop";
                isRecording = true;
                RecordWav.StartRecording();
                buttonSave.IsEnabled = false;
                buttonPlay.IsEnabled = false;        
                UpdateStatus("Recording started at " + DateTime.Now.ToString("yyyyMMdd") + ".");
            }
            else
            {
                labelRecordText.Content = "_Record";
                isRecording = false;
                recordingFile = RecordWav.EndRecording();
                buttonSave.IsEnabled = true;
                buttonPlay.IsEnabled = true;
                UpdateStatus("Recording completed and saved to " + recordingFile.FullName);

            }
            
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            LogEntry newEntry = new LogEntry(0,0,textNotes.Text,recordingFile);
            UpdateStatus(newEntry.ToString());
        }

        private void UpdateStatus(String status)
        {
            statusState.Content = status;
        }

        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            var player = new SoundPlayer(recordingFile.FullName);
            player.Play();
            UpdateStatus("Playing" + recordingFile.FullName);

        }
        private void TabChanged(object sender, RoutedEventArgs e)
        {
            if (tabController.SelectedItem == tabSummary)
            {
                //Update teh summary tab fields
                UpdateStatus("Viewing summary");
            }
        }
    }
}