using System.Globalization;

namespace Bai1
{
    public sealed class PhuongTrinhBacHai
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public PhuongTrinhBacHai(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public string Giai()
        {
            if (A == 0)
            {
                if (B == 0)
                {
                    return C == 0
                        ? "Phương trình có vô số nghiệm."
                        : "Phương trình vô nghiệm.";
                }

                return $"Phương trình có nghiệm x = {Format(-C / B)}.";
            }

            var delta = B * B - 4 * A * C;
            if (delta < 0)
            {
                return "Phương trình vô nghiệm trong tập số thực.";
            }

            if (delta == 0)
            {
                return $"Phương trình có nghiệm kép x = {Format(-B / (2 * A))}.";
            }

            var sqrtDelta = Math.Sqrt(delta);
            var x1 = (-B + sqrtDelta) / (2 * A);
            var x2 = (-B - sqrtDelta) / (2 * A);
            return $"Phương trình có hai nghiệm: x₁ = {Format(x1)}, x₂ = {Format(x2)}.";
        }

        private static string Format(double value) => value.ToString("0.##", CultureInfo.CurrentCulture);
    }
}
