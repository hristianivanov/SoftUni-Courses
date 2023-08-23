﻿namespace SoftUniBazar.Common
{
    public static class GeneralApplicationConstants
    {
        public static class Ad
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 25;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 250;

            public const string DateTimeFormat = "yyyy-MM-dd H:mm";
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 15;
        }
    }
}
