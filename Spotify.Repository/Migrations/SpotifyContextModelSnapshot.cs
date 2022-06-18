﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spotify.Repository.Context;

#nullable disable

namespace Spotify.Repository.Migrations
{
    [DbContext(typeof(SpotifyContext))]
    partial class SpotifyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.Property<Guid>("MusicasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlaylistsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MusicasId", "PlaylistsId");

                    b.HasIndex("PlaylistsId");

                    b.ToTable("MusicaPlaylist");
                });

            modelBuilder.Entity("Spotify.Domain.Account.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Playlist", (string)null);
                });

            modelBuilder.Entity("Spotify.Domain.Account.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Spotify.Domain.Album.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaminhoCapa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("BandaId");

                    b.ToTable("Albuns", (string)null);
                });

            modelBuilder.Entity("Spotify.Domain.Album.Banda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaminhoFoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Banda", (string)null);
                });

            modelBuilder.Entity("Spotify.Domain.Album.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("MusicaPlaylist", b =>
                {
                    b.HasOne("Spotify.Domain.Album.Musica", null)
                        .WithMany()
                        .HasForeignKey("MusicasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spotify.Domain.Account.Playlist", null)
                        .WithMany()
                        .HasForeignKey("PlaylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spotify.Domain.Account.Playlist", b =>
                {
                    b.HasOne("Spotify.Domain.Account.Usuario", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Spotify.Domain.Account.Usuario", b =>
                {
                    b.OwnsOne("Spotify.Domain.Account.ValueObject.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("Spotify.Domain.Account.ValueObject.Password", "Senha", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Senha");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Senha")
                        .IsRequired();
                });

            modelBuilder.Entity("Spotify.Domain.Album.Album", b =>
                {
                    b.HasOne("Spotify.Domain.Album.Banda", null)
                        .WithMany("Albuns")
                        .HasForeignKey("BandaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Spotify.Domain.Album.Musica", b =>
                {
                    b.HasOne("Spotify.Domain.Album.Album", null)
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Spotify.Domain.Album.ValueObject.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Duracao");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musica");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Duracao")
                        .IsRequired();
                });

            modelBuilder.Entity("Spotify.Domain.Account.Usuario", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("Spotify.Domain.Album.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("Spotify.Domain.Album.Banda", b =>
                {
                    b.Navigation("Albuns");
                });
#pragma warning restore 612, 618
        }
    }
}
