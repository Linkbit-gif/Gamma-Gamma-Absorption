
namespace GG_Abs
{
    internal class Gamma
    {
        private double shape;
        private double inverseScale;

        public Gamma(double shape, double inverseScale)
        {
            this.shape = shape;
            this.inverseScale = inverseScale;
        }

        internal void Samples(double[] samples)
        {
            throw new NotImplementedException();
        }
    }
}