using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PruebaEncuestas.Core.Entities;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PruebaEncuestas.Infrastructure.Data
{
    public partial class PruebaEncuestaContext : DbContext
    {
        public PruebaEncuestaContext()
        {
        }

        public PruebaEncuestaContext(DbContextOptions<PruebaEncuestaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CamposEncuesta> CamposEncuesta { get; set; }
        public virtual DbSet<Encuesta> Encuesta { get; set; }
        public virtual DbSet<Respuesta> Respuesta { get; set; }
        public virtual DbSet<RespuestaxCampo> RespuestaxCampo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CamposEncuesta>(entity =>
            {
                entity.HasKey(e => e.CampoEncuestaId)
                    .HasName("PK__CamposEn__66A4A6A8CE74E906");

                entity.Property(e => e.FkEncuestaId).HasColumnName("fk_EncuestaId");

                entity.Property(e => e.NombreCampo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCampo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TituloCampo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkEncuesta)
                    .WithMany(p => p.CamposEncuesta)
                    .HasForeignKey(d => d.FkEncuestaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CamposEnc__fk_En__267ABA7A");
            });

            modelBuilder.Entity<Encuesta>(entity =>
            {
                entity.Property(e => e.EncuestaDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EncuestaNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Respuesta>(entity =>
            {
                entity.Property(e => e.FechaRespuesta).HasColumnType("datetime");

                entity.Property(e => e.FkEncuestaId).HasColumnName("fk_EncuestaId");

                entity.Property(e => e.NombrePersona)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RespuestaxCampo>(entity =>
            {
                entity.HasKey(e => e.IdRespuestaxCampo)
                    .HasName("PK__Respuest__14CAD9C8CF3444B7");

                entity.Property(e => e.FkCampoEncuestaId).HasColumnName("fk_CampoEncuestaId");

                entity.Property(e => e.FkRespuestaId).HasColumnName("fk_RespuestaId");

                entity.Property(e => e.Respuesta).IsUnicode(false);

                entity.HasOne(d => d.FkRespuesta)
                    .WithMany(p => p.RespuestaxCampo)
                    .HasForeignKey(d => d.FkRespuestaId)
                    .HasConstraintName("FK__Respuesta__fk_Re__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
