# Job Application Tracker

Ett menybaserat konsolprogram i C# som hjälper användaren att hålla koll på sina jobbansökningar.

# Projektbeskrivning

Programmet låter användaren registrera jobbansökningar, uppdatera status, filtrera, sortera och visa statistik. Projektet visar objektorienterad programmering (klasserna `JobApplication` och `JobManager`), samlingar (`List<T>`) och LINQ.

# Funktioner

 Lägga till, visa, uppdatera status på och ta bort ansökningar
 Filtrera ansökningar efter status (LINQ: `Where`)
 Sortera ansökningar efter datum (LINQ: `OrderBy`)
 Statistik: totalt antal, antal per status, genomsnittlig svarstid och önskad lön (LINQ: `Count`, `Where`, `Average`)
 Extrafilter: ansökningar utan svar som är äldre än 14 dagar
 Färger i konsolen: grön = Offer, röd = Rejected, gul = Interview
 Felhantering av ogiltig inmatning

# Hur man kör programmet

Kräver .NET SDK (projektet använder net10.0).

```bash
git clone https://github.com/Alper-karakoc/JobApplicationTracker.git
cd JobApplicationTracker
dotnet run --project JobApplicationTracker
```

Använd menyn genom att skriva siffran för ditt val och trycka Enter.

# Projektstruktur

- `Status.cs`: enum med Applied, Interview, Offer, Rejected
- `JobApplication.cs`: representerar en enskild ansökan
- `JobManager.cs`: hanterar listan och all logik (inklusive LINQ)
- `Program.cs`: menysystemet

# Git-arbetsflöde

Arbetet gjordes i feature-grenar (`feature-models`, `feature-manager`, `feature-menu`, `feature-linq`, `feature-colors`, `feature-readme`) som slogs ihop via Pull Requests till `development`, och därefter till `main`. Branch protection är aktiverat på `main`.

# Författare

[Alper Karakoc], 2026-10-14

# Reflektion

