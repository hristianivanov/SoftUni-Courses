using System;

namespace _5.FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
           Endurance = endurance;
           Sprint = sprint;
           Dribble = dribble;
           Passing = passing;
           Shooting = shooting;
        }

        public int Endurance
        {
            get=>endurance;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (this.IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(
                        ExceptionMessages.InvalidStatMessage, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }

        //Returns true if the stat is invalid (<0 OR >100), returns false is the stat is valid
        private bool IsStatInvalid(int value)
            => value < 0 || value > 100;
    }
}