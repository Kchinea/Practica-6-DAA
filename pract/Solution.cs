namespace Pract5DAA;
public class Solution {
  public string AlgorithmName { get; set; }
  public string InstanceName { get; set; }
  public double DiversityValue { get; set; }
  public List<Point> SelectedPoints { get; set; }
  public Solution(string algorithmName, string instanceName, double diversityValue, List<Point> selectedPoints) {
    AlgorithmName = algorithmName;
    InstanceName = instanceName;
    DiversityValue = diversityValue;
    SelectedPoints = selectedPoints;
  }
}

