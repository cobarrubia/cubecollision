using System;
using Xunit;
using Xunit.Abstractions;
using DrawLibrary;

namespace CubeTests
{
    public class CubeTest
    {
        private readonly ITestOutputHelper output;

        public CubeTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        [Fact]
        public void Collisioning()
        {
            Cube A = Cube.CreateCube(1, 1, 1, 4);
            Cube B = Cube.CreateCube(0, 0, 0, 3);
            double vol = A.GetCollisionVolumen(B);

            output.WriteLine(vol.ToString());
            Assert.True(vol > 0);
        }

        [Fact]
        public void Inside()
        {
            Cube A = Cube.CreateCube(.5, .5, .5, 1);
            Cube B = Cube.CreateCube(1, 1, 1, 4);
            double vol = A.GetCollisionVolumen(B);

            output.WriteLine(vol.ToString());
            Assert.True(vol > 0);
        }

        [Fact]
        public void NoCollisioning()
        {
            Cube A = Cube.CreateCube(0, 0, 1.5, 1);
            Cube B = Cube.CreateCube(0, 0, -1.5, 1);
            double vol = A.GetCollisionVolumen(B);

            output.WriteLine(vol.ToString());
            Assert.True(vol == 0);
        }
        [Fact]
        public void NegativeSize()
        {
            Assert.Throws<System.ArgumentException>(() => Cube.CreateCube(0, 0, 1.5, -1));
        }
    }
}
