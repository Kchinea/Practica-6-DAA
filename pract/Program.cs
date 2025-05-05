﻿namespace Pract5DAA;
class Program {
  static void Main(string[] args) {
    string path = "Instances";
    Reader reader = new Reader(path);
    List<Instance> instances = reader.ReadAll();
    if (instances.Count == 0) {
      Console.WriteLine("No se encontraron instancias.");
      return;
    }
    Tester tester = new Tester(instances);
    tester.Test();
  }
}
