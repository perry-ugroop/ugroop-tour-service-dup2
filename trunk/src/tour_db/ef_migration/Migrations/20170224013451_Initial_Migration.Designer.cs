using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UGroopData.Sql.Repository2.Data;

namespace EF_Migration.Migrations
{
    [DbContext(typeof(UGroopDBContext))]
    [Migration("20170224013451_Initial_Migration")]
    partial class Initial_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Airports", b =>
                {
                    b.Property<int>("AirportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AirportID");

                    b.Property<string>("Altitude")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .HasMaxLength(255);

                    b.Property<string>("Dst")
                        .HasColumnName("DST")
                        .HasMaxLength(255);

                    b.Property<string>("Iata")
                        .HasColumnName("IATA")
                        .HasMaxLength(255);

                    b.Property<string>("Icao")
                        .HasColumnName("ICAO")
                        .HasMaxLength(255);

                    b.Property<string>("Latitude")
                        .HasMaxLength(255);

                    b.Property<string>("Longitude")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Timezone")
                        .HasMaxLength(255);

                    b.Property<string>("Tzdatabase")
                        .HasMaxLength(255);

                    b.HasKey("AirportId")
                        .HasName("PK_Airports");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CountryID");

                    b.Property<string>("CountryFlag")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("Nationality")
                        .HasColumnType("varchar(50)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Newsfeed", b =>
                {
                    b.Property<int>("NewsfeedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NewsfeedID");

                    b.Property<int>("AccountId")
                        .HasColumnName("AccountID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("NewsfeedContent")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("NewsfeedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewsfeedTitle")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("TourId")
                        .HasColumnName("TourID");

                    b.HasKey("NewsfeedId");

                    b.HasIndex("AccountId");

                    b.ToTable("Newsfeed");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrganizationID");

                    b.Property<int?>("AccountId")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OrganizationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrganizationTypeID")
                        .HasDefaultValueSql("1");

                    b.HasKey("OrganizationId");

                    b.HasIndex("OrganizationTypeId");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.OrganizationType", b =>
                {
                    b.Property<int>("OrganizationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrganizationTypeID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("OrganizationTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("OrganizationTypeId");

                    b.ToTable("Organization_Type");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TimeZone", b =>
                {
                    b.Property<int>("TimeZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TimeZoneID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("TimeGmt")
                        .HasColumnName("TimeGMT")
                        .HasMaxLength(30);

                    b.Property<string>("TimeZoneAbbr")
                        .HasMaxLength(30);

                    b.Property<string>("TimeZoneName")
                        .HasMaxLength(60);

                    b.Property<string>("TimeZoneUtc")
                        .HasColumnType("varchar(30)");

                    b.HasKey("TimeZoneId");

                    b.ToTable("TimeZone");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourID");

                    b.Property<int>("AccountId")
                        .HasColumnName("AccountID");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("DestinationCity")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("DestinationCoordinate")
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<int>("OrgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("OrgID")
                        .HasDefaultValueSql("0");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("TargetNo");

                    b.Property<string>("TourDescription")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("TourName")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<int>("TourTypeId")
                        .HasColumnName("TourTypeID");

                    b.HasKey("TourId");

                    b.HasIndex("TourTypeId");

                    b.ToTable("Tour");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivities", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityID");

                    b.Property<int>("ActivityTypeId")
                        .HasColumnName("ActivityTypeID");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool?>("IsActive");

                    b.Property<int>("TourId")
                        .HasColumnName("TourID");

                    b.Property<int>("TourPlanId")
                        .HasColumnName("TourPlanID");

                    b.HasKey("ActivityId")
                        .HasName("PK_Tour_Activities");

                    b.HasIndex("ActivityTypeId");

                    b.HasIndex("TourPlanId");

                    b.ToTable("Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesDining", b =>
                {
                    b.Property<int>("ActivityDiningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityDiningID");

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<string>("DiningName")
                        .HasMaxLength(50);

                    b.Property<string>("DiningPlace")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive");

                    b.HasKey("ActivityDiningId")
                        .HasName("PK_Tour_Activities_Dining_1");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tour_Activities_Dining");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesLodging", b =>
                {
                    b.Property<int>("ActivityLodgingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityLodgingID");

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("LodgingName")
                        .HasMaxLength(50);

                    b.Property<string>("LodgingPlace")
                        .HasMaxLength(50);

                    b.HasKey("ActivityLodgingId")
                        .HasName("PK_Tour_Activities_Lodging_1");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tour_Activities_Lodging");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesMeeting", b =>
                {
                    b.Property<int>("ActivityMeetingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityMeetingID");

                    b.Property<int>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("MeetingName")
                        .HasMaxLength(50);

                    b.Property<string>("MeetingPlace")
                        .HasMaxLength(50);

                    b.HasKey("ActivityMeetingId")
                        .HasName("PK_Tour_Activities_Meeting_1");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tour_Activities_Meeting");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesPlace", b =>
                {
                    b.Property<int>("ActivityPlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityPlaceID");

                    b.Property<int?>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<string>("Address");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool?>("IsActive");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("decimal");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("decimal");

                    b.HasKey("ActivityPlaceId")
                        .HasName("PK_Tour_Activities_Place");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tour_Activities_Place");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivityType", b =>
                {
                    b.Property<int>("ActivityTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ActivityTypeID");

                    b.Property<string>("ActivityTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive");

                    b.HasKey("ActivityTypeId")
                        .HasName("PK_Tour_ActivityType");

                    b.ToTable("Tour_ActivityType");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourAttachment", b =>
                {
                    b.Property<int>("AttachmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AttachmentID");

                    b.Property<int?>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<string>("AttachmentName")
                        .HasMaxLength(100);

                    b.Property<string>("AttachmentPath")
                        .HasMaxLength(150);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool?>("IsActive");

                    b.HasKey("AttachmentId")
                        .HasName("PK_Tour_Attachment");

                    b.HasIndex("ActivityId");

                    b.ToTable("Tour_Attachment");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourDirections", b =>
                {
                    b.Property<int>("TourDirectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourDirectionID");

                    b.Property<int?>("ActivityId")
                        .HasColumnName("ActivityID");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("DirectionTypeId")
                        .HasColumnName("DirectionTypeID");

                    b.Property<bool?>("IsActive");

                    b.Property<int?>("TransportationId")
                        .HasColumnName("TransportationID");

                    b.HasKey("TourDirectionId")
                        .HasName("PK_Tour_Directions");

                    b.HasIndex("ActivityId");

                    b.HasIndex("DirectionTypeId");

                    b.HasIndex("TransportationId");

                    b.ToTable("Tour_Directions");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourDirectionsPath", b =>
                {
                    b.Property<int>("DirectionPathId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DirectionPathID");

                    b.Property<int?>("AirportId")
                        .HasColumnName("AirportID");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool?>("IsActive");

                    b.Property<int?>("TimeZoneId")
                        .HasColumnName("TimeZoneID");

                    b.Property<int>("TourDirectionId")
                        .HasColumnName("TourDirectionID");

                    b.HasKey("DirectionPathId")
                        .HasName("PK_Tour_Directions_Path");

                    b.HasIndex("AirportId");

                    b.HasIndex("TimeZoneId");

                    b.HasIndex("TourDirectionId");

                    b.ToTable("Tour_Directions_Path");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourDirectionType", b =>
                {
                    b.Property<int>("DirectionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DirectionTypeID");

                    b.Property<string>("DirectionTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.HasKey("DirectionTypeId")
                        .HasName("PK__Tour_Dir__F06BCF9B2B12C2D6");

                    b.ToTable("Tour_DirectionType");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourNote", b =>
                {
                    b.Property<int>("TourNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourNoteID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("Note")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PhotoCaption")
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("StartTime")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("StartTimeCounterpart")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StartTimeZone")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("TourId")
                        .HasColumnName("TourID");

                    b.Property<int>("TourPlanId")
                        .HasColumnName("TourPlanID");

                    b.Property<string>("Url")
                        .HasColumnName("URL")
                        .HasColumnType("varchar(250)");

                    b.HasKey("TourNoteId");

                    b.HasIndex("TourId");

                    b.ToTable("Tour_Note");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourParticipant", b =>
                {
                    b.Property<int>("TourId")
                        .HasColumnName("TourID");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(60);

                    b.Property<DateTime?>("DateConfirmed")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateInvited")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<bool?>("IsConfirmed")
                        .HasColumnName("isConfirmed");

                    b.Property<bool?>("IsOrganizer")
                        .HasColumnName("isOrganizer");

                    b.Property<bool?>("IsParticipant")
                        .HasColumnName("isParticipant");

                    b.Property<bool?>("IsViewer")
                        .HasColumnName("isViewer");

                    b.Property<string>("Status")
                        .HasMaxLength(15);

                    b.HasKey("TourId", "EmailAddress")
                        .HasName("PK_Tour_Participant");

                    b.ToTable("Tour_Participant");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourPlan", b =>
                {
                    b.Property<int>("TourPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourPlanID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<DateTime?>("PlanDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PlanName")
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("PlanTypeId")
                        .HasColumnName("PlanTypeID");

                    b.Property<int>("TourId")
                        .HasColumnName("TourID");

                    b.HasKey("TourPlanId");

                    b.HasIndex("TourId");

                    b.ToTable("Tour_Plan");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourPlanCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID");

                    b.Property<string>("Category")
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.HasKey("CategoryId")
                        .HasName("PK__Tour_Pla__19093A2BBC8430A4");

                    b.ToTable("Tour_Plan_Category");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourPlanType", b =>
                {
                    b.Property<int>("TourPlanTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourPlanTypeID");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("PlanTypeName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("TourPlanTypeId");

                    b.ToTable("Tour_Plan_Type");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourReview", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ReviewID");

                    b.Property<int?>("AccountId")
                        .HasColumnName("AccountID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("ReviewText");

                    b.Property<int?>("TourId")
                        .HasColumnName("TourID");

                    b.HasKey("ReviewId")
                        .HasName("PK__Tour_Rev__74BC79AE89817B2A");

                    b.HasIndex("TourId");

                    b.ToTable("Tour_Review");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationCar", b =>
                {
                    b.Property<int>("TransportationCarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationCarID");

                    b.Property<string>("CarType")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<int>("TransportationId")
                        .HasColumnName("TransportationID");

                    b.HasKey("TransportationCarId")
                        .HasName("PK_Tour_Transportation_Car_1");

                    b.HasIndex("TransportationId");

                    b.ToTable("Tour_Transportation_Car");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationCruise", b =>
                {
                    b.Property<int>("TransportationCruiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationCruiseID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("ShipName")
                        .HasMaxLength(50);

                    b.Property<int>("TransportationId")
                        .HasColumnName("TransportationID");

                    b.HasKey("TransportationCruiseId")
                        .HasName("PK_Tour_Transportation_Cruise_1");

                    b.HasIndex("TransportationId");

                    b.ToTable("Tour_Transportation_Cruise");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationFlight", b =>
                {
                    b.Property<int>("TransportationFlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationFlightID");

                    b.Property<string>("FlightNo")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<int>("TransportationId")
                        .HasColumnName("TransportationID");

                    b.HasKey("TransportationFlightId")
                        .HasName("PK_Tour_Transportation_Flight_1");

                    b.HasIndex("TransportationId");

                    b.ToTable("Tour_Transportation_Flight");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportations", b =>
                {
                    b.Property<int>("TransportationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsActive");

                    b.Property<int>("TourPlanId")
                        .HasColumnName("TourPlanID");

                    b.Property<int>("TransportationTypeId")
                        .HasColumnName("TransportationTypeID");

                    b.HasKey("TransportationId")
                        .HasName("PK_Tour_Transportations");

                    b.HasIndex("TourPlanId");

                    b.HasIndex("TransportationTypeId");

                    b.ToTable("Tour_Transportations");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationTrain", b =>
                {
                    b.Property<int>("TransportationTrainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationTrainID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("StationName")
                        .HasMaxLength(50);

                    b.Property<int>("TransportationId")
                        .HasColumnName("TransportationID");

                    b.HasKey("TransportationTrainId")
                        .HasName("PK_Tour_Transportation_Train_1");

                    b.HasIndex("TransportationId");

                    b.ToTable("Tour_Transportation_Train");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationType", b =>
                {
                    b.Property<int>("TransportationTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TransportationTypeID");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("TransportationTypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("TransportationTypeId")
                        .HasName("PK_TransportationTypeID");

                    b.ToTable("Tour_TransportationType");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourType", b =>
                {
                    b.Property<int>("TourTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TourTypeID");

                    b.Property<bool?>("IsActive")
                        .HasColumnName("isActive");

                    b.Property<string>("TourTypeName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("TourTypeId");

                    b.ToTable("Tour_Type");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Newsfeed", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.Tour", "Account")
                        .WithMany("Newsfeed")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK_Newsfeed_Tour");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Organization", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.OrganizationType", "OrganizationType")
                        .WithMany("Organization")
                        .HasForeignKey("OrganizationTypeId")
                        .HasConstraintName("FK_Organization_Organization_Type");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.Tour", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourType", "TourType")
                        .WithMany("Tour")
                        .HasForeignKey("TourTypeId")
                        .HasConstraintName("FK_Tour_Tour_Type");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivities", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivityType", "ActivityType")
                        .WithMany("TourActivities")
                        .HasForeignKey("ActivityTypeId");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TourPlan", "TourPlan")
                        .WithMany("TourActivities")
                        .HasForeignKey("TourPlanId")
                        .HasConstraintName("FK_Tour_Activities_Tour_Plan");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesDining", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourActivitiesDining")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Activities_Dining_Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesLodging", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourActivitiesLodging")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Activities_Lodging_Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesMeeting", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourActivitiesMeeting")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Activities_Meeting_Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourActivitiesPlace", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourActivitiesPlace")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Activities_Place_Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourAttachment", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourAttachment")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Attachment_Tour_Activities");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourDirections", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourActivities", "Activity")
                        .WithMany("TourDirections")
                        .HasForeignKey("ActivityId")
                        .HasConstraintName("FK_Tour_Directions_Tour_Activities");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TourDirectionType", "DirectionType")
                        .WithMany("TourDirections")
                        .HasForeignKey("DirectionTypeId")
                        .HasConstraintName("FK_Tour_Directions_Tour_DirectionType");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportations", "Transportation")
                        .WithMany("TourDirections")
                        .HasForeignKey("TransportationId");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourDirectionsPath", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.Airports", "Airport")
                        .WithMany("TourDirectionsPath")
                        .HasForeignKey("AirportId")
                        .HasConstraintName("FK_Tour_Directions_Path_Airports");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TimeZone", "TimeZone")
                        .WithMany("TourDirectionsPath")
                        .HasForeignKey("TimeZoneId")
                        .HasConstraintName("FK_Tour_Directions_Path_TimeZone");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TourDirections", "TourDirection")
                        .WithMany("TourDirectionsPath")
                        .HasForeignKey("TourDirectionId")
                        .HasConstraintName("FK_Tour_Directions_Path_Tour_Directions");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourNote", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourPlan", "Tour")
                        .WithMany("TourNote")
                        .HasForeignKey("TourId")
                        .HasConstraintName("FK_Tour_Note_Tour_Plan");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourParticipant", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.Tour", "Tour")
                        .WithMany("TourParticipant")
                        .HasForeignKey("TourId")
                        .HasConstraintName("FK_Tour_Participant_Tour");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourPlan", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.Tour", "Tour")
                        .WithMany("TourPlan")
                        .HasForeignKey("TourId")
                        .HasConstraintName("FK_Tour_Plan_Tour");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourReview", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.Tour", "Tour")
                        .WithMany("TourReview")
                        .HasForeignKey("TourId")
                        .HasConstraintName("FK_Tour_Review_Tour");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationCar", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportations", "Transportation")
                        .WithMany("TourTransportationCar")
                        .HasForeignKey("TransportationId");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationCruise", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportations", "Transportation")
                        .WithMany("TourTransportationCruise")
                        .HasForeignKey("TransportationId");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationFlight", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportations", "Transportation")
                        .WithMany("TourTransportationFlight")
                        .HasForeignKey("TransportationId");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportations", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourPlan", "TourPlan")
                        .WithMany("TourTransportations")
                        .HasForeignKey("TourPlanId")
                        .HasConstraintName("FK_Tour_Transportations_Tour_Plan");

                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportationType", "TransportationType")
                        .WithMany("TourTransportations")
                        .HasForeignKey("TransportationTypeId")
                        .HasConstraintName("FK_Tour_Transportations_Tour_TransportationType");
                });

            modelBuilder.Entity("UGroopData.Sql.Repository2.Data.TourTransportationTrain", b =>
                {
                    b.HasOne("UGroopData.Sql.Repository2.Data.TourTransportations", "Transportation")
                        .WithMany("TourTransportationTrain")
                        .HasForeignKey("TransportationId");
                });
        }
    }
}
