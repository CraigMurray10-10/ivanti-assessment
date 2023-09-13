using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            // TODO: Calculate the coordinates.
            string? row = gridValue.Row;
            int col = gridValue.Column;

            // var V1 = Tuple.Create(0, 0);

            Coordinate V1 = new(0, 0);
            Coordinate V2 = new(0, 0);
            Coordinate V3 = new(0, 0);

            switch(row) {
                case "A":
                    V2.Y = 0;
                    V3.Y = 10;
                    break;
                case "B":
                    V2.Y = 10;
                    V3.Y = 20;
                    break;
                case "C":
                    V2.Y = 20;
                    V3.Y = 30;
                    break;
                case "D":
                    V2.Y = 30;
                    V3.Y = 40;
                    break;
                case "E":
                    V2.Y = 40;
                    V3.Y = 50;
                    break;
                case "F":
                    V2.Y = 50;
                    V3.Y = 60;
                    break;
                default:
                    break;
            }

            switch(col) {
                case 1:
                    V1.X = 0;
                    V1.Y = V3.Y;
                    V2.X = 0;
                    V3.X = 10;
                    break;
                case 2:
                    V1.X = 10;
                    V1.Y = V2.Y;
                    V2.X = 0;
                    V3.X = 10;
                    break;
                default:
                    break;
            }

            return new Shape(new List<Coordinate>
            {
                V1,
                V2,
                V3
            });
        }

        public GridValue ProcessGridValueFromTriangularShape(Grid grid, Triangle triangle)
        {
            // TODO: Calculate the grid value.
            return new GridValue(0, 0);
        }
    }
}