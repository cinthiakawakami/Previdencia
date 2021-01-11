namespace DesafioPrevidencia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarDadosTabelaPerfisInverstidor : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO PerfilInvestidor Values('Conservador')");
            Sql("INSERT INTO PerfilInvestidor Values('Moderado')");
            Sql("INSERT INTO PerfilInvestidor Values('Agressivo')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM PerfilInvestidor where Nome='Conservador'");
            Sql("DELETE FROM PerfilInvestidor where Nome='Moderado'");
            Sql("DELETE FROM PerfilInvestidor where Nome='Agressivo'");
        }
    }
}
