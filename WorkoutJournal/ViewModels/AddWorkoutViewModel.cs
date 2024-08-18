using WorkoutJournal.Data.Models;

namespace WorkoutJournal.ViewModels {
    public class AddWorkoutViewModel {
        public WorkoutTypes WorkoutType { get; set; } = new();
        public bool IsChecked { get; set; }
    }
}
