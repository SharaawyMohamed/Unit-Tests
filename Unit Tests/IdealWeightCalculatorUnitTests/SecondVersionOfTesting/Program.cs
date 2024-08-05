namespace SecondVersionOfTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Height and Your Gender To Calculate Ideal Width");
            var obj = new WeightCalculator();
            obj.Height = double.Parse(Console.ReadLine());
            obj.Gender = char.Parse(Console.ReadLine());
        }
    }
}
