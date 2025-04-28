﻿using Pract5DAA.Algorithm;

namespace Pract5DAA;
internal class Program {
  static void Main(string[] args) {
    if(args.Length != 1) {
      Console.WriteLine(args.Length);
      return;
    }
    string file = args[0];
    Algorithm1 algorithm1 = new Algorithm1();
    int num_ejecutions = 3;
    Algorithm2 algorithm2 = new Algorithm2(num_ejecutions);
    List<IAlgorithm> algorithms = new List<IAlgorithm> { algorithm1, algorithm2};

    Reader reader = new Reader(file);   
    List<Instance> instances = reader.ReadAll();

    Tester tester = new Tester(algorithms, instances);
    tester.DoTest();
  }
}