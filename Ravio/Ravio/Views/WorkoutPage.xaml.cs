using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ravio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var ViewModel = BindingContext as ViewModels.WorkoutPageViewModel;
            await ViewModel.GetWorkout();
            await ViewModel.StartWorkout();
        }
    }
}