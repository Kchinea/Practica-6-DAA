namespace Pract5DAA;

public class Reader {
  private string _directory;

  public Reader(string directory) {
    _directory = directory;
  }

  public List<Instance> ReadAll() {
    List<Instance> instances = new List<Instance>();
    try {
      string[] files = Directory.GetFiles(_directory, "*.txt").OrderBy(f => f.Trim(new char[] { 'i', '*', '.' })).ToArray();
      foreach (string file in files) {
        Reader reader = new Reader(file);
        instances.Add(reader.Read());
      }
    }
    catch (Exception e) {
      Console.WriteLine($"Error al leer archivos en {_directory}: {e.Message}");
    }
    return instances;
  }

  public Instance Read() {
    int size = 0, numPoints = 0;
    List<Point> points = new List<Point>();
    try {
      StreamReader sr = new StreamReader(this._directory);
      string? line = sr.ReadLine();
      int lineCounter = 0;  
      while (line != null) {
        line = line.Trim();
        if (line == "") {
          line = sr.ReadLine();
          continue;
        }
        List<string> parts = new List<string>();
        string current = "";
        foreach (char c in line) {
          if (c == ' ' || c == '\t') {
            if (current != "") {
              parts.Add(current);
              current = "";
            }
          }
          else {
            current += c;
          }
        }
        if (current != "") {
          parts.Add(current);
        }
        if (lineCounter == 0) {
          numPoints = int.Parse(parts[0]);
        }
        else if (lineCounter == 1) {
          size = int.Parse(parts[0]);
        }
        else {
          List<double> coordinates = new List<double>();
          foreach (string part in parts) {
            double coordinate = double.Parse(part.Replace(',', '.'), System.Globalization.CultureInfo.InvariantCulture);
            coordinates.Add(coordinate);
          }
          Point point = new Point(coordinates);
          points.Add(point);
        }
        line = sr.ReadLine();
        lineCounter++;
      }
      sr.Close();
    }
    catch (Exception e) {
      Console.WriteLine($"Error al leer el archivo {_directory}: {e.Message}");
    }
    return new Instance(size, numPoints, points, _directory);
  }
}