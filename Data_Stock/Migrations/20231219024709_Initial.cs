using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable



namespace Data_Stock.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID_category);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID_region = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(130)", unicode: false, maxLength: 130, nullable: true),
                    Address = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID_region);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID_supplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Address = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Contact = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID_supplier);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    Amount_Product = table.Column<int>(type: "int", nullable: true),
                    ID_category = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID_Product);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.ID_category,
                        principalTable: "Category",
                        principalColumn: "ID_category");
                });

            migrationBuilder.CreateTable(
                name: "Acquisition",
                columns: table => new
                {
                    ID_product = table.Column<int>(type: "int", nullable: false),
                    ID_supplier = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Acquisition_Product",
                        column: x => x.ID_product,
                        principalTable: "Product",
                        principalColumn: "ID_Product");
                    table.ForeignKey(
                        name: "FK_Acquisition_Supplier",
                        column: x => x.ID_supplier,
                        principalTable: "Supplier",
                        principalColumn: "ID_supplier");
                });

            migrationBuilder.CreateTable(
                name: "ExistenceByRegion",
                columns: table => new
                {
                    ID_product = table.Column<int>(type: "int", nullable: true),
                    ID_region = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ExistenceByRegion_Product",
                        column: x => x.ID_product,
                        principalTable: "Product",
                        principalColumn: "ID_Product");
                    table.ForeignKey(
                        name: "FK_ExistenceByRegion_Region",
                        column: x => x.ID_region,
                        principalTable: "Region",
                        principalColumn: "ID_region");
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    ID_motion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_product = table.Column<int>(type: "int", nullable: true),
                    type_motion = table.Column<string>(type: "char(15)", unicode: false, fixedLength: true, maxLength: 15, nullable: true),
                    Date_and_Time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.ID_motion);
                    table.ForeignKey(
                        name: "FK_Movement_Product",
                        column: x => x.ID_product,
                        principalTable: "Product",
                        principalColumn: "ID_Product");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_ID_product",
                table: "Acquisition",
                column: "ID_product");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_ID_supplier",
                table: "Acquisition",
                column: "ID_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenceByRegion_ID_product",
                table: "ExistenceByRegion",
                column: "ID_product");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenceByRegion_ID_region",
                table: "ExistenceByRegion",
                column: "ID_region");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_ID_product",
                table: "Movement",
                column: "ID_product");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ID_category",
                table: "Product",
                column: "ID_category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisition");

            migrationBuilder.DropTable(
                name: "ExistenceByRegion");

            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
