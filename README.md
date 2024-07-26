# Lab 7: (follow-up lab 4)

## Objective
Acquire practical experience with authentication and authorization by integrating .NET with
Keycloak. Implement functionality for serving static files within your .NET application. Set up and
utilize Azure Blob Storage for local development to manage file uploads and downloads.

## Adding Authentication and Authorization
### Steps:
• Set up Keycloak in a Docker container.
• Configure Keycloak to work with your .NET project.
• Assign roles to each student and teacher within Keycloak.
• Implement authentication to secure the application.
• Restrict access to endpoints based on the roles assigned to users.

## Using Azure Blob Storage Emulator
### Steps:
• Set up an Azure Blob Storage emulator inside a Docker container.
• Configure Azure Blob Storage to handle file storage.
• Modify the database to support storing profile pictures for each user.
• Add endpoints to enable uploading and downloading of user profile images.

## Using Static Files
### Steps:
• Configure static file serving in the ww