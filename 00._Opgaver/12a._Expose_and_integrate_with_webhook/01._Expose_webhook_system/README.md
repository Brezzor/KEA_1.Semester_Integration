# Webhook system

This .NET project provides a simple webhook system, with endpoints for registration, registration and testing of webhooks.

## Features

- **Register Webhook:** Add a webhook with a URL and an EventType.
- **Unregister Webhook:** Remove a webhook by its unique identifier.
- **Ping Webhook:** Ping by all, EvenType or unique identifier by sending a test message.

## API Documentation

The webhhook system includes OpenAPI and SwaggerUI. You can use SwaggerUI to explore and to test the API endpoints.

## Accessing API

Contact me on Facebook Messenger:

[Facebook page](https://www.facebook.com/OliverBresson)

I'll run the API and create a LocalTunnel. With the url:

https://brez.loca.lt

## Endpoints overview

1. Get all registered webhooks

   - **Endpoint:** GET /Webhooks
   - **Description:** Retrieves all registered webhooks.

2. Register a webhook

   - **Endpoint:** POST /Webhooks
   - **Description:** Register a new webhook.
   - **Request Body Example:**

   ```
   {
       "Url": "https://example.com/webhook",
       "EventType": "payment_received"
   }
   ```

3. Unregister a webhook

   - **Endpoint:** DELETE /Webhooks/{id}
   - **Description:** Unregisters a webhook by its unique identifier.

4. Ping all webhooks

   - **Endpoint:** POST /Webhooks/ping
   - **Description:** Sends a test message to all registered webhooks.

5. Ping webhooks by EventType

   - **Endpoint:** POST /Webhooks/ping/{eventtype}
   - **Description:** Sends a test message to all registered webhooks with a specific EventType.

6. Ping a webhook by unique identifier

   - **Endpoint:** POST /Webhooks/ping/{id}
   - **Description:** Sends a test message to a specific webhook by its unique identifier.
