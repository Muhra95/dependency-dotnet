using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHP.CodingChallenge.Backend.Dependency.Inquiry;

namespace MHP.CodingChallenge.Backend.Dependency.Notifications
{
    public class InquiryNotificationsManger : InquiryService
    {
        private readonly EmailHandler emailHandler;
        private readonly PushNotificationHandler pushNotificationHandler;
        private readonly InquiryService inquiryService;

        public InquiryNotificationsManger(EmailHandler emailHandler, PushNotificationHandler pushNotificationHandler, InquiryService inquiryService)
        {
            this.emailHandler = emailHandler;
            this.pushNotificationHandler = pushNotificationHandler;
            this.inquiryService = inquiryService;
        }

        public override void Create(Inquiry.Inquiry inquiry)
        {
            base.Create(inquiry);
            Submit(inquiry);
        }

        public void Submit(Inquiry.Inquiry inquiry)
        {
            this.emailHandler.SendEmail(inquiry);
            this.pushNotificationHandler.SendNotification(inquiry);

        }


    }
}
