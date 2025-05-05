namespace Pract5DAA.Algorithm;

public class BranchAndBoundMaximumDiversity : IAlgorithm {
  private int _m;
  private double _cotaInferiorDiversidad;
  private Instance _instance;
  private List<Point> _bestSolution;

  public string GetName => "BranchAndBound";

  public BranchAndBoundMaximumDiversity(int m) {
    _m = m;
    _bestSolution = new List<Point>();
  }

  public Solution Solve(Instance instance) {
    _instance = instance;
    GraspMaximumDiversity grasp = new GraspMaximumDiversity(_m);
    Solution graspSolution = grasp.Solve(instance);
    _cotaInferiorDiversidad = graspSolution._diversityValue;
    _bestSolution = new List<Point>(graspSolution._selectedPoints.Points);

    List<Point> initialSolution = new List<Point>();
    List<Tuple<double, List<Point>>> nodes = new List<Tuple<double, List<Point>>>
    {
      new Tuple<double, List<Point>>(double.MaxValue, initialSolution)
    };

    while (nodes.Count > 0) {
      Tuple<double, List<Point>> currentNode = NextNode(nodes);
      nodes.Remove(currentNode);

      if (currentNode.Item1 <= _cotaInferiorDiversidad)
        continue;

      List<Point> currentSolution = currentNode.Item2;
      List<Point> remainingPoints = _instance.Points.Except(currentSolution).ToList();

      foreach (var point in remainingPoints) {
        List<Point> newSolution = new List<Point>(currentSolution) { point };

        if (newSolution.Count == _m) {
          double diversity = CalculateTotalDiversity(newSolution);
          if (diversity > _cotaInferiorDiversidad) {
            _cotaInferiorDiversidad = diversity;
            _bestSolution = new List<Point>(newSolution);
          }
          continue;
        }

        double upperBound = CalculateCotaSuperior(new List<Point>(newSolution));
        nodes.Add(new Tuple<double, List<Point>>(upperBound, newSolution));
      }
    }

    return new Solution(
      "BranchAndBound",
      instance.Name,
      _cotaInferiorDiversidad,
      _bestSolution,
      _m
    );
  }

  private Tuple<double, List<Point>> NextNode(List<Tuple<double, List<Point>>> nodes) {
    nodes.Sort((a, b) => b.Item1.CompareTo(a.Item1));
    return nodes[nodes.Count - 1];
  }

  private double CalculateCotaSuperior(List<Point> partialSolution) {
    double currentDiversity = CalculateTotalDiversity(partialSolution);
    int remaining = _m - partialSolution.Count;

    if (remaining <= 0)
      return currentDiversity;

    double maxAdditional = 0;
    List<Point> availablePoints = _instance.Points.Except(partialSolution).ToList();

    for (int i = 0; i < remaining; i++) {
      Point farthestPoint = null;
      double maxDistance = double.MinValue;

      foreach (var point in availablePoints) {
        double totalDistance = 0;
        foreach (var selected in partialSolution) {
          totalDistance += CalculateDistance(point, selected);
        }

        if (totalDistance > maxDistance) {
          maxDistance = totalDistance;
          farthestPoint = point;
        }
      }

      if (farthestPoint != null) {
        maxAdditional += maxDistance;
        partialSolution.Add(farthestPoint);
        availablePoints.Remove(farthestPoint);
      }
    }

    return currentDiversity + maxAdditional;
  }

  private double CalculateTotalDiversity(List<Point> points) {
    double total = 0;
    for (int i = 0; i < points.Count; i++) {
      for (int j = i + 1; j < points.Count; j++) {
        total += CalculateDistance(points[i], points[j]);
      }
    }
    return total;
  }

  private double CalculateDistance(Point p1, Point p2) {
    if (p1.Size != p2.Size)
      throw new ArgumentException("Los puntos deben tener las mismas dimensiones");

    double sum = 0;
    for (int i = 0; i < p1.Size; i++) {
      double diff = p1.Coordinates[i] - p2.Coordinates[i];
      sum += diff * diff;
    }
    return Math.Sqrt(sum);
  }
}
