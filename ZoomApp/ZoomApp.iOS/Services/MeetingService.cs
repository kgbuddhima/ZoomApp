using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Zoomios;

namespace ZoomApp.iOS.Services
{
    public class MeetingService : NSObject, IMobileRTCMeetingServiceDelegate
    {
        MobileRTC _localMobile = null;
        public MeetingService(MobileRTC mobileRTC)
        {
            _localMobile = mobileRTC;
        }

        public event EventHandler OnJoinConfirmed;

        public List<ulong> MeetingParticipants
        {
            get
            {
                var meetingService = _localMobile.GetMeetingService();
                //meetingService.chan
                var meetingParticipants = new List<ulong>();
                var userList = meetingService.InMeetingUserList();
                if (userList != null)
                {
                    foreach (var user in userList)
                    {
                        meetingParticipants.Add(user.UInt64Value);
                    }
                }
                return meetingParticipants;
            }
        }

        public string MeetingID => MobileRTCInviteHelper.SharedInstance.OngoingMeetingID;

    }


    public class ZoomMeetingEventHandler : MobileRTCMeetingServiceDelegate
    {
        public ZoomMeetingEventHandler()
        {
        }

        public override void OnJoinMeetingConfirmed()
        {
            //CrossZoomarin.Current.MeetingService.OnJoinConfirmed?.Invoke(this, new EventArgs());
        }
    }
}