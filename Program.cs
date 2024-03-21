using EnumerablevsQueryable_SQL;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using (LearningContext db = new LearningContext())
{
    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Start();
    IQueryable<Employee> employees = db.Employees.Where(c => c.IsActive == 1);

    Console.WriteLine("IQueryable list:");
    foreach (Employee u in employees)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.IsActive}");
    }
    stopwatch.Stop();

    Console.WriteLine($" Через IQueryable было потрачено - {stopwatch.ElapsedMilliseconds}");

    stopwatch.Reset();
    stopwatch.Start();

    IEnumerable<Employee> employeesEnum = db.Employees.Where(c => c.IsActive == 1);

    Console.WriteLine("IEnumerable list:");
    foreach (Employee u in employeesEnum)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.IsActive}");
    }

    stopwatch.Stop();

    Console.WriteLine($" Через IEnumerable было потрачено - {stopwatch.ElapsedMilliseconds}");
}

