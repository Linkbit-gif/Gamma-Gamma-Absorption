using GG_Abs;
using Microsoft.VisualBasic;

namespace GammaDistributionVisualizer
{
    class Program
    {
        private static void Main(System.Diagnostics.Metrics.Histogram histogram) => Main(histogram);

        private static void Subverse(System.Diagnostics.Metrics.Histogram histogram)
        {
            const double shape = 2; // Shape parameter (k)
            const double inverseScale = 2; // Inverse scale parameter (theta)

            const int sampleCount = 10000; // Number of samples
            const int bucketCount = 100; // Number of buckets for histogram

            var gamma = new Gamma(shape, inverseScale);
            double[] samples = new double[sampleCount];
            gamma.Samples(samples);
            var dictionary = new Dictionary<int, double>();
            for (int i = 0; i < bucketCount; i++)
            {

                System.Diagnostics.Metrics.Histogram histogram1 = new System.Diagnostics.Metrics.Histogram(samples, bucketCount);
#pragma warning disable IDE0049 // Simplify Names
                dictionary.Add(i, ((Int64)histogram1)[samples].Count);
#pragma warning restore IDE0049 // Simplify Names
            }

            // Specify the folder path where the CSV file will be saved
            const string chartFolderPath = @"C:\Users\rdonn\IdeaProjects\demo\target\quarkus-app\lib\Kron0s";
            string csvPath = Path.Combine(chartFolderPath,
                $"Gamma Densities, Shape {shape}, Inverse Scale {inverseScale}, " +
                $"Samples {sampleCount}, Buckets {bucketCount}.csv");

            using var writer = new StreamWriter(csvPath);
            foreach ((int key, double value) in dictionary)
            {
                writer.WriteLine($"{key},{value}");
            }

            Console.WriteLine($"CSV file saved at: {csvPath}");
        }
    }
}

