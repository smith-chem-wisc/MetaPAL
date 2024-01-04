﻿// <auto-generated />
using System;
using MetaPAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MetaPAL.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240104160959_BuildMsDataScanTable")]
    partial class BuildMsDataScanTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MetaPAL.Models.MsDataScanModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DissociationMethod")
                        .HasColumnType("int");

                    b.Property<float?>("ExperimentalPrecursorMonoisotopicMz")
                        .HasColumnType("real");

                    b.Property<string>("FilterString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("IonInjectionTime")
                        .HasColumnType("real");

                    b.Property<float?>("IsolationWindowLowerOffset")
                        .HasColumnType("real");

                    b.Property<float?>("IsolationWindowTargetMz")
                        .HasColumnType("real");

                    b.Property<float?>("IsolationWindowUpperOffset")
                        .HasColumnType("real");

                    b.Property<int>("MassAnalyzerType")
                        .HasColumnType("int");

                    b.Property<int>("MassSpectrumType")
                        .HasColumnType("int");

                    b.Property<int>("MsLevel")
                        .HasColumnType("int");

                    b.Property<string>("NativeId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("NormalizedCollisionEnergy")
                        .HasColumnType("real");

                    b.Property<int?>("PrecursorScanNumber")
                        .HasColumnType("int");

                    b.Property<int>("ScanNumber")
                        .HasColumnType("int");

                    b.Property<int>("ScanPolarity")
                        .HasColumnType("int");

                    b.Property<float?>("ScanStartTime")
                        .HasColumnType("real");

                    b.Property<float?>("ScanWindowLowerLimit")
                        .HasColumnType("real");

                    b.Property<float?>("ScanWindowUpperLimit")
                        .HasColumnType("real");

                    b.Property<int?>("SelectedIonChargeStateGuess")
                        .HasColumnType("int");

                    b.Property<float?>("SelectedIonIntensity")
                        .HasColumnType("real");

                    b.Property<float?>("SelectedIonMz")
                        .HasColumnType("real");

                    b.Property<int>("SpectrumRepresentation")
                        .HasColumnType("int");

                    b.Property<float?>("TotalIonCurrent")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("MsDataScans");
                });

            modelBuilder.Entity("MetaPAL.Models.SpectrumMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Accession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AmbiguityLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseSequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DecoyContamTarget")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DeltaScore")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EssentialSequence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileNameWithoutExtension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullSequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentifiedSequenceVariations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntersectingSequenceVariations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MassDiffDa")
                        .HasColumnType("float");

                    b.Property<double?>("MassDiffPpm")
                        .HasColumnType("float");

                    b.Property<string>("MatchedFragmentIons")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MissedCleavage")
                        .HasColumnType("int");

                    b.Property<double?>("MonoisotopicMass")
                        .HasColumnType("float");

                    b.Property<int>("Ms2ScanNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextResidue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganismName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("PEP")
                        .HasColumnType("float");

                    b.Property<double?>("PEP_QValue")
                        .HasColumnType("float");

                    b.Property<double>("PrecursorCharge")
                        .HasColumnType("float");

                    b.Property<double>("PrecursorMass")
                        .HasColumnType("float");

                    b.Property<double>("PrecursorMz")
                        .HasColumnType("float");

                    b.Property<int>("PrecursorScanNumber")
                        .HasColumnType("int");

                    b.Property<string>("PreviousResidue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("QValue")
                        .HasColumnType("float");

                    b.Property<double?>("QValueNotch")
                        .HasColumnType("float");

                    b.Property<double?>("RetentionTime")
                        .HasColumnType("float");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<double?>("SpectralAngle")
                        .HasColumnType("float");

                    b.Property<double?>("SpectrumMatchCount")
                        .HasColumnType("float");

                    b.Property<string>("SpliceSites")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartAndEndResiduesInParentSequence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalIonCurrent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("SpectrumMatch");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
