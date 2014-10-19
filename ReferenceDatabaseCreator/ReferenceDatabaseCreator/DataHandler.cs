using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ReferenceDatabaseCreator
{
    public static class DataHandler
    {
        public static List<WorkoutPlan> workoutPlans = new List<WorkoutPlan>();

        /// <summary>
        /// Populates a list of workouts based on the contents of workouts.txt
        /// </summary>
        public async static void LoadWorkoutPlans()
        {
            StorageFolder folder = Windows.Storage.ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.GetFileAsync("workouts.txt");
            string workouts = await FileIO.ReadTextAsync(file);
            
            foreach (string workout in workouts.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)) 
            {
                DataHandler.workoutPlans.Add(new WorkoutPlan
                {
                    Name = workout.Trim()
                });
            }
        }
    }

    public class WorkoutPlan
    {
        public string Name { get; set; }
    }
}
