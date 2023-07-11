namespace TaskBoardApp.Common
{
    public class EntityValidationsConstants
    {
        public class Task 
        {
            public const int TitleMaxLength = 70;
            public const int TitleMinLength = 5;

            public const int DescriptionMaxLength = 1000;
            public const int DescriptionMinLength = 10;
        }

        public class Board
        {
            public const int NameMaxLength = 30;
            public const int NameMinLength = 3;
        }
    }
}
