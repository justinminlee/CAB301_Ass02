using System;

public class TestMovie
{
    public static void Main(string[] args)
    {

        //Testing Moive.cs
        Console.WriteLine("Testing MovieCollection.cs \n\n" + "---------------------\n");

        // create a new movie collection
        IMovieCollection collection = new MovieCollection();

        Console.WriteLine("Number of movies in moviecollection: " + collection.Number);

        // add some movies to the collection
        IMovie movie1 = new Movie("The Shark", MovieGenre.Drama, MovieClassification.M, 142, 2);
        IMovie movie2 = new Movie("The Man", MovieGenre.Action, MovieClassification.M15Plus, 175, 2);
        IMovie movie3 = new Movie("The Women", MovieGenre.Comedy, MovieClassification.M15Plus, 152, 1);
        IMovie movie4 = new Movie("The Dog", MovieGenre.History, MovieClassification.G, 154, 1);
        IMovie movie5 = new Movie("The Cat", MovieGenre.Western, MovieClassification.PG, 178, 2);
        

        bool inserted1 = collection.Insert(movie1);
        bool inserted2 = collection.Insert(movie2);
        bool inserted3 = collection.Insert(movie3);
        bool inserted4 = collection.Insert(movie4);
        bool inserted5 = collection.Insert(movie5);

        Console.WriteLine("Number of movies in moviecollection after adding: " + collection.Number);

        // try to add duplicate movies to the collection
        bool inserted6 = collection.Insert(movie1);
        bool inserted7 = collection.Insert(movie3);
        bool inserted8 = collection.Insert(movie5);

        Console.WriteLine("Number of movies in moviecollection after adding duplicate movies: " + collection.Number);

        // delete a movie from the collection
        bool deletedMovie = collection.Delete(movie3);
        Console.WriteLine("The Women deleted from collection: {0}", deletedMovie);

        // try to delete a non-existing movie from the collection
        bool deletedMovie2 = collection.Delete(movie3);
        Console.WriteLine("Non-existing movie deleted from collection: {0}", deletedMovie2);

        Console.WriteLine("Number of movies in moviecollection after deleting: " + collection.Number);

        // search for a movie in the collection
        IMovie? foundMovie = collection.Search("The Cat");
        Console.WriteLine("Search for 'The Cat': {0}", foundMovie != null ? "found" : "not found");

        // calculate the total number of DVDs in the collection
        int totalDVDs = collection.NoDVDs();
        Console.WriteLine("Total number of DVDs in collection: {0}", totalDVDs);

        // get an array of movies sorted by title
        IMovie[] sortedMovies = collection.ToArray();
        Console.WriteLine("Movies in collection sorted by title:");
        foreach (IMovie movie in sortedMovies)
        {
            Console.WriteLine("- {0} ({1})", movie.Title, movie.Genre);
        }
        
        // clear the collection
        collection.Clear();
        Console.WriteLine("Collection cleared: {0}", collection.IsEmpty());

        Console.WriteLine(collection.Number); 
    }
}