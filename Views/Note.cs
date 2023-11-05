using System;
using System.Linq;
using System.Windows.Documents;

namespace InkLink.Views
{
    public class Note
    {
        public string NoteName { get; set; }
        public string Abbreviation { get; set; }
        public string Content { get; set; }
        
        public static string GetAbbrevation(string noteName)
        {
            var words = noteName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Aggregate("", (current, word) => current + char.ToUpper(word[0]));
        }
    }
}