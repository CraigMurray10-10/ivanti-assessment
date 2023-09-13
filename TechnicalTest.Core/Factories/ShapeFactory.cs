using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.Core.Factories
{
    public class ShapeFactory : IShapeFactory
    {
	    private readonly IShapeService _shapeService;

        public ShapeFactory(IShapeService shapeService)
        {
	        _shapeService = shapeService;
        }

        public Shape? CalculateCoordinates(ShapeEnum shapeEnum, Grid grid, GridValue gridValue)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
	                return _shapeService.ProcessTriangle(grid, gridValue);
                default:
                    return null;
            }
        }

        public GridValue? CalculateGridValue(ShapeEnum shapeEnum, Grid grid, Shape shape)
        {
            switch (shapeEnum)
            {
                case ShapeEnum.Triangle:
                    if (shape.Coordinates.Count != 3)
                        return null;

                    return _shapeService.ProcessGridValueFromTriangularShape(grid, new Triangle(shape.Coordinates[0], shape.Coordinates[1], shape.Coordinates[2]));
                default:
                    return null;
            }
        }
    }
}
