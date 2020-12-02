namespace Cards
{

    public class ChanceCard
    {
        /// <summary>
        /// Konstruktor karty szans
        /// </summary>
        /// <param name="name">Nazwa karty</param>
        /// <param name="content">Zawartość karty</param>
        /// <param name="money">Ilość gotówki do zmiany</param>
        public ChanceCard(string name, string content, int money)
        {
            this.Name = name;
            this.Content = content;
            this.Money = money;
        }
        /// <summary>
        /// Nazwa karty szans
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Zawartość karty szans
        /// </summary>
        public string Content { get; }
        /// <summary>
        /// Zwraca ilość gotówki do zmiany
        /// </summary>
        public int Money { get; }
    }
}
