# 🧾 Task Management API - Duty Module

This module is a part of a larger Task Management System built using the **ABP Framework (.NET Core)**. It focuses on the **Duty entity**, implementing features such as secure role-based authorization, CRUD operations, filtering, sorting, and pagination using clean architecture principles.

---

## 📌 Features

### 🔐 Authorization & Role-Based Access Control

- **Permission Provider**:  
  All Duty-related permissions are declared in a centralized provider.

  ```csharp
  context.CreatePermission("Duty.Create", L("Permission:CreateDuty"));
  context.CreatePermission("Duty.Update", L("Permission:UpdateDuty"));
  context.CreatePermission("Duty.Delete", L("Permission:DeleteDuty"));
  context.CreatePermission("Duty.View", L("Permission:ViewDuty"));
  context.CreatePermission("Duty.Assign", L("Permission:AssignDuty"));
  ```

- **Method-Level Authorization**:  
  Permissions are enforced using `AbpAuthorize`.

  ```csharp
  [AbpAuthorize("Duty.Create")]
  public async Task<DutyDto> CreateDutyAsync(CreateDutyDto input)
  ```

- **Role Configuration**:  
  Roles such as `Admin` and `Employee` are created in `UserRoleCreator.cs` with specific permissions assigned programmatically during user seeding.

---

### 📦 CRUD Operations on Duty Entity

All standard operations are handled using `DutyAppService.cs`:

- `CreateDutyAsync(CreateDutyDto input)`
- `UpdateDutyAsync(Guid id, DutyDto input)`
- `DeleteDutyAsync(Guid id)`
- `GetDutyByIdAsync(Guid id)`
- `AssignDutyAsync(AssignDutyDto input)`

---

### 📊 Filtering, Sorting & Pagination

Efficient retrieval of duty records with flexible filtering and client-controlled sorting & pagination.

#### 🧾 Filter DTO

```csharp
public class GetDutyInput : PagedAndSortedResultRequestDto
{
    public string Title { get; set; }
    public DateTime? DueDate { get; set; }
    public Guid? AssignedUserId { get; set; }
}
```

#### 🧠 Implementation

```csharp
public async Task<PagedResultDto<DutyDto>> GetPagedDutiesAsync(GetDutyInput input)
{
    var query = _dutyRepository.GetAll()
        .WhereIf(!string.IsNullOrWhiteSpace(input.Title), d => d.Title.Contains(input.Title))
        .WhereIf(input.DueDate.HasValue, d => d.DueDate == input.DueDate)
        .WhereIf(input.AssignedUserId.HasValue, d => d.AssignedToUserId == input.AssignedUserId)
        .OrderBy(input.Sorting ?? "CreationTime DESC");

    var totalCount = await query.CountAsync();
    var items = await query.PageBy(input).ToListAsync();

    return new PagedResultDto<DutyDto>(
        totalCount,
        ObjectMapper.Map<List<DutyDto>>(items)
    );
}
```

---

## 🧱 Folder Structure

```
TaskManagementAPI/
├── Duties/
│   ├── Duty.cs                   # Entity
│   ├── DutiesAppService.cs      # Application Service
│   ├── IDutyAppService.cs       # Interface
│   ├── Authorization/
│   │   └── DutyAppAuthorizationProvider.cs
│   ├── Dto/
│   │   ├── CreateDutyDto.cs
│   │   ├── UpdateDutyDto.cs
│   │   ├── DutyDto.cs
│   │   ├── AssignDutyDto.cs
│   │   ├── GetDutyInput.cs
│   │   └── DutyFilterDto.cs
```

---

## 🛡️ Permissions Summary

| Permission Key     | Description              | Roles with Access   |
|--------------------|--------------------------|----------------------|
| Duty.Create        | Create new duties        | Admin                |
| Duty.Update        | Edit existing duties     | Admin                |
| Duty.Delete        | Delete duties            | Admin                |
| Duty.View          | View all duties          | Admin, Employee      |
| Duty.Assign        | Assign duties to users   | Admin                |

---

## ✅ Technologies Used

- **ABP Framework**
- **ASP.NET Core**
- **Entity Framework Core**
- **AutoMapper**
- **LINQ**
- **DTO Pattern**
- **Repository Pattern**
- **Authorization Provider & Roles**

---

## 🧠 Developer Notes

- Follows ABP's best practices for modularity and extensibility.
- Designed with maintainability in mind — separation of concerns through service, DTOs, and authorization layers.
- Ready for integration with frontend apps (Angular, React, etc.) via REST or gRPC.

---

## 👤 Author

**Tondwani Craig

## 📄 License

This project is licensed under the MIT License.
