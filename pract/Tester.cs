using Pract5DAA.Algorithm;
using Pract5DAA.LocalSearch;
using Spectre.Console;
using System.Diagnostics;

namespace Pract5DAA;

public class Tester {
  private List<Instance> _instances;

  public Tester(List<Instance> instances) {
    _instances = instances;
  }

  public void Test() {
    List<IAlgorithm> algorithms = new List<IAlgorithm> {
      new BranchAndBoundMaximumDiversity(2),
      new BranchAndBoundMaximumDiversity(3),
      new BranchAndBoundMaximumDiversity(4),
      new BranchAndBoundMaximumDiversity(5),
      new GreedyMaximumDiversity(2),
      new GreedyMaximumDiversity(3),
      new GreedyMaximumDiversity(4),
      new GreedyMaximumDiversity(5),
      new GraspMaximumDiversity(2),
      new GraspMaximumDiversity(3),
      new GraspMaximumDiversity(4),
      new GraspMaximumDiversity(5)
    };

    List<Solution> allSolutions = new List<Solution>();

    foreach (var instance in _instances) {
      foreach (var algorithm in algorithms) {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Solution solution = algorithm.Solve(instance);
        stopwatch.Stop();
        solution._executionTimeMs = stopwatch.ElapsedTicks;
        allSolutions.Add(solution);
        stopwatch.Restart();
        Solution improvedSolution = LocalSearchMaximumDiversity.Improve(solution, instance);
        stopwatch.Stop();
        improvedSolution._executionTimeMs = stopwatch.ElapsedMilliseconds;
        allSolutions.Add(improvedSolution);
      }
    }

    PrintResultsTable(allSolutions);
  }

  static void PrintResultsTable(List<Solution> solutions) {
    var table = new Table()
      .Border(TableBorder.Rounded)
      .Title("[yellow]Resultados de Diversidad Máxima[/]")
      .AddColumn("[bold]Algoritmo[/]")
      .AddColumn("[bold]m[/]")
      .AddColumn("[bold]Instancia[/]")
      .AddColumn("[bold]Diversidad[/]")
      .AddColumn("[bold]Tiempo (ms)[/]")
      .AddColumn("[bold]Puntos seleccionados[/]");

    foreach (var sol in solutions) {
      string puntos = "";
      foreach (var p in sol._selectedPoints.Points) {
        puntos += "(";
        for (int i = 0; i < p.Size; i++) {
          puntos += p.Coordinates[i].ToString();
          if (i < p.Size - 1) puntos += ",";
        }
        puntos += ") ";
      }

      table.AddRow(
        sol._algorithmName,
        sol._solutionSize.ToString(),
        sol._instanceName,
        sol._diversityValue.ToString("F2"),
        sol._executionTimeMs.ToString(),
        puntos.Trim()
      );
    }

    AnsiConsole.Write(table);
  }
}
