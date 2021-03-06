﻿// <auto-generated />
using System;
using Library.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("ID");

                    b.ToTable("Authors");

                    b.HasData(
                        new { ID = 1, FirstName = "William", LastName = "Shakespeare" }
                    );
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID");

                    b.Property<string>("Description");

                    b.Property<string>("ISBN");

                    b.Property<string>("Title");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");

                    b.HasData(
                        new { ID = 1, AuthorID = 1, Description = "Arguably Shakespeare's greatest tragedy", ISBN = "1472518381", Title = "Hamlet" },
                        new { ID = 2, AuthorID = 1, Description = "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.", ISBN = "9780141012292", Title = "King Lear" },
                        new { ID = 3, AuthorID = 1, Description = "An intense drama of love, deception, jealousy and destruction.", ISBN = "1853260185", Title = "Othello" }
                    );
                });

            modelBuilder.Entity("Library.Models.BookCopy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookID");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookCopyID");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime>("LoanTime");

                    b.Property<int>("MemberSSN");

                    b.Property<DateTime?>("ReturnDate");

                    b.HasKey("ID");

                    b.HasIndex("BookCopyID");

                    b.HasIndex("MemberSSN");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Models.Member", b =>
                {
                    b.Property<int>("SSN")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("SSN");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.Author", "Author")
                        .WithMany("AuthorBooks")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Library.Models.BookCopy", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("BookCopeis")
                        .HasForeignKey("BookID");
                });

            modelBuilder.Entity("Library.Models.Loan", b =>
                {
                    b.HasOne("Library.Models.BookCopy", "BookCopy")
                        .WithMany()
                        .HasForeignKey("BookCopyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.Member", "Member")
                        .WithMany()
                        .HasForeignKey("MemberSSN")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
