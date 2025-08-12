# Residences Management System

## 📌 Overview
Residences Management System is a C# desktop application designed to manage and track residencies for individuals and employees.  
It records issuance and expiration dates, residency status, and stores related images.  
The system also sends email notifications **15 days before a residency expires**.

---

## ✨ Features
- **Residency Management**: Add, edit, delete residency records with full details and images.
- **People & Employee Management**: Maintain records for both individuals and employees.
- **Expiration Tracking**: Automatically detects residencies that are close to expiring.
- **Email Alerts**: Sends notification emails 15 days before expiration.
- **Search & Filtering**: Powerful filtering and search capabilities in multiple forms (People, Employees, Residencies).
- **Layered Architecture**: Separated into Data Layer, Business Layer, and Presentation Layer for better maintainability.

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
The application automatically checks for residencies expiring within 15 days and sends email alerts.  
To enable email notifications:
- Configure your email sender details in the application’s email settings at:
  (1- ResidencesNotifier Project, which is a console project and link the exe with task scheduler 2- ResidenceManagement form which is frmMainScreen => SendResidencesExpiryAlert(int Days) function).
- Make sure the application runs daily (either manually or via Task Scheduler for automated execution).

---


## 📄 License
This project is public and for educational purposes.  
---
