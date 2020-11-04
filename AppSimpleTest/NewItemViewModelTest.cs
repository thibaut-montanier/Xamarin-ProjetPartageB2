using AppSimple.Models;
using AppSimple.Services;
using AppSimple.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppSimpleTest {
    class NewItemViewModelTest {
        private NewItemViewModel _vm;

        [SetUp]
        public void SetUp() {

            Device.Info = new MockDeviceInfo();
            Device.PlatformServices = new MockPlatformServices();
            ////DependencyService.Register<MockResourcesProvider>();
            ////DependencyService.Register<MockDeserializer>();
            DependencyService.Register<MockDataStore>();
            this._vm = new NewItemViewModel();
        }
        [Test]
        public void TestSave() {
            _vm.Text = "toto";
             _vm.SaveItem().Wait();

            var ds = DependencyService.Get<IDataStore<Item>>();
            var result = ds.GetItemsAsync();
            result.Wait();
            var r = result.Result.Last();
            Assert.AreEqual(_vm.Text, r.Text);
        }
    }
}
