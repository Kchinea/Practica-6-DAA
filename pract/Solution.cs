namespace Pract5DAA;
public class Solution {
  public string _algorithmName { get; set; }
  public string _instanceName { get; set; }
  public double _diversityValue { get; set; }
  public List<Point> _selectedPoints { get; set; }
  public int _solutionSize {get; set;} 
  public Solution(string algorithmName, string instanceName, double diversityValue, List<Point> selectedPoints, int solutionSize) {
    _algorithmName = algorithmName;
    _instanceName = instanceName;
    _diversityValue = diversityValue;
    _selectedPoints = selectedPoints;
    _solutionSize = solutionSize;
  }
}

