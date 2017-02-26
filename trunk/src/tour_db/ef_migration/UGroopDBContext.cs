using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
//using System.Configuration;

namespace UGroopData.Sql.Repository2.Data
{
    public partial class UGroopDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["UGroopDB_New"].ConnectionString);
				optionsBuilder.UseSqlServer(@"Server=.; Database=UGroopDB_Temp3; User Id=sa; Password=Password1*");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Airports>(entity => {
                entity.HasKey(e => e.AirportId)
                    .HasName("PK_Airports");

                entity.Property(e => e.AirportId).HasColumnName("AirportID");

                entity.Property(e => e.Altitude).HasMaxLength(255);

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.Country).HasMaxLength(255);

                entity.Property(e => e.Dst)
                    .HasColumnName("DST")
                    .HasMaxLength(255);

                entity.Property(e => e.Iata)
                    .HasColumnName("IATA")
                    .HasMaxLength(255);

                entity.Property(e => e.Icao)
                    .HasColumnName("ICAO")
                    .HasMaxLength(255);

                entity.Property(e => e.Latitude).HasMaxLength(255);

                entity.Property(e => e.Longitude).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Timezone).HasMaxLength(255);

                entity.Property(e => e.Tzdatabase).HasMaxLength(255);
            });

            modelBuilder.Entity<Country>(entity => {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.CountryFlag).HasColumnType("varchar(50)");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Nationality).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Newsfeed>(entity => {
                entity.Property(e => e.NewsfeedId).HasColumnName("NewsfeedID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NewsfeedContent).HasColumnType("varchar(max)");

                entity.Property(e => e.NewsfeedDate).HasColumnType("datetime");

                entity.Property(e => e.NewsfeedTitle)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Newsfeed)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Newsfeed_Tour");
            });

            modelBuilder.Entity<Organization>(entity => {
                entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrganizationName).HasColumnType("varchar(100)");

                entity.Property(e => e.OrganizationTypeId)
                    .HasColumnName("OrganizationTypeID")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.OrganizationType)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.OrganizationTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Organization_Organization_Type");
            });

            modelBuilder.Entity<OrganizationType>(entity => {
                entity.ToTable("Organization_Type");

                entity.Property(e => e.OrganizationTypeId).HasColumnName("OrganizationTypeID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrganizationTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TimeZone>(entity => {
                entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TimeGmt)
                    .HasColumnName("TimeGMT")
                    .HasMaxLength(30);

                entity.Property(e => e.TimeZoneAbbr).HasMaxLength(30);

                entity.Property(e => e.TimeZoneName).HasMaxLength(60);

                entity.Property(e => e.TimeZoneUtc).HasColumnType("varchar(30)");
            });

            modelBuilder.Entity<Tour>(entity => {
                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DestinationCity).HasColumnType("varchar(max)");

                entity.Property(e => e.DestinationCoordinate).HasColumnType("varchar(150)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.OrgId)
                    .HasColumnName("OrgID")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Photo).HasColumnType("varchar(max)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TourDescription).HasColumnType("varchar(max)");

                entity.Property(e => e.TourName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.TourTypeId).HasColumnName("TourTypeID");

                entity.HasOne(d => d.TourType)
                    .WithMany(p => p.Tour)
                    .HasForeignKey(d => d.TourTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Tour_Type");
            });

            //modelBuilder.Entity<TourActivities>(entity => {
            //    entity.HasKey(e => e.ActivityId)
            //        .HasName("PK_Tour_Activities");

            //    entity.ToTable("Tour_Activities");

            //    entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

            //    entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

            //    entity.Property(e => e.DateCreated)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("getdate()");

            //    entity.Property(e => e.TourId).HasColumnName("TourID");

            //    entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

            //    entity.HasOne(d => d.ActivityType)
            //        .WithMany(p => p.TourActivities)
            //        .HasForeignKey(d => d.ActivityTypeId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Tour_Activities_Tour_ActivityType");

            //    entity.HasOne(d => d.TourPlan)
            //        .WithMany(p => p.TourActivities)
            //        .HasForeignKey(d => d.TourPlanId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Tour_Activities_Tour_Plan");
            //});

            modelBuilder.Entity<TourActivities>(entity => {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK_Tour_Activities");

                entity.ToTable("Tour_Activities");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.TourActivities)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Activities_Tour_ActivityType");

                entity.HasOne(d => d.TourPlan)
                    .WithMany(p => p.TourActivities)
                    .HasForeignKey(d => d.TourPlanId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Activities_Tour_Plan");
            });

            //modelBuilder.Entity<TourActivitiesDining>(entity => {
            //    entity.ToTable("Tour_Activities_Dining");
            //    entity.Property(e => e.DiningName).HasMaxLength(50);
            //    entity.Property(e => e.DiningPlace).HasMaxLength(50);
            //});


            modelBuilder.Entity<TourActivitiesDining>(entity => {
                entity.HasKey(e => e.ActivityDiningId)
                    .HasName("PK_Tour_Activities_Dining_1");

                entity.ToTable("Tour_Activities_Dining");

                entity.Property(e => e.ActivityDiningId).HasColumnName("ActivityDiningID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DiningName).HasMaxLength(50);

                entity.Property(e => e.DiningPlace).HasMaxLength(50);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourActivitiesDining)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Activities_Dining_Tour_Activities");
            });


            //modelBuilder.Entity<TourActivitiesLodging>(entity => {
            //    entity.ToTable("Tour_Activities_Lodging");
            //    entity.Property(e => e.LodgingName).HasMaxLength(50);
            //    entity.Property(e => e.LodgingPlace).HasMaxLength(50);
            //});


            modelBuilder.Entity<TourActivitiesLodging>(entity => {
                entity.HasKey(e => e.ActivityLodgingId)
                    .HasName("PK_Tour_Activities_Lodging_1");

                entity.ToTable("Tour_Activities_Lodging");

                entity.Property(e => e.ActivityLodgingId).HasColumnName("ActivityLodgingID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.LodgingName).HasMaxLength(50);

                entity.Property(e => e.LodgingPlace).HasMaxLength(50);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourActivitiesLodging)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Activities_Lodging_Tour_Activities");
            });


            //modelBuilder.Entity<TourActivitiesMeeting>(entity => {
            //    entity.ToTable("Tour_Activities_Meeting");
            //    entity.Property(e => e.MeetingName).HasMaxLength(50);
            //    entity.Property(e => e.MeetingPlace).HasMaxLength(50);
            //});

            modelBuilder.Entity<TourActivitiesMeeting>(entity => {
                entity.HasKey(e => e.ActivityMeetingId)
                    .HasName("PK_Tour_Activities_Meeting_1");

                entity.ToTable("Tour_Activities_Meeting");

                entity.Property(e => e.ActivityMeetingId).HasColumnName("ActivityMeetingID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.MeetingName).HasMaxLength(50);

                entity.Property(e => e.MeetingPlace).HasMaxLength(50);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourActivitiesMeeting)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Activities_Meeting_Tour_Activities");
            });


            modelBuilder.Entity<TourActivitiesPlace>(entity => {
                entity.HasKey(e => e.ActivityPlaceId)
                    .HasName("PK_Tour_Activities_Place");

                entity.ToTable("Tour_Activities_Place");

                entity.Property(e => e.ActivityPlaceId).HasColumnName("ActivityPlaceID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.Latitude).HasColumnType("decimal");

                entity.Property(e => e.Longitude).HasColumnType("decimal");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourActivitiesPlace)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Tour_Activities_Place_Tour_Activities");
            });

            modelBuilder.Entity<TourActivityType>(entity => {
                entity.HasKey(e => e.ActivityTypeId)
                    .HasName("PK_Tour_ActivityType");

                entity.ToTable("Tour_ActivityType");

                entity.Property(e => e.ActivityTypeId).HasColumnName("ActivityTypeID");

                entity.Property(e => e.ActivityTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TourAttachment>(entity => {
                entity.HasKey(e => e.AttachmentId)
                    .HasName("PK_Tour_Attachment");

                entity.ToTable("Tour_Attachment");

                entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.AttachmentName).HasMaxLength(100);

                entity.Property(e => e.AttachmentPath).HasMaxLength(150);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourAttachment)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Tour_Attachment_Tour_Activities");
            });

            modelBuilder.Entity<TourDirectionType>(entity => {
                entity.HasKey(e => e.DirectionTypeId)
                    .HasName("PK__Tour_Dir__F06BCF9B2B12C2D6");

                entity.ToTable("Tour_DirectionType");

                entity.Property(e => e.DirectionTypeId).HasColumnName("DirectionTypeID");

                entity.Property(e => e.DirectionTypeName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TourDirections>(entity => {
                entity.HasKey(e => e.TourDirectionId)
                    .HasName("PK_Tour_Directions");

                entity.ToTable("Tour_Directions");

                entity.Property(e => e.TourDirectionId).HasColumnName("TourDirectionID");

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.DirectionTypeId).HasColumnName("DirectionTypeID");

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TourDirections)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK_Tour_Directions_Tour_Activities");

                entity.HasOne(d => d.DirectionType)
                    .WithMany(p => p.TourDirections)
                    .HasForeignKey(d => d.DirectionTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Directions_Tour_DirectionType");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.TourDirections)
                    .HasForeignKey(d => d.TransportationId)
                    .HasConstraintName("FK_Tour_Directions_Tour_Transportations");
            });

            modelBuilder.Entity<TourDirectionsPath>(entity => {
                entity.HasKey(e => e.DirectionPathId)
                    .HasName("PK_Tour_Directions_Path");

                entity.ToTable("Tour_Directions_Path");

                entity.Property(e => e.DirectionPathId).HasColumnName("DirectionPathID");

                entity.Property(e => e.AirportId).HasColumnName("AirportID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");

                entity.Property(e => e.TimeZoneId).HasColumnName("TimeZoneID");

                entity.Property(e => e.TourDirectionId).HasColumnName("TourDirectionID");

                entity.HasOne(d => d.Airport)
                    .WithMany(p => p.TourDirectionsPath)
                    .HasForeignKey(d => d.AirportId)
                    .HasConstraintName("FK_Tour_Directions_Path_Airports");

                entity.HasOne(d => d.TimeZone)
                    .WithMany(p => p.TourDirectionsPath)
                    .HasForeignKey(d => d.TimeZoneId)
                    .HasConstraintName("FK_Tour_Directions_Path_TimeZone");

                entity.HasOne(d => d.TourDirection)
                    .WithMany(p => p.TourDirectionsPath)
                    .HasForeignKey(d => d.TourDirectionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Directions_Path_Tour_Directions");
            });

            modelBuilder.Entity<TourNote>(entity => {
                entity.ToTable("Tour_Note");

                entity.Property(e => e.TourNoteId).HasColumnName("TourNoteID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.Note).HasColumnType("varchar(max)");

                entity.Property(e => e.Photo).HasColumnType("varchar(max)");

                entity.Property(e => e.PhotoCaption).HasColumnType("varchar(max)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("varchar(10)");

                entity.Property(e => e.StartTimeCounterpart).HasColumnType("varchar(50)");

                entity.Property(e => e.StartTimeZone).HasColumnType("varchar(50)");

                entity.Property(e => e.Title).HasColumnType("varchar(50)");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasColumnType("varchar(250)");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourNote)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Note_Tour_Plan");
            });

            modelBuilder.Entity<TourParticipant>(entity => {
                entity.HasKey(e => new { e.TourId, e.EmailAddress })
                    .HasName("PK_Tour_Participant");

                entity.ToTable("Tour_Participant");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.EmailAddress).HasMaxLength(60);

                entity.Property(e => e.DateConfirmed).HasColumnType("datetime");

                entity.Property(e => e.DateInvited).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsConfirmed).HasColumnName("isConfirmed");

                entity.Property(e => e.IsOrganizer).HasColumnName("isOrganizer");

                entity.Property(e => e.IsParticipant).HasColumnName("isParticipant");

                entity.Property(e => e.IsViewer).HasColumnName("isViewer");

                entity.Property(e => e.Status).HasMaxLength(15);

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourParticipant)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Participant_Tour");
            });

            modelBuilder.Entity<TourPlan>(entity => {
                entity.ToTable("Tour_Plan");

                entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PlanDate).HasColumnType("datetime");

                entity.Property(e => e.PlanName).HasColumnType("varchar(200)");

                entity.Property(e => e.PlanTypeId).HasColumnName("PlanTypeID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourPlan)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Plan_Tour");
            });

            modelBuilder.Entity<TourPlanCategory>(entity => {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Tour_Pla__19093A2BBC8430A4");

                entity.ToTable("Tour_Plan_Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Category).HasColumnType("varchar(50)");

                entity.Property(e => e.IsActive).HasColumnName("isActive");
            });

            modelBuilder.Entity<TourPlanType>(entity => {
                entity.ToTable("Tour_Plan_Type");

                entity.Property(e => e.TourPlanTypeId).HasColumnName("TourPlanTypeID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.PlanTypeName).HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TourReview>(entity => {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__Tour_Rev__74BC79AE89817B2A");

                entity.ToTable("Tour_Review");

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourReview)
                    .HasForeignKey(d => d.TourId)
                    .HasConstraintName("FK_Tour_Review_Tour");
            });

            //modelBuilder.Entity<TourTransportationCar>(entity => {
            //    entity.ToTable("Tour_Transportation_Car");
            //    entity.Property(e => e.CarType).HasColumnType("nchar(10)");
            //});

            //modelBuilder.Entity<TourTransportationCruise>(entity => {
            //    entity.ToTable("Tour_Transportation_Cruise");
            //    entity.Property(e => e.ShipName).HasColumnType("nchar(10)");
            //});

            //modelBuilder.Entity<TourTransportationFlight>(entity => {
            //    entity.ToTable("Tour_Transportation_Flight");
            //    entity.Property(e => e.FlightNo).HasColumnType("nchar(10)");
            //});

            //modelBuilder.Entity<TourTransportationTrain>(entity => {
            //    entity.ToTable("Tour_Transportation_Train");
            //    entity.Property(e => e.StationName).HasColumnType("nchar(10)");
            //});
            
            modelBuilder.Entity<TourTransportationCar>(entity => {
                entity.HasKey(e => e.TransportationCarId)
                    .HasName("PK_Tour_Transportation_Car_1");

                entity.ToTable("Tour_Transportation_Car");

                entity.Property(e => e.TransportationCarId).HasColumnName("TransportationCarID");

                entity.Property(e => e.CarType).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.TourTransportationCar)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportation_Car_Tour_Transportations");
            });

            modelBuilder.Entity<TourTransportationCruise>(entity => {
                entity.HasKey(e => e.TransportationCruiseId)
                    .HasName("PK_Tour_Transportation_Cruise_1");

                entity.ToTable("Tour_Transportation_Cruise");

                entity.Property(e => e.TransportationCruiseId).HasColumnName("TransportationCruiseID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ShipName).HasMaxLength(50);

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.TourTransportationCruise)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportation_Cruise_Tour_Transportations");
            });

            modelBuilder.Entity<TourTransportationFlight>(entity => {
                entity.HasKey(e => e.TransportationFlightId)
                    .HasName("PK_Tour_Transportation_Flight_1");

                entity.ToTable("Tour_Transportation_Flight");

                entity.Property(e => e.TransportationFlightId).HasColumnName("TransportationFlightID");

                entity.Property(e => e.FlightNo).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.TourTransportationFlight)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportation_Flight_Tour_Transportations");
            });

            modelBuilder.Entity<TourTransportationTrain>(entity => {
                entity.HasKey(e => e.TransportationTrainId)
                    .HasName("PK_Tour_Transportation_Train_1");

                entity.ToTable("Tour_Transportation_Train");

                entity.Property(e => e.TransportationTrainId).HasColumnName("TransportationTrainID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.StationName).HasMaxLength(50);

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.HasOne(d => d.Transportation)
                    .WithMany(p => p.TourTransportationTrain)
                    .HasForeignKey(d => d.TransportationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportation_Train_Tour_Transportations");
            });

            modelBuilder.Entity<TourTransportationType>(entity => {
                entity.HasKey(e => e.TransportationTypeId)
                    .HasName("PK_TransportationTypeID");

                entity.ToTable("Tour_TransportationType");

                entity.Property(e => e.TransportationTypeId).HasColumnName("TransportationTypeID");

                entity.Property(e => e.TransportationTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            //modelBuilder.Entity<TourTransportations>(entity => {
            //    entity.HasKey(e => e.TransportationId)
            //        .HasName("PK_Tour_Transportations");

            //    entity.ToTable("Tour_Transportations");

            //    entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

            //    entity.Property(e => e.DateCreated)
            //        .HasColumnType("datetime")
            //        .HasDefaultValueSql("getdate()");

            //    entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

            //    entity.Property(e => e.TransportationTypeId).HasColumnName("TransportationTypeID");

            //    entity.HasOne(d => d.TourPlan)
            //        .WithMany(p => p.TourTransportations)
            //        .HasForeignKey(d => d.TourPlanId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Tour_Transportations_Tour_Plan");

            //    entity.HasOne(d => d.TransportationType)
            //        .WithMany(p => p.TourTransportations)
            //        .HasForeignKey(d => d.TransportationTypeId)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Tour_Transportations_Tour_TransportationType");
            //});

            modelBuilder.Entity<TourTransportations>(entity => {
                entity.HasKey(e => e.TransportationId)
                    .HasName("PK_Tour_Transportations");

                entity.ToTable("Tour_Transportations");

                entity.Property(e => e.TransportationId).HasColumnName("TransportationID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.TourPlanId).HasColumnName("TourPlanID");

                entity.Property(e => e.TransportationTypeId).HasColumnName("TransportationTypeID");

                entity.HasOne(d => d.TourPlan)
                    .WithMany(p => p.TourTransportations)
                    .HasForeignKey(d => d.TourPlanId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportations_Tour_Plan");

                entity.HasOne(d => d.TransportationType)
                    .WithMany(p => p.TourTransportations)
                    .HasForeignKey(d => d.TransportationTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_Transportations_Tour_TransportationType");
            });

            modelBuilder.Entity<TourType>(entity => {
                entity.ToTable("Tour_Type");

                entity.Property(e => e.TourTypeId).HasColumnName("TourTypeID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TourTypeName).HasColumnType("varchar(50)");
            });
        }


        public virtual DbSet<Airports> Airports { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Newsfeed> Newsfeed { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        public virtual DbSet<TimeZone> TimeZone { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<TourActivities> TourActivities { get; set; }
        public virtual DbSet<TourActivitiesDining> TourActivitiesDining { get; set; }
        public virtual DbSet<TourActivitiesLodging> TourActivitiesLodging { get; set; }
        public virtual DbSet<TourActivitiesMeeting> TourActivitiesMeeting { get; set; }
        public virtual DbSet<TourActivitiesPlace> TourActivitiesPlace { get; set; }
        public virtual DbSet<TourActivityType> TourActivityType { get; set; }
        public virtual DbSet<TourAttachment> TourAttachment { get; set; }
        public virtual DbSet<TourDirectionType> TourDirectionType { get; set; }
        public virtual DbSet<TourDirections> TourDirections { get; set; }
        public virtual DbSet<TourDirectionsPath> TourDirectionsPath { get; set; }
        public virtual DbSet<TourNote> TourNote { get; set; }
        public virtual DbSet<TourParticipant> TourParticipant { get; set; }
        public virtual DbSet<TourPlan> TourPlan { get; set; }
        public virtual DbSet<TourPlanCategory> TourPlanCategory { get; set; }
        public virtual DbSet<TourPlanType> TourPlanType { get; set; }
        public virtual DbSet<TourReview> TourReview { get; set; }
        public virtual DbSet<TourTransportationCar> TourTransportationCar { get; set; }
        public virtual DbSet<TourTransportationCruise> TourTransportationCruise { get; set; }
        public virtual DbSet<TourTransportationFlight> TourTransportationFlight { get; set; }
        public virtual DbSet<TourTransportationTrain> TourTransportationTrain { get; set; }
        public virtual DbSet<TourTransportationType> TourTransportationType { get; set; }
        public virtual DbSet<TourTransportations> TourTransportations { get; set; }
        public virtual DbSet<TourType> TourType { get; set; }



        //=============================================================================
        //=============================================================================
        //=============================================================================



        //public virtual DbSet<Account> Account { get; set; }
        //public virtual DbSet<AccountInfo> AccountInfo { get; set; }
        //public virtual DbSet<AccountInfoTitle> AccountInfoTitle { get; set; }
        //public virtual DbSet<AccountMedical> AccountMedical { get; set; }
        //public virtual DbSet<AccountMedicalCondition> AccountMedicalCondition { get; set; }
        //public virtual DbSet<AccountMedicalConditionType> AccountMedicalConditionType { get; set; }
        //public virtual DbSet<AccountMedicalNotes> AccountMedicalNotes { get; set; }
        //public virtual DbSet<AccountRelative> AccountRelative { get; set; }
        //public virtual DbSet<AccountRelativeType> AccountRelativeType { get; set; }
        //public virtual DbSet<AccountRole> AccountRole { get; set; }
        //public virtual DbSet<AccountSchool> AccountSchool { get; set; }
        //public virtual DbSet<AccountSchoolType> AccountSchoolType { get; set; }
        //public virtual DbSet<AccountTravelDocument> AccountTravelDocument { get; set; }
        //public virtual DbSet<Airports> Airports { get; set; }
        //public virtual DbSet<Banking> Banking { get; set; }
        //public virtual DbSet<BookingSite> BookingSite { get; set; }
        //public virtual DbSet<Country> Country { get; set; }
        //public virtual DbSet<CreditCard> CreditCard { get; set; }
        //public virtual DbSet<DocumentType> DocumentType { get; set; }
        //public virtual DbSet<Gender> Gender { get; set; }
        //public virtual DbSet<Newsfeed> Newsfeed { get; set; }
        //public virtual DbSet<Organization> Organization { get; set; }
        //public virtual DbSet<OrganizationType> OrganizationType { get; set; }
        //public virtual DbSet<OtherEmail> OtherEmail { get; set; }
        //public virtual DbSet<Passenger> Passenger { get; set; }
        //public virtual DbSet<Religion> Religion { get; set; }
        //public virtual DbSet<Review> Review { get; set; }
        //public virtual DbSet<SchoolLocation> SchoolLocation { get; set; }
        //public virtual DbSet<SchoolPosition> SchoolPosition { get; set; }
        //public virtual DbSet<SecurityQuestion> SecurityQuestion { get; set; }
        //public virtual DbSet<SettingAboutyou> SettingAboutyou { get; set; }
        //public virtual DbSet<SettingBilling> SettingBilling { get; set; }
        //public virtual DbSet<SettingBillingPlan> SettingBillingPlan { get; set; }
        //public virtual DbSet<SettingBillingRenewalCharge> SettingBillingRenewalCharge { get; set; }
        //public virtual DbSet<SettingCreditCardType> SettingCreditCardType { get; set; }
        //public virtual DbSet<SettingEmail> SettingEmail { get; set; }
        //public virtual DbSet<SettingEmailOptionAboutPeople> SettingEmailOptionAboutPeople { get; set; }
        //public virtual DbSet<SettingEmailOptionAboutTour> SettingEmailOptionAboutTour { get; set; }
        //public virtual DbSet<SettingEmailOptionFromUgroop> SettingEmailOptionFromUgroop { get; set; }
        //public virtual DbSet<SettingEmailOptions> SettingEmailOptions { get; set; }
        //public virtual DbSet<SettingPublishing> SettingPublishing { get; set; }
        //public virtual DbSet<SettingYourProfile> SettingYourProfile { get; set; }
        //public virtual DbSet<Supplier> Supplier { get; set; }
        //public virtual DbSet<SysMethod> SysMethod { get; set; }
        //public virtual DbSet<SysPage> SysPage { get; set; }
        //public virtual DbSet<SysPagePanel> SysPagePanel { get; set; }
        //public virtual DbSet<SysPersmission> SysPersmission { get; set; }
        //public virtual DbSet<SysRoleMethodAccess> SysRoleMethodAccess { get; set; }
        //public virtual DbSet<TimeZone> TimeZone { get; set; }
        //public virtual DbSet<Tour> Tour { get; set; }
        //public virtual DbSet<TourActivities> TourActivities { get; set; }
        //public virtual DbSet<TourActivitiesPlace> TourActivitiesPlace { get; set; }
        //public virtual DbSet<TourActivity> TourActivity { get; set; }
        //public virtual DbSet<TourActivityType> TourActivityType { get; set; }
        //public virtual DbSet<TourAttachment> TourAttachment { get; set; }
        //public virtual DbSet<TourCarRental> TourCarRental { get; set; }
        //public virtual DbSet<TourCruise> TourCruise { get; set; }
        //public virtual DbSet<TourDirection> TourDirection { get; set; }
        //public virtual DbSet<TourDirectionType> TourDirectionType { get; set; }
        //public virtual DbSet<TourDirections> TourDirections { get; set; }
        //public virtual DbSet<TourDirectionsPath> TourDirectionsPath { get; set; }
        //public virtual DbSet<TourFlight> TourFlight { get; set; }
        //public virtual DbSet<TourLodging> TourLodging { get; set; }
        //public virtual DbSet<TourMap> TourMap { get; set; }
        //public virtual DbSet<TourMeeting> TourMeeting { get; set; }
        //public virtual DbSet<TourMeetingActivityType> TourMeetingActivityType { get; set; }
        //public virtual DbSet<TourNote> TourNote { get; set; }
        //public virtual DbSet<TourParking> TourParking { get; set; }
        //public virtual DbSet<TourParticipant> TourParticipant { get; set; }
        //public virtual DbSet<TourPlan> TourPlan { get; set; }
        //public virtual DbSet<TourPlanBookingSite> TourPlanBookingSite { get; set; }
        //public virtual DbSet<TourPlanCategory> TourPlanCategory { get; set; }
        //public virtual DbSet<TourPlanParticipantAssignment> TourPlanParticipantAssignment { get; set; }
        //public virtual DbSet<TourPlanSupplier> TourPlanSupplier { get; set; }
        //public virtual DbSet<TourPlanType> TourPlanType { get; set; }
        //public virtual DbSet<TourRating> TourRating { get; set; }
        //public virtual DbSet<TourRestaurant> TourRestaurant { get; set; }
        //public virtual DbSet<TourReview> TourReview { get; set; }
        //public virtual DbSet<TourRole> TourRole { get; set; }
        //public virtual DbSet<TourSegment> TourSegment { get; set; }
        //public virtual DbSet<TourTrain> TourTrain { get; set; }
        ////public virtual DbSet<TourTransportationCar> TourTransportationCar { get; set; }
        ////public virtual DbSet<TourTransportationCruise> TourTransportationCruise { get; set; }
        ////public virtual DbSet<TourTransportationFlight> TourTransportationFlight { get; set; }
        ////public virtual DbSet<TourTransportationTrain> TourTransportationTrain { get; set; }
        //public virtual DbSet<TourTransportationType> TourTransportationType { get; set; }
        //public virtual DbSet<TourTransportations> TourTransportations { get; set; }
        //public virtual DbSet<TourType> TourType { get; set; }
        //public virtual DbSet<TravelContact> TravelContact { get; set; }
        //public virtual DbSet<TravelContactType> TravelContactType { get; set; }
        //public virtual DbSet<Uirestriction> Uirestriction { get; set; }
        //public virtual DbSet<UserProfileVisibilitySetting> UserProfileVisibilitySetting { get; set; }
        //public virtual DbSet<UserSecurityQuestion> UserSecurityQuestion { get; set; }
        //public virtual DbSet<UserSession> UserSession { get; set; }


    }
}