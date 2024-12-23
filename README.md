# **Contact Sync Tool**

## **Overview**
This project is a backend application built with ASP.NET Core to synchronize contacts from MockAPI to Mailchimp. The application creates a new list in Mailchimp named after the developer and adds contacts retrieved from MockAPI into this list. It provides a RESTful API endpoint to trigger the synchronization process.

---

## **Features**
- Fetches contacts (First Name, Last Name, Email) from MockAPI.
- Creates a new Mailchimp list named after the developer.
- Adds contacts to the newly created Mailchimp list.
- Provides a `/contacts/sync` endpoint to trigger synchronization.
- Returns a JSON response with the list of synced contacts.

---

## **Technologies Used**
- **Framework**: ASP.NET Core
- **Programming Language**: C#
- **Deployment Platform**: Fly.io
- **Unit and Integration Testing**: xUnit
- **CI/CD**: Github Actions

---

## **API Documentation**
### **Endpoint**: `GET /contacts/sync`
- **Description**: Triggers the synchronization process between MockAPI and Mailchimp.
- **Response**:
  ```json
  [
    {
      "firstName": "John",
      "lastName": "Doe",
      "email": "john.doe@example.com"
    }
  ]
  ```
- **Error Codes**:
  - `500 Internal Server Error`: Issues with external APIs or unexpected server issues.
  - `400 Bad Request`: Invalid configuration or API key errors.

---

## **Setup Instructions**

### **Prerequisites**
- .NET SDK (version 6 or later).
- Fly.io account or Azure App Service account.
- Mailchimp API key.

### **Steps**
1. Clone this repository:
   ```bash
   git clone https://github.com/gustavohrgomes/contacts-synchronizer.git
   ```

2. Navigate to the project directory:
   ```bash
   cd contacts-synchronizer

   ```

3. Configure the application:
   - Add your Mailchimp API key to `appsettings.json`:
     ```json
     {
       "ApplicationSettings": {
         "MailMarketingAddress": "https://us14.api.mailchimp.com/3.0/",
         "MailMarketingAPIKey": "a2V5OjI5N2U0MDVmM2FjZmZkZGVkMjMwNzA1YzcyOGZlMjExLXVzMTQ="
       }
     }
     ```

4. Running the application:
  - Locally
    ```bash
    dotnet run --project .\Contacts.Synchronizer.WebApi\Contacts.Synchronizer.WebApi.csproj 
    ```
  - Aspire
    ```bash
    dotnet run --project .\Contacts.Synchronizer.AppHost\Contacts.Synchronizer.AppHost.csproj 
    ```


---

## **Testing**
- Run unit tests:
  ```bash
  dotnet test
  ```
- Integration tests for the `/contacts/sync` endpoint can be run using Postman or any API testing tool.

---

## **Technical Design Document**
Refer to the full [Technical Design Document](https://link-to-google-doc) for detailed information about the architecture, workflow, and decisions.

---

## **Demo**
The application is deployed and accessible at:
[https://contacts-synchronizer.fly.dev/](https://contacts-synchronizer.fly.dev/swagger/index.html)

---

## **Video Walkthrough**
A video walkthrough of the solution explaining how it works, how it was built, and the design decisions is available here:
[https://drive.google.com/file/d/1Wp2yeYb8ZAu8-rvwo3C2suUE-tw3AOHc/view?usp=sharing](https://drive.google.com/file/d/1Wp2yeYb8ZAu8-rvwo3C2suUE-tw3AOHc/view?usp=sharing)

---

## **License**
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

