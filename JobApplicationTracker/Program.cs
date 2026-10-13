var manager = new JobManager();
manager .AddJob(new JobApplication ("Company A", "Software Engineer", DateTime.Now.AddDays(-10), 60000));
manager .AddJob(new JobApplication ("Company B", "Data Analyst", DateTime.Now.AddDays(-5), 55000));

manager.ShowAll();

manager.UpdateStatus(1, Status.Interviewing);
Console.WriteLine();
manager.ShowAll();


manager.RemoveJob(2);
Console.WriteLine();
manager.ShowAll();