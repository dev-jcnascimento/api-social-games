using SocialGames.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialGames.Infra.Persistence
{
    public class SocialGamesContext : DbContext
    {
        public SocialGamesContext() : base("SocialGames")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public IDbSet<Player> Players { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<PlatForm> PlatForms { get; set; }
        public IDbSet<GamePlatForm> GamePlatForms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            //seta o schema default
            //modelbuilder.hasdefaultschema("apoio");

            //remove a pluralização dos nomes das tabelas
            modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //remove exclusão em cascata
            modelbuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelbuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //setar para usar varchar ou invés de nvarchar
            modelbuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //caso eu esqueça de informar o tamanho do campo ele irá colocar varchar de 100
            modelbuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            //mapeia as entidades
            //modelbuilder.Configurations.Add(new PlayerMap());
            //modelbuilder.configurations.add(new platformmap());

            #region adiciona entidades mapeadas - automaticamente via assembly
            modelbuilder.Configurations.AddFromAssembly(typeof(SocialGamesContext).Assembly);
            #endregion

            #region adiciona entidades mapeadas - automaticamente via namespace
            //assembly.getexecutingassembly().gettypes()
            //    .where(type => type.namespace == "socialgames.domain.entities.player")
            //    .tolist()
            //    .foreach(type =>
            //    {
            //        dynamic instance = activator.createinstance(type);
            //        modelbuilder.configurations.add(instance);
            //    });
            #endregion

            base.OnModelCreating(modelbuilder);
        }
    }
}

