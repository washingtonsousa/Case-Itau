using System;
using System.Threading.Tasks;
using Core.Data.EF.Mappings;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Core.Data.EF.Context
{


    public partial class DatabaseContext : DbContext
    {


        IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DatabaseContext(IConfiguration configuration, DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<ApplicationModule> Modules { get; set; }
        public virtual DbSet<Banner> Banner { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<FormaPagamento> FormaPagamento { get; set; }
        public virtual DbSet<Frete> Frete { get; set; }
        public virtual DbSet<Imagem> Imagem { get; set; }
        public virtual DbSet<Loja> Loja { get; set; }
        public virtual DbSet<PedidoPagamento> Pagamento { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoFrete> PedidoFrete { get; set; }
        public virtual DbSet<PedidoProduto> PedidoProduto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioEndereco> UsuarioEndereco { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
        public virtual DbSet<ProdutoImagem> ProdutoImagem { get; set; }
        public virtual DbSet<CartaoCredito> CartaoCreditos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_configuration.GetValue<string>("ConnectionStrings:Main"), 
                     optionsBuilder => optionsBuilder.ServerVersion(
                                                            new Version(10, 4, 7),
                                                            ServerType.MariaDb));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ApplicationModule>(e =>
            {
                e.ToTable("modules");
                e.Property(p => p.Description).HasColumnType("text");
            });

            modelBuilder.ApplyConfiguration(new BannerMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
            modelBuilder.ApplyConfiguration(new FormaPagamentoMapping());
            modelBuilder.ApplyConfiguration(new ImagemMapping());
            modelBuilder.ApplyConfiguration(new LojaMapping());
            modelBuilder.ApplyConfiguration(new PedidoPagamentoMapping());
            modelBuilder.ApplyConfiguration(new PedidoMapping());
            modelBuilder.ApplyConfiguration(new PedidoProdutoMapping());
            modelBuilder.ApplyConfiguration(new FreteMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new PedidoFreteMapping());
            modelBuilder.ApplyConfiguration(new UsuarioEnderecoMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
            modelBuilder.ApplyConfiguration(new ProdutoImagemMapping());
            modelBuilder.ApplyConfiguration(new ProdutoCategoriaMapping());
            modelBuilder.ApplyConfiguration(new CartaoCreditoMapping());

        }
    }
}
