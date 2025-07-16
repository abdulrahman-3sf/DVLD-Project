# DVLD - Drivers and Vehicles License Department Management System

A comprehensive desktop application for managing driver and vehicle licenses, built using **C# Windows Forms**, **ADO.NET**, and a **3-tier architecture**.

---

## 📌 Project Description

The **DVLD Project** is a full backend-driven system that simulates the operations of a real **Drivers and Vehicles License Department**. It includes processing applications, scheduling and tracking exams, managing license issuance and renewals, and handling user/admin roles.

This system was built with a **focus on backend development**, database logic, and enterprise-level structure — rather than UI/UX.

---

## 🧰 Tech Stack & Architecture

- **Language**: C#
- **Framework**: .NET Framework
- **UI**: Windows Forms (Presentation Layer)
- **Architecture**: 3-tier (Presentation → Business Logic → Data Access)
- **Database**: SQL Server
- **Data Access**: ADO.NET with **raw SQL queries**
- **Patterns & Techniques**:
  - Full use of **manual SQL statements** (SELECT, INSERT, UPDATE, DELETE)
  - **Delegates and Events** for clean communication
  - **Separation of concerns** with layered architecture
  - **Validation and workflow enforcement** through the business layer

---

## 🧠 Feature Highlights

- **Person Management**  
  Unique individuals by National ID — add, update, delete, and search
- **Application Flow**  
  Covers all stages from applying to receiving a license or retesting
- **License Services**  
  Includes new issuance, renewal, replacement, and international licenses
- **Exam Scheduling & Result Tracking**  
  Vision, theory, and practical tests with full scheduling and rescheduling logic
- **Admin Features**  
  User role management, price editing, license suspension, and full activity logging

For more detail on tables and schema, refer to the **uploaded SQL database schema** in the repo.

---

## 🧠 How the System Is Built (Technical Overview)

- **ADO.NET + SQL**: Used to write and execute all SQL statements manually for better control and understanding of database operations.
- **3-Tier Architecture**:
  - `Presentation Layer`: Handles the UI with Forms
  - `Business Logic Layer (BLL)`: Applies application logic, validations, and delegates
  - `Data Access Layer (DAL)`: Interacts directly with the database using SQL and ADO.NET
- **Delegates and Events**:
  - Implemented to improve communication between layers (e.g., notifying UI after business operation completes)

---

## 💭 Reflection

This project gave me **strong backend experience**, particularly in building realistic systems that involve full database integration and business logic. I estimate that:

- ✅ **Around 60% of the project had a strong and valuable impact** on my learning:
  - Writing manual **SQL queries** for all data operations
  - Using **ADO.NET** securely and efficiently
  - Implementing a **3-tier architecture** with clear separation of concerns
  - Applying **delegates and events** for decoupled communication between layers
  - Handling validations, workflows, and multi-step processes in a realistic way

- ⚠️ The remaining **40% of the project**, while necessary for completing the system, was a mix of:
  - **UI development and repetitive form-based work**, which didn't contribute much to my learning goals
  - And also, some parts were **more confusing**, especially when dealing with complex logic spread across different layers, or managing repeated structures with minor variations.

Although these parts didn’t add as much educational value for me personally, they still gave me a better understanding of the **challenges that come with large-scale backend systems**, such as managing complexity, keeping code organized, and maintaining clarity in logic.

As a **Software Engineering student**, this project helped me grow my backend skills, strengthened my understanding of real-world system design, and gave me a clearer picture of what working on enterprise-level systems really involves.
