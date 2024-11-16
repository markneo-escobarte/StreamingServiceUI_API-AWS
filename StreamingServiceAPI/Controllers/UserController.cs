using Microsoft.AspNetCore.Mvc;
using StreamingServiceModel;
using StreamingServiceBL;
using StreamingServiceDL;

namespace StreamingServiceAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly MovieBL _movieBL;


        public UserController(MovieBL movieBL)
        {
            _movieBL = movieBL;
        }

        [HttpGet]
        public IEnumerable<StreamingServiceAPI.User> GetMovies()
        {
            var activeMovies = _movieBL.GetTitle();

            List<StreamingServiceAPI.User> users = new List<User>();

            foreach (var item in activeMovies)
            {
                users.Add(new StreamingServiceAPI.User { Title = item.Title });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddMovie(User user)
        {
            _movieBL.AddTitle(user.Title);
            return new JsonResult("Movie added successfully");

        }

        [HttpPatch]
        public JsonResult UpdateMovie(string oldTitle, string newTitle)
        {
            _movieBL.UpdateTitle(oldTitle, newTitle);
            return new JsonResult("Movie updated successfully");
        }

        [HttpDelete]
        public JsonResult DeleteMovie(string title)
        {
            _movieBL.DeleteTitle(title);
            return new JsonResult("Movie deleted successfully");
        }
    }
}