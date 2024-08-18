using Microsoft.AspNetCore.Mvc;
using WorkoutJournal.Data.Models;
using WorkoutJournal.Managers.Contracts;
using WorkoutJournal.ViewModels;

namespace WorkoutJournal.Controllers {
    public class HomeController : Controller {

        private readonly IWorkoutJournalContract _contract;

        public HomeController(IWorkoutJournalContract workoutJournalContract) {
            _contract = workoutJournalContract;
        }

        public ActionResult Index() {
            ViewBag.Title = "Workout Journal";

            return View("~/Views/Index.cshtml");
        }

        public ActionResult BeginWorkout() {
            //var newWorkout = _contract.BeginNewWorkoutSession();
            var vm = new WorkoutViewModel() {
                CurrentWorkout = new WorkoutSessions() {
                    SessionDate = DateTime.Now,
                    SessionID = 1,
                    Workouts = [],
                }
            };

            return View(vm);
        }

        public ActionResult AddWorkout() {
            var toReturn = new WorkoutTypes() {
                ExerciseName = "Bicep curl",
                WorkoutTypeID = 1,
            };

            return Json(toReturn);
        }
    }
}
