namespace ArkkTest.Context
{
    public class SQLTransformedData
    {
        public SQLTransformedData(List<string> data)
        {
            if (data.Count != 9)
            {
                throw new Exception($"Incorrect data size of {data.Count} instead of 9");
            }
            Country = data[0];
            ReverseCharge = data[1];
            TaxCode = data[2];
            TransDate = data[3];
            APAR = data[4];
            Gross = data[5];
            Net = data[6];
            VAT = data[7];
            GoodsOrServices = data[8];
        }
        public SQLTransformedData()
        {
            
        }
        public string Country { get; set; }
        public string ReverseCharge { get; set; }
        public string TaxCode { get; set; }
        public string TransDate { get; set; }
        public string APAR { get; set; }
        public string Gross { get; set; }
        public string Net { get; set; }
        public string VAT { get; set; }
        public string GoodsOrServices { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SQLTransformedData data &&
                   Country == data.Country &&
                   ReverseCharge == data.ReverseCharge &&
                   TaxCode == data.TaxCode &&
                   TransDate == data.TransDate &&
                   APAR == data.APAR &&
                   Gross == data.Gross &&
                   Net == data.Net &&
                   VAT == data.VAT &&
                   GoodsOrServices == data.GoodsOrServices;
        }
    }
}
