using System;
using System.Collections.Generic;
using AppSimple.ViewModels;
using AppSimple.Views;
using Xamarin.Forms;

namespace AppSimple {
    public partial class AppShell : Xamarin.Forms.Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute("ItemDetailPage", typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e) {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
