using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OMSDAdmin.Models
{
    public partial class OMSDStagingSTI_CustomContext : DbContext
    {
        public OMSDStagingSTI_CustomContext()
        {
        }

        public OMSDStagingSTI_CustomContext(DbContextOptions<OMSDStagingSTI_CustomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinic> Clinic { get; set; }
        public virtual DbSet<ClinicCsv> ClinicCsv { get; set; }
        public virtual DbSet<ClinicUser> ClinicUser { get; set; }
        public virtual DbSet<ClinicUserType> ClinicUserType { get; set; }
        public virtual DbSet<DaysOfTheWeek> DaysOfTheWeek { get; set; }
        public virtual DbSet<EmailNotification> EmailNotification { get; set; }
        public virtual DbSet<EmailType> EmailType { get; set; }
        public virtual DbSet<Flag> Flag { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Lhinname> Lhinname { get; set; }
        public virtual DbSet<OntarioCity> OntarioCity { get; set; }
        public virtual DbSet<PopupContent> PopupContent { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<RelatedContentWidgets> RelatedContentWidgets { get; set; }
        public virtual DbSet<SearchParameters> SearchParameters { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Specialty> Specialty { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StreetDirection> StreetDirection { get; set; }
        public virtual DbSet<StreetType> StreetType { get; set; }
        public virtual DbSet<TClinicHours> TClinicHours { get; set; }
        public virtual DbSet<TClinicPractitioner> TClinicPractitioner { get; set; }
        public virtual DbSet<TClinicPractitionerCopy> TClinicPractitionerCopy { get; set; }
        public virtual DbSet<TClinicUser> TClinicUser { get; set; }
        public virtual DbSet<TContentItems> TContentItems { get; set; }
        public virtual DbSet<TimeDateTable> TimeDateTable { get; set; }
        public virtual DbSet<TLanguageContent> TLanguageContent { get; set; }
        public virtual DbSet<TLanguages> TLanguages { get; set; }
        public virtual DbSet<TPopupContentItem> TPopupContentItem { get; set; }
        public virtual DbSet<TServiceContent> TServiceContent { get; set; }
        public virtual DbSet<TServices> TServices { get; set; }
        public virtual DbSet<TServiceTypeContent> TServiceTypeContent { get; set; }
        public virtual DbSet<TServiceTypePromo> TServiceTypePromo { get; set; }
        public virtual DbSet<TSpecialtyContent> TSpecialtyContent { get; set; }
        public virtual DbSet<TypeOfProblem> TypeOfProblem { get; set; }
        public virtual DbSet<V51Languages> V51Languages { get; set; }
        public virtual DbSet<V51Navigation> V51Navigation { get; set; }
        public virtual DbSet<ZzAnotherListing> ZzAnotherListing { get; set; }
        public virtual DbSet<ZzCity> ZzCity { get; set; }

        // Unable to generate entity type for table 'dbo.V51_Process_Queries'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_FormDefinition'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Classifications_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ClinicUser_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Clinictransfer'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Groups'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Template'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ZZ_t_Languages_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ClinicHours_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_FormDefinition_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LexiconUsers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Template_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Template_Type'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_PageDefinition_ContentField'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Languages_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ClinicUser_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LexiconUsers_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Template_Type_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ListControl_Items'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ClinicCSV_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_PageDefinition_ContentField_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.multiselect'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Permissions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Upload_Files'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Clinic_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_PageDefinition_Element'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Permissions_Listings'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Upload_Files_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.LHINName_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Popup_Content_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_PageDefinition_Element_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ViewDefinition'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ListControl_Items_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Options'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_process_actions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ListControls'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ZZ_Another_Listing_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Options_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_ViewDefinition_Field'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Search_Parameters_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Query_Templates'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Days_Of_The_Week_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._BC_non'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ViewDefinition_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ServiceType_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._BC'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo._PHU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Popup_Content_Item_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ViewListingRelations'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_ListControls_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_ViewDefinition_Field_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_Email_Actions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Listings'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UploadFiles'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ViewListingRelations_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ServiceTypeContent_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ZZ_City_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_Fields'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Status_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UploadFiles_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ServiceTypePromo_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Languages_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Service_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Related_Content_Widgets_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.URL_Mapping'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Specialty_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.StreetType_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Email_Notifications'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ServiceContent_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EmailNotification_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Language_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Content_Items_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.StreetDirection_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_PageDefinition'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Email_Q'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.EmailType_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_PageDefinition_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CLINIC_BKUP_0815'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_LanguageContent_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ClinicHours_0815'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.OntarioCity_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TypeOfProblem_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_PageElements'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_FormDefinition_Field'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_PageElements_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ClinicUserType_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_SpecialtyContent_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Email_Q_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Flag_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_PageLabels'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_FormDefinition_Field_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Field_Types'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_V51_Navigation_Vars'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Classifications'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Province_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_process_actions'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_Services_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.t_ClinicPractitioner_multi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.V51_Field_Types_multi'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NAPHJE9;Database=OMSDStagingSTI_Custom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.Property(e => e.ClinicId).HasColumnName("Clinic_id");

                entity.Property(e => e.AcceptingNew).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClinicAdminEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CommunityAndAreasServed)
                    .HasColumnName("Community_And_Areas_Served")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.DateActivated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.DateModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DescriptionFrench)
                    .HasColumnName("Description_French")
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.DiabetesId).HasColumnName("diabetesID");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Email1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HoursOfBusinessNotes)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.HoursOfBusinessNotesForFrench)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hsphone1)
                    .HasColumnName("HSphone1")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hsphone2)
                    .HasColumnName("HSphone2")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Hsphone3)
                    .HasColumnName("HSphone3")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsAvailableForHighRiskScreening).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsEmail1Primary).HasDefaultValueSql("((0))");

                entity.Property(e => e.Latitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.Lhinname).HasColumnName("LHINName");

                entity.Property(e => e.Longitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.MailingAddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailingAddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MailingPostalCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Phone2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhysicalAddressLine1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhysicalAddressLine2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhysicalPostalCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowAcceptingNew).HasDefaultValueSql("((0))");

                entity.Property(e => e.Status).HasDefaultValueSql("((3))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.WaitTimeId)
                    .HasColumnName("WaitTimeID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WaitTimeInfo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Website)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebsiteFrench)
                    .HasColumnName("Website_French")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.LastModifiedByNavigation)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK_Clinic_ClinicUser972670245833333");

                entity.HasOne(d => d.LhinnameNavigation)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.Lhinname)
                    .HasConstraintName("FK_Clinic_LHINName98303875889");

                entity.HasOne(d => d.MailingCityNavigation)
                    .WithMany(p => p.ClinicMailingCityNavigation)
                    .HasForeignKey(d => d.MailingCity)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Clinic_OntarioCity655694764833333");

                entity.HasOne(d => d.PhysicalCityNavigation)
                    .WithMany(p => p.ClinicPhysicalCityNavigation)
                    .HasForeignKey(d => d.PhysicalCity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clinic_OntarioCity65569294194");

                entity.HasOne(d => d.ServiceTypeNavigation)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.ServiceType)
                    .HasConstraintName("FK_Clinic_ServiceType677585993723333");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Clinic)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clinic_Status655691639873333");
            });

            modelBuilder.Entity<ClinicCsv>(entity =>
            {
                entity.ToTable("ClinicCSV");

                entity.Property(e => e.ClinicCsvId).HasColumnName("ClinicCSV_id");

                entity.Property(e => e.ClinicType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Document)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<ClinicUser>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("IX_ClinicUser_Email_Unique")
                    .IsUnique();

                entity.Property(e => e.ClinicUserId).HasColumnName("ClinicUser_id");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.AdminInfo)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.DateActivated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.DiabetesId).HasColumnName("diabetesID");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Fax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PhysicianLastNameforCsn)
                    .HasColumnName("PhysicianLastNameforCSN")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.ClinicUserTypeNavigation)
                    .WithMany(p => p.ClinicUser)
                    .HasForeignKey(d => d.ClinicUserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUser_ClinicUserType626777166233333");

                entity.HasOne(d => d.ProvinceNavigation)
                    .WithMany(p => p.ClinicUser)
                    .HasForeignKey(d => d.Province)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUser_Province626778728713333");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.ClinicUser)
                    .HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClinicUser_Status6267784683");
            });

            modelBuilder.Entity<ClinicUserType>(entity =>
            {
                entity.Property(e => e.ClinicUserTypeId).HasColumnName("ClinicUserType_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<DaysOfTheWeek>(entity =>
            {
                entity.ToTable("Days_Of_The_Week");

                entity.Property(e => e.DaysOfTheWeekId).HasColumnName("Days_Of_The_Week_id");

                entity.Property(e => e.Abbreviation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<EmailNotification>(entity =>
            {
                entity.Property(e => e.EmailNotificationId).HasColumnName("EmailNotification_id");

                entity.Property(e => e.AddressFrom)
                    .HasColumnName("addressFrom")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Body)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.NameFrom)
                    .HasColumnName("nameFrom")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sub)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.EmailLanguageNavigation)
                    .WithMany(p => p.EmailNotification)
                    .HasForeignKey(d => d.EmailLanguage)
                    .HasConstraintName("FK_EmailNotification_Language913082904166667");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.EmailNotification)
                    .HasForeignKey(d => d.Type)
                    .HasConstraintName("FK_EmailNotification_EmailType904115195833333");
            });

            modelBuilder.Entity<EmailType>(entity =>
            {
                entity.Property(e => e.EmailTypeId).HasColumnName("EmailType_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.TypeName)
                    .HasColumnName("Type_Name")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Flag>(entity =>
            {
                entity.Property(e => e.FlagId).HasColumnName("Flag_id");

                entity.Property(e => e.Closed).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Details)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.InternalNotes)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.ClinicNavigation)
                    .WithMany(p => p.Flag)
                    .HasForeignKey(d => d.Clinic)
                    .HasConstraintName("FK_Flag_Clinic6808221167");

                entity.HasOne(d => d.TypeOfProblemNavigation)
                    .WithMany(p => p.Flag)
                    .HasForeignKey(d => d.TypeOfProblem)
                    .HasConstraintName("FK_Flag_TypeOfProblem680821075053333");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageId).HasColumnName("Language_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<Lhinname>(entity =>
            {
                entity.ToTable("LHINName");

                entity.Property(e => e.LhinnameId).HasColumnName("LHINName_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<OntarioCity>(entity =>
            {
                entity.Property(e => e.OntarioCityId).HasColumnName("OntarioCity_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.DiabetesId).HasColumnName("diabetesID");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Long)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<PopupContent>(entity =>
            {
                entity.ToTable("Popup_Content");

                entity.Property(e => e.PopupContentId).HasColumnName("Popup_Content_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.Property(e => e.ProvinceId).HasColumnName("Province_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<RelatedContentWidgets>(entity =>
            {
                entity.ToTable("Related_Content_Widgets");

                entity.Property(e => e.RelatedContentWidgetsId).HasColumnName("Related_Content_Widgets_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.WebsiteSection)
                    .HasColumnName("Website_Section")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.RelatedContentWidgets)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_Related_Content_Widgets_V51_Languages939938470833333");
            });

            modelBuilder.Entity<SearchParameters>(entity =>
            {
                entity.ToTable("Search_Parameters");

                entity.Property(e => e.SearchParametersId).HasColumnName("Search_Parameters_id");

                entity.Property(e => e.Browser)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CityId1).HasColumnName("CityID");

                entity.Property(e => e.DateSearched)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1/1/1900')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.LocatedNear)
                    .HasColumnName("Located_Near")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Long)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NumOfResults)
                    .HasColumnName("Num_of_Results")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ProximityLimit).HasDefaultValueSql("((0))");

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ServicesOffered)
                    .HasColumnName("Services_Offered")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.UserAgent)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityId1Navigation)
                    .WithMany(p => p.SearchParameters)
                    .HasForeignKey(d => d.CityId1)
                    .HasConstraintName("FK_Search_Parameters_OntarioCity843199479166667");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("Service_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.DiabetesId).HasColumnName("diabetesID");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.ParentNavigation)
                    .WithMany(p => p.InverseParentNavigation)
                    .HasForeignKey(d => d.Parent)
                    .HasConstraintName("FK_Service_Service853306835416667");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceType_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.Property(e => e.SpecialtyId).HasColumnName("Specialty_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<StreetDirection>(entity =>
            {
                entity.Property(e => e.StreetDirectionId).HasColumnName("StreetDirection_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<StreetType>(entity =>
            {
                entity.Property(e => e.StreetTypeId).HasColumnName("StreetType_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<TClinicHours>(entity =>
            {
                entity.ToTable("t_ClinicHours");

                entity.HasIndex(e => new { e.TClinicHoursId, e.StartTime, e.EndTime, e.Sublistingid, e.Day })
                    .HasName("_dta_index_t_ClinicHours_143_100195407__K3_K9_1_5_8");

                entity.Property(e => e.TClinicHoursId).HasColumnName("t_ClinicHours_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.EndTime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartTime)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TClinicHours)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_ClinicHours_Clinic664659747321667");
            });

            modelBuilder.Entity<TClinicPractitioner>(entity =>
            {
                entity.ToTable("t_ClinicPractitioner");

                entity.HasIndex(e => new { e.Name, e.PractitionerPhone, e.Description, e.Sublistingid })
                    .HasName("IX_ClinicPractitioner_Sublisting");

                entity.Property(e => e.TClinicPractitionerId).HasColumnName("t_ClinicPractitioner_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Languages)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PractitionerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sortOrder")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TClinicPractitioner)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_ClinicPractitioner_Clinic66256394774");
            });

            modelBuilder.Entity<TClinicPractitionerCopy>(entity =>
            {
                entity.HasKey(e => e.TClinicPractitionerId);

                entity.ToTable("t_ClinicPractitionerCopy");

                entity.Property(e => e.TClinicPractitionerId)
                    .HasColumnName("t_ClinicPractitioner_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Language).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PractitionerPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Specialty).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TClinicPractitionerCopy)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_ClinicPractitionerCopy_Clinic66256394774");
            });

            modelBuilder.Entity<TClinicUser>(entity =>
            {
                entity.ToTable("t_ClinicUser");

                entity.Property(e => e.TClinicUserId).HasColumnName("t_ClinicUser_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.ClinicUserNavigation)
                    .WithMany(p => p.TClinicUser)
                    .HasForeignKey(d => d.ClinicUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_t_ClinicUser_ClinicUser665565377945");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.TClinicUser)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_t_ClinicUser_Status665565117556667");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TClinicUser)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_ClinicUser_Clinic665563294838333");
            });

            modelBuilder.Entity<TContentItems>(entity =>
            {
                entity.ToTable("t_Content_Items");

                entity.Property(e => e.TContentItemsId).HasColumnName("t_Content_Items_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Href)
                    .HasColumnName("HREF")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ShowBullet)
                    .HasColumnName("Show_Bullet")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SortOrder)
                    .HasColumnName("sortOrder")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Upload)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TContentItems)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_Content_Items_Related_Content_Widgets941114252083333");
            });

            modelBuilder.Entity<TimeDateTable>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.Property(e => e.TimeId).HasColumnName("TimeID");

                entity.Property(e => e.QuarterOfYear)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TheDate)
                    .HasColumnName("theDate")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.TheDay)
                    .HasColumnName("theDay")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TheMonth)
                    .HasColumnName("theMonth")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TheYear).HasColumnName("theYear");
            });

            modelBuilder.Entity<TLanguageContent>(entity =>
            {
                entity.ToTable("t_LanguageContent");

                entity.Property(e => e.TLanguageContentId).HasColumnName("t_LanguageContent_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.V51Language).HasColumnName("V51_Language");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TLanguageContentLanguageNavigation)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_t_LanguageContent_Language6606686595");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TLanguageContentSublisting)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_LanguageContent_Language660666576193333");

                entity.HasOne(d => d.V51LanguageNavigation)
                    .WithMany(p => p.TLanguageContent)
                    .HasForeignKey(d => d.V51Language)
                    .HasConstraintName("FK_t_LanguageContent_V51_Languages68844905");
            });

            modelBuilder.Entity<TLanguages>(entity =>
            {
                entity.ToTable("t_Languages");

                entity.Property(e => e.TLanguagesId).HasColumnName("t_Languages_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.LanNavigation)
                    .WithMany(p => p.TLanguages)
                    .HasForeignKey(d => d.Lan)
                    .HasConstraintName("FK_t_Languages_Language78297639375");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TLanguages)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_Languages_Clinic782967279166667");
            });

            modelBuilder.Entity<TPopupContentItem>(entity =>
            {
                entity.ToTable("t_Popup_Content_Item");

                entity.Property(e => e.TPopupContentItemId).HasColumnName("t_Popup_Content_Item_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TPopupContentItem)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_t_Popup_Content_Item_V51_Languages870249502083333");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TPopupContentItem)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_Popup_Content_Item_Popup_Content87024585625");
            });

            modelBuilder.Entity<TServiceContent>(entity =>
            {
                entity.ToTable("t_ServiceContent");

                entity.Property(e => e.TServiceContentId).HasColumnName("t_ServiceContent_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TServiceContent)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_t_ServiceContent_V51_Languages640450022916667");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TServiceContent)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_ServiceContent_Service676152176263333");
            });

            modelBuilder.Entity<TServices>(entity =>
            {
                entity.ToTable("t_Services");

                entity.HasIndex(e => new { e.Sublistingid, e.Service })
                    .HasName("IX_Services_sublisting_service");

                entity.Property(e => e.TServicesId).HasColumnName("t_Services_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.ServiceNavigation)
                    .WithMany(p => p.TServices)
                    .HasForeignKey(d => d.Service)
                    .HasConstraintName("FK_t_Services_Service72326171875");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TServices)
                    .HasForeignKey(d => d.Sublistingid)
                    .HasConstraintName("FRK_t_Services_Clinic7232421875");
            });

            modelBuilder.Entity<TServiceTypeContent>(entity =>
            {
                entity.ToTable("t_ServiceTypeContent");

                entity.Property(e => e.TServiceTypeContentId).HasColumnName("t_ServiceTypeContent_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.LearnMoreLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OptionalLinkName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.OptionalLinkUrl)
                    .HasColumnName("OptionalLinkURL")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Summary)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitleLegend)
                    .HasColumnName("Title_Legend")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.TitlePlural)
                    .HasColumnName("Title_Plural")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Tooltip)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.V51Languages).HasColumnName("V51_Languages");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TServiceTypeContent)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_ServiceTypeContent_ServiceType672392418818333");

                entity.HasOne(d => d.V51LanguagesNavigation)
                    .WithMany(p => p.TServiceTypeContent)
                    .HasForeignKey(d => d.V51Languages)
                    .HasConstraintName("FK_t_ServiceTypeContent_V51_Languages98712710625");
            });

            modelBuilder.Entity<TServiceTypePromo>(entity =>
            {
                entity.ToTable("t_ServiceTypePromo");

                entity.Property(e => e.TServiceTypePromoId).HasColumnName("t_ServiceTypePromo_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.ImageLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TServiceTypePromo)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("FK_t_ServiceTypePromo_V51_Languages858630533333333");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TServiceTypePromo)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_ServiceTypePromo_ServiceType858620897916667");
            });

            modelBuilder.Entity<TSpecialtyContent>(entity =>
            {
                entity.ToTable("t_SpecialtyContent");

                entity.Property(e => e.TSpecialtyContentId).HasColumnName("t_SpecialtyContent_id");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.V51Language).HasColumnName("v51_Language");

                entity.HasOne(d => d.Sublisting)
                    .WithMany(p => p.TSpecialtyContent)
                    .HasForeignKey(d => d.Sublistingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FRK_t_SpecialtyContent_Specialty66160146006");

                entity.HasOne(d => d.V51LanguageNavigation)
                    .WithMany(p => p.TSpecialtyContent)
                    .HasForeignKey(d => d.V51Language)
                    .HasConstraintName("FK_t_SpecialtyContent_V51_Languages832768841666667");
            });

            modelBuilder.Entity<TypeOfProblem>(entity =>
            {
                entity.Property(e => e.TypeOfProblemId).HasColumnName("TypeOfProblem_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SortOrder).HasDefaultValueSql("((0))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<V51Languages>(entity =>
            {
                entity.ToTable("V51_Languages");

                entity.Property(e => e.V51LanguagesId).HasColumnName("V51_Languages_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<V51Navigation>(entity =>
            {
                entity.ToTable("V51_Navigation");

                entity.Property(e => e.V51NavigationId).HasColumnName("V51_Navigation_id");

                entity.Property(e => e.Csid).HasColumnName("csid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.FullPath)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.NavigationTitle)
                    .IsRequired()
                    .HasColumnName("Navigation_Title")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PageObject).HasDefaultValueSql("((0))");

                entity.Property(e => e.Parent).HasDefaultValueSql("((0))");

                entity.Property(e => e.SOrder).HasColumnName("sOrder");

                entity.Property(e => e.ShowLink)
                    .HasColumnName("Show_Link")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShowNav)
                    .HasColumnName("Show_Nav")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<ZzAnotherListing>(entity =>
            {
                entity.HasKey(e => e.AnotherListingId);

                entity.ToTable("ZZ_Another_Listing");

                entity.Property(e => e.AnotherListingId).HasColumnName("Another_Listing_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Richard)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });

            modelBuilder.Entity<ZzCity>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("ZZ_City");

                entity.Property(e => e.CityId).HasColumnName("City_id");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("('1900/1/1')");

                entity.Property(e => e.Editstate).HasColumnName("editstate");

                entity.Property(e => e.Lat)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Long)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Sublistingid).HasColumnName("sublistingid");
            });
        }
    }
}
