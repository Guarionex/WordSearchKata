using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.GetNeighbors
{
    sealed class DirectionSearchFactory
    {
        public Dictionary<DirectionEnum, IDirectionSearchStrategy> GetNeighborStrategy { get; }

        public DirectionSearchFactory(WordSearchPuzzle puzzle)
        {
            GetNeighborStrategy = new Dictionary<DirectionEnum, IDirectionSearchStrategy>();
            GetNeighborStrategy.Add(DirectionEnum.Up, new UpDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.Down, new DownDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.Left, new LeftDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.Right, new RightDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.UpLeft, new UpLeftDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy());
        }
    }
}
