using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "FirstName", "LastName" },
                values: new object[] { 1, "William", "Shakespeare" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Description", "ISBN", "Title" },
                values: new object[] { 1, 1, "Arguably Shakespeare's greatest tragedy", "1472518381", "Hamlet" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Description", "ISBN", "Title" },
                values: new object[] { 2, 1, "King Lear is a tragedy written by William Shakespeare. It depicts the gradual descent into madness of the title character, after he disposes of his kingdom by giving bequests to two of his three daughters egged on by their continual flattery, bringing tragic consequences for all.", "9780141012292", "King Lear" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Description", "ISBN", "Title" },
                values: new object[] { 3, 1, "An intense drama of love, deception, jealousy and destruction.", "1853260185", "Othello" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
