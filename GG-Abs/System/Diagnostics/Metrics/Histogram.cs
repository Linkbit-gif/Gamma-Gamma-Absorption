
namespace System.Diagnostics.Metrics
{
    internal class Histogram
    {
        private double[] samples;
        private int bucketCount;

        public Histogram(double[] samples, int bucketCount)
        {
            this.samples = samples;
            this.bucketCount = bucketCount;
        }

        public static implicit operator Int64(Histogram v)
        {
            throw new NotImplementedException();
        }
    }
}