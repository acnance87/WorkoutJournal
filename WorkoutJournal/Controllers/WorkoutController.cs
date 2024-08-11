using Microsoft.AspNetCore.Mvc;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Data.Repository;
using WorkoutJournal.Managers;
using WorkoutJournal.Managers.Contracts;

namespace WorkoutJournal.Controllers
{
    public class WorkoutController : Controller, IWorkoutJournalContract {

        
        public Workouts AddWorkout(Workouts workout) {
            throw new NotImplementedException();
        }

        public WorkoutSessions CreateWorkoutSession(IEnumerable<Workouts> workouts) {
            throw new NotImplementedException();
        }

        public IEnumerable<Workouts> GetWorkouts() {
            throw new NotImplementedException();
        }

        public IActionResult Index() {
            return View();
        }

        public void SaveChanges() {
            throw new NotImplementedException();
        }

        public void UpdateWorkoutSession(WorkoutSessions workoutSession) {
            throw new NotImplementedException();
        }
    }
}
