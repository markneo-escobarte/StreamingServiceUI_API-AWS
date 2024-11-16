using System;
using System.Threading.Tasks;
using StreamingServiceModel;


namespace StreamingServiceDL
{
    public class MovieDL

    {
        List<User> movie = new List<User>();

        public void MovieTitle()
        {
            User title1 = new User
            {
                Title = "Avengers: Endgame"

            };

            User title2 = new User
            {
                Title = "Avengers: Infinity War"

            };

            User title3 = new User
            {
                Title = "Black Panther"

            };

            User title4 = new User
            {
                Title = "The Avengers"

            };

            User title5 = new User
            {
                Title = "Avengers: Age of Ultron"

            };

            User title6 = new User
            {
                Title = "Iron Man 3"

            };

            User title7 = new User
            {
                Title = "Captain America: Civil War"

            };

            User title8 = new User
            {
                Title = "Spider-Man: Homecoming"

            };

            User title9 = new User
            {
                Title = "Guardians of the Galaxy Vol. 2"

            };

            User title10 = new User
            {
                Title = "Thor: Ragnarok"

            };

            movie.Add(title1);
            movie.Add(title2);
            movie.Add(title3);
            movie.Add(title4);
            movie.Add(title5);
            movie.Add(title6);
            movie.Add(title7);
            movie.Add(title8);
            movie.Add(title9);
            movie.Add(title10);

        }

        public User GetTitle(string Title)
        {
            User foundtitle = new User();
            foreach (var user in movie)
            {
                if (Title == user.Title)
                {
                    foundtitle = user;

                }


            }

            return foundtitle;
        }


        public static void Movie1(string Title)
        {

            Console.WriteLine("-----------------------------------------------------");

            Console.WriteLine("");
            Console.WriteLine("Title: Avengers: Endgame");
            Console.WriteLine("Release Date: April 26, 2019");
            Console.WriteLine("Runtime: 181 minutes");
            Console.WriteLine("Synopsis: The culmination of the Marvel Cinematic Universe's Infinity Saga, Avengers: Endgame sees the surviving Avengers reeling from the events of Infinity War as they attempt to undo Thanos' devastating snap and restore order to the universe.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie2(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Avengers: Infinity War");
            Console.WriteLine("Release Date: April 27, 2018");
            Console.WriteLine("Runtime: 149 minutes");
            Console.WriteLine("Synopsis: Thanos, the powerful intergalactic warlord, seeks to collect all six Infinity Stones to bring balance to the universe by wiping out half of all life. The Avengers and their allies must come together to stop him in this epic showdown.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie3(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Black Panther");
            Console.WriteLine("Release Date: February 16, 2018");
            Console.WriteLine("Runtime: 134 minutes");
            Console.WriteLine("Synopsis: T'Challa returns to his technologically advanced African nation of Wakanda to assume the throne following his father's death. As the new king, he must defend his people and the powerful vibranium resource from external threats, including the vengeful Erik Killmonger.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie4(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: The Avengers");
            Console.WriteLine("Release Date: May 4, 2012");
            Console.WriteLine("Runtime: 143 minutes");
            Console.WriteLine("Synopsis: Nick Fury, the director of S.H.I.E.L.D., assembles a team of superheroes, including Iron Man, Captain America, Thor, Hulk, Black Widow, and Hawkeye, to thwart the villainous Loki's plans to conquer Earth.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie5(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Avengers: Age of Ultron");
            Console.WriteLine("Release Date: May 1, 2015");
            Console.WriteLine("Runtime: 141 minutes");
            Console.WriteLine("Synopsis: Tony Stark's creation, Ultron, an artificial intelligence with a god complex, decides that the only way to save humanity is to eradicate it. The Avengers must unite once again to stop Ultron's plans and confront their own inner demons.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie6(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Iron Man 3");
            Console.WriteLine("Release Date: May 3, 2013");
            Console.WriteLine("Runtime: 130 minutes");
            Console.WriteLine("Synopsis: Tony Stark faces a powerful enemy known as the Mandarin, whose terrorist attacks leave Stark without his suit and gadgets. As he embarks on a journey to reclaim his identity, Stark discovers the true nature of the Mandarin's schemes.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie7(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Captain America: Civil War");
            Console.WriteLine("Release Date: May 6, 2016");
            Console.WriteLine("Runtime: 147 minutes");
            Console.WriteLine("Synopsis: Political pressure mounts to install a system of accountability when the Avengers inadvertently cause collateral damage. This results in a rift between Captain America and Iron Man, leading to an epic clash between former allies.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie8(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Spider-Man: Homecoming");
            Console.WriteLine("Release Date: July 7, 2017");
            Console.WriteLine("Runtime: 133 minutes");
            Console.WriteLine("Synopsis: Peter Parker balances life as a high school student in Queens with his superhero alter ego, Spider-Man. When he encounters the villainous Vulture, Parker must prove himself worthy of being a hero while navigating the challenges of adolescence.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie9(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Guardians of the Galaxy Vol. 2");
            Console.WriteLine("Release Date: May 5, 2017");
            Console.WriteLine("Runtime: 136 minutes");
            Console.WriteLine("Synopsis: Peter Quill and his misfit band of intergalactic heroes embark on a new adventure to uncover the mystery of Quill's parentage while facing cosmic threats and discovering the true meaning of family.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine();
        }

        public static void Movie10(string Title)
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("NOW PLAYING");
            Console.WriteLine("");
            Console.WriteLine("Title: Thor: Ragnarok");
            Console.WriteLine("Release Date: November 3, 2017");
            Console.WriteLine("Runtime: 130 minutes");
            Console.WriteLine("Synopsis: Thor finds himself imprisoned on the other side of the universe without his mighty hammer. To escape captivity and prevent the apocalyptic event known as Ragnarok, Thor must team up with his fellow Avenger, the Hulk, and confront the ruthless goddess of death, Hela.");
            Console.WriteLine("");
            Console.WriteLine("ENJOY WATCHING!");
            Console.WriteLine("-----------------------------------------------------");
        }

    }
}