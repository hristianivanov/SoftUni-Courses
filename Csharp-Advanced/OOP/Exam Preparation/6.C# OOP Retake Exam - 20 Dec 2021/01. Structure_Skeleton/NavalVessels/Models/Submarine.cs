namespace NavalVessels.Models
{
    using System;

    using Contracts;
    public class Submarine : Vessel, ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
        }

        public bool SubmergeMode { get; private set; }
        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                Environment.NewLine +
                $" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}";
        }
    }
}
