using System.ComponentModel;

namespace EFreelancer.Global
{
    namespace Enums
    {
        namespace Common
        {
            public enum UserRoles
            {
                [Description("Admin")]
                Admin = 0,
                [Description("Full Admin")]
                FullAdmin = 1,
                [Description("Trader")]
                Trader = 2,
                 [Description("Organization")]
                Organization = 3,
            }
            public enum DateFilters
            {
                [Description("Today")]
                Today = 0,
                [Description("Yesterday")]
                Yesterday = 1,
                [Description("Last 7 Days")]
                Last7Days = 2,
                [Description("This Month")]
                ThisMonth = 3,
                [Description("Last Month")]
                LastMonth = 4,
                [Description("Custom")]
                Custom = 5
            }

            public enum GoldTransactionStatuses
            {
                [Description("Pending")]
                Pending = 0,
                [Description("Paid")]
                Paid = 1,
                [Description("Failed")]
                Failed = 2,
                 [Description("Success")]
                Success = 3,
                [Description("Cancelled")]
                Cancelled = 99
            }
        }
        namespace Organization
        {
            public enum OrganizationStatuses
            {
                [Description("Inactive")]
                Inactive = 0,
                [Description("Active")]
                Active = 1
            }
        }

        namespace Trader
        {
            public enum TraderStatuses
            {
                [Description("Approved")]
                Approved = 0,
                [Description("Rejected")]
                Rejected = 1
            }

            public enum TraderNationalIdTypes
            {
                [Description("NRIC")]
                NRIC = 0,
                [Description("Passport")]
                Passport = 1
            }

            public enum TraderStates
            {
                [Description("Johor")]
                Johor = 0,
                [Description("Kedah")]
                Kedah = 1,
                [Description("Kelantan")]
                Kelantan = 2,
                [Description("Labuan")]
                Labuan = 3,
                [Description("Melaka")]
                Melaka = 4,
                [Description("Negeri Sembilan")]
                NegeriSembilan = 5,
                [Description("Pahang")]
                Pahang = 6,
                [Description("Perlis")]
                Perlis = 7,
                [Description("Penang")]
                Penang = 8,
                [Description("Sabah")]
                Sabah = 9,
                [Description("Sarawak")]
                Sarawak = 10,
                [Description("Selangor")]
                Selangor = 11,
                [Description("Terengganu")]
                Terengganu = 12,
                [Description("Wilayah Persekutuan Kuala Lumpur")]
                WilayahPersekutuanKualaLumpur = 13,
                [Description("Wilayah Persekutuan Putrajaya")]
                WilayahPersekutuanPutrajaya = 14,
            }

            public enum TraderTransactionTypes
            {
                [Description("Buy Gold")]
                BuyGold = 0,
                [Description("Sell Gold")]
                SellGold = 1
            }
        }

        namespace Transaction
        {
            public enum TransactionStatuses
            {
                [Description("Approved")]
                Approved = 0,
                [Description("Rejected")]
                Rejected = 1
            }

            public enum PaymentMethodTypes
            {
                [Description("FPX")]
                FPX = 0
            }
        }
    }
}
