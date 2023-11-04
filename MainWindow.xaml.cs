using System.Windows;

namespace InkLink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public class Note
        {
            public string Abbreviation { get; set; }
            public string NoteName { get; set; }
            public string Content { get; set; }
        }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}