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
            GetNeighborStrategy.Add(DirectionEnum.Down, new DownDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.Left, new LeftDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.Right, new RightDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.UpLeft, new UpLeftDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy());
            GetNeighborStrategy.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy());
        }
    }
}
