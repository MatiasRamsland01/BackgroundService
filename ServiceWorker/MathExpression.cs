namespace ServiceWorker
{
    public interface IMathExpression
    {
        public double Value { get; set; }
    }
    public class MathExpression : IMathExpression
    {
        public double Value { get; set; }
        public MathExpression(double value) { Value = value; }

        public double Multiply (double value) { return Value * value;}
        public double Divide (double value) { return Value / value;}
        public double Modulus (double value) { return Value % value;}
    }
}
