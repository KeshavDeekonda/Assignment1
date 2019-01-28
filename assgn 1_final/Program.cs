using System;

namespace assgn_1_final
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ques 1 = Print Prime Numbers
            int a = 5, b = 17;
            Console.WriteLine("Print Prime Numbers");
            printPrimeNumbers(a, b);
            
            // Ques 2 = GetSeries Result
            int n1 = 5;
            double r1 = getSeriesResult(n1); // calling the getseriesresult method
            Console.WriteLine("The sum of the series is: " + Math.Round(r1,3));

            // Ques 3 = decimal to Binary
            long n2 = 15;
            if (n2 < 0)
            {
                Console.WriteLine("Enter a positive number");
            }
            else
            {
                long r2 = decimalToBinary(n2);
                Console.WriteLine("Binary conversion of the decimal number " + n2 + " is: " + r2);
            }

            // Ques 4 = binary to decimal
            long n3 = 10;
            if (n3 < 0)
            {
                Console.WriteLine("Enter a positive number");
            }
            else
            {
                long r3 = binaryToDecimal(n3);
                if (r3 == -99)
                {
                    Console.WriteLine("Enter a valid number");
                }
                else
                {
                    Console.WriteLine("Decimal conversion of the binary number " + n3 + " is: " + r3);
                }
            }


            // ques 5 = print triangle
            int valueofn = 5;
            PrintTriangle(valueofn);

            
            // ques 6 = compute frequency of numbers in an array
            int[] arr = new int[10] { 1, 2, 2, 2, 1, 1, 4, 4, 5, 8 };
            ComputeFrequency(arr);   //method call Compute Frequency
            
            Console.ReadKey();
        }

        //method to print prime numbers for a given range
        public static void printPrimeNumbers(int x, int y)
        {
            try
            {
                Console.WriteLine("the Prime Numbers are:");
                int max=y, min=x;
                if(x>y)
                {
                    max = x;
                    min = y;
                }
                for (int i = min; i <= max; i++)
                {
                    if (isPrime(i))
                    {
                        Console.WriteLine(i);
                    }
                } //end of for loop
            } // end of try
            catch
            {
                Console.WriteLine("Exception occured while computing printPrimeNumbers()");
            } // end of catch
        }

        public static bool isPrime(int n)
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            } //end of for loop

            return true;
        }

        // Method to get the result of series
        public static double getSeriesResult(int n)
        {
            try
            {
                double output = 0, fact1;  // Declaring double variables
                for (int i = 1; i <= n; i++)
                {
                    fact1 = factorialmethod(i);

                    if (i % 2 == 0) // verifying whether the number is even or odd
                    {
                        output = output - ((fact1 / (i + 1))); // computation for even
                    }
                    else  // odd number
                    {
                        output = output + (fact1 / (i + 1)); // computation for odd
                    }
                } //end of for loop
                return output;
            } // end of try

            catch
            {
                Console.WriteLine("Exception occured while computing getSeriesResult()");
                return 0;
            } //end of catch 
        }

        public static int factorialmethod(int fact)
        {
                int factresult = 1;
                for (int i = 1; i <= fact; i++)
                {
                    factresult = factresult * i;// calculating the factorial
                } //end of for loop
            return factresult;
        }

        // method to decimal to binary
        public static long decimalToBinary(long n)
        {
            long binary = 0;
            long number = n;
            long remainder = 0;
            string binresult = string.Empty;
            try
            {
                while (n > 0)
                {
                    remainder = (n % 2);  // calculate the remainder
                    n /= 2;  // divide the number by 2
                    binresult = remainder.ToString() + binresult;  // append result to string
                }
                binary = Convert.ToInt64(Convert.ToDecimal(binresult)); // convert the string to decimal and then long
            } // end of try
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            } //end of catch 
            return binary;   // Return Result
        }

        // method to convert binary to decimal
        public static long binaryToDecimal(long n)
        {
            long remainder = 0;
            long dec = 0;
            int iterator = 0; // iterator to get the position of the digit
            try
            {
                while (n > 0)
                {
                    remainder = n % 10;   //get the remainder
                    if(remainder > 1)     // any digit other than 0 or 1
                    {
                        return -99;
                    }
                    else if (remainder == 1)
                    {
                        dec = dec + pow(iterator);   // computing decimal value of each digit if remainder is 1 using pow function
                        iterator++;
                    }
                    else
                    {
                        iterator++;
                    }
                    n = n / 10;         // removing the digit which is computed
                } // end of while
                //binary=Convert.ToInt64(Convert.ToDecimal(binresult)); // convert the string to decimal and then long
            } // end of try
            catch
            {
                Console.WriteLine("Exception occured while computing decimalToBinary()");
            } //end of catch 
            return dec;
        }

        
        public static long pow(long n)
        {
            long result = 1;
            for (int i = 0; i < n; i++)
            {
                result = result * 2;  // multiplying the number 2 with n number of times
            } //end of for loop
            return result;
        }

        // method to print triangle
        public static void PrintTriangle(int n)
        {
            try
            {
                int i, j;
                for (i = 1; i <= n; i++)
                {
                    for (j = i; j < n; j++)
                    {
                        Console.Write(" ");
                    } //end of for loop
                    for (j = 0; j < 2 * i - 1; j++)
                    {
                        Console.Write("*");
                    } //end of for loop
                    Console.WriteLine();
                } //end of for loop
            } // end of try
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            } //end of catch 
        }

        // method to compute frquency of numbers in an array
        public static void ComputeFrequency(int[] a)
        {
            int i, j, count;
            int n = a.Length;

            sortArray(a);
            
            Console.WriteLine("Number  Frequency");
            for (i = 0; i < n; i++)
            {
                count = 1;
                for (j = i + 1; j < n - 1; j++)
                {
                    if (a[i] == a[j])  // checking the number with next element in array
                    {
                        count++;  //increasing the frequency
                        i++; // increasing the iteration to avoid multiple comparisions
                    }
                } //end of for loop
                Console.WriteLine("{0}       {1} ", a[i], count); // printing the numbers and their frequency
            } //end of for loop
        }

        public static void sortArray(int []a)
        {
            int i, j, tmp;
            int n = a.Length;
            for (i = 0; i < n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (a[j] < a[i])  //loop and condition to sort the array before computing the frequency
                    {
                        tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                } //end of for loop
            } //end of for loop
        }
    }
}
