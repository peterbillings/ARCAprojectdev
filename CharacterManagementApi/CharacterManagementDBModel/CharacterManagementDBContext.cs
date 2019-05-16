using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CharacterManagementApi.CharacterManagementDBModel
{
    public partial class CharacterManagementDBContext : DbContext
    {
        public CharacterManagementDBContext()
        {
        }

        public CharacterManagementDBContext(DbContextOptions<CharacterManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CharacterDetails> CharacterDetails { get; set; }
        public virtual DbSet<CharacterInventory> CharacterInventory { get; set; }
        public virtual DbSet<CharacterSpells> CharacterSpells { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Spells> Spells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-F2RUMMJU\\SQLEXPRESS;Database=CharacterManagementDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CharacterDetails>(entity =>
            {
                entity.HasKey(e => e.CharacterName)
                    .HasName("CharacterDetails_pk");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalFeatures)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Alignment)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Background)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Bonds)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.CharacterClass)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Flaws)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HitDice)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Ideals)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Languages)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalityTraits)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterInventory>(entity =>
            {
                entity.HasKey(e => new { e.CharacterName, e.ItemName })
                    .HasName("CharacterName_pk");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CharacterNameNavigation)
                    .WithMany(p => p.CharacterInventory)
                    .HasForeignKey(d => d.CharacterName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CharacterInventory_fk1");

                entity.HasOne(d => d.ItemNameNavigation)
                    .WithMany(p => p.CharacterInventory)
                    .HasForeignKey(d => d.ItemName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CharacterInventory_fk2");
            });

            modelBuilder.Entity<CharacterSpells>(entity =>
            {
                entity.HasKey(e => new { e.CharacterName, e.SpellName })
                    .HasName("CharacterSpells_pk");

                entity.Property(e => e.CharacterName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpellName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CharacterNameNavigation)
                    .WithMany(p => p.CharacterSpells)
                    .HasForeignKey(d => d.CharacterName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CharacterSpells_fk1");

                entity.HasOne(d => d.SpellNameNavigation)
                    .WithMany(p => p.CharacterSpells)
                    .HasForeignKey(d => d.SpellName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CharacterSpells_fk2");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemName)
                    .HasName("Items_pk");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Spells>(entity =>
            {
                entity.HasKey(e => e.SpellName)
                    .HasName("SpellName_pk");

                entity.Property(e => e.SpellName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.SchoolOfMagic)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SpellCastingTime)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpellComponents)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpellDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SpellDuration)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpellRange)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
