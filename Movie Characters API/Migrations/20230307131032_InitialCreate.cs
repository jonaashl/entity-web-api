using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Movie_Characters_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Franchises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franchises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ReleaseYear = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FranchiseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Franchises_FranchiseId",
                        column: x => x.FranchiseId,
                        principalTable: "Franchises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovieCharacter",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCharacter", x => new { x.MovieId, x.CharacterId });
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCharacter_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Alias", "FranchiseId", "Gender", "Name", "Picture" },
                values: new object[,]
                {
                    { 1, "The boy who lived", 1, "Male", "Harry Potter", "https://www.imdb.com/title/tt0241527/mediaviewer/rm2113437952" },
                    { 2, null, 1, "Female", "Hermoine Granger", "https://www.imdb.com/title/tt0241527/mediaviewer/rm2923487745/" },
                    { 3, "Professor Slughorn", 1, "Male", "Horace Slughorn", "https://www.imdb.com/title/tt0417741/mediaviewer/rm1934071552" },
                    { 4, null, 2, "Male", "Frodo Baggins", "https://www.imdb.com/title/tt0120737/mediaviewer/rm2645131264" },
                    { 5, "Strider", 2, "Male", "Aragorn", "https://www.imdb.com/title/tt0120737/mediaviewer/rm2368970240" }
                });

            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Harry Potter is a film series based on the eponymous novels by J. K. Rowling. The series is produced and distributed by Warner Bros. Pictures and consists of eight fantasy films, beginning with Harry Potter and the Philosopher's Stone (2001) and culminating with Harry Potter and the Deathly Hallows – Part 2 (2011).", "Harry Potter" },
                    { 2, "The Lord of the Rings is a series of three epic fantasy adventure films directed by Peter Jackson, based on the novel The Lord of the Rings by J. R. R. Tolkien. The films are subtitled The Fellowship of the Ring (2001), The Two Towers (2002), and The Return of the King (2003).", "Lord of the Rings" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Director", "FranchiseId", "Genre", "Picture", "ReleaseYear", "Title", "Trailer" },
                values: new object[,]
                {
                    { 1, "Chris Colombus", 1, "Adventure, Family, Fantasy", "https://www.imdb.com/title/tt0241527/mediaviewer/rm2105413120/", 2001, "Harry Potter and the Philosopher's Stone", "https://www.imdb.com/video/vi3115057433/?playlistId=tt0241527" },
                    { 2, "David Yates", 1, "Action, Adventure, Family, Fantasy, Mystery", "https://www.imdb.com/title/tt0417741/mediaviewer/rm282560512/", 2009, "Harry Potter and the Half-Blood Prince", "https://www.imdb.com/video/vi1061421849/?playlistId=tt0417741" },
                    { 3, "Peter Jackson", 2, "Action, Adventure, Drama, Fantasy", "https://www.imdb.com/title/tt0120737/mediaviewer/rm3592958976/", 2001, "The Lord of the Rings: The Fellowship of the Ring", "https://www.imdb.com/video/vi684573465/?playlistId=tt0120737" }
                });

            migrationBuilder.InsertData(
                table: "MovieCharacter",
                columns: new[] { "CharacterId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCharacter_CharacterId",
                table: "MovieCharacter",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FranchiseId",
                table: "Movies",
                column: "FranchiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCharacter");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Franchises");
        }
    }
}
