using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.DirectionSearchStrategies
{
    public sealed class DirectionSearchFactory
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
            GetNeighborStrategy.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy(puzzle));
            GetNeighborStrategy.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy(puzzle));
        }

        public Dictionary<DirectionEnum, IDirectionSearchStrategy> CreateStrategies()
        {
            return new Dictionary<DirectionEnum, IDirectionSearchStrategy>();
        }
    }
}
