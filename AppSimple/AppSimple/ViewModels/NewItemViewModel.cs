﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppSimple.Models;
using Xamarin.Forms;

namespace AppSimple.ViewModels {
    public class NewItemViewModel : BaseViewModel {
        private string text;
        private string description;

        public NewItemViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public async void OnCancel() {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave() {

            await SaveItem();
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        public async Task SaveItem() {
            Item newItem = new Item() {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Description = Description
            };

            await DataStore.AddItemAsync(newItem);
        }

       
    }
}
