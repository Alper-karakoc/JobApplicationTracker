

//representerar bara en jobbansökan
public class JobApplication
{
    // Properties for the company name, position, and application status
    // Olika attributer 
    public string CompanyName { get; set; }
    public string PositionTitle { get; set; }
    public Status Status { get; set; }
    public DateTime ApplicationDate { get; set; } // The date the application was submitted.
    public DateTime? ResponseDate { get; set; } // Kan vara null om det inte finns något svar än.
    public int SalaryExpectation { get; set; } // The salary offered for the position, if applicable.

    public JobApplication(string companyName, string positionTitle,  DateTime applicationDate, int salaryExpectation)
    {
        CompanyName = companyName;
        PositionTitle = positionTitle;
        Status = Status.Applied; // Default status is Applied when a new application is created.
        ApplicationDate = applicationDate;
        ResponseDate = null; // Initialize ResponseDate as null since there may not be a response yet.
        SalaryExpectation = salaryExpectation;
    }

    public int GetDaysSinceApplied() // Method to calculate the number of days since the application was submitted
    {
        return (DateTime.Now - ApplicationDate).Days;
    }
    
    public string GetSummary() // retunerar en kort sammanfattning av ansökan
    {
        string responseDateStr = ResponseDate.HasValue ? ResponseDate.Value.ToShortDateString() : "No response yet";
        return $"Company: {CompanyName}, Position: {PositionTitle}, Status: {Status}, Applied on: {ApplicationDate.ToShortDateString()}, Response Date: {responseDateStr}, Salary Expectation: {SalaryExpectation} kr";
    }



}