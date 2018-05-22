using System;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            DoEF();
            DoLinq2Sql();
        }

        static void DoLinq2Sql()
        {
            var myDb = new DataClasses1DataContext();
            var dnrs = myDb.participants.GroupJoin(
                    myDb.prereg_participants,
                    x => new { x.barcode, x.event_id },
                    y => new { y.barcode, y.event_id },
                    (x, y) => new { deelnr = x, vi = y })
                .SelectMany(
                    x => x.vi.DefaultIfEmpty(),
                    (x, y) => new { deelnr = x, vi = y })
                .Where(x => x.deelnr.deelnr.event_id == 1)
                .ToList();

            foreach (var item in dnrs)
            {
                Console.WriteLine($"{item.deelnr.deelnr.barcode},{item.deelnr.deelnr.event_id}  {item.vi?.barcode},{item.vi?.event_id}");
            }
        }

        static void DoEF()
        {
            var myDb = new MyModel();

            var dnrs = myDb.participants.GroupJoin(
                    myDb.prereg_participants,
                    x => new { x.barcode, x.event_id },
                    y => new { y.barcode, y.event_id },
                    (x, y) => new { deelnr = x, vi = y })
                .SelectMany(
                    x => x.vi.DefaultIfEmpty(),
                    (x, y) => new { deelnr = x, vi = y })
                .Where(x => x.deelnr.deelnr.event_id == 1)
                .ToList();

            foreach (var item in dnrs)
            {
                Console.WriteLine($"{item.deelnr.deelnr.barcode},{item.deelnr.deelnr.event_id}  {item.vi?.barcode},{item.vi?.event_id}");
            }
        }
    }
}
