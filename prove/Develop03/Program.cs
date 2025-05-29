// Isaac Moore
// In order to "exceed requirements" I've included a csv file that contains every single
// verse in the book of Mormon so you can run the program with any verse they want. You 
// just have to give the reference. 
class Program
{
    static void Main(string[] args)
    {
        string book;
        int chapter;
        int verse;

        Scripture scripture;

        bool validVerse = false;
        // Getting user input. This uses a pretty lazy try catch statement in combination
        // with a while loop to keep prompting until a valid reference is given, as well as 
        // a method to check to see that a verse was actually created based on the reference 
        // they gave. 
        do
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("What book does the verse belong to? Please capitalize booknames as they appear in the book of mormon. ");
                    book = Console.ReadLine();
                    Console.WriteLine("What what chapter is the verse in? ");
                    chapter = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the verse number? ");
                    verse = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Something went wrong. Make sure that chapter and verse numbers" +
                    " are numbers.");
                }
            }


            Reference reference = new Reference(book, chapter, verse);
            scripture = new Scripture(reference);
            if (scripture.CheckValidVerse())
            {
                validVerse = true;
            }
            else
            {
                Console.WriteLine("Something went wrong, and the verse could not be found. Please make" +
                " sure you are inputting the book, chapter, and verse correctly.\n");
            }
        } while (!validVerse);

        Console.WriteLine();
        scripture.DisplayScripture();
        Console.WriteLine("\n");


        // Continually hide words and re-print verse until all words are hidden.
        while (true)
        {
            Console.Write("> ");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "quit" || userInput.ToLower() == "q")
            {
                break;
            }
            scripture.HideWords();
            scripture.DisplayScripture();
            Console.WriteLine("\n");

            if (scripture.AllHidden == true)
            {
                break;
            }
        }
    }
}