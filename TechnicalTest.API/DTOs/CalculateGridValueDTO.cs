using TechnicalTest.Core.Models;
namespace TechnicalTest.API.DTOs
{
    public class CalculateGridValueDTO
    {
        public GridDTO Grid { get; set; }

        public List<Coordinate> Coordinates { get; set; } // converted to use pre-built Coordinate model class

        public int ShapeType { get; set; }
    }

    // public class Vertex
    // {
    //     public int x { get; set; }

    //     public int y { get; set; }
    // }
}
