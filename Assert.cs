using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson7
{
    internal static class Assert
    {
        internal static bool AssertEquals(int actual, int expected)
        {
            return actual == expected;
        }

        internal static bool AssertEquals(double actual, double expected)
        {
            return Math.Abs(actual - expected) < 0.0001f;
        }

        internal static bool AssertEquals(float actual, float expected)
        {
            return Math.Abs(actual - expected) < 0.0001f;
        }
    }
}