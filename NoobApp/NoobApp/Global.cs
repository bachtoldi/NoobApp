using NoobApp.Model;
using System.Data.Entity;
using System.Linq;

namespace NoobApp {
  public static class Global {

    private static DataService _dataService;

    public static DataService DataService {
      get {

        if (_dataService == null) {
          _dataService = new DataService();

          _dataService.Attendances.Load();
          _dataService.AttendanceTypes.Load();
          _dataService.EventInventories.Load();
          _dataService.EventPrices.Load();
          _dataService.Events.Load();
          _dataService.Items.Load();
          _dataService.Purchases.Load();
          _dataService.Users.Load();
        }

        return _dataService;
      }
    }

    public static void Rollback() {
      var changedEntries = DataService.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList();

      foreach (var entry in changedEntries) {
        switch (entry.State) {
          case EntityState.Modified:
            entry.CurrentValues.SetValues(entry.OriginalValues);
            entry.State = EntityState.Unchanged;
            break;
          case EntityState.Added:
            entry.State = EntityState.Detached;
            break;
          case EntityState.Deleted:
            entry.State = EntityState.Unchanged;
            break;
        }
      }
    }

  }
}
