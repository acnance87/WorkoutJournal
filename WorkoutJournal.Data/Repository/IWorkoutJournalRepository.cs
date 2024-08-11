using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutJournal.Data.Models;

namespace WorkoutJournal.Data.Repository
{
    public interface IWorkoutJournalRepository
    {
        IEnumerable<Workouts> GetWorkouts();

        IEnumerable<WorkoutTypes> GetWorkoutsTypes();

        WorkoutSessions CreateWorkoutSession(WorkoutSessions workoutSessions);

        Workouts AddWorkout(Workouts workout);

        void SaveChanges();

        void UpdateWorkoutSession(WorkoutSessions workoutSession);
    }
}
