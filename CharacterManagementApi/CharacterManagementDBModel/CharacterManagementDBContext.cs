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

        public virtual DbSet<Alignment> Alignment { get; set; }
        public virtual DbSet<Background> Background { get; set; }
        public virtual DbSet<CharacterClass> CharacterClass { get; set; }
        public virtual DbSet<CharacterDetails> CharacterDetails { get; set; }
        public virtual DbSet<CharacterInventory> CharacterInventory { get; set; }
        public virtual DbSet<CharacterSpells> CharacterSpells { get; set; }
        public virtual DbSet<HitDice> HitDice { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Race> Race { get; set; }
        public virtual DbSet<SchoolOfMagic> SchoolOfMagic { get; set; }
        public virtual DbSet<Spells> Spells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-F2RUMMJU\\SQLEXPRESS;Database=CharacterManagementDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Alignment>(entity =>
            {
                entity.HasKey(e => e.Alignment1)
                    .HasName("Alignment_pk");

                entity.Property(e => e.Alignment1)
                    .HasColumnName("Alignment")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Background>(entity =>
            {
                entity.HasKey(e => e.Background1)
                    .HasName("Background_pk");

                entity.Property(e => e.Background1)
                    .HasColumnName("Background")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CharacterClass>(entity =>
            {
                entity.HasKey(e => e.CharacterClass1)
                    .HasName("CharacterClass_pk");

                entity.Property(e => e.CharacterClass1)
                    .HasColumnName("CharacterClass")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<CharacterDetails>(entity =>
            {
                entity.HasKey(e => e.CharacterName)
                    .HasName("CharacterDetails_pk");

                entity.HasIndex(e => e.Alignment)
                    .HasName("cDetails_Alignment");

                entity.HasIndex(e => e.Background)
                    .HasName("cDetails_Background");

                entity.HasIndex(e => e.CharacterClass)
                    .HasName("cDetails_CharacterClass");

                entity.HasIndex(e => e.HitDice)
                    .HasName("cDetails_HitDice");

                entity.HasIndex(e => e.Race)
                    .HasName("cDetails_Race");

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

                entity.HasOne(d => d.AlignmentNavigation)
                    .WithMany(p => p.CharacterDetails)
                    .HasForeignKey(d => d.Alignment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Alignment_fk");

                entity.HasOne(d => d.BackgroundNavigation)
                    .WithMany(p => p.CharacterDetails)
                    .HasForeignKey(d => d.Background)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Background_fk");

                entity.HasOne(d => d.CharacterClassNavigation)
                    .WithMany(p => p.CharacterDetails)
                    .HasForeignKey(d => d.CharacterClass)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CharacterClass_fk");

                entity.HasOne(d => d.HitDiceNavigation)
                    .WithMany(p => p.CharacterDetails)
                    .HasForeignKey(d => d.HitDice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HitDice_fk");

                entity.HasOne(d => d.RaceNavigation)
                    .WithMany(p => p.CharacterDetails)
                    .HasForeignKey(d => d.Race)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Race_fk");
            });

            modelBuilder.Entity<CharacterInventory>(entity =>
            {
                entity.HasKey(e => new { e.CharacterName, e.ItemName })
                    .HasName("CharacterInventory_pk");

                entity.HasIndex(e => e.CharacterName)
                    .HasName("cInventory_CharacterName");

                entity.HasIndex(e => e.ItemName)
                    .HasName("cInventory_ItemName");

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

                entity.HasIndex(e => e.CharacterName)
                    .HasName("cSpells_CharacterName");

                entity.HasIndex(e => e.SpellName)
                    .HasName("cSpells_SpellName");

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

            modelBuilder.Entity<HitDice>(entity =>
            {
                entity.HasKey(e => e.HitDice1)
                    .HasName("HitDice_pk");

                entity.Property(e => e.HitDice1)
                    .HasColumnName("HitDice")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
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

            modelBuilder.Entity<Race>(entity =>
            {
                entity.HasKey(e => e.Race1)
                    .HasName("Race_pk");

                entity.Property(e => e.Race1)
                    .HasColumnName("Race")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<SchoolOfMagic>(entity =>
            {
                entity.HasKey(e => e.SchoolOfMagic1)
                    .HasName("SchoolOfMagic_pk");

                entity.Property(e => e.SchoolOfMagic1)
                    .HasColumnName("SchoolOfMagic")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Spells>(entity =>
            {
                entity.HasKey(e => e.SpellName)
                    .HasName("SpellName_pk");

                entity.HasIndex(e => e.SchoolOfMagic)
                    .HasName("spells_SchoolOfMagic");

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

                entity.HasOne(d => d.SchoolOfMagicNavigation)
                    .WithMany(p => p.Spells)
                    .HasForeignKey(d => d.SchoolOfMagic)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SchoolOfMagic_fk");
            });
        }
    }
}
