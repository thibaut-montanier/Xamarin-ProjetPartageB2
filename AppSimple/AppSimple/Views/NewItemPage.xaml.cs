using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppSimple.Models;
using AppSimple.ViewModels;

namespace AppSimple.Views {
    public partial class NewItemPage : ContentPage {
        public Item Item { get; set; }

        public NewItemPage() {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}