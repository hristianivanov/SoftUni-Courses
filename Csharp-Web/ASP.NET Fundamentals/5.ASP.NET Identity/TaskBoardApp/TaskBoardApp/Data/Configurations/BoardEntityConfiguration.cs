namespace TaskBoardApp.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class BoardEntityConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(this.GenerateBoards());
        }

        private ICollection<Board> GenerateBoards()
        {
            ICollection<Board> boards = new HashSet<Board>()
            {
                new Board
                {
                    Id = 1,
                    Name = "Open",
                },
                new Board
                {
                    Id = 2,
                    Name = "In Progress",
                },
                new Board
                {
                    Id = 3,
                    Name = "Done",
                }
            };

            return boards;
        }
    }
}
