using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utilities
{
    public abstract class PrimeGenerator<T>
    {
        protected List<T> primes;
        public PrimeGenerator()
        {
            primes = new List<T>();
        }
        public static bool IsPrime(long number)
        {
            if (number == 2)
                return true;
            else if (number % 2 == 0 || number % 5 == 0 && number != 5)
                return false;

            int sqrt = (int)Math.Sqrt(number);
            for (int i = 3; i <= sqrt; i += 2)
            {
                if (number % i == 0 && number != i)
                    return false;
            }
            return true;
        }
        public abstract IEnumerable<T> Seive(T value);
        public abstract IEnumerable<T> GeneratePrimes(T value);
        public abstract T NextPrime(T value);
    }
    public class IntPrimeGenerator: PrimeGenerator<int>{
        public IntPrimeGenerator():base(){
            primes.Add(2);
            primes.Add(3);
        }

        public override IEnumerable<int> Seive(int max)
        {
            if (primes.Last() > max)
                return primes.Where(x => x < max);

            else
            {
                while (primes.Last() < max)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
        public override int NextPrime(int previous)
        {
            for (int i = previous + 2; ; i++)
            {
                if (IsPrime(i))
                    return i;
            }
        }
        public override IEnumerable<int> GeneratePrimes(int value)
        {
            if (primes.Count() > value)
                return primes.Take(value);
            else
            {
                while(primes.Count()<value)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
    }
    public class DoublePrimeGenerator : PrimeGenerator<double>
    {
        public DoublePrimeGenerator()
            : base()
        {
            primes.Add(2);
            primes.Add(3);
        }
        public override IEnumerable<double> Seive(double max)
        {
            if (primes.Last() > max)
                return primes.Where(x => x < max);

            else
            {
                while (primes.Last() < max)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
        public override double NextPrime(double previous)
        {
            for (double i = previous + 2; ; i++)
            {
                if (PrimeGenerator<double>.IsPrime((long)i))
                    return i;
            }
        }
        public override IEnumerable<double> GeneratePrimes(double value)
        {
            if (primes.Count() > value)
                return primes.Take((int)value);
            else
            {
                while (primes.Count() < value)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
    }
    public class LongPrimeGenerator : PrimeGenerator<long>
    {
        public LongPrimeGenerator()
            : base()
        {
            primes.Add(2);
            primes.Add(3);
        }
        public override IEnumerable<long> Seive(long max)
        {
            if (primes.Last() > max)
                return primes.Where(x => x < max);

            else
            {
                while (primes.Last() < max)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
        public override long NextPrime(long previous)
        {
            for (long i = previous + 2; ; i++)
            {
                if (IsPrime(i))
                    return i;
            }
        }
        public override IEnumerable<long> GeneratePrimes(long value)
        {
            if (primes.Count() > value)
                return primes.Take((int)value);
            else
            {
                while (primes.Count() < value)
                {
                    primes.Add(NextPrime(primes.Last()));
                }
            }
            return primes;
        }
    }
}
