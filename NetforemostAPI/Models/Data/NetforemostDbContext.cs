using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NetforemostAPI.Models.Data;

public partial class NetforemostDbContext : DbContext
{
    public NetforemostDbContext()
    {
    }

    public NetforemostDbContext(DbContextOptions<NetforemostDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gestore> Gestores { get; set; }

    public virtual DbSet<SaldoModel> Saldos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gestore>(entity =>
        {
            entity.HasKey(e => e.GestorId).HasName("PK__Gestores__7477A1F8C4E7D59A");

            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SaldoModel>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Saldo).HasColumnName("Saldo");

            entity.HasOne(d => d.Gestor).WithMany()
                .HasForeignKey(d => d.GestorId)
                .HasConstraintName("FK__Saldos__Saldo__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
