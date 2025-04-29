﻿using Pract5DAA.Algorithm;
using Pract5DAA.LocalSearch;

namespace Pract5DAA;
class Program {
  static void Main(string[] args) {
    string path = "Instances";
    Reader reader = new Reader(path);
    List<Instance> instances = reader.ReadAll();
    if (instances.Count == 0) {
      Console.WriteLine("No se encontraron instancias.");
      return;
    }
    List<IAlgorithm> algorithms = new List<IAlgorithm> {
      // new GreedyMaximumDiversity(2),
      // new GreedyMaximumDiversity(3),
      // new GreedyMaximumDiversity(4),
      // new GreedyMaximumDiversity(5),
      new GraspMaximumDiversity(2),
      new GraspMaximumDiversity(3),
      new GraspMaximumDiversity(4),
      new GraspMaximumDiversity(5)
    };
    List<Solution> allSolutions = new List<Solution>();
    foreach (var instance in instances) {
      foreach (var algorithm in algorithms) {
        Solution initialSolution = algorithm.Solve(instance);
        allSolutions.Add(initialSolution);
        Solution improvedSolution = LocalSearchMaximumDiversity.Improve(initialSolution, instance);
        allSolutions.Add(improvedSolution);
      }
    }
    PrintResultsTable(allSolutions);
  }
  static void PrintResultsTable(List<Solution> solutions) {
    Console.WriteLine("\n--- RESULTADOS ---");
    Console.WriteLine($"{"Algoritmo",-40} {"m",-15} {"Instancia",-20} {"Diversidad",-15}");
    Console.WriteLine(new string('-', 80));
    foreach (var sol in solutions) {
      Console.WriteLine($"{sol._algorithmName,-40} {sol._solutionSize,-15:F2} {sol._instanceName,-20} {sol._diversityValue,-15:F2} ");
    }
  }
}
