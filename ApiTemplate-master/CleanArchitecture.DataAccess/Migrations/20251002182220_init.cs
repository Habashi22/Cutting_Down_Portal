using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchitecture.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Channels",
                columns: table => new
                {
                    Channel_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Channel_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channels", x => x.Channel_Key);
                });

            migrationBuilder.CreateTable(
                name: "Governrates",
                columns: table => new
                {
                    Governrate_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Governrate_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governrates", x => x.Governrate_Key);
                });

            migrationBuilder.CreateTable(
                name: "Network_Element_Hierarchy_Paths",
                columns: table => new
                {
                    Network_Element_Hierarchy_Path_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Netwrok_Element_Hierarchy_Path_Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_Element_Hierarchy_Paths", x => x.Network_Element_Hierarchy_Path_Key);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTypes",
                columns: table => new
                {
                    Problem_Type_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Problem_Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTypes", x => x.Problem_Type_Key);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Key);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Sector_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Governrate_Key = table.Column<int>(type: "int", nullable: false),
                    Sector_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Sector_Key);
                    table.ForeignKey(
                        name: "FK_Sectors_Governrates_Governrate_Key",
                        column: x => x.Governrate_Key,
                        principalTable: "Governrates",
                        principalColumn: "Governrate_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Network_Element_Type",
                columns: table => new
                {
                    Network_Element_Type_key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Network_Element_Type_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Parent_Network_Element_Type_Key = table.Column<int>(type: "int", nullable: true),
                    Network_Element_Hierarchy_Path_Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_Element_Type", x => x.Network_Element_Type_key);
                    table.ForeignKey(
                        name: "FK_Network_Element_Type_Network_Element_Hierarchy_Paths_Network_Element_Hierarchy_Path_Key",
                        column: x => x.Network_Element_Hierarchy_Path_Key,
                        principalTable: "Network_Element_Hierarchy_Paths",
                        principalColumn: "Network_Element_Hierarchy_Path_Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_Element_Type_Network_Element_Type_Parent_Network_Element_Type_Key",
                        column: x => x.Parent_Network_Element_Type_Key,
                        principalTable: "Network_Element_Type",
                        principalColumn: "Network_Element_Type_key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cutting_Down_Headers",
                columns: table => new
                {
                    Cutting_Down_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cutting_Down_Incident_ID = table.Column<int>(type: "int", nullable: false),
                    Channel_Key = table.Column<int>(type: "int", nullable: false),
                    Cutting_Down_Problem_Type_Key = table.Column<int>(type: "int", nullable: false),
                    ActualCreatetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SynchCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SynchUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreateSystemUserID = table.Column<int>(type: "int", nullable: false),
                    UpdateSystemUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutting_Down_Headers", x => x.Cutting_Down_Key);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Headers_Channels_Channel_Key",
                        column: x => x.Channel_Key,
                        principalTable: "Channels",
                        principalColumn: "Channel_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Headers_ProblemTypes_Cutting_Down_Problem_Type_Key",
                        column: x => x.Cutting_Down_Problem_Type_Key,
                        principalTable: "ProblemTypes",
                        principalColumn: "Problem_Type_Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Zone_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sector_Key = table.Column<int>(type: "int", nullable: false),
                    Zone_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Zone_Key);
                    table.ForeignKey(
                        name: "FK_Zones_Sectors_Sector_Key",
                        column: x => x.Sector_Key,
                        principalTable: "Sectors",
                        principalColumn: "Sector_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Network_Elements",
                columns: table => new
                {
                    Network_Element_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Network_Element_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Network_Element_Type_Key = table.Column<int>(type: "int", nullable: false),
                    Parent_Network_Element_Key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network_Elements", x => x.Network_Element_Key);
                    table.ForeignKey(
                        name: "FK_Network_Elements_Network_Element_Type_Network_Element_Type_Key",
                        column: x => x.Network_Element_Type_Key,
                        principalTable: "Network_Element_Type",
                        principalColumn: "Network_Element_Type_key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Network_Elements_Network_Elements_Parent_Network_Element_Key",
                        column: x => x.Parent_Network_Element_Key,
                        principalTable: "Network_Elements",
                        principalColumn: "Network_Element_Key",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cutting_Down_Ignoreds",
                columns: table => new
                {
                    Cutting_Down_Incident_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cutting_Down_Key = table.Column<int>(type: "int", nullable: true),
                    ActualCreatetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SynchCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cabel_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cabin_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cutting_Down_HeaderCutting_Down_Key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutting_Down_Ignoreds", x => x.Cutting_Down_Incident_ID);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Ignoreds_Cutting_Down_Headers_Cutting_Down_HeaderCutting_Down_Key",
                        column: x => x.Cutting_Down_HeaderCutting_Down_Key,
                        principalTable: "Cutting_Down_Headers",
                        principalColumn: "Cutting_Down_Key");
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Ignoreds_Cutting_Down_Headers_Cutting_Down_Key",
                        column: x => x.Cutting_Down_Key,
                        principalTable: "Cutting_Down_Headers",
                        principalColumn: "Cutting_Down_Key",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    City_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zone_Key = table.Column<int>(type: "int", nullable: false),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.City_Key);
                    table.ForeignKey(
                        name: "FK_Cities_Zones_Zone_Key",
                        column: x => x.Zone_Key,
                        principalTable: "Zones",
                        principalColumn: "Zone_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cutting_Down_Details",
                columns: table => new
                {
                    Cutting_Down_Detail_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cutting_Down_Key = table.Column<int>(type: "int", nullable: true),
                    Network_Element_Key = table.Column<int>(type: "int", nullable: true),
                    ActualCreatetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImpactedCustomers = table.Column<int>(type: "int", nullable: false),
                    Network_Element_Key1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cutting_Down_Details", x => x.Cutting_Down_Detail_Key);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Details_Cutting_Down_Headers_Cutting_Down_Key",
                        column: x => x.Cutting_Down_Key,
                        principalTable: "Cutting_Down_Headers",
                        principalColumn: "Cutting_Down_Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Details_Network_Elements_Network_Element_Key",
                        column: x => x.Network_Element_Key,
                        principalTable: "Network_Elements",
                        principalColumn: "Network_Element_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cutting_Down_Details_Network_Elements_Network_Element_Key1",
                        column: x => x.Network_Element_Key1,
                        principalTable: "Network_Elements",
                        principalColumn: "Network_Element_Key");
                });

            migrationBuilder.CreateTable(
                name: "CuttingDownAs",
                columns: table => new
                {
                    Cutting_Down_A_Incident_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cutting_Down_Cabin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problem_Type_Key = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network_Element_Key = table.Column<int>(type: "int", nullable: true),
                    NetworkElementNetwork_Element_Key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownAs", x => x.Cutting_Down_A_Incident_ID);
                    table.ForeignKey(
                        name: "FK_CuttingDownAs_Network_Elements_NetworkElementNetwork_Element_Key",
                        column: x => x.NetworkElementNetwork_Element_Key,
                        principalTable: "Network_Elements",
                        principalColumn: "Network_Element_Key");
                    table.ForeignKey(
                        name: "FK_CuttingDownAs_ProblemTypes_Problem_Type_Key",
                        column: x => x.Problem_Type_Key,
                        principalTable: "ProblemTypes",
                        principalColumn: "Problem_Type_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuttingDownBs",
                columns: table => new
                {
                    Cutting_Down_B_Incident_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cutting_Down_Cable_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Problem_Type_Key = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPlanned = table.Column<bool>(type: "bit", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    PlannedStartDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PlannedEndDTS = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network_Element_Key = table.Column<int>(type: "int", nullable: true),
                    NetworkElementNetwork_Element_Key = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuttingDownBs", x => x.Cutting_Down_B_Incident_ID);
                    table.ForeignKey(
                        name: "FK_CuttingDownBs_Network_Elements_NetworkElementNetwork_Element_Key",
                        column: x => x.NetworkElementNetwork_Element_Key,
                        principalTable: "Network_Elements",
                        principalColumn: "Network_Element_Key");
                    table.ForeignKey(
                        name: "FK_CuttingDownBs_ProblemTypes_Problem_Type_Key",
                        column: x => x.Problem_Type_Key,
                        principalTable: "ProblemTypes",
                        principalColumn: "Problem_Type_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Station_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Key = table.Column<int>(type: "int", nullable: false),
                    Station_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Station_Key);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_City_Key",
                        column: x => x.City_Key,
                        principalTable: "Cities",
                        principalColumn: "City_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towers",
                columns: table => new
                {
                    Tower_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Station_Key = table.Column<int>(type: "int", nullable: false),
                    Tower_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towers", x => x.Tower_Key);
                    table.ForeignKey(
                        name: "FK_Towers_Stations_Station_Key",
                        column: x => x.Station_Key,
                        principalTable: "Stations",
                        principalColumn: "Station_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    Cabin_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tower_Key = table.Column<int>(type: "int", nullable: false),
                    Cabin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.Cabin_Key);
                    table.ForeignKey(
                        name: "FK_Cabins_Towers_Tower_Key",
                        column: x => x.Tower_Key,
                        principalTable: "Towers",
                        principalColumn: "Tower_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    Cable_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cabin_Key = table.Column<int>(type: "int", nullable: false),
                    Cable_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.Cable_Key);
                    table.ForeignKey(
                        name: "FK_Cables_Cabins_Cabin_Key",
                        column: x => x.Cabin_Key,
                        principalTable: "Cabins",
                        principalColumn: "Cabin_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Block_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cable_Key = table.Column<int>(type: "int", nullable: false),
                    Block_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Block_Key);
                    table.ForeignKey(
                        name: "FK_Blocks_Cables_Cable_Key",
                        column: x => x.Cable_Key,
                        principalTable: "Cables",
                        principalColumn: "Cable_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Building_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block_Key = table.Column<int>(type: "int", nullable: false),
                    Building_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Building_Key);
                    table.ForeignKey(
                        name: "FK_Buildings_Blocks_Block_Key",
                        column: x => x.Block_Key,
                        principalTable: "Blocks",
                        principalColumn: "Block_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Flat_Key = table.Column<int>(type: "int", nullable: false),
                    Building_Key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => new { x.Flat_Key, x.Building_Key });
                    table.ForeignKey(
                        name: "FK_Flats_Buildings_Building_Key",
                        column: x => x.Building_Key,
                        principalTable: "Buildings",
                        principalColumn: "Building_Key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Subscription_Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flat_Key = table.Column<int>(type: "int", nullable: false),
                    Building_Key = table.Column<int>(type: "int", nullable: false),
                    Meter_Key = table.Column<int>(type: "int", nullable: true),
                    Palet_Key = table.Column<int>(type: "int", nullable: true),
                    Building_Key1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Subscription_Key);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Buildings_Building_Key",
                        column: x => x.Building_Key,
                        principalTable: "Buildings",
                        principalColumn: "Building_Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Buildings_Building_Key1",
                        column: x => x.Building_Key1,
                        principalTable: "Buildings",
                        principalColumn: "Building_Key");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Flats_Flat_Key_Building_Key",
                        columns: x => new { x.Flat_Key, x.Building_Key },
                        principalTable: "Flats",
                        principalColumns: new[] { "Flat_Key", "Building_Key" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8408c5f2-0932-40f8-911a-6d49a3bbfe16", "2", "User", "User" },
                    { "8de70db5-c6fb-4555-a3df-476db1e632b3", "1", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Channels",
                columns: new[] { "Channel_Key", "Channel_Name" },
                values: new object[,]
                {
                    { 1, "Source A" },
                    { 2, "Source B" }
                });

            migrationBuilder.InsertData(
                table: "Cutting_Down_Ignoreds",
                columns: new[] { "Cutting_Down_Incident_ID", "ActualCreatetDate", "Cabel_Name", "Cabin_Name", "CreatedUser", "Cutting_Down_HeaderCutting_Down_Key", "Cutting_Down_Key", "SynchCreateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "147", "963", "admin", null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "963", "admin", null, null, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Governrates",
                columns: new[] { "Governrate_Key", "Governrate_Name" },
                values: new object[,]
                {
                    { 1, "Cairo" },
                    { 2, "Alex" },
                    { 3, "Giza" },
                    { 4, "Suez" }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Hierarchy_Paths",
                columns: new[] { "Network_Element_Hierarchy_Path_Key", "Abbreviation", "Netwrok_Element_Hierarchy_Path_Name" },
                values: new object[,]
                {
                    { 1, "Governrate -> Individual Subscription", "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Flat, Individual Subscription" },
                    { 2, "Governrate -> Corporate Subscription", "Governrate, Sector, Zone, City, Station, Tower, Cabin, Cable, Buidling, Corporate Subscription" }
                });

            migrationBuilder.InsertData(
                table: "ProblemTypes",
                columns: new[] { "Problem_Type_Key", "Problem_Type_Name" },
                values: new object[,]
                {
                    { 1, "حريق" },
                    { 2, "ضغط عالى" },
                    { 3, "استهلاك عالى" },
                    { 4, "مديونيه" },
                    { 5, "تلف عداد" },
                    { 6, "سرقة تيار" },
                    { 7, "امطار" },
                    { 8, "كسر ماسورة مياه" },
                    { 9, "كسر ماسورة غاز" },
                    { 10, "تحديث واحلال" },
                    { 11, "صيانه" },
                    { 12, "كابل مقطوع" },
                    { 13, "توصيل كابل" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "User_Key", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "test", "test" },
                    { 3, "SourceA", "Source_A" },
                    { 4, "SourceB", "Source_B" }
                });

            migrationBuilder.InsertData(
                table: "CuttingDownAs",
                columns: new[] { "Cutting_Down_A_Incident_ID", "CreateDate", "CreatedUser", "Cutting_Down_Cabin_Name", "EndDate", "IsActive", "IsGlobal", "IsPlanned", "NetworkElementNetwork_Element_Key", "Network_Element_Key", "PlannedEndDTS", "PlannedStartDTS", "Problem_Type_Key", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-1", null, true, false, false, null, null, null, null, 1, null },
                    { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-2", null, true, false, true, null, null, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-3", null, true, true, false, null, null, null, null, 3, null },
                    { 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-4", null, true, true, true, null, null, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 5, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-5", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, null, null, null, null, 5, null },
                    { 6, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "cab-1-6", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, null, null, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null }
                });

            migrationBuilder.InsertData(
                table: "CuttingDownBs",
                columns: new[] { "Cutting_Down_B_Incident_ID", "CreateDate", "CreatedUser", "Cutting_Down_Cable_Name", "EndDate", "IsActive", "IsGlobal", "IsPlanned", "NetworkElementNetwork_Element_Key", "Network_Element_Key", "PlannedEndDTS", "PlannedStartDTS", "Problem_Type_Key", "UpdatedUser" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-1", null, true, false, false, null, null, null, null, 11, null },
                    { 2, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-2", null, true, false, true, null, null, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, null },
                    { 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-3", null, true, true, false, null, null, null, null, 13, null },
                    { 4, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-4", null, true, true, true, null, null, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null },
                    { 5, new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-5", new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, false, null, null, null, null, 5, null },
                    { 6, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ch-1-6", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, null, null, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null }
                });

            migrationBuilder.InsertData(
                table: "Cutting_Down_Headers",
                columns: new[] { "Cutting_Down_Key", "ActualCreatetDate", "ActualEndDate", "Channel_Key", "CreateSystemUserID", "Cutting_Down_Incident_ID", "Cutting_Down_Problem_Type_Key", "IsActive", "IsGlobal", "IsPlanned", "PlannedEndDTS", "PlannedStartDTS", "SynchCreateDate", "SynchUpdateDate", "UpdateSystemUserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 1, 1, 1, true, false, false, null, null, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 2, 2, 2, true, false, false, null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 },
                    { 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 3, 123, 3, true, false, false, null, null, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 4, 321, 4, true, false, false, null, null, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 1, 1, "Governrate", null });

            migrationBuilder.InsertData(
                table: "Sectors",
                columns: new[] { "Sector_Key", "Governrate_Key", "Sector_Name" },
                values: new object[,]
                {
                    { 1, 1, "North" },
                    { 2, 1, "East" },
                    { 3, 1, "West" },
                    { 4, 1, "South" }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 2, 1, "Sector", 1 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 1, "gov 1 (cairo for example)", 1, null });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Zone_Key", "Sector_Key", "Zone_Name" },
                values: new object[,]
                {
                    { 1, 1, "منطقه اولى" },
                    { 2, 1, "منطقه ثانيه" },
                    { 3, 1, "منطقه ثالثه" },
                    { 4, 1, "منطقه رابعه" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "City_Key", "City_Name", "Zone_Key" },
                values: new object[,]
                {
                    { 1, "Nasr City", 1 },
                    { 2, "Al Salam City", 1 },
                    { 3, "Dar Al Salam", 2 },
                    { 4, "Helwan", 2 }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 3, 1, "Zone", 2 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 2, "sec 1 (north)", 2, 1 });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 4, 1, "City", 3 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 3, "Zone 1 (1st)", 3, 2 });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Station_Key", "City_Key", "Station_Name" },
                values: new object[,]
                {
                    { 1, 1, "prod-1-1" },
                    { 2, 1, "prod-1-2" },
                    { 3, 2, "prod-2-1" },
                    { 4, 2, "prod-2-2" }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 5, 1, "Station", 4 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 4, "Cty 1 (Nasr City)", 4, 3 });

            migrationBuilder.InsertData(
                table: "Towers",
                columns: new[] { "Tower_Key", "Station_Key", "Tower_Name" },
                values: new object[,]
                {
                    { 1, 1, "dc-1-1" },
                    { 2, 1, "dc-1-2" },
                    { 3, 2, "dc-2-1" },
                    { 4, 2, "dc-2-2" }
                });

            migrationBuilder.InsertData(
                table: "Cabins",
                columns: new[] { "Cabin_Key", "Cabin_Name", "Tower_Key" },
                values: new object[,]
                {
                    { 1, "cab-1-1", 1 },
                    { 2, "cab-1-2", 1 },
                    { 3, "cab-2-1", 2 },
                    { 4, "cab-2-2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 6, 1, "Tower", 5 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 5, "Stion 1 (prod-1-1)", 5, 4 });

            migrationBuilder.InsertData(
                table: "Cables",
                columns: new[] { "Cable_Key", "Cabin_Key", "Cable_Name" },
                values: new object[,]
                {
                    { 1, 1, "ch-1-1" },
                    { 2, 1, "ch-1-2" },
                    { 3, 2, "ch-2-1" },
                    { 4, 2, "ch-2-2" }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 7, 1, "Cabin", 6 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 6, "Toer 1 (dc-1-1)", 6, 5 });

            migrationBuilder.InsertData(
                table: "Blocks",
                columns: new[] { "Block_Key", "Block_Name", "Cable_Key" },
                values: new object[,]
                {
                    { 1, "111-111-111", 1 },
                    { 2, "222-222-222", 1 },
                    { 3, "333-333-333", 2 },
                    { 4, "444-444-444", 2 }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 8, 1, "Cable", 7 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 7, "Cbn 1 (cab-1-1)", 7, 6 });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Building_Key", "Block_Key", "Building_Name" },
                values: new object[,]
                {
                    { 1, 1, "asd-1-1" },
                    { 2, 1, "asd-1-2" },
                    { 3, 2, "asd-2-1" },
                    { 4, 2, "asd-2-1" }
                });

            migrationBuilder.InsertData(
                table: "Cutting_Down_Details",
                columns: new[] { "Cutting_Down_Detail_Key", "ActualCreatetDate", "ActualEndDate", "Cutting_Down_Key", "ImpactedCustomers", "Network_Element_Key", "Network_Element_Key1" },
                values: new object[] { 11, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 100, 7, null });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 9, 1, "Block", 8 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 8, "Cbl 1 (ch-1-1)", 8, 7 });

            migrationBuilder.InsertData(
                table: "Cutting_Down_Details",
                columns: new[] { "Cutting_Down_Detail_Key", "ActualCreatetDate", "ActualEndDate", "Cutting_Down_Key", "ImpactedCustomers", "Network_Element_Key", "Network_Element_Key1" },
                values: new object[] { 12, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, 50, 8, null });

            migrationBuilder.InsertData(
                table: "Flats",
                columns: new[] { "Building_Key", "Flat_Key" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 10, 1, "Building", 9 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 9, "Blk 1 (111-111-111)", 9, 8 });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[,]
                {
                    { 11, 1, "Flat", 10 },
                    { 13, 2, "Corporate Subscription", 10 }
                });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[] { 10, "Blding 1 (asd-1-1)", 10, 9 });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Subscription_Key", "Building_Key", "Building_Key1", "Flat_Key", "Meter_Key", "Palet_Key" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1, 11 },
                    { 2, 1, null, 2, 1, 2 },
                    { 3, 2, null, 3, 3, null },
                    { 4, 2, null, 4, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Network_Element_Type",
                columns: new[] { "Network_Element_Type_key", "Network_Element_Hierarchy_Path_Key", "Network_Element_Type_Name", "Parent_Network_Element_Type_Key" },
                values: new object[] { 12, 1, "Individual Subscription", 11 });

            migrationBuilder.InsertData(
                table: "Network_Elements",
                columns: new[] { "Network_Element_Key", "Network_Element_Name", "Network_Element_Type_Key", "Parent_Network_Element_Key" },
                values: new object[,]
                {
                    { 11, "Flt 1 (1)", 11, 10 },
                    { 13, "Corp Subs 1 (3)", 13, 10 },
                    { 12, "Indv Subs 1 (1)", 12, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_Cable_Key",
                table: "Blocks",
                column: "Cable_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_Block_Key",
                table: "Buildings",
                column: "Block_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_Tower_Key",
                table: "Cabins",
                column: "Tower_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cables_Cabin_Key",
                table: "Cables",
                column: "Cabin_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Zone_Key",
                table: "Cities",
                column: "Zone_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Details_Cutting_Down_Key",
                table: "Cutting_Down_Details",
                column: "Cutting_Down_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Details_Network_Element_Key",
                table: "Cutting_Down_Details",
                column: "Network_Element_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Details_Network_Element_Key1",
                table: "Cutting_Down_Details",
                column: "Network_Element_Key1");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Headers_Channel_Key",
                table: "Cutting_Down_Headers",
                column: "Channel_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Headers_Cutting_Down_Problem_Type_Key",
                table: "Cutting_Down_Headers",
                column: "Cutting_Down_Problem_Type_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Ignoreds_Cutting_Down_HeaderCutting_Down_Key",
                table: "Cutting_Down_Ignoreds",
                column: "Cutting_Down_HeaderCutting_Down_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Cutting_Down_Ignoreds_Cutting_Down_Key",
                table: "Cutting_Down_Ignoreds",
                column: "Cutting_Down_Key");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownAs_NetworkElementNetwork_Element_Key",
                table: "CuttingDownAs",
                column: "NetworkElementNetwork_Element_Key");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownAs_Problem_Type_Key",
                table: "CuttingDownAs",
                column: "Problem_Type_Key");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownBs_NetworkElementNetwork_Element_Key",
                table: "CuttingDownBs",
                column: "NetworkElementNetwork_Element_Key");

            migrationBuilder.CreateIndex(
                name: "IX_CuttingDownBs_Problem_Type_Key",
                table: "CuttingDownBs",
                column: "Problem_Type_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_Building_Key",
                table: "Flats",
                column: "Building_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Element_Type_Network_Element_Hierarchy_Path_Key",
                table: "Network_Element_Type",
                column: "Network_Element_Hierarchy_Path_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Element_Type_Parent_Network_Element_Type_Key",
                table: "Network_Element_Type",
                column: "Parent_Network_Element_Type_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Elements_Network_Element_Type_Key",
                table: "Network_Elements",
                column: "Network_Element_Type_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Network_Elements_Parent_Network_Element_Key",
                table: "Network_Elements",
                column: "Parent_Network_Element_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_Governrate_Key",
                table: "Sectors",
                column: "Governrate_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_City_Key",
                table: "Stations",
                column: "City_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Building_Key",
                table: "Subscriptions",
                column: "Building_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Building_Key1",
                table: "Subscriptions",
                column: "Building_Key1");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Flat_Key_Building_Key",
                table: "Subscriptions",
                columns: new[] { "Flat_Key", "Building_Key" });

            migrationBuilder.CreateIndex(
                name: "IX_Towers_Station_Key",
                table: "Towers",
                column: "Station_Key");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Sector_Key",
                table: "Zones",
                column: "Sector_Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cutting_Down_Details");

            migrationBuilder.DropTable(
                name: "Cutting_Down_Ignoreds");

            migrationBuilder.DropTable(
                name: "CuttingDownAs");

            migrationBuilder.DropTable(
                name: "CuttingDownBs");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cutting_Down_Headers");

            migrationBuilder.DropTable(
                name: "Network_Elements");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Channels");

            migrationBuilder.DropTable(
                name: "ProblemTypes");

            migrationBuilder.DropTable(
                name: "Network_Element_Type");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Network_Element_Hierarchy_Paths");

            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "Cables");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Towers");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Governrates");
        }
    }
}
