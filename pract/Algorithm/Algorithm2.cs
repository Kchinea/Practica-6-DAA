namespace Pract5DAA.Algorithm;
public class GraspMaximumDiversity : IAlgorithm {
  private int m; // número de puntos a seleccionar
  private Random random;
  public GraspMaximumDiversity(int m) {
    this.m = m;
    random = new Random();
  }
  public string GetName => "GraspMaximumDiversity";
  public Solution Solve(Instance instance) {
    List<Point> selected = Grasp(instance, m);
    double diversity = CalculateTotalDiversity(selected);
    return new Solution(GetName, instance.Name, diversity, selected, m);
  }
  private List<Point> Grasp(Instance instance, int m) {
    List<Point> Elem = new List<Point>();
    foreach (var p in instance.Points) {
      Elem.Add(p);
    }
    List<Point> S = new List<Point>();
    Point center = GetCenter(Elem);
    while (S.Count < m) {
      // Calcular todas las distancias al centro
      List<(Point point, double distance)> distances = new List<(Point, double)>();
      for (int i = 0; i < Elem.Count; i++) {
        double distance = CalculateDistance(Elem[i], center);
        distances.Add((Elem[i], distance));
      }
      // Ordenar por distancia descendente
      distances.Sort((a, b) => b.distance.CompareTo(a.distance));
      // Tomar los tres mejores (o menos si hay pocos elementos)
      int candidatesCount = Math.Min(3, distances.Count);
      int chosenIndex = random.Next(candidatesCount);
      Point selectedPoint = distances[chosenIndex].point;
      // Añadir a S
      S.Add(selectedPoint);
      // Eliminar de Elem
      for (int i = 0; i < Elem.Count; i++) {
        if (Elem[i] == selectedPoint) {
          Elem.RemoveAt(i);
          break;
        }
      }
      // Recalcular centro
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
