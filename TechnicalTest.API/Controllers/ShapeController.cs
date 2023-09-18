using Microsoft.AspNetCore.Mvc;
using TechnicalTest.API.DTOs;
using TechnicalTest.Core;
using TechnicalTest.Core.Interfaces;
using TechnicalTest.Core.Models;

namespace TechnicalTest.API.Controllers
{
    /// <summary>
    /// Shape Controller which is responsible for calculating coordinates and grid value.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
        private readonly IShapeFactory _shapeFactory;

        /// <summary>
        /// Constructor of the Shape Controller.
        /// </summary>
        /// <param name="shapeFactory"></param>
        public ShapeController(IShapeFactory shapeFactory)
        {
            _shapeFactory = shapeFactory;
        }

        /// <summary>
        /// Calculates the Coordinates of a shape given the Grid Value.
        /// </summary>
        /// <param name="calculateCoordinatesRequest"></param>   
        /// <returns>A Coordinates response with a list of coordinates.</returns>
        /// <response code="200">Returns the Coordinates response model.</response>
        /// <response code="400">If an error occurred while calculating the Coordinates.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Shape))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateCoordinates")]
        [HttpPost]
        public IActionResult CalculateCoordinates([FromBody]CalculateCoordinatesDTO calculateCoordinatesRequest)
        {
            // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

            // TODO: Call the Calculate function in the shape factory.

            // TODO: Return BadRequest with error message if the calculate result is null

            // TODO: Create ResponseModel with Coordinates and return as OK with responseModel.

            int shapeType = calculateCoordinatesRequest.ShapeType;
            int gridSize = calculateCoordinatesRequest.Grid.Size;
            Grid grid = new Grid(gridSize);
            GridValue gridValue = new GridValue(calculateCoordinatesRequest.GridValue);

            ShapeEnum shapeEnum;
            CalculateCoordinatesResponseDTO responseModel = new CalculateCoordinatesResponseDTO();
            // CalculateCoordinatesResponseDTO.Coordinate coordinateDTO = new CalculateCoordinatesResponseDTO.Coordinate(0,0);

            switch (shapeType) {
                case 0:
                    shapeEnum = ShapeEnum.None;
                    return BadRequest();
                case 1:
                    shapeEnum = ShapeEnum.Triangle;
                    Shape? shapeResult = _shapeFactory.CalculateCoordinates(shapeEnum, grid, gridValue);
                    if (shapeResult == null)
                        return BadRequest("Error: Null result returned from coordinates calculator");
                    else
                        responseModel.Coordinates = shapeResult.Coordinates; 
                        // unsure best way to convert Model coordinate class to inner DTO coordinate class
                        // foreach (Coordinate coordinate in shapeResult.Coordinates) {
                        //     int xDTO = coordinate.X;
                        //     int yDTO = coordinate.Y;
                        //     coordinateDTO.X = xDTO;
                        //     coordinateDTO.Y = yDTO;
                        //     responseModel.Coordinates.Add(coordinateDTO); 
                        // }
                        
                        return Ok(responseModel);
                default:
                    shapeEnum = ShapeEnum.Other;
                    return BadRequest();
            }

            // return Ok();
        }

        /// <summary>
        /// Calculates the Grid Value of a shape given the Coordinates.
        /// </summary>
        /// <remarks>
        /// A Triangle Shape must have 3 vertices, in this order: Top Left Vertex, Outer Vertex, Bottom Right Vertex.
        /// </remarks>
        /// <param name="gridValueRequest"></param>   
        /// <returns>A Grid Value response with a Row and a Column.</returns>
        /// <response code="200">Returns the Grid Value response model.</response>
        /// <response code="400">If an error occurred while calculating the Grid Value.</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GridValue))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("CalculateGridValue")]
        [HttpPost]
        public IActionResult CalculateGridValue([FromBody]CalculateGridValueDTO gridValueRequest)
        {
	        // TODO: Get the ShapeEnum and if it is default (ShapeEnum.None) or not triangle, return BadRequest as only Triangle is implemented yet.

            // TODO: Create new Shape with coordinates based on the parameters from the DTO.

            // TODO: Call the function in the shape factory to calculate grid value.

            // TODO: If the GridValue result is null then return BadRequest with an error message.

            // TODO: Generate a ResponseModel based on the result and return it in Ok();

            int shapeType = gridValueRequest.ShapeType;
            int gridSize = gridValueRequest.Grid.Size;
            Grid grid = new Grid(gridSize);            
            
            ShapeEnum shapeEnum;
            CalculateGridValueResponseDTO responseModel = new CalculateGridValueResponseDTO("",0);

            switch (shapeType) {
                case 0:
                    shapeEnum = ShapeEnum.None;
                    return BadRequest();
                case 1:
                    shapeEnum = ShapeEnum.Triangle;

                    // ? way to determine order of coordinates list?
                    Shape shape = new Triangle(gridValueRequest.Coordinates[0], gridValueRequest.Coordinates[1], gridValueRequest.Coordinates[2]);
                    GridValue? gridValueResult = _shapeFactory.CalculateGridValue(shapeEnum, grid, shape);

                    if (gridValueResult == null)
                        return BadRequest("Error: Null result returned from coordinates calculator");
                    else
                        responseModel.Row = gridValueResult.Row;
                        responseModel.Column = gridValueResult.Column;

                        return Ok(responseModel);
                default:
                    shapeEnum = ShapeEnum.Other;
                    return BadRequest();
            }

            // return Ok();
        }
    }
}
