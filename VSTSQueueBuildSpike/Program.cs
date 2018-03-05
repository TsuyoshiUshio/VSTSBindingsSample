using System;

namespace VSTSQueueBuildSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            var base64Pat = Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "", "PAT")));
            Console.WriteLine(base64Pat);
            Console.ReadLine();
        }
    }
}
