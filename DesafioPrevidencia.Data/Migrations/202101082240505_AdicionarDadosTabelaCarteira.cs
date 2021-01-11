namespace DesafioPrevidencia.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionarDadosTabelaCarteira : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Carteira Values('70% Renda Fixa, 10% Fundos de Ações', '3,56% nos últimos 12 meses', 'Carteira em Renda Fixa', '1')");
            Sql("INSERT INTO Carteira Values('40% Renda Fixa, 40% Fundos Imobiliários, 10% Ações', '5,56% nos últimos 12 meses', 'Carteira em FUndo Imobiliário', '1')");
            Sql("INSERT INTO Carteira Values('50% Renda Fixa, 50% Fundos de Ações', '2,56% nos últimos 12 meses', 'Carteira Mista', '2')");
            Sql("INSERT INTO Carteira Values('40% Renda Fixa, 30% Fundos Imobiliários, 30% Ações', '4,06% nos últimos 12 meses', 'Carteira Mista em Fundo Imobiliário', '2')");
            Sql("INSERT INTO Carteira Values('20% Renda Fixa, 80% Fundos de Ações', '1,86% nos últimos 12 meses', 'Carteira Variável', '3')");
            Sql("INSERT INTO Carteira Values('20% Renda Fixa, 20% Fundos Imobiliários, 60% Ações', '2,55% nos últimos 12 meses', 'Carteira Mista em Ações', '3')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Carteira where PerfilInvstidorId='1'");
            Sql("DELETE FROM Carteira where PerfilInvstidorId='2'");
            Sql("DELETE FROM Carteira where PerfilInvstidorId='3'");
        }
    }
}
