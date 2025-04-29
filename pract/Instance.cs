namespace Pract5DAA;

public class Instance {
  private int _pointSize;
  private int _numPoints;
  private List<Point> _points;
  private string _name; 

  public Instance(int pointSize,int numPoints, List<Point> points, string name) {
  this._pointSize = pointSize;
  this._numPoints = numPoints;
  this._points = points;
  this._name = name;
  }
  public override string ToString() {
    return $"Instance: {_name} \n" +
           $"  Number of points: {_numPoints}\n" +
           $"  Size of points: {_pointSize}\n" + 
           $" Points: {_points}\n";
  }

  public List<Point> Points {
    get => _points;
  }
  public int numPoints {
    get => _numPoints;
  }
  public int Size {
    get => _pointSize;
  }
  public string Name {
    get => _name;
  }
}