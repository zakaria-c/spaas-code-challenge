

# SPaaS-challenge

This README file provides detailed instructions on how to set up, run, and test the solution.

## Table of Contents

1. [Prerequisites](#prerequisites)
2. [Installation](#installation)
3. [Running the Application](#running-the-application)
4. [Testing](#testing)

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/zakaria-c/spaas-code-challenge.git
   ```

2. **Restore dependencies**

   Open a terminal in the project directory and run:

   ```bash
   cd spaas-code-challenge
   cd src
   cd Engie.PowerPlant.Api
   dotnet restore
   ```

## Running the Application

1. **Build the application**

   ```bash
   dotnet build
   ```

2. **Run the application**

   ```bash
   dotnet run
   ```

   The API will be available at `http://localhost:8888/swagger/index.html`.

## Testing

To run the tests, use the following command:

   ```bash
   dotnet test
   ```

---

Feel free to customize this README file to better suit your project's needs.
