﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Domains
{
    public partial class fastradeContext : DbContext
    {
        public fastradeContext()
        {
        }

        public fastradeContext(DbContextOptions<fastradeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatProduto> CatProduto { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoReceita> ProdutoReceita { get; set; }
        public virtual DbSet<Receita> Receita { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-IF0O2B1\\SQLEXPRESS;Database=fastrade;User Id=sa; Password=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatProduto>(entity =>
            {
                entity.HasKey(e => e.IdCatProduto)
                    .HasName("PK__Cat_Prod__27A1E38DEBEE3FBB");

                entity.HasIndex(e => e.Tipo)
                    .HasName("UQ__Cat_Prod__8E762CB4C51AF5C3")
                    .IsUnique();

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__4B564035EE59849C");

                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Complemento).IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NomeEndereco).IsUnicode(false);
            });

            modelBuilder.Entity<Oferta>(entity =>
            {
                entity.HasKey(e => e.IdOferta)
                    .HasName("PK__Oferta__6C9F2EA0FE1B31F3");

                entity.Property(e => e.DescricaoDoProduto).IsUnicode(false);

                entity.Property(e => e.NomeProduto).IsUnicode(false);

                entity.Property(e => e.Quantidade).IsUnicode(false);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Oferta__Id_Produ__6383C8BA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Oferta)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Oferta__Id_Usuar__6477ECF3");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__Pedido__A5D00139942BB249");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Pedido__Id_Produ__5FB337D6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pedido)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Pedido__Id_Usuar__60A75C0F");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto)
                    .HasName("PK__Produto__94E704D8B7F84854");

                entity.HasOne(d => d.IdCatProdutoNavigation)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.IdCatProduto)
                    .HasConstraintName("FK__Produto__Id_Cat___5070F446");
            });

            modelBuilder.Entity<ProdutoReceita>(entity =>
            {
                entity.HasKey(e => e.IdProdutoReceita)
                    .HasName("PK__Produto___ADAB9BA86B812390");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("FK__Produto_R__Id_Pr__5535A963");

                entity.HasOne(d => d.IdReceitaNavigation)
                    .WithMany(p => p.ProdutoReceita)
                    .HasForeignKey(d => d.IdReceita)
                    .HasConstraintName("FK__Produto_R__Id_Re__5629CD9C");
            });

            modelBuilder.Entity<Receita>(entity =>
            {
                entity.HasKey(e => e.IdReceita)
                    .HasName("PK__Receita__22C96730FA55311D");

                entity.Property(e => e.NomeReceita).IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__Tipo_Usu__689D5FEA7EACA206");

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__63C76BE2D7890DD3");

                entity.Property(e => e.CelularTelefone).IsUnicode(false);

                entity.Property(e => e.CpfCnpj).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.NomeRazaoSocial).IsUnicode(false);

                entity.Property(e => e.Senha).IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Usuario__Id_Ende__5AEE82B9");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__Id_Tipo__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
