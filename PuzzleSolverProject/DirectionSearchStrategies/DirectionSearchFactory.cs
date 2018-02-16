using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public sealed class DirectionSearchFactory
    {
        private WordSearchPuzzle puzzle;

        public DirectionSearchFactory(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
        }

        public Dictionary<DirectionEnum, IDirectionSearchStrategy> CreateStrategies()
        {
            Dictionary<DirectionEnum, IDirectionSearchStrategy> directionSearchStrategies = new Dictionary<DirectionEnum, IDirectionSearchStrategy>();
            directionSearchStrategies.Add(DirectionEnum.Up, new UpDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.Down, new DownDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.Left, new LeftDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.Right, new RightDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.UpLeft, new UpLeftDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy(puzzle));
            directionSearchStrategies.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy(puzzle));
            return directionSearchStrategies;
        }
    }
}
