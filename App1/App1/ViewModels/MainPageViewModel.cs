using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public Command SelectedNoteChangedCommand { get; }

        string selectedNote;

        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;

                var args = new PropertyChangedEventArgs(nameof(SelectedNote));

                PropertyChanged?.Invoke(this, args);
            }
        }
        
        public MainPageViewModel() 
        {
            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() =>
            {
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });


            SelectedNoteChangedCommand = new Command( async() => 
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushAsync(detailPage);

            });



        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;
        public string TheNote
        {
            get => theNote;
            set
                {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

    }
}
