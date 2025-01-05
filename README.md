# API Test Automation Framework

## Overview
This repository contains an automated API testing framework built using NUnit to validate a RESTful API, specifically targeting the JSONPlaceholder API. The framework performs basic CRUD operations (GET, POST, PUT, DELETE) and validates the responses against expected results.

## Features
1. **GET Request Validation**
   - Fetches a post using `/posts/1`.
   - Verifies the response status code is 200.
   - Validates the presence and correctness of `userId`, `id`, `title`, and `body` in the response.

2. **POST Request Validation**
   - Creates a new post using `/posts`.
   - Verifies the response status code is 201.
   - Validates the created post details, including `userId`, `title`, and `body`.

3. **PUT Request Validation**
   - Updates a post using `/posts/1`.
   - Verifies the response status code is 200.
   - Validates the updated post details, including `userId`, `title`, and `body`.

4. **DELETE Request Validation**
   - Deletes a post using `/posts/1`.
   - Verifies the response status code is 200 or 204.
   - Ensures the response body is empty, if applicable.

5. **Test Reporting**
   - Generates an HTML report summarizing test results.
   - Includes test names, statuses (Passed/Failed), and timestamps.

6. **Request/Response Logging**
   - Logs the requests and responses for each test case.

---

## Prerequisites
1. **Tools and Frameworks**
   - .NET SDK (version 6.0 or higher)
   - NUnit Framework
   - RestSharp Library
   - Newtonsoft.Json Library

2. **Configuration**
   - Set the API base URL in the `appsettings.json` file:
     ```json
     {
       "BaseUrl": "https://jsonplaceholder.typicode.com"
     }
     ```

3. **IDE**
   - Visual Studio 2022 (or any IDE that supports .NET).

---

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd ApiTestsAutomation
   ```

2. **Install Dependencies**
   - Open the solution in Visual Studio.
   - Restore NuGet packages to install required dependencies.

3. **Update Configuration**
   - Modify `appsettings.json` to set the `BaseUrl` if needed.

4. **Build the Solution**
   - In Visual Studio, select "Build Solution" to ensure the project is ready for testing.

---

## Execution

### Running Tests
1. Open a terminal or use Visual Studio Test Explorer.
2. Run the tests using the following command:
   ```bash
   dotnet test
   ```

### Viewing Test Reports
1. After execution, the HTML report will be generated in the `Reports` folder.
2. Open `test-report.html` in any browser to view detailed results.

---

## Framework Components

### 1. **BaseTests**
   - Handles the test setup and teardown.
   - Loads configurations from `appsettings.json`.
   - Manages test reporting lifecycle.

### 2. **RestClientHelper**
   - Simplifies making HTTP requests (GET, POST, PUT, DELETE).
   - Logs the request details and response for debugging.

### 3. **ReportManager**
   - Generates an HTML report summarizing test results.
   - Includes timestamps, test names, and statuses.

### 4. **PostData**
   - Provides helper methods to generate test payloads for the POST and PUT requests.
