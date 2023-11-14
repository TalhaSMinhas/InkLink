using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace InkLink.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
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
                note.Abbreviation = Note.GetAbbrevation(note.NoteName);
            }
            
            Notes.Add(note1);
            Notes.Add(note2);
            Notes.Add(note3);
            Notes.Add(note4);
            Notes.Add(note5);
        }
        
        private void BtnAddNote_OnClick(object sender, RoutedEventArgs e)
        {
            Note newNote = new Note
            {
                Abbreviation = "New Abbreviation",
                NoteName = "New Note",
                Content = "New content"
            };

            Notes.Add(newNote); // Add the new note to the collection
        }
        
        private void NotesList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnMaximise_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtnMinimise_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Serialize(Note note)
        {
            var fileName = $"{note}.json";
            string jsonString = JsonSerializer.Serialize(note);
            File.WriteAllText(fileName, jsonString);
        }
    }
}