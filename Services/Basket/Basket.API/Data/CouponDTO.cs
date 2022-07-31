using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    ///<summary>
    /// Classe ""intermediaria"" para serviços de cupon e desconto
    ///</summary>
    public class CouponDTO
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }
    }
}