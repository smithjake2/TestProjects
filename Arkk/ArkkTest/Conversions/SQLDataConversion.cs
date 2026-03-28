using ArkkTest.Context;
using BoDi;
using TechTalk.SpecFlow.Assist;

namespace ArkkTest.Conversions
{
    [Binding]
    public class SQLDataConversion
    {
        private readonly IObjectContainer objectContainer;

        public SQLDataConversion(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [StepArgumentTransformation]
        public IEnumerable<SQLTransformedData> TransformTableToSQLData(Table sqlData)
        {
            return sqlData.CreateSet<SQLTransformedData>();
        }
    }
}
