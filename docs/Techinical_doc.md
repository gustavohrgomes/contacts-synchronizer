# Synchronize Contacts

## Introduction

Synchronize contacts from MockAPI to Mailchimp, creating a new list named after the developer. The project focuses on creating a backend API with an endpoint `/contacts/sync` to perform the integration with the mail marketing tool of choice, in this case, mailchimp.

## Requirements

#### Functional Requirements:
  - Retrieve contacts (first name, last name, email) from MockAPI.
  - Create a new list in Mailchimp with the developer’s name.
  - Add retrieved contacts to the Mailchimp list.
  - Provide a /contacts/sync endpoint that triggers the sync process and returns the synced contacts in JSON format.

#### Non-functional Requirements:
  - Deploy the application on a free platform (e.g., Fly.io).
  - Ensure the application is secure, efficient, and adheres to RESTful principles.

## Technical Design

### System Architecture
  - Components:
    - MockAPI Integration: Fetch contacts from MockAPI.
    - Mailchimp API Integration: Authenticate and interact with the Mailchimp API to create a list and add contacts.
    - Backend API: ASP.NET Core web server to handle the /contacts/sync endpoint.

  - High-level Design:
    - Use ASP.NET Core for backend implementation.
    - Use the built-in HttpClient for API interactions.
    - Deploy on Fly.io or Azure App Service for scalability and cost-efficiency.