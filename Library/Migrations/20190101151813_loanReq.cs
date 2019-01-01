using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class loanReq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BookCopies_BookCopyID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberSSN",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "MemberSSN",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookCopyID",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BookCopies_BookCopyID",
                table: "Loans",
                column: "BookCopyID",
                principalTable: "BookCopies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberSSN",
                table: "Loans",
                column: "MemberSSN",
                principalTable: "Members",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_BookCopies_BookCopyID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Members_MemberSSN",
                table: "Loans");

            migrationBuilder.AlterColumn<int>(
                name: "MemberSSN",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BookCopyID",
                table: "Loans",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorID",
                table: "Books",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_BookCopies_BookCopyID",
                table: "Loans",
                column: "BookCopyID",
                principalTable: "BookCopies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Members_MemberSSN",
                table: "Loans",
                column: "MemberSSN",
                principalTable: "Members",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
