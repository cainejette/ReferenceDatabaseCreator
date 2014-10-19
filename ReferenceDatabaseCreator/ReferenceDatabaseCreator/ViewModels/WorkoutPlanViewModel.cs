using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceDatabaseCreator.ViewModels
{
    public class WorkoutPlanViewModel : BaseViewModel
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
