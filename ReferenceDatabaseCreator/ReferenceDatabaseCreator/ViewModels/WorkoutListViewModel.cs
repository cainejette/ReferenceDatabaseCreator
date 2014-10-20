using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceDatabaseCreator.ViewModels
{
    /// <summary>
    /// ViewModel for the list of workouts associated with a particular workout plan
    /// </summary>
    public class WorkoutListViewModel : BaseViewModel
    {
        private string _name;

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this.SetProperty(ref this._name, value);
            }
        }
    }
}
