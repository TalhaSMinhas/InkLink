using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InkLink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public class Note
        {
            public string NoteName { get; set; }
            public string Abbreviation { get; set; }
            public string Content { get; set; }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            
            var note1 = new Note
            {
                NoteName = "Client Meeting Notes",
                Content = "Discussed project requirements and deadlines with the client. Agreed to finalize the proposal by Friday."
            };

            var note2 = new Note
            {
                NoteName = "Daily Tasks",
                Content = "1. Buy groceries\n2. Finish report for the marketing team\n3. Call the plumber about the leaky faucet"
            };

            var note3 = new Note
            {
                NoteName = "Project Idea",
                Content = "Brainstormed a new app concept that could revolutionize the way we take notes. Exciting potential!"
            };

            var note4 = new Note
            {
                NoteName = "Pasta Recipe",
                Content = "Ingredients:\n- 8 oz pasta\n- 2 cups tomato sauce\n- 1/2 cup grated Parmesan cheese\nInstructions: Boil pasta, mix with sauce, sprinkle cheese, and serve."
            };

            var note5 = new Note
            {
                NoteName = "Inspiration",
                Content = "In the middle of every difficulty lies opportunity. - Albert Einstein"
            };

            var notes = new List<Note>
            {
                note1,
                note2,
                note3,
                note4,
                note5
            };

            foreach (var note in notes)
            {
                note.Abbreviation = GetAbbrevation(note.NoteName);
            }
            
            NotesList.ItemsSource = notes;
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string GetAbbrevation(string noteName)
        {
            var words = noteName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Aggregate("", (current, word) => current + char.ToUpper(word[0]));
        }

        private void NotesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NoteContent.Text = Content.ToString();
        }
    }
}