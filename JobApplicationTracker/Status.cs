

// This file defines the Status enum used in the JobApplicationTracker application.
public enum Status
{
    Applied, // The application has been submitted.
    Interviewing, // The applicant is currently in the interview process.
    Offered, // The applicant has received a job offer.
    Rejected, // The application has been rejected.
    Accepted // The applicant has accepted the job offer.
}