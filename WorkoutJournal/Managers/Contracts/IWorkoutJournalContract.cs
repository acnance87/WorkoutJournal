﻿using Microsoft.AspNetCore.Mvc;
using WorkoutJournal.Data.Models;

namespace WorkoutJournal.Managers.Contracts {
    public interface IWorkoutJournalContract {

        Workouts AddWorkout(Workouts workout);

        WorkoutSessions BeginNewWorkoutSession(WorkoutSessions workoutSession);

        IEnumerable<Workouts> GetWorkouts();

        IEnumerable<WorkoutTypes> GetWorkoutsTypes();

        void UpdateWorkoutSession(WorkoutSessions workoutSession);
    }
}
