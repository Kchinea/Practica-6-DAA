// namespace Pract5DAA.LocalSearch;

// public class IntraSwapLocalSearch : ILocalSearch {
//   public string GetName => "IntraSwapLocalSearch";

//   public Solution Solve(Solution solution, PathMap map) {
//     // while(true) {
      
//     // }
//     return solution; // si no consigue mejora devolver la solucion que dio
//   }
//   public Solution Movement(Solution solution, int i, int j){
//     List<Truck> trucks = solution.Trucks;
//     Solution solution1 = new Solution(trucks);
//     List<Zone> zones = new List<Zone>();
//     Truck proveTruck = new Truck(0, 0, 0, 0);
//     foreach(Truck truck in trucks) {
//       foreach(Zone zone in truck.Path) {
//         if (zone.Id == i) {
//           zones = truck.Path;
//           proveTruck.Id = truck.Id;
//           proveTruck.MaximumLoad = truck.MaximumLoad;
//           proveTruck.MaximumTime = truck.MaximumTime;
//           proveTruck.Speed = truck.Speed;
//           break;
//         }
//       }
//     }
//     foreach(Zone zone1 in zones) {
//       if (zone1.Id == i) {
//         continue;
//       } else if (zone1.Id == j) {
//         // int time = Truck.lastZone();
//         if(proveTruck.CanAddZone(zone1, zone1.Load, time)) {
//           proveTruck.AddZone(zone1, zone1.Time, zone1.Load);
//         } else {
//           return solution;
//         }
//       }
//     }
//     // foreach(Truck truck in trucks) {
//     return solution1;
//   }

//   public bool FactibleMovement(Solution solution, int i, int j) {
//     return true;
//   }
// }