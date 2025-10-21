# WarhammerStats

CLI tool for parsing Warhammer lists.

## Getting Started

Clone the repo:

```bash
git clone https://github.com/<your-username>/<your-repo>.git
cd <your-repo>
```

## Build and Run

```
dotnet build
```

checks if the program is working
```
dotnet run --project src/WarhammerStats.Cli -- status
```

checks the current version of the programm
```
dotnet run --project src/WarhammerStats.Cli -- version
```

updates data
```
dotnet run --project src/WarhammerStats.Cli -- update-units 