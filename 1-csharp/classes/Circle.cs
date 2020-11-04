namespace classes
{
    public class Circle
    {
        private double diameter;

        public double Radius {
            get { return diameter / 2; }
            set { diameter = value * 2; }
        }

        // auto-property

        // there is a hidden "backing field"
        // like "private string color" that i can't
        // access. if i need to access that
        // (e.g. to add rules like valid color)
        //, i'll need to switch to the full property
        public string Color { get; set; }
    }
}
