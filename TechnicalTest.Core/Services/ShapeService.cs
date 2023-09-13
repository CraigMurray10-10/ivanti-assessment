using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Services
{
    public class ShapeService : IShapeService
    {
        public Shape ProcessTriangle(Grid grid, GridValue gridValue)
        {
            string? row = gridValue.Row;
            int col = gridValue.Column;

            Coordinate V1 = new(0, 0); // V1: vertex at 90degree angle
            Coordinate V2 = new(0, 0); // V2: vertex at leftmost 45degree angle
            Coordinate V3 = new(0, 0); // V3: vertex at rightmost 45degree angle

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
                case 3:
                    V1.X = 10;
                    V1.Y = V3.Y;
                    V2.X = 10;
                    V3.X = 20;
                    break;
                case 4:
                    V1.X = 20;
                    V1.Y = V2.Y;
                    V2.X = 10;
                    V3.X = 20;
                    break;
                case 5:
                    V1.X = 20;
                    V1.Y = V3.Y;
                    V2.X = 20;
                    V3.X = 30;
                    break;
                case 6:
                    V1.X = 30;
                    V1.Y = V2.Y;
                    V2.X = 20;
                    V3.X = 30;
                    break;
                case 7:
                    V1.X = 30;
                    V1.Y = V3.Y;
                    V2.X = 30;
                    V3.X = 40;
                    break;
                case 8:
                    V1.X = 40;
                    V1.Y = V2.Y;
                    V2.X = 30;
                    V3.X = 40;
                    break;
                case 9:
                    V1.X = 40;
                    V1.Y = V3.Y;
                    V2.X = 40;
                    V3.X = 50;
                    break;
                case 10:
                    V1.X = 50;
                    V1.Y = V2.Y;
                    V2.X = 40;
                    V3.X = 50;
                    break;
                case 11:
                    V1.X = 50;
                    V1.Y = V3.Y;
                    V2.X = 50;
                    V3.X = 60;
                    break;
                case 12:
                    V1.X = 60;
                    V1.Y = V2.Y;
                    V2.X = 50;
                    V3.X = 60;
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
            string? row;
            int col;
            string outerVertexPos;

            Coordinate brv = triangle.BottomRightVertex;
            Coordinate ov = triangle.OuterVertex;
            switch(brv.Y) {
                case 10:
                    row = "A";
                    break;
                case 20:
                    row = "B";
                    break;
                case 30:
                    row = "C";
                    break;
                case 40:
                    row = "D";
                    break;
                case 50:
                    row = "E";
                    break;
                case 60:
                    row = "F";
                    break;
                default:
                    row = "";
                    break;
            }

            if (brv.Y == ov.Y) {
                outerVertexPos = "bottomLeft";
                col = brv.X / 5 - 1;
            }
            else {
                outerVertexPos = "topRight";
                col = brv.X / 5;
            }
            
            return new GridValue("" + row + col);
        }
    }
}