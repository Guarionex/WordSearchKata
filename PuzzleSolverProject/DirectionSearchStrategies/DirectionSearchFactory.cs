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
        private WordSearchPuzzle puzzle;

        public DirectionSearchFactory(WordSearchPuzzle wordSearchPuzzle)
        {
            puzzle = wordSearchPuzzle;
            GetNeighborStrategy = new Dictionary<DirectionEnum, IDirectionSearchStrategy>();
            GetNeighborStrategy.Add(DirectionEnum.Up, new UpDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.Down, new DownDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.Left, new LeftDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.Right, new RightDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.UpLeft, new UpLeftDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy(wordSearchPuzzle));
            GetNeighborStrategy.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy(wordSearchPuzzle));
        }

        public Dictionary<DirectionEnum, IDirectionSearchStrategy> CreateStrategies()
        {
            Dictionary<DirectionEnum, IDirectionSearchStrategy> expected = new Dictionary<DirectionEnum, IDirectionSearchStrategy>();
            expected.Add(DirectionEnum.Up, new UpDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.Down, new DownDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.Left, new LeftDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.Right, new RightDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.UpLeft, new UpLeftDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.UpRight, new UpRightDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.DownLeft, new DownLeftDirectionSearchStrategy(puzzle));
            expected.Add(DirectionEnum.DownRight, new DownRightDirectionSearchStrategy(puzzle));
            return expected;
        }
    }
}
