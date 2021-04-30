using System;
using System.IO;

internal class Solution
{
    private static int JumpingOnClouds(int[] c)
    {
        int thunderheadCloud = 1;
        int shortJump = 1;
        int longJump = 2;

        int jumps = 0;

        int currIndex = 0;
        int maxIndex = c.Length - 1;
        while (currIndex < maxIndex)
        {
            int nextIndex = currIndex + longJump;
            if (nextIndex > maxIndex || c[nextIndex] == thunderheadCloud)
            {
                nextIndex = currIndex + shortJump;
            }
            jumps++;
            currIndex = nextIndex;
            //Console.WriteLine($"Jump #{jumps} to {nextIndex}");
        }
        return jumps;
    }

    private static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter( @System.Environment.GetEnvironmentVariable( "OUTPUT_PATH" ), true );

        int n = Convert.ToInt32( Console.ReadLine() );

        int[] c = Array.ConvertAll( Console.ReadLine().Split( ' ' ), cTemp => Convert.ToInt32( cTemp ) )
        ;
        int result = JumpingOnClouds( c );

        textWriter.WriteLine( result );

        textWriter.Flush();
        textWriter.Close();
    }
}
