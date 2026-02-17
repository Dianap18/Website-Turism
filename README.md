# Travel Booking Platform

## About the Project
A Full Stack web application dedicated to travel bookings. It functions as an interactive catalog where users can explore destinations, read reviews, and check accommodation availability in real-time.

## Tech Stack & Architecture
The system relies on a strict Client-Server architecture, separating the business logic from the user interface.

* **Backend:** Built with .NET Core and C#. It functions as a RESTful API.
* **Database:** SQL Server, managed via Entity Framework Core (includes automatic data seeding).
* **Design Pattern:** The `BookingManager` uses the Singleton design pattern to ensure centralized, thread-safe management of all reservations.
* **Frontend:** Built with React.js as a Single Page Application (SPA). Uses React Hooks (`useState`, `useEffect`) for state management and `fetch` for asynchronous API calls.

## API Endpoints
* `GET /api/destinations` - Retrieve the list of available offers.
* `GET /api/destinations/{slug}` - Retrieve complete details for a specific offer.
* `POST /api/bookings` - Submit and save a new booking.

## Getting Started
1. **Backend:** Configure your SQL Server connection string in `appsettings.json` and run the .NET project. The database will seed automatically.
2. **Frontend:** Open a terminal in the React project folder, run `npm install`, and then `npm run dev`.
3. The application will be accessible at `http://localhost:5173`.
