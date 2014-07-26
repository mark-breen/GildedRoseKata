namespace GildedRose.Console.Items
{
    public abstract class ImprovedItem : Item
    {
        private const int MinimumQuality = 0;
        private const int MaximumQuality = 50;

        protected ImprovedItem(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public abstract void UpdateQuality();

        public bool IsExpired
        {
            get { return SellIn < 0; }
        }

        public void DecreaseSellIn()
        {
            SellIn--;
        }

        public void IncreaseQuality()
        {
            if (Quality < MaximumQuality) Quality++;
        }

        public void DropQuality()
        {
            Quality = MinimumQuality;
        }

        public void DecreaseQuality()
        {
            if (Quality > MinimumQuality) Quality--;
        }

        protected bool Equals(Item other)
        {
            return
                string.Equals(Name, other.Name) &&
                SellIn == other.SellIn &&
                Quality == other.Quality;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ImprovedItem)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name.GetHashCode();
                hashCode = (hashCode * 397) ^ SellIn;
                hashCode = (hashCode * 397) ^ Quality;
                return hashCode;
            }
        }

        public static bool operator ==(ImprovedItem left, ImprovedItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ImprovedItem left, ImprovedItem right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return string.Format("{0}(sellIn: {1}, quality: {2})", Name, SellIn, Quality);
        }
    }
}
