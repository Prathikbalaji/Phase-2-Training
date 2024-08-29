
namespace PayInsurance
{

    class Insurance
    {
        private string insuranceNo;
        private string insuranceName;
        private double amountCovered;

        public string InsuranceNo
        {
            get { return insuranceNo; }
            set { insuranceNo = value; }
        }

        public string InsuranceName
        {
            get { return insuranceName; }
            set { insuranceName = value; }
        }

        public double AmountCovered
        {
            get { return amountCovered; }
            set { amountCovered = value; }
        }

    }

    class MotorInsurance : Insurance
    {
        private double idv;
        private float depPercent;

        public double Idv
        {
            get { return idv; }
            set { idv = value; }
        }

        public float DepPercent
        {
            get { return depPercent; }
            set { depPercent = value; }
        }

        public double calculatePremium()
        {
            Idv = AmountCovered -((AmountCovered * DepPercent) /100);
            return Idv * 0.03;
        }

    }

    class LifeInsurance : Insurance
    {
        private int policyTerm;
        private float benefitPercent;

        public int PolicyTerm
        {
            get { return policyTerm; }
            set { policyTerm = value; }
        }

        public float BenefitPercent
        {
            get { return benefitPercent; }
            set { benefitPercent = value; }
        }

        public double calculatePremium()
        {
            return Convert.ToDouble( (AmountCovered - ((AmountCovered * BenefitPercent) / 100)) / PolicyTerm );
        }

    }

    internal class Program
    {

        public double addPolicy(Insurance ins,int opt)
        {
            if(opt == 1)
            {
                LifeInsurance lf =(LifeInsurance) ins;
                return lf.calculatePremium();
            }
            else if (opt == 2){
                MotorInsurance mf = (MotorInsurance) ins;
                return mf.calculatePremium();
            }
            return 0;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Insurance Number : ");
            string Ino = Console.ReadLine();
            Console.WriteLine("Insurance Name : ");
            string Iname = Console.ReadLine();
            Console.WriteLine("Amount Covered : ");
            double AmtCvd = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Select");
            Console.WriteLine("1.Life Insurance");
            Console.WriteLine("2.Motor Insurance");
            int op = Convert.ToInt32(Console.ReadLine());
            Program p = new Program();

            if(op == 1)
            {
                Console.WriteLine("Policy Term : ");
                int pt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Benefit Percent : ");
                float bp = float.Parse(Console.ReadLine());
                LifeInsurance li = new LifeInsurance() {InsuranceNo = Ino,InsuranceName = Iname,AmountCovered = AmtCvd , PolicyTerm = pt , BenefitPercent = bp };
                Console.WriteLine("Calculated Premium : " + p.addPolicy(li, op));
            }
            else if(op == 2)
            {
                Console.WriteLine("Depreciation Percent : ");
                float dp = float.Parse(Console.ReadLine());
                MotorInsurance mi = new MotorInsurance() { InsuranceNo = Ino, InsuranceName = Iname, AmountCovered = AmtCvd, DepPercent = dp};
                Console.WriteLine("Calculated Premium : " + p.addPolicy(mi , op));
            }


        }
    }

}
