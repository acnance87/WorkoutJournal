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

        public ActionResult AddWorkout(int exerciseId) {
            var toReturn = new Workouts() {
                Weight = 0,
                PerceivedExertion = 0,
                Repetitions = 0,
                WorkoutType = new WorkoutTypes() {
                    WorkoutTypeID = exerciseId,
                }
            };


            return Json(toReturn);
        }

        public ActionResult GetWorkouts() {
            var newWorkouts = new List<AddWorkoutViewModel>() {
                new AddWorkoutViewModel() { WorkoutType = new() { ExerciseName = "Abdominal crunch", WorkoutTypeID = 1 }, IsChecked = false },
                new AddWorkoutViewModel() { WorkoutType = new() { ExerciseName = "Bicep curl", WorkoutTypeID = 2 }, IsChecked = false },
                new AddWorkoutViewModel() { WorkoutType = new() { ExerciseName = "Chest press", WorkoutTypeID = 3 }, IsChecked = false },
                new AddWorkoutViewModel() { WorkoutType = new() { ExerciseName = "Seated squat", WorkoutTypeID = 4 }, IsChecked = false },
            }; 
            return PartialView("_AddWorkout", newWorkouts);
            //return PartialView("_AddWorkout", _contract.GetWorkoutsTypes());
        }

        [HttpPost]
        public ActionResult CreateWorkout([FromBody] IEnumerable<AddWorkoutViewModel> workoutsSelected) {
            return Ok();
        }
    }   
}
