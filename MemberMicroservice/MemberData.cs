using MemberMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberMicroservice
{
    public class MemberData
    {
        public static List<Member> members = new List<Member>()
        {
            new Member()
            {
                MemberID = 1,
                MemberName = "John",
                MemberAddress1 = "412 Street",
                MemberAddress2 = "Victorious",
                MemberCity = "California",
                MemberPhone = 0124345454,
                Username = "john@123",
                Password = "Training@123"
            },
            new Member()
            {
                MemberID = 2,
                MemberName = "Jack",
                MemberAddress1 = "4432 main Street",
                MemberAddress2 = "George",
                MemberCity = "Paris",
                MemberPhone = 0432345242,
                Username = "jack432",
                Password = "mypass@123"
            }

        };
        public static List<MemberPremium> premiumDetails = new List<MemberPremium>()
        {
            new MemberPremium()
            {
                MemberID = 1,
                PolicyID = 1,
                PremiumDue = 43242.0,
                PaymentDetails = "UPI Mode",
                DueDate = new DateTime(2020, 12, 20),
                LastPremiumPaidDate = new DateTime(2019, 12, 21)
            },
            new MemberPremium()
            {
                MemberID = 2,
                PolicyID = 1,
                PremiumDue = 54342.0,
                PaymentDetails = "Cheque Mode",
                DueDate = new DateTime(2021, 04, 16),
                LastPremiumPaidDate = new DateTime(2020, 04, 22)
            }
        };
    }
}
