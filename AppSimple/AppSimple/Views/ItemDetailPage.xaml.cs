﻿using System.ComponentModel;
using Xamarin.Forms;
using AppSimple.ViewModels;

namespace AppSimple.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}