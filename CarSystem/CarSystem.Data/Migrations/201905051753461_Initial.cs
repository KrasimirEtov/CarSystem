namespace CarSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        Model = c.String(),
                        Paint = c.String(),
                        EnginePower = c.Int(nullable: false),
                        PeopleCarry = c.Int(nullable: false),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Number = c.String(),
                        FuelId = c.Int(nullable: false),
                        EmissionStandartId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmissionStandarts", t => t.EmissionStandartId, cascadeDelete: true)
                .ForeignKey("dbo.Fuels", t => t.FuelId, cascadeDelete: true)
                .Index(t => t.FuelId)
                .Index(t => t.EmissionStandartId);
            
            CreateTable(
                "dbo.EmissionStandarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EGN = c.String(),
                        CardId = c.String(),
                        GenderId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonFines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LicenceBackOn = c.DateTime(nullable: false),
                        FineNumber = c.String(),
                        PersonId = c.Int(nullable: false),
                        FineId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        ViolationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.Fines", t => t.FineId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Violations", t => t.ViolationId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.FineId)
                .Index(t => t.CarId)
                .Index(t => t.ViolationId);
            
            CreateTable(
                "dbo.Fines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Violation = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Violations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Message = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonFines", "ViolationId", "dbo.Violations");
            DropForeignKey("dbo.PersonFines", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonFines", "FineId", "dbo.Fines");
            DropForeignKey("dbo.PersonFines", "CarId", "dbo.Cars");
            DropForeignKey("dbo.PersonCars", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "GenderId", "dbo.Genders");
            DropForeignKey("dbo.PersonCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Cars", "FuelId", "dbo.Fuels");
            DropForeignKey("dbo.Cars", "EmissionStandartId", "dbo.EmissionStandarts");
            DropIndex("dbo.PersonFines", new[] { "ViolationId" });
            DropIndex("dbo.PersonFines", new[] { "CarId" });
            DropIndex("dbo.PersonFines", new[] { "FineId" });
            DropIndex("dbo.PersonFines", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "GenderId" });
            DropIndex("dbo.PersonCars", new[] { "CarId" });
            DropIndex("dbo.PersonCars", new[] { "PersonId" });
            DropIndex("dbo.Cars", new[] { "EmissionStandartId" });
            DropIndex("dbo.Cars", new[] { "FuelId" });
            DropTable("dbo.Violations");
            DropTable("dbo.Fines");
            DropTable("dbo.PersonFines");
            DropTable("dbo.Genders");
            DropTable("dbo.People");
            DropTable("dbo.PersonCars");
            DropTable("dbo.Fuels");
            DropTable("dbo.EmissionStandarts");
            DropTable("dbo.Cars");
        }
    }
}
