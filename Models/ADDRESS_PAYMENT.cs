namespace Models
{
    public class ADD
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PNumber { get; set; }
        public string Pcode { get; set; }

    }

    public class Card
    {
        public string Name { get; set; }
        public string CNumber { get; set; }
        public string EDate { get; set; }
        public string CVV { get; set; }

    }

    public class Bank
    {
        public string Name { get; set; }
        public string BNumber { get; set; }
        public string Holder { get; set; }

    }

    public class Gcash
    {
        public string Name { get; set; }
        public string GNumber { get; set; }

    }
}
