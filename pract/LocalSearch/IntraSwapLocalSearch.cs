namespace Pract5DAA.LocalSearch;
public class LocalSearchMaximumDiversity {
  public static Solution Improve(Solution initialSolution, Instance instance) {
    List<Point> selected = new List<Point>(initialSolution._selectedPoints.Points);
    List<Point> notSelected = instance.Points.Except(selected).ToList();
    double currentDiversity = CalculateTotalDiversity(selected);
    for (int i = 0; i < selected.Count; i++) {
      for (int j = 0; j < notSelected.Count; j++) {
        var newSelected = new List<Point>(selected);
        var newNotSelected = new List<Point>(notSelected);
        Point removed = newSelected[i];
        Point added = newNotSelected[j];
        newSelected[i] = added;
        newNotSelected[j] = removed;
        double newDiversity = CalculateTotalDiversity(newSelected);
        if (newDiversity > currentDiversity){
          selected = newSelected;
          notSelected = newNotSelected;
          currentDiversity = newDiversity;
        }
      }
    }
    return new Solution(
      initialSolution._algorithmName + " + LocalSearch",
      initialSolution._instanceName,
      CalculateTotalDiversity(selected),
      selected,
      initialSolution._solutionSize
    );
  }
  private static double CalculateTotalDiversity(List<Point> points) {
    double total = 0;
    for (int i = 0; i < points.Count; i++) {
      for (int j = i + 1; j < points.Count; j++) {
        total += CalculateDistance(points[i], points[j]);
      }
    }
    return total;
  }
  private static double CalculateDistance(Point p1, Point p2) {
    if (p1.Size != p2.Size)
      throw new ArgumentException("Points must have the same dimensions");
    double sum = 0;
    for (int i = 0; i < p1.Size; i++) {
      double diff = p1.Coordinates[i] - p2.Coordinates[i];
      sum += diff * diff;
    }
    return Math.Sqrt(sum);
  }
}
