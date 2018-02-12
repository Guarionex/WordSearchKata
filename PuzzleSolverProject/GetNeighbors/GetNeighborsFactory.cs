using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleSolverProject.GetNeighbors
{
    sealed class GetNeighborsFactory
    {
        public Dictionary<DirectionEnum, IGetNeighborsFrom> GetNeighborStrategy { get; }

        public GetNeighborsFactory()
        {
            GetNeighborStrategy = new Dictionary<DirectionEnum, IGetNeighborsFrom>();
            GetNeighborStrategy.Add(DirectionEnum.Up, new UpGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.Down, new DownGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.Left, new LeftGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.Right, new RightGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.UpLeft, new UpLeftGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.UpRight, new UpRightGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.DownLeft, new DownLeftGetNeighborsFrom());
            GetNeighborStrategy.Add(DirectionEnum.DownRight, new DownRightGetNeighborsFrom());
        }
    }
}
