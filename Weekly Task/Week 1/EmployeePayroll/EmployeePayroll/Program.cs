namespace EmployeePayroll
{

    abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float BasicSalary {  get; set; }
        public float Bonus { get; set; }
        public float NetSalary {  get; set; }

        public abstract float CalculateSalary();

        public abstract float CalculateBonus();

    }

    class PermanentEmployee : Employee
    {

        public int Pf {  get; set; }

        public override float CalculateSalary() {
            NetSalary = BasicSalary - Pf;
            return NetSalary;
        }

        public override float CalculateBonus()
        {
            if (Pf < 1000)
            {
                Bonus = 0.10f * BasicSalary;
            }
            else if (Pf >= 1000 && Pf < 1500)
            {
                Bonus = 0.115f * BasicSalary;
            }
            else if (Pf >= 1500 && Pf < 1800)
            {
                Bonus = 0.12f * BasicSalary;
            }
            else if (Pf >= 1800)
            {
                Bonus = 0.15f * BasicSalary;
            }
            return Bonus;

        }

    }

    class TemporaryEmployee : Employee
    {

        public int DailyWages {  get; set; }
        public int NoOfDays { get; set; }

        /*If pf<1000 set bonus as 10% of basic pay
         If pf>=1000 and pf <1500 set bonus as 11.5% basic pay
         If pf>=1500 and pf <1800 set bonus as 12% basic pay
         If pf>=1800 set bonus as 15% basic pay
        NetSalary = basic_salary – pf*/

        public override float CalculateSalary()
        {
            NetSalary = DailyWages * NoOfDays;
            return NetSalary;
        }

        public override float CalculateBonus()
        {
            if (DailyWages < 1000)
            {
                Bonus = 0.15f * NetSalary;
            }
            else if (DailyWages >= 1000 && DailyWages < 1500)
            {
                Bonus = 0.12f * NetSalary;
            }
            else if (DailyWages >= 1500 && DailyWages < 1750)
            {
                Bonus = 0.11f * NetSalary;
            }
            else if (DailyWages >= 1750)
            {
                Bonus = 0.08f * NetSalary;
            }
            return Bonus;
        }

    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter the Details");
            Console.WriteLine("Enter the type of Employee : ");
            string EmpType = Console.ReadLine();
            if (EmpType.Equals("Permanent")){
                PermanentEmployee pe = new PermanentEmployee();

                Console.WriteLine("Enter Employee Id:");
                pe.Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Employee Name:");
                pe.Name = Console.ReadLine();

                Console.WriteLine("Enter Basic Salary:");
                pe.BasicSalary = float.Parse(Console.ReadLine());

                Console.WriteLine("Enter PF:");
                pe.Pf = int.Parse(Console.ReadLine());

                pe.CalculateSalary();
                pe.CalculateBonus();

                Console.WriteLine($"Employee Id: {pe.Id}");
                Console.WriteLine($"Employee Name: {pe.Name}");
                Console.WriteLine($"Basic Salary: {pe.BasicSalary}");
                Console.WriteLine($"PF: {pe.Pf}");
                Console.WriteLine($"Bonus: {pe.Bonus}");
                Console.WriteLine($"Net Salary: {pe.NetSalary}");
            }
            else if (EmpType.Equals("Temporary"))
            {
                TemporaryEmployee te = new TemporaryEmployee();

                Console.WriteLine("Enter Employee Id:");
                te.Id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Employee Name:");
                te.Name = Console.ReadLine();

                Console.WriteLine("Enter Daily Wages:");
                te.DailyWages = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter No. of days worked:");
                te.NoOfDays = int.Parse(Console.ReadLine());

                te.CalculateSalary();
                te.CalculateBonus();

                Console.WriteLine($"Employee Id: {te.Id}");
                Console.WriteLine($"Employee Name: {te.Name}");
                Console.WriteLine($"Daily Wages: {te.DailyWages}");
                Console.WriteLine($"No. of Days Worked: {te.NoOfDays}");
                Console.WriteLine($"Bonus: {te.Bonus}");
                Console.WriteLine($"Net Salary: {te.NetSalary}");
            }
        }
    }

}