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

            Coordinate V1 = new(0, 0); // (outer vertex)
            Coordinate V2 = new(0, 0); // (top left vertex)
            Coordinate V3 = new(0, 0); // (bottom right vertex)

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

            if (col%2 == 0) {       // column is an even number, so outer vertex is in top-right pos
                V1.X = col * 5;

                V1.Y = V2.Y;        // given position is top-right, can find matching X/Y values accordingly
                V3.X = V1.X;        
                V2.X = V1.X - 10;
            }
            else {                  // column is an odd number, so outer vertex is in bottom-left pos
                V1.X = (col - 1)*5; // since vertex is shared with previous col (or is at 0), use that to calc coords 
                
                V1.Y = V3.Y;        // given position is bottom-left, can find matching X/Y values accordingly
                V2.X = V1.X;        
                V3.X = V2.X + 10;
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

            Coordinate V3 = triangle.BottomRightVertex;
            Coordinate V1 = triangle.OuterVertex;
            switch(V3.Y) {
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

            // determine triangle orientation by checking for matching y/x coords
            if (V3.Y == V1.Y) {                // outer vertex is on same y-level as bottom right vertex
                outerVertexPos = "bottomLeft"; // so right angle must be in bottom-left position
                col = V3.X / 5 - 1;            // and grid value will be an odd number
            }
            else {
                outerVertexPos = "topRight";
                col = V3.X / 5;
            }
            
            return new GridValue("" + row + col);
        }
    }
}