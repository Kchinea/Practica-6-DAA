namespace Pract5DAA;
public class Point {
  public int _size;
  public List<double> _coordinates;
  public int _id;
  public Point(List<double> coordinates){
    this._coordinates = coordinates;
    this._size = coordinates.Count;
  }
  public double CalculateDistance(Point other){
    if (this._size != other._size) {
      throw new ArgumentException("Points must have the same number of dimensions.");
    }
    double sum = 0;
    for (int i = 0; i < this._size; i++) {
      double diff = this._coordinates[i] - other._coordinates[i];
      sum += diff * diff;
    }
    return Math.Sqrt(sum);
  }
  public int Size {
    get => _size;
  }
  public List<double> Coordinates {
    get => _coordinates;
  }
  public override string ToString() {
    return $"Coordinates: ({string.Join(", ", _coordinates)})";
  }
}