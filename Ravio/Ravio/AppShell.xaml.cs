using Ravio.Views;
using Xamarin.Forms;

namespace Ravio
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(SignInPage), typeof(SignInPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));

            Routing.RegisterRoute(nameof(WorkoutsPage), typeof(WorkoutsPage));
            Routing.RegisterRoute(nameof(ExercisesPage), typeof(ExercisesPage));
            Routing.RegisterRoute(nameof(FoodPage), typeof(FoodPage));

            Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
            Routing.RegisterRoute(nameof(WorkoutResultPage), typeof(WorkoutResultPage));

            Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
            Routing.RegisterRoute(nameof(ExerciseResultPage), typeof(ExerciseResultPage));

            Routing.RegisterRoute(nameof(SearchFoodPage), typeof(SearchFoodPage));
        }
    }
}
