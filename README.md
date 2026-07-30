# ASP.NET Core Web API & Cosmos DB Template

A clean, production-ready project template for building Web APIs with ASP.NET Core and Azure Cosmos DB using the native `Microsoft.Azure.Cosmos` SDK. It includes secure local configuration structures.

## Features

- **Native SDK Integration**: High-performance, thread-safe `CosmosClient` setup.
- **Fail-Fast Configuration**: Immediate validation on startup to catch missing settings early.
- **Zero Secret Leakage**: Configured natively to leverage .NET User Secrets for safe local development.

---

## Local Development Setup

### 1. Prerequisites

- [.NET 8.0 SDK](https://microsoft.com) (or higher)
- [Azure Cosmos DB Emulator](https://microsoft.com) running locally.

### 2. Configure Local User Secrets

Do not add real connection keys to `appsettings.json`. Run these commands in your terminal at the **project folder level** (where the `.csproj` file lives) to map your local database emulator safely:

```bash
# Initialize User Secrets
dotnet user-secrets init

# Set local Cosmos DB Emulator credentials
dotnet user-secrets set "CosmosDb:Account" "YOUR_EMULATOR_URI"
dotnet user-secrets set "CosmosDb:Key" "YOUR_EMULATOR_PRIMARY_KEY"
```

### 3. Verify Configuration

To ensure your secrets are mapped and stored safely outside the repository directory, run:

```bash
dotnet user-secrets list
```

### 4. Run the Application

Return to your solution root directory and boot up the API:

```bash
dotnet run --project Catalog.API
```

Open your browser and navigate to `https://localhost:xxxx/swagger` to interact with the API endpoints.
