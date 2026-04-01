namespace PetStoreApiTest.Conversions
{
    [Binding]
    public class CSVConversion
    {
        [StepArgumentTransformation("the multiple tag options of \"(.*)\"")]
        [StepArgumentTransformation("the multiple status options of \"(.*)\"")]
        public List<string> CSVToList(string csv)
        {
            return csv.Split(',').ToList();
        }
    }
}
