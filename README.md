Authentication Process.
The UserServer connects to the UserClient to receive a username and password. The process differs slightly depending on whether the client is attempting to log in or create a new account.

Login
The client sends the username and password to the server.
The server retrieves the salt associated with the username from the PostgreSQL database.
The server hashes the provided password using the retrieved salt.
The server checks if the hashed password matches the one stored in the database.
If the credentials are correct, the server responds with true. Otherwise, it responds with false.
Account Creation
The client sends a new username and password to the server.
The server generates a salt and hashes the provided password with it.
The server stores the username, hashed password, and salt in the PostgreSQL database.
The new account is created, and the client can use the username and password to log in subsequently.
By using this method, passwords are securely hashed and salted, ensuring that the original passwords are not stored in plain text in the database. This enhances security by protecting user data even if the database is compromised.
