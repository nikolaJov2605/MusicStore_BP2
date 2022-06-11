using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.ModelDTOs
{
    public partial class MusicStoreDBContext : DbContext
    {
        public MusicStoreDBContext()
        {
        }

        public MusicStoreDBContext(DbContextOptions<MusicStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cena> Cene { get; set; }
        public virtual DbSet<Instrument> Instrumenti { get; set; }
        public virtual DbSet<Kupac> Kupci { get; set; }
        public virtual DbSet<Plata> Plate { get; set; }
        public virtual DbSet<RadniStaz> RadniStaz { get; set; }
        public virtual DbSet<Radnik> Radnici { get; set; }
        public virtual DbSet<Testiranje> Testiranja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cena>(entity =>
            {
                entity.HasKey(e => e.SifraC)
                    .HasName("C_PK");

                entity.ToTable("CENA");

                entity.Property(e => e.SifraC).HasColumnName("SIFRA_C");

                entity.Property(e => e.DatPocetka)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DAT_POCETKA");

                entity.Property(e => e.DatZavrsetka)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DAT_ZAVRSETKA");

                entity.Property(e => e.Iznos)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("IZNOS");

                entity.Property(e => e.SifraI).HasColumnName("SIFRA_I");

                entity.HasOne(d => d.SifraINavigation)
                    .WithMany(p => p.Cene)
                    .HasForeignKey(d => d.SifraI)
                    .HasConstraintName("C_I_FK");
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.HasKey(e => e.SifraI)
                    .HasName("I_PK");

                entity.ToTable("INSTRUMENT");

                entity.Property(e => e.SifraI).HasColumnName("SIFRA_I");

                entity.Property(e => e.BrPragovaGitare).HasColumnName("BR_PRAGOVA_GITARE");

                entity.Property(e => e.BrTonovaKlavijature).HasColumnName("BR_TONOVA_KLAVIJATURE");

                entity.Property(e => e.BrTonovaKlavira).HasColumnName("BR_TONOVA_KLAVIRA");

                entity.Property(e => e.DatKup)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DAT_KUP");

                entity.Property(e => e.DubinaKlavijature).HasColumnName("DUBINA_KLAVIJATURE");

                entity.Property(e => e.DubinaKlavira).HasColumnName("DUBINA_KLAVIRA");

                entity.Property(e => e.DuzinaKlavijature).HasColumnName("DUZINA_KLAVIJATURE");

                entity.Property(e => e.IdK).HasColumnName("ID_K");

                entity.Property(e => e.IdR).HasColumnName("ID_R");

                entity.Property(e => e.MasaKlavijature).HasColumnName("MASA_KLAVIJATURE");

                entity.Property(e => e.MasaKlavira).HasColumnName("MASA_KLAVIRA");

                entity.Property(e => e.MatGlaveGitare)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAT_GLAVE_GITARE");

                entity.Property(e => e.MatTrupaGitare)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAT_TRUPA_GITARE");

                entity.Property(e => e.MatVrataGitare)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAT_VRATA_GITARE");

                entity.Property(e => e.Naziv)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAZIV");

                entity.Property(e => e.Opis)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("OPIS");

                entity.Property(e => e.Proizvodjac)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PROIZVODJAC");

                entity.Property(e => e.SirinaKlavijature).HasColumnName("SIRINA_KLAVIJATURE");

                entity.Property(e => e.SirinaKlavira).HasColumnName("SIRINA_KLAVIRA");

                entity.Property(e => e.Stat).HasColumnName("STAT");

                entity.Property(e => e.TipInstrumenta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TIP_INSTRUMENTA");

                entity.Property(e => e.VisinaKlavira).HasColumnName("VISINA_KLAVIRA");

                entity.Property(e => e.VrsBubnja)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VRS_BUBNJA");

                entity.Property(e => e.VrsGitare)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VRS_GITARE");

                entity.Property(e => e.VrsKlavijature)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VRS_KLAVIJATURE");

                entity.Property(e => e.VrsKlavira)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VRS_KLAVIRA");

                entity.HasOne(d => d.IdKNavigation)
                    .WithMany(p => p.Instrumenti)
                    .HasForeignKey(d => d.IdK)
                    .HasConstraintName("I_K_FK");

                entity.HasOne(d => d.IdRNavigation)
                    .WithMany(p => p.Instrumenti)
                    .HasForeignKey(d => d.IdR)
                    .HasConstraintName("I_R_FK");
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasKey(e => e.IdK)
                    .HasName("KP_PK");

                entity.ToTable("KUPAC");

                entity.Property(e => e.IdK).HasColumnName("ID_K");

                entity.Property(e => e.Ime)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IME");

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("JMBG");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PREZIME");
            });

            modelBuilder.Entity<Plata>(entity =>
            {
                entity.HasKey(e => e.SifraP)
                    .HasName("PL_PK");

                entity.ToTable("PLATA");

                entity.Property(e => e.SifraP).HasColumnName("SIFRA_P");

                entity.Property(e => e.Iznos)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("IZNOS");
            });

            modelBuilder.Entity<RadniStaz>(entity =>
            {
                entity.HasKey(e => e.SifraS)
                    .HasName("RS_PK");

                entity.ToTable("RADNI_STAZ");

                entity.Property(e => e.SifraS).HasColumnName("SIFRA_S");

                entity.Property(e => e.BrGod).HasColumnName("BR_GOD");
            });

            modelBuilder.Entity<Radnik>(entity =>
            {
                entity.HasKey(e => e.IdR)
                    .HasName("R_PK");

                entity.ToTable("RADNIK");

                entity.Property(e => e.IdR).HasColumnName("ID_R");

                entity.Property(e => e.BrLk)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("BR_LK");

                entity.Property(e => e.Ime)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IME");

                entity.Property(e => e.Pozicija)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("POZICIJA");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PREZIME");

                entity.Property(e => e.SifraP).HasColumnName("SIFRA_P");

                entity.Property(e => e.SifraS).HasColumnName("SIFRA_S");

                entity.HasOne(d => d.SifraPNavigation)
                    .WithMany(p => p.Radnici)
                    .HasForeignKey(d => d.SifraP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_P_FK");

                entity.HasOne(d => d.SifraSNavigation)
                    .WithMany(p => p.Radnici)
                    .HasForeignKey(d => d.SifraS)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("R_S_FK");
            });

            modelBuilder.Entity<Testiranje>(entity =>
            {
                entity.HasKey(e => new { e.SifraI, e.IdK })
                    .HasName("TEST_PK");

                entity.ToTable("TESTIRANJE");

                entity.Property(e => e.SifraI).HasColumnName("SIFRA_I");

                entity.Property(e => e.IdK).HasColumnName("ID_K");

                entity.Property(e => e.DatTest)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("DAT_TEST");

                entity.Property(e => e.IdR).HasColumnName("ID_R");

                entity.HasOne(d => d.IdKNavigation)
                    .WithMany(p => p.Testiranja)
                    .HasForeignKey(d => d.IdK)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEST_K_FK");

                entity.HasOne(d => d.IdRNavigation)
                    .WithMany(p => p.Testiranja)
                    .HasForeignKey(d => d.IdR)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEST_R_FK");

                entity.HasOne(d => d.SifraINavigation)
                    .WithMany(p => p.Testiranja)
                    .HasForeignKey(d => d.SifraI)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TEST_I_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
