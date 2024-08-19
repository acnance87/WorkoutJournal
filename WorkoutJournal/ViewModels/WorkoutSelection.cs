using WorkoutJournal.Data.Models;

namespace WorkoutJournal.ViewModels {

    public class WorkoutSelection {
        public int WorkoutID { get; set; }
        public string ExerciseName { get; set; } = string.Empty;
    }
}
