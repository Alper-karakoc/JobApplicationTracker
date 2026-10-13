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

}