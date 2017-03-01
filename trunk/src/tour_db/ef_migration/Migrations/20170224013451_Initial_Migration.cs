using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EF_Migration.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Altitude = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 255, nullable: true),
                    Country = table.Column<string>(maxLength: 255, nullable: true),
                    DST = table.Column<string>(maxLength: 255, nullable: true),
                    IATA = table.Column<string>(maxLength: 255, nullable: true),
                    ICAO = table.Column<string>(maxLength: 255, nullable: true),
                    Latitude = table.Column<string>(maxLength: 255, nullable: true),
                    Longitude = table.Column<string>(maxLength: 255, nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Timezone = table.Column<string>(maxLength: 255, nullable: true),
                    Tzdatabase = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryFlag = table.Column<string>(type: "varchar(50)", nullable: true),
                    CountryName = table.Column<string>(type: "varchar(50)", nullable: false),
                    isActive = table.Column<bool>(nullable: true),
                    Nationality = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Type",
                columns: table => new
                {
                    OrganizationTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    OrganizationTypeName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Type", x => x.OrganizationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TimeZone",
                columns: table => new
                {
                    TimeZoneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    TimeGMT = table.Column<string>(maxLength: 30, nullable: true),
                    TimeZoneAbbr = table.Column<string>(maxLength: 30, nullable: true),
                    TimeZoneName = table.Column<string>(maxLength: 60, nullable: true),
                    TimeZoneUtc = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZone", x => x.TimeZoneID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_ActivityType",
                columns: table => new
                {
                    ActivityTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_ActivityType", x => x.ActivityTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_DirectionType",
                columns: table => new
                {
                    DirectionTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DirectionTypeName = table.Column<string>(type: "varchar(50)", nullable: false),
                    isActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tour_Dir__F06BCF9B2B12C2D6", x => x.DirectionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Plan_Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(type: "varchar(50)", nullable: true),
                    isActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tour_Pla__19093A2BBC8430A4", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Plan_Type",
                columns: table => new
                {
                    TourPlanTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: true),
                    PlanTypeName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Plan_Type", x => x.TourPlanTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_TransportationType",
                columns: table => new
                {
                    TransportationTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: true),
                    TransportationTypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationTypeID", x => x.TransportationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Type",
                columns: table => new
                {
                    TourTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    TourTypeName = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Type", x => x.TourTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    OrganizationName = table.Column<string>(type: "varchar(100)", nullable: true),
                    OrganizationTypeID = table.Column<int>(nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationID);
                    table.ForeignKey(
                        name: "FK_Organization_Organization_Type",
                        column: x => x.OrganizationTypeID,
                        principalTable: "Organization_Type",
                        principalColumn: "OrganizationTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    TourID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    DestinationCity = table.Column<string>(type: "varchar(max)", nullable: true),
                    DestinationCoordinate = table.Column<string>(type: "varchar(150)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    OrgID = table.Column<int>(nullable: false, defaultValueSql: "0"),
                    Photo = table.Column<string>(type: "varchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TargetNo = table.Column<int>(nullable: true),
                    TourDescription = table.Column<string>(type: "varchar(max)", nullable: true),
                    TourName = table.Column<string>(type: "varchar(max)", nullable: false),
                    TourTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.TourID);
                    table.ForeignKey(
                        name: "FK_Tour_Tour_Type",
                        column: x => x.TourTypeID,
                        principalTable: "Tour_Type",
                        principalColumn: "TourTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Newsfeed",
                columns: table => new
                {
                    NewsfeedID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: true),
                    NewsfeedContent = table.Column<string>(type: "varchar(max)", nullable: true),
                    NewsfeedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NewsfeedTitle = table.Column<string>(type: "varchar(max)", nullable: false),
                    TourID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsfeed", x => x.NewsfeedID);
                    table.ForeignKey(
                        name: "FK_Newsfeed_Tour",
                        column: x => x.AccountID,
                        principalTable: "Tour",
                        principalColumn: "TourID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Participant",
                columns: table => new
                {
                    TourID = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 60, nullable: false),
                    DateConfirmed = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateInvited = table.Column<DateTime>(type: "datetime", nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    isConfirmed = table.Column<bool>(nullable: true),
                    isOrganizer = table.Column<bool>(nullable: true),
                    isParticipant = table.Column<bool>(nullable: true),
                    isViewer = table.Column<bool>(nullable: true),
                    Status = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Participant", x => new { x.TourID, x.EmailAddress });
                    table.ForeignKey(
                        name: "FK_Tour_Participant_Tour",
                        column: x => x.TourID,
                        principalTable: "Tour",
                        principalColumn: "TourID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Plan",
                columns: table => new
                {
                    TourPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    PlanDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PlanName = table.Column<string>(type: "varchar(200)", nullable: true),
                    PlanTypeID = table.Column<int>(nullable: true),
                    TourID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Plan", x => x.TourPlanID);
                    table.ForeignKey(
                        name: "FK_Tour_Plan_Tour",
                        column: x => x.TourID,
                        principalTable: "Tour",
                        principalColumn: "TourID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountID = table.Column<int>(nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    ReviewText = table.Column<string>(nullable: true),
                    TourID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tour_Rev__74BC79AE89817B2A", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Tour_Review_Tour",
                        column: x => x.TourID,
                        principalTable: "Tour",
                        principalColumn: "TourID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Activities",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityTypeID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(nullable: true),
                    TourID = table.Column<int>(nullable: false),
                    TourPlanID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Activities", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Tour_ActivityType_ActivityTypeID",
                        column: x => x.ActivityTypeID,
                        principalTable: "Tour_ActivityType",
                        principalColumn: "ActivityTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Tour_Plan",
                        column: x => x.TourPlanID,
                        principalTable: "Tour_Plan",
                        principalColumn: "TourPlanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Note",
                columns: table => new
                {
                    TourNoteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    Note = table.Column<string>(type: "varchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "varchar(max)", nullable: true),
                    PhotoCaption = table.Column<string>(type: "varchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    StartTime = table.Column<string>(type: "varchar(10)", nullable: true),
                    StartTimeCounterpart = table.Column<string>(type: "varchar(50)", nullable: true),
                    StartTimeZone = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", nullable: true),
                    TourID = table.Column<int>(nullable: false),
                    TourPlanID = table.Column<int>(nullable: false),
                    URL = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Note", x => x.TourNoteID);
                    table.ForeignKey(
                        name: "FK_Tour_Note_Tour_Plan",
                        column: x => x.TourID,
                        principalTable: "Tour_Plan",
                        principalColumn: "TourPlanID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Transportations",
                columns: table => new
                {
                    TransportationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    TourPlanID = table.Column<int>(nullable: false),
                    TransportationTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Transportations", x => x.TransportationID);
                    table.ForeignKey(
                        name: "FK_Tour_Transportations_Tour_Plan",
                        column: x => x.TourPlanID,
                        principalTable: "Tour_Plan",
                        principalColumn: "TourPlanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Transportations_Tour_TransportationType",
                        column: x => x.TransportationTypeID,
                        principalTable: "Tour_TransportationType",
                        principalColumn: "TransportationTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Activities_Dining",
                columns: table => new
                {
                    ActivityDiningID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: false),
                    DiningName = table.Column<string>(maxLength: 50, nullable: true),
                    DiningPlace = table.Column<string>(maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Activities_Dining_1", x => x.ActivityDiningID);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Dining_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Activities_Lodging",
                columns: table => new
                {
                    ActivityLodgingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    LodgingName = table.Column<string>(maxLength: 50, nullable: true),
                    LodgingPlace = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Activities_Lodging_1", x => x.ActivityLodgingID);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Lodging_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Activities_Meeting",
                columns: table => new
                {
                    ActivityMeetingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    MeetingName = table.Column<string>(maxLength: 50, nullable: true),
                    MeetingPlace = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Activities_Meeting_1", x => x.ActivityMeetingID);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Meeting_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Activities_Place",
                columns: table => new
                {
                    ActivityPlaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal", nullable: true),
                    Longitude = table.Column<decimal>(type: "decimal", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Activities_Place", x => x.ActivityPlaceID);
                    table.ForeignKey(
                        name: "FK_Tour_Activities_Place_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Attachment",
                columns: table => new
                {
                    AttachmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: true),
                    AttachmentName = table.Column<string>(maxLength: 100, nullable: true),
                    AttachmentPath = table.Column<string>(maxLength: 150, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Attachment", x => x.AttachmentID);
                    table.ForeignKey(
                        name: "FK_Tour_Attachment_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Directions",
                columns: table => new
                {
                    TourDirectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivityID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    DirectionTypeID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    TransportationID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Directions", x => x.TourDirectionID);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Tour_Activities",
                        column: x => x.ActivityID,
                        principalTable: "Tour_Activities",
                        principalColumn: "ActivityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Tour_DirectionType",
                        column: x => x.DirectionTypeID,
                        principalTable: "Tour_DirectionType",
                        principalColumn: "DirectionTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Tour_Transportations_TransportationID",
                        column: x => x.TransportationID,
                        principalTable: "Tour_Transportations",
                        principalColumn: "TransportationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Transportation_Car",
                columns: table => new
                {
                    TransportationCarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarType = table.Column<string>(maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    TransportationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Transportation_Car_1", x => x.TransportationCarID);
                    table.ForeignKey(
                        name: "FK_Tour_Transportation_Car_Tour_Transportations_TransportationID",
                        column: x => x.TransportationID,
                        principalTable: "Tour_Transportations",
                        principalColumn: "TransportationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Transportation_Cruise",
                columns: table => new
                {
                    TransportationCruiseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    ShipName = table.Column<string>(maxLength: 50, nullable: true),
                    TransportationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Transportation_Cruise_1", x => x.TransportationCruiseID);
                    table.ForeignKey(
                        name: "FK_Tour_Transportation_Cruise_Tour_Transportations_TransportationID",
                        column: x => x.TransportationID,
                        principalTable: "Tour_Transportations",
                        principalColumn: "TransportationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Transportation_Flight",
                columns: table => new
                {
                    TransportationFlightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNo = table.Column<string>(maxLength: 50, nullable: true),
                    isActive = table.Column<bool>(nullable: true),
                    TransportationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Transportation_Flight_1", x => x.TransportationFlightID);
                    table.ForeignKey(
                        name: "FK_Tour_Transportation_Flight_Tour_Transportations_TransportationID",
                        column: x => x.TransportationID,
                        principalTable: "Tour_Transportations",
                        principalColumn: "TransportationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Transportation_Train",
                columns: table => new
                {
                    TransportationTrainID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isActive = table.Column<bool>(nullable: true),
                    StationName = table.Column<string>(maxLength: 50, nullable: true),
                    TransportationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Transportation_Train_1", x => x.TransportationTrainID);
                    table.ForeignKey(
                        name: "FK_Tour_Transportation_Train_Tour_Transportations_TransportationID",
                        column: x => x.TransportationID,
                        principalTable: "Tour_Transportations",
                        principalColumn: "TransportationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tour_Directions_Path",
                columns: table => new
                {
                    DirectionPathID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportID = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(nullable: true),
                    TimeZoneID = table.Column<int>(nullable: true),
                    TourDirectionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour_Directions_Path", x => x.DirectionPathID);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Path_Airports",
                        column: x => x.AirportID,
                        principalTable: "Airports",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Path_TimeZone",
                        column: x => x.TimeZoneID,
                        principalTable: "TimeZone",
                        principalColumn: "TimeZoneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tour_Directions_Path_Tour_Directions",
                        column: x => x.TourDirectionID,
                        principalTable: "Tour_Directions",
                        principalColumn: "TourDirectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Newsfeed_AccountID",
                table: "Newsfeed",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_OrganizationTypeID",
                table: "Organization",
                column: "OrganizationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_TourTypeID",
                table: "Tour",
                column: "TourTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_ActivityTypeID",
                table: "Tour_Activities",
                column: "ActivityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_TourPlanID",
                table: "Tour_Activities",
                column: "TourPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_Dining_ActivityID",
                table: "Tour_Activities_Dining",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_Lodging_ActivityID",
                table: "Tour_Activities_Lodging",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_Meeting_ActivityID",
                table: "Tour_Activities_Meeting",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Activities_Place_ActivityID",
                table: "Tour_Activities_Place",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Attachment_ActivityID",
                table: "Tour_Attachment",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_ActivityID",
                table: "Tour_Directions",
                column: "ActivityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_DirectionTypeID",
                table: "Tour_Directions",
                column: "DirectionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_TransportationID",
                table: "Tour_Directions",
                column: "TransportationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_Path_AirportID",
                table: "Tour_Directions_Path",
                column: "AirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_Path_TimeZoneID",
                table: "Tour_Directions_Path",
                column: "TimeZoneID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Directions_Path_TourDirectionID",
                table: "Tour_Directions_Path",
                column: "TourDirectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Note_TourID",
                table: "Tour_Note",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Plan_TourID",
                table: "Tour_Plan",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Review_TourID",
                table: "Tour_Review",
                column: "TourID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportation_Car_TransportationID",
                table: "Tour_Transportation_Car",
                column: "TransportationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportation_Cruise_TransportationID",
                table: "Tour_Transportation_Cruise",
                column: "TransportationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportation_Flight_TransportationID",
                table: "Tour_Transportation_Flight",
                column: "TransportationID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportations_TourPlanID",
                table: "Tour_Transportations",
                column: "TourPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportations_TransportationTypeID",
                table: "Tour_Transportations",
                column: "TransportationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tour_Transportation_Train_TransportationID",
                table: "Tour_Transportation_Train",
                column: "TransportationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Newsfeed");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Tour_Activities_Dining");

            migrationBuilder.DropTable(
                name: "Tour_Activities_Lodging");

            migrationBuilder.DropTable(
                name: "Tour_Activities_Meeting");

            migrationBuilder.DropTable(
                name: "Tour_Activities_Place");

            migrationBuilder.DropTable(
                name: "Tour_Attachment");

            migrationBuilder.DropTable(
                name: "Tour_Directions_Path");

            migrationBuilder.DropTable(
                name: "Tour_Note");

            migrationBuilder.DropTable(
                name: "Tour_Participant");

            migrationBuilder.DropTable(
                name: "Tour_Plan_Category");

            migrationBuilder.DropTable(
                name: "Tour_Plan_Type");

            migrationBuilder.DropTable(
                name: "Tour_Review");

            migrationBuilder.DropTable(
                name: "Tour_Transportation_Car");

            migrationBuilder.DropTable(
                name: "Tour_Transportation_Cruise");

            migrationBuilder.DropTable(
                name: "Tour_Transportation_Flight");

            migrationBuilder.DropTable(
                name: "Tour_Transportation_Train");

            migrationBuilder.DropTable(
                name: "Organization_Type");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "TimeZone");

            migrationBuilder.DropTable(
                name: "Tour_Directions");

            migrationBuilder.DropTable(
                name: "Tour_Activities");

            migrationBuilder.DropTable(
                name: "Tour_DirectionType");

            migrationBuilder.DropTable(
                name: "Tour_Transportations");

            migrationBuilder.DropTable(
                name: "Tour_ActivityType");

            migrationBuilder.DropTable(
                name: "Tour_Plan");

            migrationBuilder.DropTable(
                name: "Tour_TransportationType");

            migrationBuilder.DropTable(
                name: "Tour");

            migrationBuilder.DropTable(
                name: "Tour_Type");
        }
    }
}
