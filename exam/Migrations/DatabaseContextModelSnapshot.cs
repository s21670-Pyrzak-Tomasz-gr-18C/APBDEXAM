﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using exam.Models;

namespace exam.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("exam.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("IdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "AlbumName1",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "AlbumName2",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 3,
                            AlbumName = "AlbumName3",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 4,
                            AlbumName = "AlbumName4",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 5,
                            AlbumName = "AlbumName5",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("exam.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "MusicLabel1"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "MusicLabel2"
                        },
                        new
                        {
                            IdMusicLabel = 3,
                            Name = "MusicLabel3"
                        },
                        new
                        {
                            IdMusicLabel = 4,
                            Name = "MusicLabel4"
                        },
                        new
                        {
                            IdMusicLabel = 5,
                            Name = "MusicLabel5"
                        });
                });

            modelBuilder.Entity("exam.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "FirstName1",
                            LastName = "LastName1",
                            Nickname = "Nickname1"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "FirstName2",
                            LastName = "LastName2",
                            Nickname = "Nickname2"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "FirstName3",
                            LastName = "LastName3",
                            Nickname = "Nickname3"
                        },
                        new
                        {
                            IdMusician = 4,
                            FirstName = "FirstName4",
                            LastName = "LastName4",
                            Nickname = "Nickname4"
                        },
                        new
                        {
                            IdMusician = 5,
                            FirstName = "FirstName5",
                            LastName = "LastName5",
                            Nickname = "Nickname5"
                        });
                });

            modelBuilder.Entity("exam.Models.MusicianTrack", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("IdMusician");

                    b.ToTable("MusicianTracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 4,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 5,
                            IdMusician = 3
                        });
                });

            modelBuilder.Entity("exam.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 1f,
                            IdMusicAlbum = 1,
                            TrackName = "Track1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 1f,
                            IdMusicAlbum = 2,
                            TrackName = "Track2"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 1f,
                            IdMusicAlbum = 3,
                            TrackName = "Track3"
                        },
                        new
                        {
                            IdTrack = 4,
                            Duration = 1f,
                            IdMusicAlbum = 4,
                            TrackName = "Track4"
                        },
                        new
                        {
                            IdTrack = 5,
                            Duration = 1f,
                            IdMusicAlbum = 5,
                            TrackName = "Track5"
                        });
                });

            modelBuilder.Entity("exam.Models.Album", b =>
                {
                    b.HasOne("exam.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("IdMusicLabel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("exam.Models.MusicianTrack", b =>
                {
                    b.HasOne("exam.Models.Musician", "Musician")
                        .WithMany("MusicTracks")
                        .HasForeignKey("IdMusician")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("exam.Models.Track", "Track")
                        .WithMany("MusicianTracks")
                        .HasForeignKey("IdTrack")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("exam.Models.Track", b =>
                {
                    b.HasOne("exam.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("exam.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("exam.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("exam.Models.Musician", b =>
                {
                    b.Navigation("MusicTracks");
                });

            modelBuilder.Entity("exam.Models.Track", b =>
                {
                    b.Navigation("MusicianTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
