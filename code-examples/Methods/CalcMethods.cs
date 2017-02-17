namespace Methods
{
    static class CalcMethods
    {
        public static uint FacultyRecursion(uint n)
        {
            if (n == 0)
                return 0;

            if (n == 1)
                return 1;
            return n * FacultyRecursion(n - 1);
        }

        public static uint FibonacciRecursive(uint n)
        {
            if (n == 1 || n == 0)
                return 1;

            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        public static uint FibonacciNonRecursive(uint n)
        {
            if (n == 1 || n == 0)
                return 1;

            uint hight = 1;
            uint low = 1;

            for (uint i = 0; i < n; i++)
            {
                var oldHight = hight;
                hight = low + hight;
                low = oldHight;
            }

            return low;
        }
    }
}