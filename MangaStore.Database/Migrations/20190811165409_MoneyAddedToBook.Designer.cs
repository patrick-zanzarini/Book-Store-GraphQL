﻿// <auto-generated />
using MangaStore.Database.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MangaStore.Database.Migrations
{
    [DbContext(typeof(MangaStoreDbContext))]
    [Migration("20190811165409_MoneyAddedToBook")]
    partial class MoneyAddedToBook
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MangaStore.Database.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsUsed");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("MangaStore.Database.Models.BookGenre", b =>
                {
                    b.Property<int>("IdBook");

                    b.Property<int>("IdGenre");

                    b.HasKey("IdBook", "IdGenre");

                    b.HasIndex("IdGenre");

                    b.ToTable("BookGenres");
                });

            modelBuilder.Entity("MangaStore.Database.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MangaStore.Database.Models.Book", b =>
                {
                    b.OwnsOne("MangaStore.Database.Models.Money", "CoverPrice", b1 =>
                        {
                            b1.Property<int>("BookId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Currency");

                            b1.Property<decimal>("Value");

                            b1.HasKey("BookId");

                            b1.ToTable("Books");

                            b1.HasOne("MangaStore.Database.Models.Book")
                                .WithOne("CoverPrice")
                                .HasForeignKey("MangaStore.Database.Models.Money", "BookId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MangaStore.Database.Models.BookGenre", b =>
                {
                    b.HasOne("MangaStore.Database.Models.Book", "Book")
                        .WithMany("BookGenres")
                        .HasForeignKey("IdBook")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MangaStore.Database.Models.Genre", "Genre")
                        .WithMany("BookGenres")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
