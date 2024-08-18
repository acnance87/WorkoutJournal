using WorkoutJournal.Data.Models;

namespace WorkoutJournal.ViewModels {
    public class WorkoutViewModel {
        public WorkoutSessions CurrentWorkout { get; set; } = new WorkoutSessions();
    }
}
