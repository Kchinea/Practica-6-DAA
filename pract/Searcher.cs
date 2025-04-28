// using Pract5DAA.LocalSearch;

// namespace Pract5DAA;

// public class Searcher {
//   private List<bool> _active;
//   private List<ILocalSearch> _localSearches;
//   private Random _rand = new Random();

//   public Searcher(List<ILocalSearch> localSearches) {
//     _localSearches = localSearches;
//     _active = new List<bool>();
//     for (int i = 0; i < _localSearches.Count; i++) {
//       _active.Add(true);
//     }
//   }
//   public void Run(Solution solution, int iterations) {
//     while (_active.Contains(true)) {
//       int actives = _active.FindAll(x => x == true).Count;
//       int index = _rand.Next(0, actives);
//       int counter = 0;
//       for(int i = 0; i < _active.Count; i++) {
//         if (_active[i]) {
//           counter++;
//           if (counter == index) {
//             ILocalSearch localSearch = _localSearches[i];
//             Solution newSolution = localSearch.Solve(solution);
//             if (newSolution != null) {
//               solution = newSolution;
//             } else {
//               _active[i] = false;
//             }
//           }
//         }
//       }          
//     }
//   }

// }