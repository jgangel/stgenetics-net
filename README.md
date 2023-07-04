# Notes
Check the infrastructure repo before running the API, as we need to create the schema defined there.

As the animal endpoints are secured by JWT tokens, it's needed to login via the /auth/login endpoint. If you don't own a user, you can create one via the /auth/register endpoint.

# Needs
.NET 7
SQL Server