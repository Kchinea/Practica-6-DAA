﻿// using Pract5DAA.Algorithm;

// namespace Pract5DAA;
// internal class Program {
//   static void Main(string[] args) {
//     if(args.Length != 1) {
//       Console.WriteLine(args.Length);
//       return;
//     }
//     string file = args[0];
//     Algorithm1 algorithm1 = new Algorithm1();
//     int num_ejecutions = 3;
//     Algorithm2 algorithm2 = new Algorithm2(num_ejecutions);
//     List<IAlgorithm> algorithms = new List<IAlgorithm> { algorithm1, algorithm2};

//     Reader reader = new Reader(file);   
//     List<Instance> instances = reader.ReadAll();

//     Tester tester = new Tester(algorithms, instances);
//     tester.DoTest();
//   }
// }

using Pract5DAA;

namespace Pract5DAA
{
  class Program
  {
    static void Main(string[] args)
    {
      // Ruta a la carpeta donde tienes los ficheros .txt
      string path = "Instances"; // <-- Cambia esto

      Reader reader = new Reader(path);

      List<Instance> instances = reader.ReadAll();

      if (instances.Count == 0)
      {
        Console.WriteLine("No se encontraron instancias.");
        return;
      }

      int instanceIndex = 1;
      foreach (var instance in instances)
      {
        Console.WriteLine($"--- Instancia {instanceIndex} ---");
        Console.WriteLine($"Número de puntos: {instance.numPoints}");
        Console.WriteLine($"Dimensiones: {instance.Size}");

        foreach (var point in instance.Points)
        {
          Console.WriteLine(point);
        }

        Console.WriteLine();
        instanceIndex++;
      }
    }
  }
}
