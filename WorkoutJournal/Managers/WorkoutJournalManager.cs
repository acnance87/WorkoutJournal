﻿using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Repository;
using WorkoutJournal.Managers.Contracts;

namespace WorkoutJournal.Managers
{
    public class WorkoutJournalManager : IWorkoutJournalContract {

        private readonly IWorkoutJournalRepository _repository;
        public WorkoutJournalManager(IWorkoutJournalRepository repository) { 
            _repository = repository;
        }

        public Workouts AddWorkout(Workouts workout) {
            return _repository.AddWorkout(workout);
        }

        public WorkoutSessions CreateWorkoutSession(IEnumerable<Workouts> workouts) {
            var toAdd = new WorkoutSessions();
            toAdd.Workouts = workouts.ToList();
            toAdd.SessionDate = DateTime.Now;

            return _repository.CreateWorkoutSession(toAdd);
        }

        public IEnumerable<Workouts> GetWorkouts() {
            return _repository.GetWorkouts();
        }

        public IEnumerable<WorkoutTypes> GetWorkoutsTypes() {
            return _repository.GetWorkoutsTypes();
        }

        public void UpdateWorkoutSession(WorkoutSessions workoutSession) {
            _repository.UpdateWorkoutSession(workoutSession);
        }
    }
}
