namespace Pract5DAA;

public class Map {
  private List<Point> _points;
  public Map(List<Point> points) {
    _points = points;
  }
  public List<Point> Points {
    get => _points;
  }
  public int Size {
    get => _points.Count;
  }
  public Point this[int index] {
    get => _points[index];
    set => _points[index] = value;
  }
  public void AddPoint(Point point) {
    _points.Add(point);
  }
  public void RemovePoint(Point point) {
    _points.Remove(point);
  }
  public void Clear() {
    _points.Clear();
  }
  public override string ToString() {
    string result = "";
    result += "Map:";
    foreach (var point in _points) {
      result += point.ToString();
    }
    return result;
  }
  public double CalculateDistance(Point point1, Point point2) {
    return point1.CalculateDistance(point2);
  }
  public Point GetCenter() {
    double[] centerCoordinates = new double[_points[0].Size];
    foreach (var point in _points) {
      for (int i = 0; i < point.Size; i++) {
        centerCoordinates[i] += point.Coordinates[i];
      }
    }
    for (int i = 0; i < centerCoordinates.Length; i++) {
      centerCoordinates[i] /= _points.Count;
    }
    return new Point(centerCoordinates.ToList());
  }
  public double CalculateAverageDistance() {
    double totalDistance = 0;
    int count = 0;
    for (int i = 0; i < _points.Count; i++) {
      for (int j = i + 1; j < _points.Count; j++) {
        totalDistance += CalculateDistance(_points[i], _points[j]);
        count++;
      }
    }
    return totalDistance / count;
  }
  public Point CalculateFurthestPoint(Point referencePoint) {
    double maxDistance = 0;
    Point furthestPoint = null;
    foreach (var point in _points) {
      double distance = CalculateDistance(referencePoint, point);
      if (distance > maxDistance) {
        maxDistance = distance;
        furthestPoint = point;
      }
    }
    return furthestPoint;
  }
}