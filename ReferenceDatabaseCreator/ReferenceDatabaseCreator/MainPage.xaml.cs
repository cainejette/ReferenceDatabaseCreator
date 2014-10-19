using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ReferenceDatabaseCreator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        SQLiteConnection _db; 
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            _db = new SQLiteConnection("Workouts.db");
            _db.CreateCommand("PRAGMA foreign_keys = ON").ExecuteNonQuery();
            _db.DropTable<Workouts>();
            _db.DropTable<WorkoutPlans>();
            _db.CreateTable<WorkoutPlans>();
            _db.CreateTable<Workouts>();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void createDatabase_Click(object sender, RoutedEventArgs e)
        {
            WorkoutPlans workoutPlans = new WorkoutPlans()
            {
                Name = "Insanity"
            };

            _db.Insert(workoutPlans);

            var query = _db.Table<WorkoutPlans>().Where(x => x.Name.Contains("Insanity"));
            var result = query.ToList()[0];

            List<Workouts> workoutList = new List<Workouts>()
            {
                new Workouts()
                {
                    Name = "Fit Test",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Plyometric Cardio Circuit",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Cardio Power and Resistance",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Cardio Recovery",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Pure Cardio",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Rest",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Cardio Abs",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "Core Cardio and Balance",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "MAX Interval Circuit",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "MAX Interval Plyometrics",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "MAX Cardio Conditioning",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "MAX Recovery",
                    WorkoutPlanId = result.Id
                },
                new Workouts()
                {
                    Name = "MAX Cardio",
                    WorkoutPlanId = result.Id
                }
            };

            _db.InsertAll(workoutList);

            var query2 = _db.Table<Workouts>().Where(x => x.Name.Contains("MAX"));
            var result2 = query2.ToList();
            string name2 = "";

        }
    }

    [Table("WorkoutPlans")]
    public class WorkoutPlans
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
    }

    [Table("Workouts")]
    public class Workouts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(WorkoutPlans))]
        public int WorkoutPlanId { get; set; }
    }
}
