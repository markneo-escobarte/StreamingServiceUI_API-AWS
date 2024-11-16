using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using StreamingServiceDL;
using StreamingServiceModel;

namespace StreamingServiceBL
{
    public class MovieBL
    {
        private readonly SqlDbData _dataService;
        private readonly EmailTool _emailTool;

        public MovieBL()
        {
            _dataService = new SqlDbData();
            _emailTool = new EmailTool();
        }

        public bool VerifyUser(string Username, string Password)
        {
            UserDL movieDL = new UserDL();
            var result1 = movieDL.GetUser(Username);
            return result1.Username != null;
        }

        public List<User> GetTitle()
        {
            return _dataService.GetTitle();
        }

        public void AddTitle(string title)
        {
            _dataService.AddTitle(new User { Title = title });
            _emailTool.SendEmail("Movie Added to Watchlist", $"You have successfully added '{title}' to your watchlist.");
        }

        public void DeleteTitle(string title)
        {
            _dataService.DeleteTitle(title);
            _emailTool.SendEmail("Movie Deleted from Watchlist", $"You have successfully deleted '{title}' from your watchlist.");
        }

        public void UpdateTitle(string oldTitle, string newTitle)
        {
            _dataService.UpdateTitle(oldTitle, newTitle);
            _emailTool.SendEmail("Movie Updated in Watchlist", $"You have successfully updated '{oldTitle}' to '{newTitle}' in your watchlist.");
        }
    }
}