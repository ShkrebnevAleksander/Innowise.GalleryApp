# Gallery App on .NET MAUI

This project is a mobile photo gallery application developed as a technical assessment for an Intern position. The application allows users to browse images fetched from the Unsplash API, view details, and manage a list of their favorite photos locally.

The app is built using .NET 9 and .NET MAUI, following modern development practices such as the MVVM architectural pattern and SOLID principles.

---

## Features

*   **Image Gallery:** Displays an infinite-scrolling grid of photos from the Unsplash API.
*   **Pagination:** Automatically loads more photos as the user scrolls to the end of the list.
*   **Image Details:** Users can tap on any photo to view a larger version with its description and author details.
*   **Favorites System:** A heart-shaped button on the detail screen allows users to add or remove photos from their favorites. Favorite status is indicated on the main gallery screen.
*   **Data Persistence:** The list of favorite photos is saved locally on the device using `.NET MAUI Essentials: Preferences`.

### Additional Features Implemented
Beyond the stated requirements, the following features were added to improve user experience:
*   **Favorites Tab:** A dedicated "Favorites" screen was implemented, accessible via a bottom TabBar, to display all favorited images in one place.
*   **Real-time UI Updates:** The UI on the main gallery screen instantly reflects changes made to the favorites list on the detail screen.

---

## Technical Overview

*   **Framework:** .NET 9 & .NET MAUI
*   **Language:** C#
*   **Architecture:** Model-View-ViewModel (MVVM)
*   **Key Libraries:** `CommunityToolkit.Mvvm` for modern MVVM implementation (ObservableObject, RelayCommand, etc.).
*   **API:** Unsplash REST API for fetching image data.
*   **Asynchronous Programming:** All network and long-running operations are handled asynchronously using `async`/`await` to ensure a responsive UI.
*   **Dependency Injection:** Services and ViewModels are registered and resolved using the built-in DI container.

---

## Configuration

To run this application, you must provide your own **Unsplash API Access Key**.

1.  **Get an Access Key:** Register as a developer on the [Unsplash Developers portal](https://unsplash.com/developers) and create a new application to receive your key.

2.  **Set the API Key:** Open the `UnsplashService.cs` file located in the `Services` folder and replace the placeholder with your actual key:

    ```csharp
    // In Services/UnsplashService.cs
    private const string ApiKey = "YOUR_UNSPLASH_ACCESS_KEY";
    ```

---

## How to Run

1.  Clone this repository.
2.  Open the solution file (`.sln`) in a compatible version of Visual Studio 2022 (with the .NET MAUI workload installed).
3.  Configure the Unsplash API key as described in the **Configuration** section above.
4.  Build the project to restore NuGet packages.
5.  Select a target to run on (Android emulator or a physical device).
6.  Press the "Run" button to deploy and start the application.

---

## Project Overview & Contact

*   **Developer:** Shkrebnev Aleksandr
*   **Contact:** Email:shkrebnev.aleksander@gmail.com / Telegram: @NoTimeTDie
*   **GitHub Profile:** https://github.com/ShkrebnevAleksander
