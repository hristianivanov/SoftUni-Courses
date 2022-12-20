namespace NavalVessels.Models
{
    using System;

    using Contracts;
    public class Battleship : Vessel, IBattleship
    {
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
        }

        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $" *Sonar mode: {(SonarMode ? "ON" : "OFF")}";
        }
    }
}
