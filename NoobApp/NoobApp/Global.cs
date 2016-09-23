using NoobApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoobApp {
  public static class Global {

    private static DataService _dataService;
    public static DataService DataService { get {

        if(_dataService== null) {
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
  }
}
