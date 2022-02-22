namespace Domain
{
    public class Card
    {
        public Card(long digits, decimal balance)
        {
            Digits = digits;
            Balance = balance;
        }

        public int Id { get; set; }
        public long Digits { get; set; }
        public decimal Balance { get; set; }
    }
}