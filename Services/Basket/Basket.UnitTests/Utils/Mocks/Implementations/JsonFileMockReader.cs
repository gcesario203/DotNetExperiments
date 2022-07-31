using System.Text.Json;
using Basket.UnitTests.Utils.Mocks.Interfaces;

namespace Basket.UnitTests.Utils.Mocks.Implementations
{
    public class JsonFileMockReader<TMock> : MockReader<TMock> where TMock : IMock
    {
        public override async Task<IEnumerable<TMock>> Read()
        {
            var returnList = new List<TMock>();

            var teste = $"{Path.GetFullPath(".")}\\Products.json";
            using (StreamReader fileReader = new StreamReader(teste))
            {
                returnList = await JsonSerializer.DeserializeAsync<List<TMock>>(fileReader.BaseStream);

                fileReader.Dispose();
            }

            return returnList ?? new List<TMock>();
        }
    }
}