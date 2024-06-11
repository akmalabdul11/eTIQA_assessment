using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;

namespace EFreelancer.Global
{
    public class Constants
    {
        public class Common
        {
            public const string CurrentAdminClaimKey = "CurrentAdmin";

            public const string CurrentFreelancerClaimKey = "CurrentFreeLancer";

            public const string InstagramProfileURL = "https://www.instagram.com/";

            public const string FacebookProfileURL = "https://www.facebook.com/";

            public const string WhatsappDirectMsgURL = "https://wa.me/";

            public const string TradersIdParam = "TradersId";
        }

        public class StripePlanIds
        {
            public const string StartupMonthly = "price_1OP219HgKEBKJfQyxhugd7lW";
            public const string StartupYearly = "price_1OPKKmHgKEBKJfQy6DRyGn7X";

            public const string LetsGetSeriousMonthly = "price_1OP22QHgKEBKJfQyk31a3yCT";
            public const string LetsGetSeriousYearly = "price_1OPKPaHgKEBKJfQy58DW2g6d";

            public const string BossModeMonthly = "price_1OP23DHgKEBKJfQyoDPgLORB";
            public const string BossModeYearly = "price_1OPKPtHgKEBKJfQyGktnCVl3";

            // public const string StartupMonthly = "price_1OtPpPHgKEBKJfQy6KW4PcCi";
            // public const string StartupYearly = "price_1OtPpeHgKEBKJfQyyFXJZ0Qr";

            // public const string LetsGetSeriousMonthly = "price_1OtPoxHgKEBKJfQyMefUyVXm";
            // public const string LetsGetSeriousYearly = "price_1OtPoiHgKEBKJfQyMneBQEe8";

            // public const string BossModeMonthly = "price_1OtPmkHgKEBKJfQyjpcih3JH";
            // public const string BossModeYearly = "price_1OtPnLHgKEBKJfQyCBS4YWMU";
        }

        public class Payments
        {
            public const decimal TransactionFeePercentage = 3; //3%

            public const decimal MinimumTransactionFee = 1; //RM1 minimum transaction fee

            public const string CurrentAdminClaimKey = "CurrentAdmin";

        }
    }
}
