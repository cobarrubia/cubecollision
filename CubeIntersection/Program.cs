using System;
using System.Collections.Generic;
using System.Linq;
using DrawLibrary;

namespace CubeIntersection
{
    class Program
    {

        static void Main(string[] args)
        {
            Cube[] Cubes=new Cube[2];
            double[] temp_data = new double[4];
            string[] label = new string[4] { "X", "Y", "Z", "Size"};
            string buffer;

            for (int iCube = 0; iCube < 2; iCube++) 
            {
                Console.WriteLine("Insert Cube #{0}",iCube+1);
                for (int iCoord = 0; iCoord < 4; iCoord++)
                {
                    do
                    {
                        Console.WriteLine("Insert the {0}", label[iCoord]);
                        buffer = Console.ReadLine();
                        if (double.TryParse(buffer, out temp_data[iCoord]))
                        {
                            break;
                        }
                        if (iCoord == 3 && temp_data[3]<=0) // control input error over throw 
                        {
                            Console.WriteLine("Invalid Size");
                        }
                    } 
                    while (true);
                }
                Cubes[iCube] = Cube.CreateCube(temp_data[0], temp_data[1], temp_data[2], temp_data[3]);
            }
            double vol = Cubes[0].GetCollisionVolumen(Cubes[1]);
            Console.WriteLine("The volumen of inserction is {0}", vol);
            Console.ReadKey();

        }
    }
}
