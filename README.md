# Electricity Incident Management System (EIMS)

## 📘 Overview

This project is a comprehensive system designed for an electricity company to **manage and monitor cutting down (outage) incidents** across its network infrastructure. It involves test data generation, data migration from staging to production-like databases, incident tracking, and an interactive web portal for incident search and management.

The system is built for **high performance, data integrity, and scalability**, handling large datasets efficiently and securely.

---

## 🧩 System Components

### 1. **Staging Tables Area (STA)**
- Temporary area for ingesting and preparing test data.
- Includes incidents from:
  - `Cutting_Down_A` (Cabins - Source A)
  - `Cutting_Down_B` (Cables - Source B)
- If `EndDate` is null → **Open incident**, else → **Closed incident**

### 2. **Fact Tables Area (FTA)**
- Production-level structured storage for historical and current data.
- Stores incidents in:
  - `Cutting_Down_Header` and `Cutting_Down_Detail` (Valid network elements)
  - `Cutting_Down_Ignored` (Invalid/undefined network elements)

---

## ✅ Features

### 🔗 REST API Services
- Built with **C# (.NET Core / Web API)**
- Endpoints to:
  - Generate test incidents for STA (`Cutting_Down_A`, `Cutting_Down_B`)
  - Rate limiting (requests/sec and bandwidth/IP)
  - Best data compression & serialization practices (e.g., GZip, JSON/BSON)
  - Security best practices (SQL injection prevention, IP filtering)

---

### 🖥️ Console Application
- Continuously runs to automate the sync process.
- Uses:
  - Multithreading, parallelism, and concurrency
  - Calls REST APIs for test data generation
  - Executes stored procedures:
    - `SP_Create` (Insert new incidents to FTA)
    - `SP_Close` (Update closed incidents in FTA)

---

### 🧠 SQL Server Stored Procedures & Functions

- `SP_Create`: Migrate **open incidents** from STA → FTA
- `SP_Close`: Migrate **closed incidents** from STA → FTA
- `SP_BuildHierarchy`: Builds network element hierarchy (from STA → FTA)
- `SP_GetChildElements`: Get all first-level children of a network element
- `SP_GetParentHierarchy`: Retrieve the full parent hierarchy of an element
- `FN_CalculateImpactedCustomers`: Returns total leaf-level affected customers for an incident (scalar/tabled function)

---

### 🌐 Web Portal

Built with **ASP.NET Core MVC + Razor Pages** (or Blazor / Angular if preferred)

#### Pages:

1. **Login Page**
   - Authenticates users

2. **Master Dashboard**
   - **Search Incidents**
     - Multiple filters (by date, type, source, network element, etc.)
     - Tree-based search with multiselect checkbox support
     - Visualize hierarchy & show incidents + impacted customers
   - **Add Manual Incident**
     - Directly insert incidents into FTA manually
   - **Ignored Incidents**
     - View and delete individual entries

---

## 🧪 Test Data Generation
- REST APIs simulate business logic scenarios
- Includes random incident generation for both sources
- Ensures consistent, realistic data patterns for testing and validation

---

## ⚙️ Technical Stack

| Component         | Technology               |
|------------------|--------------------------|
| Backend API       | C# (.NET Core Web API)   |
| Console App       | C# (.NET Console App)    |
| Database          | SQL Server (Stored Procedures, Functions) |
| Web Portal        | ASP.NET Core MVC / Razor / Blazor |
| Data Compression  | GZip / Brotli            |
| Serialization     | System.Text.Json / BSON  |
| Security          | SQL injection prevention, IP rate limiting |

---

## 📌 Setup Instructions

1. **Database**
   - Run the provided SQL scripts to create STA & FTA schema
   - Configure connection strings for all apps

2. **Web APIs**
   - Build & run the REST API project
   - Ensure rate-limiting & security middleware is enabled

3. **Console App**
   - Configure API base URLs and DB access
   - Run as a background service or scheduled task

4. **Web Portal**
   - Set up authentication method (JWT/Session-based)
   - Deploy and configure for IIS / Docker / Azure as needed

---

## 🧠 Notes & Recommendations

- Incident timestamps (`SynchCreateDate`, `SynchUpdateDate`) should always be **greater than or equal to** `CreateDate` and `EndDate`, respectively.
- For undefined network elements, store incidents in the `Cutting_Down_Ignored` table.
- Ensure proper indexing and query optimization for high data volume.
- Validate all incoming data to prevent schema violations.

---

## 🏁 Completion Guidelines

- The solution can be extended or modified based on assumptions or clarifications.
- Early and complete submissions are positively evaluated.
- Suggestions or improvements beyond the core requirements are welcome and encouraged.

---

## 📂 Project Structure (Sample)

