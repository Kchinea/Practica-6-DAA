namespace Pract5DAA.Algorithm;
public class GreedyMaximumDiversity : IAlgorithm  {
  private int m; // número de puntos a seleccionar
  public GreedyMaximumDiversity(int m) {
    this.m = m;
  }
  public string GetName => "GreedyMaximumDiversity";
  public Solution Solve(Instance instance) {
    List<Point> selected = Greedy(instance, m);
    double diversity = CalculateTotalDiversity(selected);
    return new Solution(GetName, instance.Name, diversity, selected, m);
  }
  private List<Point> Greedy(Instance instance, int m) {
    // Copiar los puntos manualmente
    List<Point> Elem = new List<Point>();
    foreach (var p in instance.Points) {
      Elem.Add(p);
    }
    List<Point> S = new List<Point>();
    Point center = GetCenter(Elem);
    while (S.Count < m) {
      Point furthest = null;
      double maxDistance = double.MinValue;
      for (int i = 0; i < Elem.Count; i++) {
        double distance = CalculateDistance(Elem[i], center);
        if (distance > maxDistance) {
            maxDistance = distance;
            furthest = Elem[i];
        }
      }
      // Añadir a S
      S.Add(furthest);
      // Eliminar de Elem
      for (int i = 0; i < Elem.Count; i++){
        if (Elem[i] == furthest){
          Elem.RemoveAt(i);
          break;
        }
      }
      center = GetCenter(S);
    }
    return S;
  }
  private Point GetCenter(List<Point> points) {
    if (points.Count == 0)
      throw new ArgumentException("List of points is empty");
    int dimension = points[0].Size;
    double[] centerCoordinates = new double[dimension];
    for (int i = 0; i < points.Count; i++) {
      for (int j = 0; j < dimension; j++) {
        centerCoordinates[j] += points[i].Coordinates[j];
      }
    }
    for (int j = 0; j < dimension; j++) {
      centerCoordinates[j] /= points.Count;
    }
    List<double> coords = new List<double>();
    for (int j = 0; j < dimension; j++) {
      coords.Add(centerCoordinates[j]);
    }
    return new Point(coords);
  }
  private double CalculateDistance(Point p1, Point p2) {
    if (p1.Size != p2.Size)
      throw new ArgumentException("Points must have the same dimensions");
    double sum = 0;
    for (int i = 0; i < p1.Size; i++) {
      double diff = p1.Coordinates[i] - p2.Coordinates[i];
      sum += diff * diff;
    }
    return Math.Sqrt(sum);
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
}
