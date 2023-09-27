# Pokemon Review API

Welcome to the Pokemon Review API! This ASP.NET Core API is built using .NET 6 and allows users to review and rate their favorite Pokemon. Whether you're a Pokemon enthusiast or just curious about what others think, this API provides a platform for sharing your thoughts and opinions on these beloved creatures.

<kbd>![UMLDiagram](https://github.com/ErenKarakaya01/pokemon-review-api/assets/58625563/c263c460-5d1d-4b45-a708-ba1d1e4967d1)
</kbd>

## Getting Started

To get started with the Pokemon Review API, follow these steps:

1. **Prerequisites:**

   - Install [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) on your machine.
   - Clone this repository to your local machine.

2. **Configuration:**

   - Open the `appsettings.json` file and configure your database connection string.
   - You may need to set up a local database or use a cloud-based database service like Azure SQL.

3. **Database Migration:**

   - Run the following command to apply database migrations and create the necessary tables:

     ```shell
     dotnet ef database update
     ```

4. **Run the API:**

   - Navigate to the project directory and run the following command:

     ```shell
     dotnet run
     ```

   - The API should now be running locally at `https://localhost:5001`.

## Usage

The Pokemon Review API allows you to:

- Create a new Pokemon review.
- Read reviews for a specific Pokemon.
- Update your review for a Pokemon.
- Delete your review for a Pokemon.
- List all Pokemon available for reviewing.

## Endpoints

Here are a few of the API endpoints and their descriptions:

- `GET /api/pokemon`: Get a list of all available Pokemon.
- `GET /api/pokemon/{id}`: Get details for a specific Pokemon by its ID.
- `GET /api/pokemon/{id}/reviews`: Get reviews for a specific Pokemon by its ID.
- `POST /api/reviews`: Create a new review for a Pokemon.
- `PUT /api/reviews/{id}`: Update your review by its ID.
- `DELETE /api/reviews/{id}`: Delete your review by its ID.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Enjoy using the Pokemon Review API, and happy reviewing! If you have any questions or encounter issues, please don't hesitate to [open an issue](https://github.com/ErenKarakaya01/pokemon-review-api/issues).
