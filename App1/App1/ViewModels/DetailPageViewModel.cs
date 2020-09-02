using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class DetailPageViewModel : INotifyPropertyChanged
    {
        public DetailPageViewModel(string note)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;


        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;

                var args = new PropertyChangedEventArgs(nameof(NoteText));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command DismissPageCommand { get; }
    }
}
