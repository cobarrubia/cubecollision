using System;
using System.Collections.Generic;

namespace DrawLibrary
{
    /// <summary>
    /// class to manage cube creation and collisioning volume
    /// </summary>
    public sealed class Cube: Vector
    {
        public double Size { private set; get; }

        /// <summary>
        /// Contatin the data of min and max vertices of cube.
        /// the format is {x0,y0,z0,x1,y1,z1} 
        /// </summary>
        private readonly double[] data = new double[6];

        private Cube()
        {

        }

        /// <summary>
        /// Factory to create the cube with center x,y,z with a [size]
        /// </summary>
        /// <param name="x">center coord in x axis</param>
        /// <param name="y">center coord in y axis</param>
        /// <param name="z">center coord in z axis</param>
        /// <param name="size">size of cube</param>
        /// <returns></returns>
        public static Cube CreateCube(double x, double y, double z, double size)
        {
            if (size <= 0) 
            {
                throw new ArgumentException(nameof(size), "Cannot support negative value or zero size");
            }
            Cube cube = new Cube() { Size = size, X=x, Y=y, Z=z};

            size /= 2;
            cube.data[0] = x - size;
            cube.data[1] = y - size;
            cube.data[2] = z - size;
            cube.data[3] = x + size;
            cube.data[4] = y + size;
            cube.data[5] = z + size;

            return cube;
        }

        /// <summary>
        /// Calculate the volumen intersection between current cube and other cube.
        /// </summary>
        /// <param name="cubeB"></param>
        /// <returns>The volumen of intersection. Return 0 if not exist intersection.</returns>
        public double GetCollisionVolumen(Cube cubeB)
        {
            double val = 1;

            double[] tempdata = new double[6];

            for (int i = 0; i < 3; ++i)
            {
                tempdata[i] = Math.Max(this.data[i], cubeB.data[i]);
            }
            for (int i = 3; i < 6; ++i)
            {
                tempdata[i] = Math.Min(this.data[i], cubeB.data[i]);
            }
            for (int i = 0; i < 3; ++i)
            {
                val *= Math.Max(0, tempdata[3 + i] - tempdata[i]);
            }


            return val;
        }


    }


}
