namespace Pract5DAA.LocalSearch;

public interface ILocalSearch {
  public Solution Solve(Solution solution, PathMap map);
  public Solution Movement(Solution solution, int i, int j);
  // public bool FactibleMovement(Solution solution, int i, int j);
  string GetName { get; }
}