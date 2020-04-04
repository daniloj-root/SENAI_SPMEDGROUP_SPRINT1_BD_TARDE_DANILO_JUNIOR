using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SPMedicalGroup.WebApi.Domains;

namespace SPMedicalGroup.WebApi.Context
{
    public partial class SPMedGroupContext : DbContext
    {
        public SPMedGroupContext()
        {
        }

        public SPMedGroupContext(DbContextOptions<SPMedGroupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Clinica> Clinica { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Prontuario> Prontuario { get; set; }
        public virtual DbSet<Situacao> Situacao { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-CJ3GJR7N\\SQLEXPRESS; Initial Catalog=SPMedGroup_Tarde; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica);

                entity.Property(e => e.HoraFim)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.HoraInicio)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.IdTelefone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Clinica)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Clinica__IdEnder__286302EC");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.IdConsulta);

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.IdSituacao).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__IdClin__4222D4EF");

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__IdMedi__4316F928");

                entity.HasOne(d => d.IdProntuarioNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdProntuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__IdPron__440B1D61");

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__Consulta__IdSitu__44FF419A");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico);

                entity.HasIndex(e => e.Crm)
                    .HasName("UQ__Medico__C1F887FF41D0492A")
                    .IsUnique();

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasColumnName("CRM")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdArea__35BCFE0A");

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdClinica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdClinic__34C8D9D1");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Medico__IdEndere__33D4B598");

                entity.HasOne(d => d.IdTelefoneNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdTelefone)
                    .HasConstraintName("FK__Medico__IdTelefo__32E0915F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medico)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medico__IdUsuari__36B12243");
            });

            modelBuilder.Entity<Prontuario>(entity =>
            {
                entity.HasKey(e => e.IdProntuario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Prontuar__C1F89731B51FB216")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__Prontuar__321537C8DF9EFEAD")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Nascimento).HasColumnType("date");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("RG")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Prontuari__IdEnd__3C69FB99");

                entity.HasOne(d => d.IdTelefoneNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.IdTelefone)
                    .HasConstraintName("FK__Prontuari__IdTel__3B75D760");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Prontuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Prontuari__IdUsu__3D5E1FD2");
            });

            modelBuilder.Entity<Situacao>(entity =>
            {
                entity.HasKey(e => e.IdSituacao);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.IdTelefone);

                entity.Property(e => e.Descricao)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Usuario__IdTipoU__2F10007B");
            });
        }
    }
}
