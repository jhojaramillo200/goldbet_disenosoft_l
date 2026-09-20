using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using GolBet.Repositories.Data;

#nullable disable

namespace GolBet.Repositories.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("GolBet.Entities.Team", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
                    b.Property<bool>("IsActive").HasColumnType("bit");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<DateTime?>("ModifiedDate").HasColumnType("datetime2");
                    b.Property<string>("Name").IsRequired().HasMaxLength(80).HasColumnType("nvarchar(80)");
                    b.Property<string>("City").IsRequired().HasMaxLength(60).HasColumnType("nvarchar(60)");
                    b.Property<string>("CrestUrl").HasMaxLength(300).HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("Name").IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("GolBet.Entities.Match", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
                    b.Property<bool>("IsActive").HasColumnType("bit");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<DateTime?>("ModifiedDate").HasColumnType("datetime2");
                    b.Property<DateTime>("Date").HasColumnType("datetime2");
                    b.Property<int>("Status").HasColumnType("int");
                    b.Property<int?>("HomeGoals").HasColumnType("int");
                    b.Property<int?>("AwayGoals").HasColumnType("int");
                    b.Property<decimal>("HomeOdds").HasColumnType("decimal(5,2)");
                    b.Property<decimal>("DrawOdds").HasColumnType("decimal(5,2)");
                    b.Property<decimal>("AwayOdds").HasColumnType("decimal(5,2)");
                    b.Property<int>("HomeTeamId").HasColumnType("int");
                    b.Property<int>("AwayTeamId").HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("HomeTeamId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("GolBet.Entities.Bet", b =>
                {
                    b.Property<int>("Id").ValueGeneratedOnAdd().HasColumnType("int");
                    b.Property<bool>("IsActive").HasColumnType("bit");
                    b.Property<DateTime>("CreatedDate").HasColumnType("datetime2");
                    b.Property<DateTime?>("ModifiedDate").HasColumnType("datetime2");
                    b.Property<decimal>("Amount").HasColumnType("decimal(12,2)");
                    b.Property<decimal>("OddsAtPlacement").HasColumnType("decimal(5,2)");
                    b.Property<int>("Pick").HasColumnType("int");
                    b.Property<int>("Status").HasColumnType("int");
                    b.Property<int>("MatchId").HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("GolBet.Entities.Match", b =>
                {
                    b.HasOne("GolBet.Entities.Team")
                        .WithMany()
                        .HasForeignKey("AwayTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GolBet.Entities.Team")
                        .WithMany()
                        .HasForeignKey("HomeTeamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GolBet.Entities.Bet", b =>
                {
                    b.HasOne("GolBet.Entities.Match")
                        .WithMany("Bets")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
        }
    }
}
