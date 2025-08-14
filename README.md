# Residences Management System

## 📌 Overview
Residences Management System is a C# desktop application designed to manage and track residencies for individuals and employees.  
It records issuance and expiration dates, residency status, and stores related images.  
The system also sends email notifications (variable) days before a residency expires** through a dedicated console application.

---

## ✨ Features
- **Residency Management**: Add, edit, and delete residency records with full details and images.
- **People & Employee Management**: Maintain records for both individuals and employees.
- **Expiration Tracking**: Automatically detects residencies that are close to expiring.
- **Email Alerts**: Sends notification emails 15 days before expiration.
- **Search & Filtering**: Powerful filtering and search capabilities in multiple forms (People, Employees, Residencies).
- **Layered Architecture**: Separated into Data Layer, Business Layer, and Presentation Layer for better maintainability.
- **Dynamic Image Storage**: Images are stored dynamically based on the project’s root folder, ensuring portability.
- **Automatic Backups**: Both the SQL database file and residency image files are saved:
  - Inside the project directory.
  - As an additional backup copy on the `C:` drive for extra safety.
- **Layered Architecture**: Separated into Data Layer, Business Layer, and Presentation Layer for better maintainability.

---

## 💾 Backup & Storage
- The application ensures data safety by maintaining **two copies** of important files:
  1. **Primary copy**: Stored within the project’s directory.
  2. **Backup copy**: Automatically saved to a dedicated folder on the `C:` drive after any transaction.
- Files covered by the backup process:
  - **SQL database file**.
  - **Residency image files**.
- Image paths are saved dynamically in the database (relative to the project root), so the application can be easily moved to a different location without breaking links.

---

## 🛠 Technologies Used
- **Language**: C#
- **Framework**: .NET Framework
- **Database**: SQL Server
- **Architecture**: 3-Layer Architecture (Data, Business, Presentation)
- **UI Framework**: Windows Forms

---

## 📂 Project Structure
- **Data Layer**: Handles database connections, queries, and data retrieval.
- **Business Layer**: Contains application logic, validation, and processing rules.
- **Presentation Layer**: UI forms for interacting with the user.
- **ResidencesNotifier**: A separate console application dedicated to sending automatic email alerts.

---

## 🚀 Installation & Setup
1. **Restore the Database**  
   - Go to the `Database` folder in the project files.  
   - Restore the provided `.bak` file to your SQL Server.

2. **Update the Connection String**  
   - Open the `App.config` file.  
   - Locate the `<connectionStrings>` section.  
   - Update `MyDbConnection` with your SQL Server instance and database name.

3. **Build & Run the Application**  
   - Open the project in Visual Studio.  
   - Build the solution (`Ctrl + Shift + B`).  
   - Run the application (`F5`).

---

## 📧 Email Notification Setup
The system includes an **independent console application** called **`ResidencesNotifier`**, specifically created to run through **Windows Task Scheduler** for automated email notifications.

- **Purpose**: Automatically send alerts about residencies that will expire within a set number of days (default: 30 days).
- **Integration**:
  - This console project calls the same business logic as the main app (`SendResidencesExpiryAlert(int Days)`).
  - Can be scheduled to run **daily** or at **system startup** via Task Scheduler.
- **Setup Steps**:
  1. Open the `ResidencesNotifier` project and configure:
     - Sender email.
     - Password (App Password for Gmail).
     - Recipient email.
  2. Build the console project.
  3. Create a Task in **Task Scheduler**:
     - Set the trigger (daily, weekly, or at startup).
     - Point the action to the built `.exe` file of the `ResidencesNotifier`.
  4. Test it manually before relying on automated scheduling.

---

## 📄 License
This project is public and for educational purposes.
