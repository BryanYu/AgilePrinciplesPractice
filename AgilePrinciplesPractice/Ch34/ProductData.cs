namespace AgilePrinciplesPractice.Ch34
{
    public class ProductData
    {
        public string Name { get; set; }

        public int Price { get; set; }

        public string Sku { get; set; }

        public ProductData(string name, int price, string sku)
        {
            this.Name = name;
            this.Price = price;
            this.Sku = sku;
        }

        public ProductData()
        {
        }

        public override bool Equals(object o)
        {
            ProductData pd = (ProductData)o;
            return string.Equals(this.Name, pd.Name) && this.Price == pd.Price && string.Equals(this.Sku, pd.Sku);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() ^ this.Sku.GetHashCode() ^ this.Price.GetHashCode();
        }
    }
}