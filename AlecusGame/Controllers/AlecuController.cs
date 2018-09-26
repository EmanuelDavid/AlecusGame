using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlecusGame.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlecusGame.Controllers
{
    public class AlecuController : Controller
    {
        private int[,] _matrix;

        [HttpPost]
        [Route("Alecu/CheckIfCorrect")]
        public bool CheckIfCorrect([FromBody] AlecuTableModel model)
        {
            if(model == null)
            {
                return false;
            }

            var cellValues = model.AlecuMoves;
            _matrix = new int[,]
            {
                {cellValues[0], cellValues[1], cellValues[2],cellValues[3] },
                {cellValues[4], cellValues[5], cellValues[6],cellValues[7] },
                {cellValues[8], cellValues[9], cellValues[10],cellValues[11]}
            };

            bool result = true;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    if ((row == 0 && col == 0) || (row == 0 && col == 3) || (row == 2 && col == 0) || (row == 2 && col == 3))
                    {
                        continue;
                    }

                    var currentCellValue = _matrix[row, col];

                    if ((0 > currentCellValue) || (currentCellValue > 8))
                    {
                        return false;
                    }

                    result &= GetNeighborsAndVerifyMove(new Tuple<int, int>(row, col), currentCellValue);
                }
            }

            return result;
        }

        private bool GetNeighborsAndVerifyMove(Tuple<int, int> index, int value)
        {
            bool result = true;

            var neighbour1X = index.Item1 - 1;
            var neighbour1Y = index.Item2;

            result &= CheckMove(neighbour1X, neighbour1Y, value);

            var neighbour2X = index.Item1 - 1;
            var neighbour2Y = index.Item2 + 1;

            result &= CheckMove(neighbour2X, neighbour2Y, value);

            var neighbour3X = index.Item1;
            var neighbour3Y = index.Item2 + 1;

            result &= CheckMove(neighbour3X, neighbour3Y, value);

            var neighbour4X = index.Item1 + 1;
            var neighbour4Y = index.Item2 + 1;

            result &= CheckMove(neighbour4X, neighbour4Y, value);

            var neighbour5X = index.Item1 + 1;
            var neighbour5Y = index.Item2;

            result &= CheckMove(neighbour5X, neighbour5Y, value);


            var neighbour6X = index.Item1 + 1;
            var neighbour6Y = index.Item2 - 1;

            result &= CheckMove(neighbour6X, neighbour6Y, value);

            var neighbour7X = index.Item1;
            var neighbour7Y = index.Item2 - 1;

            result &= CheckMove(neighbour7X, neighbour7Y, value);

            var neighbour8X = index.Item1 - 1;
            var neighbour8Y = index.Item2 - 1;

            result &= CheckMove(neighbour8X, neighbour8Y, value);
            return result;
        }

        private bool CheckMove(int neighbourX, int neighbourY, int currentCellValue)
        {
            if (neighbourX < 0 || neighbourY < 0 || neighbourX >= 3 || neighbourY > 3)
            {
                neighbourX = 0;
                neighbourY = 0;
            }

            return CheckConsecutive(currentCellValue, _matrix[neighbourX, neighbourY]);
        }

        private bool CheckConsecutive(int firstNo, int secondNo)
        {
            if (firstNo == 0 || secondNo == 0)
            {
                return true;
            }

            if (Math.Abs(firstNo - secondNo) > 1)
            {
                return true;
            }
            return false;
        }
    }
}