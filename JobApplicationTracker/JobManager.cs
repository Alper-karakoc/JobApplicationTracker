//Ska hantera alla jobbansökningar och deras status.
public class JobManager
{
    public List<JobApplication> Applications { get; private set; } = new List<JobApplication>(); // List to store all job applications


    public void AddJob(JobApplication application) // Method to add a new job application
    {
        Applications.Add(application);
    }

    public void ShowAll() //visar alla ansökningar numrerade från 1 
    {
        if (Applications.Count == 0)
        {
            Console.WriteLine("Ingen ansökan registrerad ännu.");
            return;
        }

        for (int i = 0; i < Applications.Count; i++)
        {
            Console.WriteLine($"Ansökan {i + 1}: {Applications[i].GetSummary()}");
        }

    }

    public bool UpdateStatus(int number, Status newStatus) // Method to update the status of a job application
    {
        //användaren ser ansökningarna numrerade från 1, men listan är nollindexerad
        int index = number - 1; // Convert to zero-based index
        if (index < 0 || index >= Applications.Count)

        {
            return false; // Invalid index
        }

        JobApplication application = Applications[index];
        application.Status = newStatus;


        if (newStatus != Status.Applied && application.ResponseDate == null)
        {
            application.ResponseDate = DateTime.Today; // Set the response date to now if the status is not Applied and ResponseDate is null
        }

        return true; // Status updated successfully
    }

    public bool RemoveJob(int number) // Method to remove a job application
    {
        int index = number - 1; // Convert to zero-based index
        if (index < 0 || index >= Applications.Count)
        {
            return false; // Invalid index
        }

        Applications.RemoveAt(index);
        return true; // Job application removed successfully
    }


    Public void ShowByStatus(Status status)
    {
        
        var filtered =  Applications.Where(app => app.Status == status).ToList();
        if (filtered.Count == 0)
        {
            Console.WriteLine($"Ingen ansökan med status {status}.");
            return;
        }

        foreach (var app in filtered)
        {
            Console.WriteLine(app.GetSummary());
        }
    }

    //visar statistik över ansökningarna, t.ex. antal ansökningar, antal per status, etc.
    public void ShowStatistics()
    {
        Console.WriteLine($"Total ansökningar: {Applications.Count}");

        //antal per status
        Console.WriteLine("Antal per status:");
        foreach (Status status in Enum.GetValues<Status>())
        {
            int count = Applications.Count(app => app.Status == status);
            Console.WriteLine($" {status}: {count}");
        }

        //genomsnittlig svarstid
        var answered = Applications.Where (a => (a.ResponseDate != null)).ToList();
        if (answered.Count > 0)
        {
            double averageDays = answered.Average(a => (a.ResponseDate.Value - a.ApplicationDate).TotalDays);
            Console.WriteLine($"Genomsnittlig svarstid: {averageDays:F2} dagar");
        }
        else
        {
            Console.WriteLine("Genomsnittlig svarstid: inga svar än.");
        }

        if (Applications.Count > 0)
        {
            double averageSalary = Applications.Average(a => a.SalaryExpectation);
            Console.WriteLine($"Genomsnittlig löneförväntning: {averageSalary:F0} kr");
        }
       
    }

    //Extrafilter: ansökningar utan svar som är äldre än ett visst antal dagar.
    public void ShowNoResponseOlderThan(int days)
    {
        var overdue = Applications
            .Where(a => a.ResponseDate == null && a.GetDaysSinceApplied() > days)
            .OrderByDescending(a => a.GetDaysSinceApplied())
            .ToList();

        if (overdue.Count == 0)
        {
            
            Console.WriteLine("Inga ansökningar utan svar som är äldre än {days} dagar.");
            return;
        }

        foreach (var app in overdue)
        {
          Console.WriteLine($"{app.GetSummary()} ({app.GetDaysSinceApplied()} dagar sedan)");
        }

    }

}