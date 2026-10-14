// using System.Linq;

// var manager = new JobManager();
// manager .AddJob(new JobApplication ("Company A", "Software Engineer", DateTime.Now.AddDays(-10), 60000));
// manager .AddJob(new JobApplication ("Company B", "Data Analyst", DateTime.Now.AddDays(-5), 55000));

// manager.ShowAll();

// manager.UpdateStatus(1, Status.Interviewing);
// Console.WriteLine();
// manager.ShowAll();


// manager.RemoveJob(2);
// Console.WriteLine();
// manager.ShowAll();

// Program.cs - menybaserad konsolapplikation för Job Application Tracker

var manager = new JobManager();
bool running = true;

// Huvudloopen: körs tills användaren väljer att avsluta
while (running)
{
    ShowMenu();
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddApplication();
            break;
        case "2":
            Console.WriteLine();
            manager.ShowAll();
            break;
        case "3":
            FilterByStatus();
            break;
        case "4":
            Console.WriteLine();
            manager.ShowSortedByDate();
            break;
        case "5":
            Console.WriteLine();
            manager.ShowStatistics();
            break;
        case "6":
            UpdateApplicationStatus();
            break;
        case "7":
            RemoveApplication();
            break;
        case "8":
            Console.WriteLine();
            manager.ShowNoResponseOlderThan(14);
            break;
        case "0":
            Console.WriteLine("Programmet avslutas. Hejdå!");
            running = false;
            break;
        default:
            Console.WriteLine("Ogiltigt val, försök igen.");
            break;
    }
}

// Menyn 

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== JOB APPLICATION TRACKER =====");
    Console.WriteLine("1. Lägg till ny ansökan");
    Console.WriteLine("2. Visa alla ansökningar");
    Console.WriteLine("3. Filtrera ansökningar efter status");
    Console.WriteLine("4. Sortera ansökningar efter datum");
    Console.WriteLine("5. Visa statistik");
    Console.WriteLine("6. Uppdatera status på en ansökan");
    Console.WriteLine("7. Ta bort en ansökan");
     Console.WriteLine("8. Visa ansökningar utan svar äldre än 14 dagar");   // NY RAD
    Console.WriteLine("0. Avsluta");
    Console.Write("Välj: ");
}

//Menyval 

void AddApplication()
{
    string company = ReadText("Företag: ");
    string position = ReadText("Befattning: ");
    DateTime date = ReadDate("Ansökningsdatum (yyyy-MM-dd): ");
    int salary = ReadInt("Önskad lön (kr): ");

    manager.AddJob(new JobApplication(company, position, date, salary));
    Console.WriteLine("Ansökan har lagts till!");
}

void UpdateApplicationStatus()
{
    if (manager.Applications.Count == 0)
    {
        Console.WriteLine("Det finns inga ansökningar att uppdatera.");
        return;
    }

    manager.ShowAll();
    int number = ReadInt("Nummer på ansökan: ");

    Console.WriteLine("1. Applied  2. Interview  3. Offer  4. Rejected");
    int statusChoice = ReadInt("Ny status: ");

    if (statusChoice < 1 || statusChoice > 4)
    {
        Console.WriteLine("Ogiltig status.");
        return;
    }

    // Menyn börjar på 1, enum-värdena på 0, därför - 1
    Status newStatus = (Status)(statusChoice - 1);

    if (manager.UpdateStatus(number, newStatus))
        Console.WriteLine("Status uppdaterad!");
    else
        Console.WriteLine("Det finns ingen ansökan med det numret.");
}

void RemoveApplication()
{
    if (manager.Applications.Count == 0)
    {
        Console.WriteLine("Det finns inga ansökningar att ta bort.");
        return;
    }

    manager.ShowAll();
    int number = ReadInt("Nummer på ansökan som ska tas bort: ");

    if (manager.RemoveJob(number))
        Console.WriteLine("Ansökan borttagen!");
    else
        Console.WriteLine("Det finns ingen ansökan med det numret.");
}



void FilterByStatus()
{
    Console.WriteLine("1. Applied  2. Interview  3. Offer  4. Rejected");
    int choice = ReadInt("Välj status att filtrera på: ");

    if (choice < 1 || choice > 4)
    {
        Console.WriteLine("Ogiltig status.");
        return;
    }

    Console.WriteLine();
    manager.ShowByStatus((Status)(choice - 1));
}





string ReadText(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(input))
            return input.Trim();

        Console.WriteLine("Fältet får inte vara tomt.");
    }
}

int ReadInt(string prompt)
{
    while (true)
    {
        Console.Write(prompt);

        if (int.TryParse(Console.ReadLine(), out int result) && result >= 0)
            return result;

        Console.WriteLine("Ange ett heltal (0 eller större).");
    }
}

DateTime ReadDate(string prompt)
{
    while (true)
    {
        Console.Write(prompt);

        if (DateTime.TryParse(Console.ReadLine(), out DateTime result))
            return result;

        Console.WriteLine("Ogiltigt datum. Skriv t.ex. 2026-10-13.");
    }
}