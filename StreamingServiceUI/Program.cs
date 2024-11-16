using Org.BouncyCastle.Security;
using StreamingServiceBL;
using StreamingServiceDL;
using StreamingServiceModel;
using System;

namespace StreamingServiceUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlDbData.Connect();

            bool loggedIn = false;
            while (true)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("            Welcome to Marvel Assemble!");
                Console.WriteLine("Binge Worthy Marvel Cinematic Universe Movies Below!");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------");

                Console.Write("Enter your username: ");
                string Username = Console.ReadLine();

                Console.Write("Enter your password: ");
                string Password = Console.ReadLine();

                MovieBL movieBL1 = new MovieBL();
                bool result1 = movieBL1.VerifyUser(Username, Password);

                SqlDbData dataService = new SqlDbData();

                if (result1)
                {
                    loggedIn = true;
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Welcome back " + Username);
                    Console.WriteLine();
                    Console.WriteLine("Available Movies: ");
                    Console.WriteLine("1. Avengers: Endgame");
                    Console.WriteLine("2. Avengers: Infinity War");
                    Console.WriteLine("3. Black Panther");
                    Console.WriteLine("4. The Avengers");
                    Console.WriteLine("5. Avengers: Age of Ultron");
                    Console.WriteLine("6. Iron Man 3");
                    Console.WriteLine("7. Captain America: Civil War");
                    Console.WriteLine("8. Spider-Man: Homecoming");
                    Console.WriteLine("9. Guardians of the Galaxy Vol. 2");
                    Console.WriteLine("10. Thor: Ragnarok");
                    Console.WriteLine();
                    Console.WriteLine("Type 'quit' to exit app.");
                    Console.WriteLine("-----------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("-----------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("It seems the username or password that you input is invalid.");
                    Console.WriteLine();

                }

                while (loggedIn)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please choose an action below: ");
                    Console.WriteLine("");
                    Console.WriteLine("1. add - Add a movie to watchlist");
                    Console.WriteLine("2. delete - Remove a movie from watchlist");
                    Console.WriteLine("3. view - View watchlist");
                    Console.WriteLine("4. quit - log out profile");
                    Console.WriteLine("5. update - Update watchlist");
                    Console.WriteLine("");
                    Console.Write("Enter your action here: ");
                    string action = Console.ReadLine();

                    if (action == "add")
                    {
                        Console.WriteLine("");
                        Console.Write("Enter a movie title here: ");
                        string Title = Console.ReadLine();

                        dataService.AddTitle(new User { Title = Title });

                        Console.WriteLine("");
                        Console.WriteLine("-----------------------------------------------------");

                        switch (Title)
                        {
                            case "Avengers: Endgame":
                                MovieDL.Movie1(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Avengers: Infinity War":
                                MovieDL.Movie2(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;

                            case "Black Panther":
                                MovieDL.Movie3(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "The Avengers":
                                MovieDL.Movie4(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Avengers: Age of Ultron":
                                MovieDL.Movie5(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Iron Man 3":
                                MovieDL.Movie6(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Captain America: Civil War":
                                MovieDL.Movie7(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Spider-Man: Homecoming":
                                MovieDL.Movie8(Title);
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Guardians of the Galaxy Vol. 2":
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;


                            case "Thor: Ragnarok":
                                Console.WriteLine($"{Title} successfully added to your watchlist.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;

                            default:
                                Console.WriteLine("-----------------------------------------------------");
                                Console.WriteLine();
                                Console.WriteLine("It seems the movie that you input is invalid. Please try again.");
                                Console.WriteLine();
                                Console.WriteLine("-----------------------------------------------------");
                                break;
                        }

                        if (Title.ToLower() == "quit")
                        {
                            loggedIn = false;
                            Console.WriteLine(Username + " has logged out");
                            Console.WriteLine();

                        }


                    }
                    else if (action == "delete")
                    {
                        Console.WriteLine("");
                        Console.Write("Enter a movie title here to delete: ");
                        string Title = Console.ReadLine();

                        dataService.DeleteTitle(Title);

                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine("");
                        Console.WriteLine($"{Title} successfully deleted from your watchlist.");
                        Console.WriteLine("");
                        Console.WriteLine("-----------------------------------------------------");

                        if (Title.ToLower() == "quit")
                        {
                            loggedIn = false;
                            Console.WriteLine("");
                            Console.WriteLine(Username + " has logged out");
                            Console.WriteLine();

                        }

                    }

                    else if (action == "view")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("My Watchlist: ");


                        int movieIndex = 1;

                        foreach (var addedTitle in dataService.GetTitle())
                        {
                            Console.WriteLine($"{movieIndex++}: {addedTitle.Title}");

                        }

                        Console.WriteLine("");
                        Console.Write("Type 'quit' to log out or press Enter to continue: ");
                        string Title = Console.ReadLine();

                        if (Title.ToLower() == "quit")
                        {
                            loggedIn = false;
                            Console.WriteLine("");
                            Console.WriteLine(Username + " has logged out");
                            Console.WriteLine();

                        }

                    }
                    else if (action == "update")
                    {
                        Console.WriteLine("");
                        Console.Write("Enter the current movie title: ");
                        string oldTitle = Console.ReadLine();

                        Console.WriteLine("");
                        Console.Write("Enter the new movie title: ");
                        string newTitle = Console.ReadLine();

                        dataService.UpdateTitle(oldTitle, newTitle);

                        Console.WriteLine("-----------------------------------------------------");
                        Console.WriteLine($"{oldTitle} successfully updated to {newTitle} in your watchlist.");
                        Console.WriteLine("-----------------------------------------------------");


                        Console.WriteLine("");
                        Console.Write("Type 'quit' to log out or press Enter to continue: ");
                        string Title = Console.ReadLine();

                        if (Title.ToLower() == "quit")
                        {
                            loggedIn = false;
                            Console.WriteLine("");
                            Console.WriteLine(Username + " has logged out");
                            Console.WriteLine();

                        }

                    }

                    else if (action.ToLower() == "quit")
                    {
                        loggedIn = false;
                        Console.WriteLine("");
                        Console.WriteLine(Username + " has logged out");
                        Console.WriteLine();
                    }



                    else
                    {
                        Console.WriteLine("It appears that the action you requested is invalid.");
                    }




                }
            }

            

        }
    }
}
