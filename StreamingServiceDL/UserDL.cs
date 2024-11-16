using System;
using System.Threading.Tasks;
using StreamingServiceModel;


namespace StreamingServiceDL
{
    public class UserDL

    {
        List<User> dummyUser = new List<User>();

        public UserDL()
        {
            CreateDummyUser();
        }

        public void CreateDummyUser()
        {
            User user1 = new User
            {
                Username = "Neo",
                Password = "hello"
            };

            User user2 = new User
            {
                Username = "User",
                Password = "hello"
            };

            dummyUser.Add(user1);
            dummyUser.Add(user2);

        }

        public User GetUser(string Username)
        {
            User foundUser = new User();
            foreach (var user in dummyUser)
            {
                if (Username == user.Username)
                {
                    foundUser = user;

                }
            }

            return foundUser;
        }
    }
}