namespace CustomerDepositeTest
{

    internal class Customer_Depo
    {

        public string Name { get; set; }

        public string Deposite { get; set; }

        public string Account_Number { get; set; }

        public Customer_Depo() { Name = ""; Deposite = ""; Account_Number = ""; }

        public Customer_Depo(string name, string deposite, string acc_numb) { Name = name; Deposite = deposite; Account_Number = acc_numb; }
    }
}