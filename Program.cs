using System.IO;

namespace TextEditor;

class Program
{
    static void Main(string[] args){
        Menu();
    }
    static void Menu() {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("TEXT EDITOR");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("[1] - Open an arquive");
        Console.WriteLine("[2] - Create a new arquive");
        Console.WriteLine("[0] - Exit");
        Console.WriteLine("");
        short option = short.Parse(Console.ReadLine());

        switch(option) {
            case 0: System.Environment.Exit(0); break;
            case 1: Open(); break;
            case 2: Edit(); break;
            default: Menu(); break;
        }
    }
    static void Open(){
        Console.Clear();
        Console.WriteLine("What's the path of the arquive?");
        string path = Console.ReadLine();

        using(var file = new StreamReader(path)){
            string text = file.ReadToEnd(); // It'll read the text, last to the end.
            Console.WriteLine(text);
        }
        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }
    static void Edit(){
        Console.Clear();
        Console.WriteLine("PRESS THE KEY 'ESC' TO EXIT THE TEXT");
        Console.WriteLine("Type your text below: ");
        Console.WriteLine("----------------------");

        string text = ""; // Users text it's allocated on variable "text".
        
        do {
            text += Console.ReadLine(); // Read a line of the user's write.
            text += Environment.NewLine; // Breaking a line in each readline.
        } while (Console.ReadKey().Key != ConsoleKey.Escape); // While the key isn't the ESC key.

        Save(text);
    }
    static void Save(string text){
        Console.Clear();
        Console.WriteLine("What's the path do you want to save your arquive?"); 
        var path = Console.ReadLine();

        using(var file = new StreamWriter(path)) { // Stream of bites.
            file.Write(text); // Write in arquive.
        } // The using parameter it'll open and close an arquive.
        Console.WriteLine($"The arquive {path} was saved with success!");
        Console.WriteLine("Press the key [Enter] for return to the Menu");
        Console.ReadLine();
        Menu();
    }
}