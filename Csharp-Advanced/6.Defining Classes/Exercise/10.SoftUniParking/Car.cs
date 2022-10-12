namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public Car(string make, string moddel, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = moddel;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }
        public override string ToString()
        {
            return $"Make: {Make}\n" +
                   $"Model: {Model}\n" +
                   $"HorsePower: {HorsePower}\n" +
                   $"RegistrationNumber: {RegistrationNumber}";
        }

    }
}